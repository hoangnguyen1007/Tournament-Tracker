<div align="center">

  # 🏆 TOURNAMENT TRACKER
  
  **Hệ thống Quản lý Giải đấu Bóng đá & Theo dõi Tỉ số Trực tuyến**
  
  [![.NET](https://img.shields.io/badge/.NET-8.0-purple.svg)](https://dotnet.microsoft.com/)
  [![Language](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
  [![Database](https://img.shields.io/badge/Database-SQL%20Server%20Cloud-red.svg)](https://azure.microsoft.com/en-us/services/sql-database/)
  [![Status](https://img.shields.io/badge/Status-Release%20v1.0-success.svg)]()

  <p align="center">
    <a href="#tính-năng-nổi-bật">Tính năng</a> •
    <a href="#công-nghệ-sử-dụng">Công nghệ</a> •
    <a href="#cài-đặt">Cài đặt</a> •
    <a href="#kiến-trúc-hệ-thống">Kiến trúc</a> •
    <a href="#nhóm-tác-giả">Tác giả</a>
  </p>
</div>

---

## 📖 Giới thiệu (About)

**Tournament Tracker** là giải pháp phần mềm Desktop Application hiện đại, giúp đơn giản hóa quy trình tổ chức và quản lý các giải đấu thể thao. Dự án tập trung giải quyết bài toán đồng bộ dữ liệu giữa nhiều người dùng thông qua kiến trúc **Centralized Cloud Database**.

Thay vì lưu trữ cục bộ, ứng dụng cho phép Ban tổ chức (Admin) tạo giải đấu tại máy chủ, và Người xem (Viewer) có thể cập nhật kết quả theo thời gian thực từ bất kỳ đâu chỉ cần có Internet.

---

## 🚀 Tính năng nổi bật (Key Features)

* **☁️ Cloud-First Architecture:** Dữ liệu được lưu trữ tập trung trên máy chủ SQL Server Cloud, đảm bảo tính nhất quán và đồng bộ thời gian thực (Real-time Sync).
* **🔒 Secure Authentication:** Hệ thống đăng ký/đăng nhập bảo mật, phân quyền người dùng.
* **📅 Smart Scheduling:** Thuật toán tự động sắp xếp lịch thi đấu vòng tròn (Round-Robin) và tạo bảng đấu một cách công bằng.
* **📊 Dashboard Trực quan:** Giao diện theo dõi tỉ số, bảng xếp hạng (Standings) được cập nhật tự động ngay khi có kết quả trận đấu.
* **📦 Flexible Deployment:** Cung cấp đa dạng tùy chọn cài đặt: Bộ cài chuẩn Windows (.msi) hoặc bản Portable (.zip) chạy ngay không cần cài đặt.

---

## 🛠 Công nghệ sử dụng (Tech Stack)

| Thành phần | Công nghệ | Chi tiết |
| :--- | :--- | :--- |
| **Frontend** | Windows Forms (WinForms) | .NET 8.0, Modern UI Design |
| **Backend Logic** | C# | OOP, LINQ, Exception Handling |
| **Database** | SQL Server (Cloud Hosted) | T-SQL, Stored Procedures, Relational Design |
| **Connectivity** | ADO.NET | Direct TCP/IP Connection, SqlClient |
| **Tools** | Visual Studio 2022 | SSMS, Git, GitHub Actions |

---

## 📥 Hướng dẫn Cài đặt & Sử dụng (Installation)

Dự án cung cấp 2 phiên bản tại mục [**Releases**](../../releases). Vui lòng chọn phiên bản phù hợp:

### 🔹 Cách 1: Cài đặt chuyên nghiệp (Recommended)
Dành cho người dùng phổ thông, tự động tạo Shortcut.
1. Tải file **`TournamentTracker_Installer.msi`**.
2. Chạy file cài đặt và nhấn **Next** liên tục.
3. Mở ứng dụng từ biểu tượng ngoài Desktop.

### 🔹 Cách 2: Bản Portable (Chạy ngay)
Dành cho người dùng muốn nhanh gọn, copy vào USB.
1. Tải file **`TournamentTracker_Portable.zip`**.
2. Giải nén (Extract) toàn bộ thư mục.
3. Chạy file **`TournamentTracker.exe`** bên trong.

> **⚠️ Lưu ý:** Do ứng dụng chưa được ký số (Digital Signature), Windows Defender có thể hiện cảnh báo màu xanh (SmartScreen). Bạn vui lòng chọn **"More info"** -> **"Run anyway"** để tiếp tục.

---

## 👥 Nhóm Tác giả (Authors)
<div align="center"> <i>Developed with ❤️ & ☕ by UIT Students.</i> </div>
