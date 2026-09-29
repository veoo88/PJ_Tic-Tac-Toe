# BÁO CÁO DỰ ÁN: GAME CỜ CARO PRO (WINFORMS C#)

> **Môn học**: Lập trình Windows (LTWIN)  
> **Nền tảng**: C# / .NET Framework 4.7.2 (Windows Forms)  
> **Công nghệ đồ họa**: GDI+ (Graphics Device Interface Plus) với kỹ thuật Double Buffering  
> **Kiến trúc**: Tách lớp hướng đối tượng (Core Board Engine - Heuristic AI Engine - UI View)  

---

## 📑 MỤC LỤC
1. [Giới Thiệu Đề Tài](#1-giới-thiệu-đề-tài)
2. [Các Tính Năng Nổi Bật](#2-các-tính-năng-nổi-bật)
3. [Kiến Trúc & Cấu Trúc Mã Nguồn](#3-kiến-trúc--cấu-trúc-mã-nguồn)
4. [Chi Tiết Các Module & Lớp Đối Tượng](#4-chi-tiết-các-module--lớp-đối-tượng)
5. [Các Giải Thuật Cốt Lõi (Core Algorithms)](#5-các-giải-thuật-cốt-lõi-core-algorithms)
6. [Tối Ưu Hiệu Năng & Đồ Họa GDI+](#6-tối-ưu-hiệu-năng--đồ-họa-gdi)
7. [Hướng Dẫn Cài Đặt & Chạy Dự Án](#7-hướng-dẫn-cài-đặt--chạy-dự-án)
8. [Hướng Phát Triển Tiếp Theo](#8-hướng-phát-triển-tiếp-theo)

---

## 1. Giới Thiệu Đề Tài

**Game Cờ Caro Pro** là một ứng dụng trò chơi cờ Caro (Gomoku) hoàn chỉnh được xây dựng trên nền tảng Windows Forms trong C#. Dự án mô phỏng trò chơi cờ dân gian kinh điển nhưng được nâng tầm với:
- Đồ họa hiển thị mượt mà với công nghệ **GDI+ (Double Buffering)**, không sử dụng hàng trăm Control Button tĩnh như các phiên bản truyền thống.
- Hệ thống **Trí tuệ nhân tạo (AI)** thông minh được thiết kế theo 3 cấp độ: Dễ, Trung bình, và Cao thủ (có khả năng gài bẫy và chống gài bẫy đôi).
- Trọng tài chuẩn mực hỗ trợ cả **Luật Caro Việt Nam** (chặn 2 đầu bởi quân đối phương thì không thắng) và **Luật Tự Do** (Gomoku chuẩn quốc tế).
- Bảng điều khiển thi đấu thời gian thực: Đồng hồ đếm ngược từng lượt, bảng tỉ số, hoàn tác/đi lại (Undo/Redo), gợi ý nước đi (Hint) và âm thanh tương tác.

---

## 2. Các Tính Năng Nổi Bật

### 🎮 Chế Độ Chơi Đa Dạng
- **Chế độ 2 Người chơi (PvP - Player vs Player)**: Đấu trí trực tiếp giữa hai người chơi trên cùng một máy tính.
- **Chế độ Đấu với Máy (PvE - Player vs AI)**: Thử thách với 3 cấp độ AI thông minh:
  - ⭐ **Dễ (Easy)**: Nước đi tự nhiên, có sơ hở cho người mới làm quen.
  - ⭐⭐ **Trung bình (Medium)**: Nhận biết nguy hiểm, chặn các nước 3 và 4 quân hở.
  - ⭐⭐⭐ **Cao thủ (Hard/Master)**: Phân tích ma trận thế cờ, giăng bẫy đôi (Double Three 3-3, Four-Three 4-3), phòng thủ kiên cố.
- **Tùy chọn quân đi trước**: Có thể tùy chọn Người chơi (X) đi trước hoặc Máy (O) đi trước.
- **Tùy chọn Luật chơi**:
  - *Luật Caro Việt Nam*: 5 quân liên tiếp, nếu bị quân đối phương chặn cả 2 đầu thì **chưa thắng**. Mép bàn cờ không bị coi là quân chặn.
  - *Luật Tự Do (Free Gomoku)*: Đạt đủ 5 quân liên tiếp bất kỳ là giành chiến thắng.

### 🎨 Giao Diện & Hiệu Ứng Trực Quan (UI/UX)
- Phong cách **Luxury Dark Slate (`#1E212D`) kết hợp Bàn Cờ Gỗ (`#F5DEB3` / `#DEB887`)**: Tạo cảm giác như bàn cờ thi đấu thực tế, dịu mắt và chuyên nghiệp.
- **Vẽ quân cờ Vector X & O**: Khử răng cưa mịn màng (`SmoothingMode.AntiAlias`), không lo vỡ hình hay thiếu file ảnh ngoài đĩa.
- **Bóng mờ khi rê chuột (Hover Ghost Piece)**: Hiển thị trước vị trí quân cờ khi lia chuột qua ô trống.
- **Đánh dấu nước đi gần nhất (Last Move Marker)**: Điểm tâm phát sáng màu vàng kim giúp theo dõi tức thì nước cờ đối thủ vừa đánh.
- **Đường thắng cuộc (Winning Line)**: Kẻ đường nối hào quang vàng kim qua 5 quân chiến thắng.
- **Điểm sao Thiên Nguyên (Star Points)** & Tọa độ cạnh (1 - 18, A - V).

### ⚙️ Tiện Ích Thi Đấu
- **Đồng hồ đếm ngược (Turn Timer)**: 20 giây cho mỗi lượt đi kèm thanh `ProgressBar` mượt mà (đổi sang màu đỏ cảnh báo khi còn dưới 5 giây; quá giờ sẽ bị xử thua).
- **Hoàn tác & Đi lại (Undo / Redo)**: 
  - Trong PvP: Hoàn tác từng nước của người chơi.
  - Trong PvE: Tự động hoàn tác 2 nước (nước của máy + nước của người) để người chơi có cơ hội đi lại.
- **Gợi ý nước đi (AI Hint)**: Bộ não AI phân tích và khoanh vùng ô cờ tối ưu nhất để tư vấn cho người chơi.
- **Bảng tỉ số (Scoreboard)**: Ghi nhận tổng số trận Thắng - Hòa - Thua trong suốt phiên chơi.
- **Âm thanh tương tác**: Tiếng đặt quân lách cách và âm thanh chúc mừng chiến thắng.

---

## 3. Kiến Trúc & Cấu Trúc Mã Nguồn

Dự án áp dụng mô hình phân tách trách nhiệm (Separation of Concerns):

```
D:\VHU_TLIEU\LTWIN\Game_Co_Caro\
│
├── GameEnums.cs              # Định nghĩa các enum trạng thái, chế độ, luật chơi
├── CaroBoard.cs              # Model dữ liệu bàn cờ, trọng tài kiểm tra thắng thua, Undo/Redo
├── CaroAI.cs                 # Bộ não AI (Heuristic Pattern Evaluation, Candidate Filter, Hint)
│
├── Form1.cs                  # Controller điều khiển game, render GDI+, Timer, Event Handlers
├── Form1.Designer.cs         # Layout giao diện bàn cờ và sidebar dashboard
├── Form1.resx                # Tài nguyên giao diện Form1
│
├── Menu.cs                   # Form khởi động và cấu hình trận đấu
├── Menu.Designer.cs          # Layout giao diện Menu dạng thẻ phẳng
├── Menu.resx                 # Tài nguyên giao diện Menu
│
├── Program.cs                # Entry Point khởi chạy ứng dụng
├── Co_Caro.csproj            # File cấu hình build dự án C# (.NET 4.7.2)
└── README.md                 # Tài liệu hướng dẫn & báo cáo dự án
```

---

## 4. Chi Tiết Các Module & Lớp Đối Tượng

### 4.1. `GameEnums.cs`
Định nghĩa các kiểu dữ liệu liệt kê cốt lõi:
- `CellState`: `Empty` (0), `Player1` (1 - X), `Player2` (2 - O / Máy).
- `AIMode`: `Easy` (0), `Medium` (1), `Hard` (2).
- `GameRule`: `VietnameseCaro` (Luật VN chặn 2 đầu), `FreeGomoku` (Luật tự do).
- `GameMode`: `PvP` (2 người), `PvE` (Đấu với máy).
- `FirstTurn`: `Player1` (X đi trước), `Player2` (O đi trước).

### 4.2. `CaroBoard.cs`
Lớp đóng vai trò **Model** trung tâm của trò chơi:
- `Grid`: Mảng 2 chiều `int[Rows, Cols]` lưu trạng thái các ô cờ (mặc định 18 hàng x 22 cột = 396 ô).
- `UndoHistory` & `RedoHistory`: Hai cấu trúc ngăn xếp `Stack<CaroMove>` phục vụ việc quay lại nước cờ và đi tiếp.
- `LastWinningLine`: Danh sách tọa độ `List<Point>` của 5 quân chiến thắng để vẽ đường highlight.
- `CheckWin(row, col, out winLine)`: Hàm trọng tài kiểm tra xem nước đi tại `(row, col)` có tạo thành đường thắng hợp lệ theo luật quy định hay không.
- `IsValidMove(r, c)` & `IsFull()`: Kiểm tra tính hợp lệ của ô cờ và kiểm tra thế cờ hòa khi kín bàn.

### 4.3. `CaroAI.cs`
Bộ não trí tuệ nhân tạo (AI Engine):
- `GetCandidateMoves(board, radius)`: Lọc các ô cờ trống nằm trong bán kính 1 - 2 ô quanh các quân cờ đã có.
- `EvaluatePoint(board, r, c, player)`: Đánh giá sức mạnh của một ô cờ trên 4 phương hướng (ngang, dọc, 2 đường chéo).
- `GetEasyMove()`: Kiểm tra nước thắng 5 và nước chặn 5, sau đó chọn ngẫu nhiên có trọng số trong khu vực giao tranh.
- `GetMediumMove()`: Quét toàn bộ candidate moves, tính toán tổng điểm công thủ:
  $$\text{Score} = \text{Score}_{\text{Attack}} \times 1.0 + \text{Score}_{\text{Defense}} \times 1.2$$
- `GetHardMove()`: Nhận diện thế cờ bẫy đôi (**3-3**, **4-3**), ưu tiên phòng thủ cực mạnh và chiếm vị trí trung tâm bàn cờ:
  $$\text{Score} = \text{Score}_{\text{Attack}} \times 1.1 + \text{Score}_{\text{Defense}} \times 1.3 + (10 - \text{DistanceToCenter})$$
- `GetHint(board, player)`: Cung cấp nước đi tối ưu nhất cho người chơi khi cần trợ giúp.

### 4.4. `Form1.cs` & `Form1.Designer.cs`
Lớp giao diện chính (Main Game Screen):
- Dựng giao diện Sidebar Dashboard: Thẻ người chơi, đồng hồ đếm ngược, thanh tiến trình, thanh nút chức năng.
- Sự kiện vẽ đồ họa `pnlBoard_Paint`: Sử dụng các lớp đồ họa chuyên sâu của GDI+ (`LinearGradientBrush`, `Pen`, `GraphicsPath`, `SmoothingMode.AntiAlias`).
- Xử lý bất đồng bộ AI: Sử dụng `await Task.Run(...)` để AI tính toán trong tiến trình nền, giúp giao diện người dùng luôn mượt mà 60 FPS, không bao giờ bị hiện tượng "Not Responding".

### 4.5. `Menu.cs` & `Menu.Designer.cs`
Lớp giao diện khởi động (Launcher):
- Bố cục trực quan với các `GroupBox` lựa chọn: Chế độ chơi, Độ khó AI, Bên đi trước, Luật chơi.
- Tự động bật/tắt các tùy chọn phụ thuộc (ví dụ khi chọn PvP thì tự động vô hiệu hóa lựa chọn độ khó AI).
- Quản lý vòng đời ứng dụng: Đóng ván đấu sẽ hiển thị lại Menu; tắt Menu sẽ gọi `Application.Exit()` để giải phóng triệt để tài nguyên hệ thống.

---

## 5. Các Giải Thuật Cốt Lõi (Core Algorithms)

### 5.1. Thuật Toán Kiểm Tra Thắng Cuộc (Win Condition Checking)

Khi một quân cờ vừa hạ xuống vị trí $(r_0, c_0)$, hệ thống kiểm tra 4 hướng với vector chỉ phương $(\Delta r, \Delta c)$:
1. Hướng ngang: $(0, 1)$
2. Hướng dọc: $(1, 0)$
3. Hướng chéo chính: $(1, 1)$
4. Hướng chéo phụ: $(1, -1)$

Trên mỗi hướng, thuật toán duyệt tiến và duyệt lùi để đếm số quân liên tiếp cùng màu $K$:
- Nếu $K \ge 5$:
  - Trong **Luật Tự Do**: Trả về `true` (Thắng).
  - Trong **Luật Việt Nam**: Kiểm tra 2 ô ở 2 đầu chuỗi:
    - Đầu tiến: $(r_{\text{forward}}, c_{\text{forward}})$
    - Đầu lùi: $(r_{\text{backward}}, c_{\text{backward}})$
    - **Quy tắc**: Chỉ khi **cả 2 đầu** đều nằm trong bàn cờ VÀ đều là quân của **đối phương** thì mới bị tính là bị chặn 2 đầu (chưa thắng). Nếu một trong hai đầu là ô trống hoặc chạm mép bàn cờ thì nước đi vẫn **hợp lệ và giành chiến thắng**.

### 5.2. Thuật Toán Lọc Nước Đi Tiềm Năng (Candidate Move Filtering)
Bàn cờ có $18 \times 22 = 396$ ô. Nếu duyệt qua toàn bộ các ô trống:
- Tốn nhiều thời gian CPU.
- Rất nhiều ô nằm ở góc xa bàn cờ hoàn toàn vô nghĩa đối với thế trận hiện tại.

**Giải thuật lọc**:
- Thuật toán chỉ thu thập các ô trống nằm trong khoảng cách Chebyshev $\le 2$ so với các quân cờ đã đánh:
  $$\max(|r - r'|, |c - c'|) \le 2$$
- Kỹ thuật này giúp thu hẹp tập hợp tìm kiếm từ ~380 ô xuống chỉ còn **15 đến 30 ô**, giúp tốc độ phản hồi của AI đạt mức chớp mắt **$< 150\text{ ms}$**.

### 5.3. Bảng Điểm Đánh Giá Thế Cờ (Pattern Evaluation Table)

| Thế Cờ | Số Quân | Đầu Hở | Điểm Đánh Giá | Ý Nghĩa Chiến Thuật |
| :--- | :---: | :---: | :---: | :--- |
| **Thắng Ngay** | $\ge 5$ | - | $20,000,000$ | Nước cờ kết thúc ván đấu |
| **4 Hở 2 Đầu** | $4$ | $2$ | $2,000,000$ | Thế cờ tất thắng nước kế tiếp |
| **4 Chặn 1 Đầu** | $4$ | $1$ | $200,000$ | Buộc đối phương phải chặn ngay |
| **3 Hở 2 Đầu** | $3$ | $2$ | $50,000$ | Thế tấn công cực mạnh, đe dọa tạo 4 hở |
| **3 Chặn 1 Đầu** | $3$ | $1$ | $4,000$ | Thế cờ tiềm năng |
| **2 Hở 2 Đầu** | $2$ | $2$ | $800$ | Nước phát triển cờ |
| **2 Chặn 1 Đầu** | $2$ | $1$ | $100$ | Nước cờ nhẹ |
| **Bẫy Kép (Fork)** | $\ge 2$ thế mở | - | $+2,000,000$ | Đòn gài đôi (3-3 hoặc 3-4) không thể cản phá |

---

## 6. Tối Ưu Hiệu Năng & Đồ Họa GDI+

### 6.1. Khắc Phục Hiện Tượng Giật Lag (Flickering)
Trong Windows Forms, việc vẽ lại nhiều thành phần có thể gây hiện tượng chớp nháy khó chịu do cơ chế vẽ trực tiếp lên màn hình (Direct Screen Drawing). Dự án khắc phục triệt để bằng cách kích hoạt thuộc tính ẩn `DoubleBuffered` thông qua Reflection:

```csharp
typeof(Panel).InvokeMember("DoubleBuffered",
    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
    null, control, new object[] { true });
```
Mọi thao tác vẽ sẽ được thực hiện trước trên một vùng đệm đồ họa trong bộ nhớ RAM (Back Buffer), sau đó mới đẩy toàn bộ hình ảnh hoàn chỉnh lên màn hình trong một lần duy nhất.

### 6.2. Cơ Chế Bất Đồng Bộ Giữ Giao Diện 60 FPS
Khi chơi với máy, nếu thuật toán AI chạy trực tiếp trên UI Thread (luồng giao diện) thì cửa sổ game sẽ bị đơ, con trỏ chuột quay tròn và xuất hiện chữ *(Not Responding)*.
Dự án sử dụng cơ chế `async / await Task.Run(...)`:
- AI tính toán hoàn toàn độc lập trên Background Worker Thread.
- UI Thread vẫn tự do xử lý hiệu ứng rê chuột, đếm ngược đồng hồ và vẽ lại màn hình mượt mà.

---

## 7. Hướng Dẫn Cài Đặt & Chạy Dự Án

### Yêu Cầu Môi Trường
- **Hệ điều hành**: Windows 10 / 11.
- **Công cụ phát triển**: Visual Studio 2017 / 2019 / 2022.
- **Target Framework**: .NET Framework 4.7.2 trở lên.

### Các Bước Khởi Chạy
1. Mở file giải pháp **`Co_Caro.sln`** bằng Visual Studio.
2. Chọn cấu hình **Debug** hoặc **Release** với nền tảng **Any CPU**.
3. Nhấn **`F5`** (Start Debugging) hoặc **`Ctrl + F5`** (Start Without Debugging).
4. Tại Menu chính:
   - Chọn chế độ chơi (PvP hoặc PvE).
   - Chọn độ khó (Dễ / Trung bình / Cao thủ).
   - Chọn luật chơi (Luật VN hoặc Luật tự do).
   - Bấm **▶ BẮT ĐẦU TRẬN ĐẤU** để trải nghiệm.

> **Chạy trực tiếp file thực thi**: Bạn có thể chạy ngay file đã được biên dịch sẵn tại đường dẫn:  
> `bin\Debug\Tic_Tac_toe_1.exe`

---

## 8. Hướng Phát Triển Tiếp Theo

1. **Chơi qua Mạng LAN / Internet**: Sử dụng Socket TCP/IP để 2 người chơi trên 2 máy tính khác nhau trong cùng mạng nội bộ có thể thi đấu với nhau.
2. **Lưu & Xem lại Trận Đấu (Replay System)**: Lưu lịch sử trận đấu ra file JSON hoặc XML để phát lại từng nước cờ phục vụ phân tích chiến thuật.
3. **Tùy biến Giao diện (Theme Chooser)**: Cho phép người dùng chuyển đổi linh hoạt giữa giao diện Bàn Cờ Gỗ Cổ Điển, Giao Diện Tối Neon, hoặc Bàn Cờ Thủy Tinh.
4. **Bảng Xếp Hạng Người Chơi**: Lưu trữ thành tích và điểm Elo của người chơi vào cơ sở dữ liệu SQLite hoặc SQL Server.

---

*Bản quyền dự án thuộc về sinh viên - Đồ án Lập trình Windows (VHU).*

