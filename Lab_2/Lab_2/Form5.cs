using System;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form5 : Form
    {
        private CalculatorProcessor calculatorProcessor;
        private double firstOperand;
        private string currentOperator;
        private bool isNewInput;

        public Form5()
        {
            InitializeComponent();

            // Khởi tạo đối tượng xử lý máy tính để thực hiện các phép toán và bộ nhớ.
            calculatorProcessor = new CalculatorProcessor();

            // Thiết lập trạng thái ban đầu cho chương trình máy tính.
            firstOperand = 0;
            currentOperator = string.Empty;
            isNewInput = true;

            // Thiết lập giá trị hiển thị mặc định khi mở form.
            txtDisplay.Text = "0";
            lblHistory.Text = string.Empty;
        }

        private void NumberButton_Click(object sender, EventArgs e)
        {
            // Ép kiểu sender về Button để lấy nội dung số được nhấn.
            Button clickedButton = (Button)sender;

            // Nếu đang ở trạng thái nhập mới hoặc màn hình đang là 0 thì thay bằng số vừa nhấn.
            if (isNewInput || txtDisplay.Text == "0" || txtDisplay.Text == string.Empty)
            {
                txtDisplay.Text = clickedButton.Text;
            }
            else
            {
                // Nếu đang nhập tiếp thì ghép số mới vào cuối chuỗi hiện tại.
                txtDisplay.Text = txtDisplay.Text + clickedButton.Text;
            }

            // Sau khi nhấn số, trạng thái không còn là nhập mới.
            isNewInput = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetOperator("+");
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            SetOperator("-");
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            SetOperator("*");
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            SetOperator("/");
        }

        private void SetOperator(string op)
        {
            // Lưu số hạng thứ nhất từ màn hình hiển thị.
            firstOperand = GetDisplayValue();

            // Lưu toán tử hiện tại để chuẩn bị tính khi bấm dấu bằng.
            currentOperator = op;

            // Cập nhật giá trị hiện tại trong lớp xử lý.
            calculatorProcessor.CurrentValue = firstOperand;

            // Hiển thị lịch sử phép tính dạng: "15 + " để người dùng theo dõi.
            lblHistory.Text = firstOperand.ToString() + " " + currentOperator + " ";

            // Đánh dấu rằng lần nhập tiếp theo là nhập số thứ hai.
            isNewInput = true;

            // Làm rỗng vùng hiển thị để chuẩn bị nhập số thứ hai.
            txtDisplay.Text = string.Empty;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            // Lấy số hạng thứ hai từ màn hình hiển thị.
            double secondOperand = GetDisplayValue();

            // Kiểm tra trường hợp chia cho 0 để tránh lỗi logic.
            if (currentOperator == "/" && secondOperand == 0)
            {
                MessageBox.Show("Không thể chia cho 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isNewInput = true;
                return;
            }

            // Cập nhật lịch sử phép tính đầy đủ dạng: "15 + 10 =".
            lblHistory.Text = lblHistory.Text + secondOperand.ToString() + " =";

            // Gọi lớp xử lý để thực hiện phép toán dựa trên toán tử hiện tại.
            double result = calculatorProcessor.ExecuteOperation(firstOperand, secondOperand, currentOperator);

            // Hiển thị kết quả lên màn hình và cập nhật trạng thái.
            txtDisplay.Text = result.ToString();
            calculatorProcessor.CurrentValue = result;
            firstOperand = result;
            isNewInput = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ trạng thái tính toán và đưa màn hình về 0.
            txtDisplay.Text = "0";
            lblHistory.Text = string.Empty;
            firstOperand = 0;
            currentOperator = string.Empty;
            isNewInput = true;
            calculatorProcessor.CurrentValue = 0;
        }

        private void btnClearEntry_Click(object sender, EventArgs e)
        {
            // Chỉ xóa giá trị đang hiển thị để nhập lại số hiện tại.
            txtDisplay.Text = "0";
            isNewInput = true;
        }

        private void btnMC_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ giá trị trong bộ nhớ máy tính.
            calculatorProcessor.MemoryClear();
            calculatorProcessor.CurrentValue = 0;

            // Hiển thị lịch sử thao tác bộ nhớ để người dùng dễ theo dõi.
            lblHistory.Text = "MC (0)";
        }

        private void btnMR_Click(object sender, EventArgs e)
        {
            // Gọi lại giá trị bộ nhớ và hiển thị lên màn hình.
            double memoryValue = calculatorProcessor.MemoryRecall();
            txtDisplay.Text = memoryValue.ToString();

            // Đồng bộ lại các giá trị đang xử lý để các phép tính tiếp theo hoạt động ổn định.
            calculatorProcessor.CurrentValue = memoryValue;
            firstOperand = memoryValue;
            currentOperator = string.Empty;

            // Hiển thị lịch sử thao tác bộ nhớ dạng có giá trị.
            lblHistory.Text = "MR (" + memoryValue.ToString() + ")";
            isNewInput = true;
        }

        private void btnMPlus_Click(object sender, EventArgs e)
        {
            // Cộng giá trị phù hợp vào bộ nhớ (ưu tiên giá trị đang hiển thị, nếu rỗng thì lấy giá trị đang xử lý).
            double currentDisplayValue = GetMemoryInputValue();
            calculatorProcessor.MemoryAdd(currentDisplayValue);

            // Hiển thị lịch sử thao tác bộ nhớ theo yêu cầu, kèm giá trị bộ nhớ mới.
            lblHistory.Text = "M+ (" + currentDisplayValue.ToString() + ") -> M=" + calculatorProcessor.MemoryValue.ToString();
            isNewInput = true;
        }

        private void btnMMinus_Click(object sender, EventArgs e)
        {
            // Trừ giá trị phù hợp khỏi bộ nhớ (ưu tiên giá trị đang hiển thị, nếu rỗng thì lấy giá trị đang xử lý).
            double currentDisplayValue = GetMemoryInputValue();
            calculatorProcessor.MemorySubtract(currentDisplayValue);

            // Hiển thị lịch sử thao tác bộ nhớ theo yêu cầu, kèm giá trị bộ nhớ mới.
            lblHistory.Text = "M- (" + currentDisplayValue.ToString() + ") -> M=" + calculatorProcessor.MemoryValue.ToString();
            isNewInput = true;
        }

        private double GetMemoryInputValue()
        {
            // Nếu màn hình có dữ liệu thì dùng trực tiếp dữ liệu đó.
            if (txtDisplay.Text != string.Empty)
            {
                return GetDisplayValue();
            }

            // Nếu màn hình rỗng (thường xảy ra sau khi bấm toán tử), dùng số hạng thứ nhất đang lưu.
            if (currentOperator != string.Empty)
            {
                return firstOperand;
            }

            // Trường hợp còn lại, dùng giá trị hiện tại trong processor.
            return calculatorProcessor.CurrentValue;
        }

        private double GetDisplayValue()
        {
            // Chuyển đổi chuỗi trên màn hình sang kiểu double để tính toán.
            // Nếu chuyển đổi thất bại thì trả về 0 để đảm bảo chương trình không lỗi.
            double value;
            bool isValid = double.TryParse(txtDisplay.Text, out value);
            if (isValid)
            {
                return value;
            }

            return 0;
        }
    }

    public class CalculatorProcessor
    {
        public double MemoryValue { get; private set; }
        public double CurrentValue { get; set; }

        public CalculatorProcessor()
        {
            // Khởi tạo giá trị bộ nhớ và giá trị hiện tại khi tạo đối tượng.
            MemoryValue = 0;
            CurrentValue = 0;
        }

        public double ExecuteOperation(double operand1, double operand2, string op)
        {
            // Thực hiện phép toán theo toán tử truyền vào bằng switch-case truyền thống.
            switch (op)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "*":
                    return operand1 * operand2;
                case "/":
                    if (operand2 == 0)
                    {
                        return 0;
                    }
                    return operand1 / operand2;
                default:
                    return operand2;
            }
        }

        public void MemoryAdd(double value)
        {
            // Cộng thêm giá trị vào vùng nhớ.
            MemoryValue = MemoryValue + value;
        }

        public void MemorySubtract(double value)
        {
            // Trừ giá trị khỏi vùng nhớ.
            MemoryValue = MemoryValue - value;
        }

        public void MemoryClear()
        {
            // Đặt lại bộ nhớ về 0.
            MemoryValue = 0;
        }

        public double MemoryRecall()
        {
            // Trả về giá trị đang lưu trong bộ nhớ.
            return MemoryValue;
        }
    }
}
