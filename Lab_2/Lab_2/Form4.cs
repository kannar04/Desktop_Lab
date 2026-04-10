using System;
using System.Windows.Forms;

namespace Lab_2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnInLoiGioiThieu_Click(object sender, EventArgs e)
        {
            // Lấy họ tên người dùng nhập và loại bỏ khoảng trắng dư ở đầu/cuối.
            string hoTenDaTrim = txtHoTen.Text.Trim();

            // Tạo đối tượng xử lý họ tên theo mô hình hướng đối tượng.
            HoTenProcessor processor = new HoTenProcessor(hoTenDaTrim);

            // Gọi hàm in lời giới thiệu và hiển thị lên nhãn kết quả.
            lblKetQua.Text = processor.InLoiGioiThieu();
        }

        private void btnHoLot_Click(object sender, EventArgs e)
        {
            // Lấy họ tên và xóa khoảng trắng dư ở hai đầu chuỗi.
            string hoTenDaTrim = txtHoTen.Text.Trim();

            // Khởi tạo đối tượng xử lý với chuỗi họ tên hiện tại.
            HoTenProcessor processor = new HoTenProcessor(hoTenDaTrim);

            // Lấy phần họ lót và hiển thị kết quả.
            lblKetQua.Text = processor.LayHoLot();
        }

        private void btnTen_Click(object sender, EventArgs e)
        {
            // Lấy chuỗi họ tên đã được Trim trước khi xử lý.
            string hoTenDaTrim = txtHoTen.Text.Trim();

            // Khởi tạo đối tượng xử lý họ tên.
            HoTenProcessor processor = new HoTenProcessor(hoTenDaTrim);

            // Gọi phương thức lấy tên và gán vào nhãn kết quả.
            lblKetQua.Text = processor.LayTen();
        }

        private void btnDemTu_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ ô nhập và loại bỏ khoảng trắng dư ở đầu/cuối.
            string hoTenDaTrim = txtHoTen.Text.Trim();

            // Tạo đối tượng để thực hiện các thao tác xử lý họ tên.
            HoTenProcessor processor = new HoTenProcessor(hoTenDaTrim);

            // Gọi phương thức đếm từ và nhận về số lượng từ hợp lệ.
            int soTu = processor.DemTu();

            // Hiển thị số từ đã đếm được lên nhãn kết quả.
            lblKetQua.Text = "Số lượng từ: " + soTu;
        }

        private void btnHoaDauTu_Click(object sender, EventArgs e)
        {
            // Đọc họ tên từ TextBox và chuẩn hóa khoảng trắng đầu/cuối.
            string hoTenDaTrim = txtHoTen.Text.Trim();

            // Khởi tạo lớp xử lý họ tên bằng dữ liệu vừa đọc.
            HoTenProcessor processor = new HoTenProcessor(hoTenDaTrim);

            // Chuẩn hóa hoa đầu từ rồi xuất ra vùng kết quả.
            lblKetQua.Text = processor.HoaDauTu();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xóa nội dung trong ô nhập họ tên.
            txtHoTen.Text = string.Empty;

            // Xóa nội dung đang hiển thị ở nhãn kết quả.
            lblKetQua.Text = string.Empty;

            // Đưa con trỏ nhập liệu quay lại ô họ tên.
            txtHoTen.Focus();
        }

        private void btnDung_Click(object sender, EventArgs e)
        {
            // Đóng toàn bộ ứng dụng Windows Forms.
            Application.Exit();
        }
    }

    public class HoTenProcessor
    {
        private readonly string _chuoiHoTen;

        public HoTenProcessor(string chuoiHoTen)
        {
            _chuoiHoTen = chuoiHoTen;
        }

        public string InLoiGioiThieu()
        {
            return "Chào mừng đến với chương trình xử lý họ tên của ABC";
        }

        public string LayHoLot()
        {
            // Tách chuỗi họ tên thành mảng theo ký tự khoảng trắng.
            string[] mangTu = _chuoiHoTen.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Nếu không có từ nào thì trả về rỗng.
            if (mangTu.Length == 0)
            {
                return string.Empty;
            }

            // Nếu chỉ có một từ thì không có phần họ lót.
            if (mangTu.Length == 1)
            {
                return string.Empty;
            }

            // Khởi tạo biến để ghép họ lót.
            string ketQua = string.Empty;

            // Duyệt từ phần tử đầu đến phần tử kế cuối để lấy họ lót.
            for (int i = 0; i < mangTu.Length - 1; i++)
            {
                // Nếu chưa phải phần tử đầu tiên thì thêm 1 khoảng trắng trước khi ghép.
                if (i > 0)
                {
                    ketQua = ketQua + " ";
                }

                // Ghép từ hiện tại vào chuỗi kết quả.
                ketQua = ketQua + mangTu[i];
            }

            // Trả về chuỗi họ lót đã ghép.
            return ketQua;
        }

        public string LayTen()
        {
            // Tách chuỗi họ tên thành mảng theo khoảng trắng và bỏ phần tử rỗng.
            string[] mangTu = _chuoiHoTen.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Nếu mảng rỗng thì trả về chuỗi rỗng.
            if (mangTu.Length == 0)
            {
                return string.Empty;
            }

            // Trả về phần tử cuối cùng trong mảng, chính là tên.
            return mangTu[mangTu.Length - 1];
        }

        public int DemTu()
        {
            // Tách chuỗi theo khoảng trắng, ở đây giữ cả phần tử rỗng để tự đếm bằng vòng lặp.
            string[] mangTu = _chuoiHoTen.Split(' ');

            // Khởi tạo biến đếm số từ hợp lệ.
            int soLuongTu = 0;

            // Duyệt tuần tự từng phần tử trong mảng.
            for (int i = 0; i < mangTu.Length; i++)
            {
                // Lấy phần tử hiện tại và tiếp tục Trim để chắc chắn loại bỏ khoảng trắng dư.
                string tuHienTai = mangTu[i].Trim();

                // Chỉ tăng biến đếm khi phần tử hiện tại không rỗng.
                if (tuHienTai != string.Empty)
                {
                    soLuongTu = soLuongTu + 1;
                }
            }

            // Trả về tổng số từ hợp lệ sau khi đếm.
            return soLuongTu;
        }

        public string HoaDauTu()
        {
            // Tách chuỗi theo khoảng trắng và loại bỏ phần tử rỗng.
            string[] mangTu = _chuoiHoTen.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Nếu không có dữ liệu thì trả về chuỗi rỗng.
            if (mangTu.Length == 0)
            {
                return string.Empty;
            }

            // Duyệt từng từ để chuẩn hóa hoa đầu từ.
            for (int i = 0; i < mangTu.Length; i++)
            {
                // Lấy từ hiện tại.
                string tuHienTai = mangTu[i];

                // Chỉ xử lý khi từ có ký tự.
                if (tuHienTai.Length > 0)
                {
                    // Lấy ký tự đầu và chuyển thành chữ hoa.
                    string kyTuDau = tuHienTai.Substring(0, 1).ToUpper();

                    // Nếu từ dài hơn 1 ký tự thì lấy phần còn lại và chuyển thành chữ thường.
                    string phanConLai = string.Empty;
                    if (tuHienTai.Length > 1)
                    {
                        phanConLai = tuHienTai.Substring(1).ToLower();
                    }

                    // Gán lại từ đã chuẩn hóa vào mảng.
                    mangTu[i] = kyTuDau + phanConLai;
                }
            }

            // Ghép các từ lại thành chuỗi kết quả, phân tách bởi 1 khoảng trắng.
            string ketQua = string.Empty;
            for (int i = 0; i < mangTu.Length; i++)
            {
                // Nếu không phải từ đầu tiên thì thêm khoảng trắng trước khi ghép.
                if (i > 0)
                {
                    ketQua = ketQua + " ";
                }

                // Ghép từ hiện tại vào chuỗi kết quả.
                ketQua = ketQua + mangTu[i];
            }

            // Trả về chuỗi sau khi chuẩn hóa hoa đầu từ.
            return ketQua;
        }
    }
}
