using System;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form6 : Form
    {
        private MemoryGameProcessor gameProcessor;
        private PictureBox[] pictureBoxes;
        private Image[] cardImages;
        private bool[] matchedCards;
        private bool[] pendingRemoveCards;
        private int firstSelectedIndex;
        private int secondSelectedIndex;
        private bool isWaitingToFlipBack;

        public Form6()
        {
            InitializeComponent();

            // Tạo đối tượng xử lý game theo phương pháp hướng đối tượng.
            gameProcessor = new MemoryGameProcessor();

            // Gom 10 PictureBox vào mảng để thao tác bằng vòng lặp cho gọn và rõ ràng.
            pictureBoxes = new PictureBox[10];
            pictureBoxes[0] = pic0;
            pictureBoxes[1] = pic1;
            pictureBoxes[2] = pic2;
            pictureBoxes[3] = pic3;
            pictureBoxes[4] = pic4;
            pictureBoxes[5] = pic5;
            pictureBoxes[6] = pic6;
            pictureBoxes[7] = pic7;
            pictureBoxes[8] = pic8;
            pictureBoxes[9] = pic9;

            // Tạo mảng lưu trạng thái đã ghép đúng của từng ô hình.
            matchedCards = new bool[10];
            pendingRemoveCards = new bool[10];

            // Tạo 5 ảnh đại diện cho 5 cặp hình.
            cardImages = new Image[5];
            cardImages[0] = CreateCardImage(Color.Red, "1");
            cardImages[1] = CreateCardImage(Color.Blue, "2");
            cardImages[2] = CreateCardImage(Color.Green, "3");
            cardImages[3] = CreateCardImage(Color.Orange, "4");
            cardImages[4] = CreateCardImage(Color.Purple, "5");

            // Khởi tạo các biến chọn hình ban đầu.
            firstSelectedIndex = -1;
            secondSelectedIndex = -1;
            isWaitingToFlipBack = false;

            // Bắt đầu ván chơi mới khi mở form.
            StartNewGame();
        }

        private Image CreateCardImage(Color backgroundColor, string text)
        {
            // Tạo một Bitmap kích thước phù hợp với PictureBox để hiển thị mặt trước lá bài.
            Bitmap bitmap = new Bitmap(80, 80);

            // Dùng Graphics để vẽ màu nền và số lên ảnh.
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(backgroundColor);

            Font font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            Brush brush = Brushes.White;
            SizeF textSize = graphics.MeasureString(text, font);

            // Tính toán vị trí căn giữa chữ trên ảnh.
            float x = (80 - textSize.Width) / 2;
            float y = (80 - textSize.Height) / 2;
            graphics.DrawString(text, font, brush, x, y);
            graphics.Dispose();

            return bitmap;
        }

        private void StartNewGame()
        {
            // Đặt lại điểm số, lượt chơi, số cặp đã tìm thấy và trộn lại vị trí hình.
            gameProcessor.ResetGameState();
            gameProcessor.Shuffle();

            // Đặt lại trạng thái chọn hình.
            firstSelectedIndex = -1;
            secondSelectedIndex = -1;
            isWaitingToFlipBack = false;
            timerFlip.Stop();
            timerRemoveMatched.Stop();
            timerFlip.Interval = 1000;

            // Úp toàn bộ các hình và cho phép click lại.
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i].Image = null;
                pictureBoxes[i].BackColor = Color.LightGray;
                pictureBoxes[i].Enabled = true;
                pictureBoxes[i].Visible = true;
                matchedCards[i] = false;
                pendingRemoveCards[i] = false;
            }

            // Cập nhật các nhãn thông tin người chơi.
            UpdateScoreLabels();
            UpdateTurnLabel();
        }

        private void UpdateScoreLabels()
        {
            // Hiển thị điểm của từng người chơi.
            lblPlayer1Score.Text = "Người chơi 1: " + gameProcessor.Score1;
            lblPlayer2Score.Text = "Người chơi 2: " + gameProcessor.Score2;
        }

        private void UpdateTurnLabel()
        {
            // Hiển thị người chơi hiện tại đang đến lượt.
            lblTurn.Text = "Đến lượt: Người chơi " + gameProcessor.CurrentPlayer;
        }

        private void RevealCard(int index)
        {
            // Hiển thị hình tương ứng của ô được lật dựa trên chỉ số đã trộn.
            int imageIndex = gameProcessor.ImageIndices[index];
            pictureBoxes[index].Image = cardImages[imageIndex];
            pictureBoxes[index].BackColor = Color.White;
        }

        private void HideCard(int index)
        {
            // Úp lại ô hình bằng cách xóa ảnh hiển thị.
            pictureBoxes[index].Image = null;
            pictureBoxes[index].BackColor = Color.LightGray;
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // Nếu đang chờ timer úp hình thì không cho click thêm.
            if (isWaitingToFlipBack)
            {
                return;
            }

            // Lấy PictureBox vừa được nhấn.
            PictureBox selectedPictureBox = (PictureBox)sender;
            int selectedIndex = int.Parse(selectedPictureBox.Tag.ToString());

            // Nếu ô này đã ghép đúng hoặc đang là ô đã chọn đầu tiên thì bỏ qua.
            if (matchedCards[selectedIndex])
            {
                return;
            }

            if (selectedIndex == firstSelectedIndex)
            {
                return;
            }

            // Hiển thị mặt trước của ô vừa chọn.
            RevealCard(selectedIndex);

            // Nếu chưa có ô đầu tiên thì lưu ô này là ô đầu tiên.
            if (firstSelectedIndex == -1)
            {
                firstSelectedIndex = selectedIndex;
                return;
            }

            // Lưu ô thứ hai khi người chơi chọn đủ 2 ô.
            secondSelectedIndex = selectedIndex;

            // Kiểm tra 2 ô có tạo thành cặp hay không.
            bool isMatch = gameProcessor.CheckMatch(firstSelectedIndex, secondSelectedIndex);
            UpdateScoreLabels();

            if (isMatch)
            {
                // Nếu ghép đúng thì đánh dấu 2 ô để ẩn sau 2 giây, người chơi vẫn tiếp tục thao tác.
                matchedCards[firstSelectedIndex] = true;
                matchedCards[secondSelectedIndex] = true;
                pictureBoxes[firstSelectedIndex].Enabled = false;
                pictureBoxes[secondSelectedIndex].Enabled = false;
                pendingRemoveCards[firstSelectedIndex] = true;
                pendingRemoveCards[secondSelectedIndex] = true;

                // Bật timer xóa cặp đúng sau 2 giây, không khóa thao tác người chơi.
                timerRemoveMatched.Interval = 2000;
                if (!timerRemoveMatched.Enabled)
                {
                    timerRemoveMatched.Start();
                }

                // Reset trạng thái chọn để người chơi có thể chọn tiếp ngay.
                firstSelectedIndex = -1;
                secondSelectedIndex = -1;
            }
            else
            {
                // Nếu ghép sai thì bật timer, sau 1 giây sẽ úp lại 2 hình rồi đổi lượt.
                isWaitingToFlipBack = true;
                timerFlip.Interval = 1000;
                timerFlip.Start();
            }
        }

        private void timerFlip_Tick(object sender, EventArgs e)
        {
            // Dừng timer ngay khi vào Tick để tránh chạy lặp không cần thiết.
            timerFlip.Stop();

            // Úp lại 2 ô vừa chọn sai nếu chỉ số hợp lệ.
            if (firstSelectedIndex >= 0)
            {
                HideCard(firstSelectedIndex);
            }

            if (secondSelectedIndex >= 0)
            {
                HideCard(secondSelectedIndex);
            }

            // Đổi lượt người chơi sau khi lật sai.
            gameProcessor.SwitchPlayer();
            UpdateTurnLabel();

            // Đặt lại trạng thái chọn cho lượt kế tiếp.
            firstSelectedIndex = -1;
            secondSelectedIndex = -1;
            isWaitingToFlipBack = false;
            timerFlip.Interval = 1000;
        }

        private void timerRemoveMatched_Tick(object sender, EventArgs e)
        {
            // Dừng timer và xóa toàn bộ các ô đang chờ ẩn sau khi ghép đúng.
            timerRemoveMatched.Stop();

            for (int i = 0; i < pendingRemoveCards.Length; i++)
            {
                if (pendingRemoveCards[i])
                {
                    pictureBoxes[i].Visible = false;
                    pendingRemoveCards[i] = false;
                }
            }

            // Kiểm tra nếu đã tìm đủ 5 cặp thì thông báo kết quả.
            CheckGameOver();
        }

        private void CheckGameOver()
        {
            // Nếu đã tìm đủ 5 cặp thì xác định người chiến thắng và hiển thị thông báo.
            if (gameProcessor.MatchesFound == 5)
            {
                string message;

                if (gameProcessor.Score1 > gameProcessor.Score2)
                {
                    message = "Kết thúc game! Người chơi 1 chiến thắng.";
                }
                else if (gameProcessor.Score2 > gameProcessor.Score1)
                {
                    message = "Kết thúc game! Người chơi 2 chiến thắng.";
                }
                else
                {
                    message = "Kết thúc game! Hai người chơi hòa nhau.";
                }

                MessageBox.Show(message, "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Sau khi có kết quả thắng thua, tự động bắt đầu ván mới và trộn ngẫu nhiên lại các ô.
                StartNewGame();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Người dùng bấm nút ván mới thì khởi động lại toàn bộ trạng thái game.
            StartNewGame();
        }
    }

    public class MemoryGameProcessor
    {
        private Random random;

        public int Score1 { get; private set; }
        public int Score2 { get; private set; }
        public int CurrentPlayer { get; private set; }
        public int MatchesFound { get; private set; }
        public int[] ImageIndices { get; private set; }

        public MemoryGameProcessor()
        {
            // Khởi tạo giá trị ban đầu cho game processor.
            ResetGameState();
            ImageIndices = new int[10];
            random = new Random(Guid.NewGuid().GetHashCode());
        }

        public void ResetGameState()
        {
            Score1 = 0;
            Score2 = 0;
            CurrentPlayer = 1;
            MatchesFound = 0;
        }

        public void Shuffle()
        {
            // Tạo lại seed ngẫu nhiên mới ở mỗi lần trộn để hạn chế trùng thứ tự giữa các ván.
            random = new Random(Guid.NewGuid().GetHashCode());

            // Tạo mảng gốc chứa 5 cặp hình: 0,0,1,1,2,2,3,3,4,4.
            int[] baseValues = new int[10];
            int valueIndex = 0;

            for (int i = 0; i < 5; i++)
            {
                baseValues[valueIndex] = i;
                valueIndex = valueIndex + 1;
                baseValues[valueIndex] = i;
                valueIndex = valueIndex + 1;
            }

            // Dùng Fisher-Yates bằng vòng lặp for để trộn ngẫu nhiên mảng.
            for (int i = baseValues.Length - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                int temp = baseValues[i];
                baseValues[i] = baseValues[j];
                baseValues[j] = temp;
            }

            // Sao chép kết quả đã trộn sang ImageIndices.
            for (int i = 0; i < baseValues.Length; i++)
            {
                ImageIndices[i] = baseValues[i];
            }
        }

        public void SwitchPlayer()
        {
            // Đổi lượt giữa 2 người chơi.
            if (CurrentPlayer == 1)
            {
                CurrentPlayer = 2;
            }
            else
            {
                CurrentPlayer = 1;
            }
        }

        public bool CheckMatch(int firstIndex, int secondIndex)
        {
            // So sánh hai ô được lật dựa trên chỉ số hình đã trộn.
            if (ImageIndices[firstIndex] == ImageIndices[secondIndex])
            {
                // Nếu đúng cặp thì cộng điểm cho người chơi hiện tại.
                if (CurrentPlayer == 1)
                {
                    Score1 = Score1 + 1;
                }
                else
                {
                    Score2 = Score2 + 1;
                }

                // Tăng số cặp đã tìm được.
                MatchesFound = MatchesFound + 1;
                return true;
            }

            // Nếu không phải cặp đúng thì trả về false.
            return false;
        }
    }
}
