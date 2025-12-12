using TourApp;

namespace TeamListForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // --- KIỂM TRA ĐĂNG NHẬP TỰ ĐỘNG ---
            int savedId = Properties.Settings.Default.SavedUserId;

            if (savedId != -1) // Nếu khác -1 nghĩa là đã từng đăng nhập
            {
                // 1. Khôi phục lại Session
                UserSession.CurrentUserId = savedId;
                // (Lưu ý: Bạn nên viết thêm hàm lấy Username từ ID để hiển thị cho đúng, 
                // tạm thời gán tạm hoặc query DB lấy tên nếu cần kỹ tính)

                // 2. Vào thẳng Home
                Application.Run(new Home());
            }
            else
            {
                // Chưa đăng nhập -> Hiện Form Login
                Application.Run(new LoginForm());
            }
        }
    }
}