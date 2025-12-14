# Tournament Tracker

Project quản lý giải đấu thể thao (Bóng đá), được viết bằng **C# WinForms** kết hợp với **SQL Server**.
Đây là đồ án môn học **IT008 - Lập trình trực quan** (UIT).

## 👨‍💻 Team Dev

Dự án được thực hiện bởi 3 thành viên:
1. **[Tên Thành Viên 1]** - [MSSV]
2. **[Tên Thành Viên 2]** - [MSSV]
3. **[Tên Thành Viên 3]** - [MSSV]

## 📋 Giới thiệu

Ứng dụng Desktop giúp các nhà tổ chức giải đấu quản lý quy trình từ lúc tạo giải, thêm đội bóng cho đến khi xếp lịch và cập nhật kết quả.
Hệ thống tập trung vào việc xử lý dữ liệu chặt chẽ (Ràng buộc khóa ngoại, phân quyền) và hỗ trợ nhiều thể thức thi đấu.

## ✨ Tính năng chính

* **Authentication:** Đăng ký, Đăng nhập, Phân quyền (Chỉ người tạo giải mới có quyền sửa/xóa giải đó).
* **Quản lý Giải đấu (Tournaments):**
    * Tạo giải đấu mới với các tùy chọn Format: **Single Stage** hoặc **Multi Stage**.
    * Xem danh sách giải đấu dạng Dashboard.
* **Quản lý Đội bóng & Cầu thủ:**
    * Thêm/Sửa/Xóa đội bóng (Dữ liệu đội bóng gắn liền với giải đấu, không dùng chung).
    * Quản lý danh sách cầu thủ chi tiết.
* **Vận hành giải:**
    * Xem lịch thi đấu (Schedule).
    * Cập nhật tỉ số trận đấu.

## 🛠 Tech Stack

* **Language:** C# (.NET Framework/.NET Core)
* **GUI:** Windows Forms (WinForms)
* **Database:** SQL Server
* **Architecture:** 3-Layer (cơ bản), sử dụng **ADO.NET** thuần (không dùng Entity Framework để tối ưu query).

## 🗄️ Database Schema

Hệ thống gồm 5 bảng chính:
* `Account`: Lưu User/Pass (Password được hash SHA256).
* `Tournaments`: Lưu thông tin giải và cấu hình thể thức (`FormatMode`, `Stage1Format`, `Stage2Format`).
* `Teams`: Đội bóng (FK tới Tournaments).
* `Players`: Cầu thủ (FK tới Teams).
* `Matches`: Trận đấu, tỉ số, vòng đấu.

## 🚀 Cài đặt & Chạy (Localhost)

**Bước 1: Clone source code**
```bash
git clone [https://github.com/username/Tournament-Tracker.git](https://github.com/username/Tournament-Tracker.git)
```
Bước 2: Cài đặt Database

Mở SQL Server Management Studio (SSMS).

Mở file TournamentTracker.sql trong thư mục code.

Chạy toàn bộ script (Execute) để tạo database và dữ liệu mẫu.

Bước 3: Cấu hình kết nối

Mở file DatabaseHelper.cs trong Visual Studio.

Tìm dòng connectionString và sửa lại Data Source cho đúng với tên Server của máy bạn:

private static string connectionString = @"Data Source=TEN_MAY_CUA_BAN;Initial Catalog=TournamentTracker;Integrated Security=True;...";

Bước 4: Build & Run

Nhấn F5 trong Visual Studio để chạy ứng dụng.

Tài khoản Admin mặc định (nếu có trong script SQL): admin / 123456.

---
*© 2025 UIT - Tournament Tracker Project*
