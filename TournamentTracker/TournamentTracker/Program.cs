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
            int savedId = Properties.Settings.Default.SavedUserId;

            if (savedId > 0)
            {
                // 2. Nếu có: Khôi phục Session và vào thẳng Home
                UserSession.CurrentUserId = savedId;
                Application.Run(new Home());
            }
            else
            {
                // 3. Nếu không: Chạy màn hình Login
                Application.Run(new LoginForm());
            }
        }
    }
}