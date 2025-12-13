using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamListForm
{
    public static class UserSession
    {
        public static int CurrentUserId { get; set; } = 0; // ID người dùng
        public static string CurrentUsername { get; set; } = ""; // Tên hiển thị
        public static bool IsLoggedIn => CurrentUserId > 0; // Kiểm tra đã đăng nhập chưa

        // Hàm xóa session khi đăng xuất
        public static void Logout()
        {
            CurrentUserId = 0;
            CurrentUsername = "";
        }
    }
}
