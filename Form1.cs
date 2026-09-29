using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Media;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_toe_1
{
    public partial class Form1 : Form
    {
        #region Constants & Fields

        public const int BOARD_ROWS = 18;
        public const int BOARD_COLS = 22;
        public const int CELL_SIZE = 32;
        public const int MARGIN_X = 35;
        public const int MARGIN_Y = 35;
        private const int MAX_TURN_TIME = 20;

        private CaroBoard board;
        private GameMode gameMode = GameMode.PvP;
        private AIMode aiMode = AIMode.Hard;
        private GameRule gameRule = GameRule.VietnameseCaro;
        private int currentPlayer = 1; // 1 = X (Người 1), 2 = O (Người 2 / Máy)
        private int firstPlayer = 1;

        private bool isGameOver = false;
        private bool isThinking = false;
        private bool soundEnabled = true;

        private Point? hoverPoint = null;
        private Point? hintPoint = null;

        private int timeLeft = MAX_TURN_TIME;
        private int p1Wins = 0;
        private int p2Wins = 0;
        private int drawCount = 0;

        public Menu MenuForm { get; set; }

        #endregion

        #region Constructors

        public Form1() : this(GameMode.PvP, AIMode.Easy, GameRule.VietnameseCaro, FirstTurn.Player1, null)
        {
        }

        public Form1(bool isPvP) : this(isPvP ? GameMode.PvP : GameMode.PvE, AIMode.Medium, GameRule.VietnameseCaro, FirstTurn.Player1, null)
        {
        }

        public Form1(AIMode mode) : this(GameMode.PvE, mode, GameRule.VietnameseCaro, FirstTurn.Player1, null)
        {
        }

        public Form1(GameMode mode, AIMode ai, GameRule rule, FirstTurn firstTurn, Menu menu)
        {
            InitializeComponent();

            this.gameMode = mode;
            this.aiMode = ai;
            this.gameRule = rule;
            this.firstPlayer = (firstTurn == FirstTurn.Player1) ? 1 : 2;
            this.currentPlayer = this.firstPlayer;
            this.MenuForm = menu;

            board = new CaroBoard(BOARD_ROWS, BOARD_COLS)
            {
                Rule = this.gameRule
            };

            EnableDoubleBuffering(pnlBoard);
            CalculateBoardSize();
        }

        #endregion

        #region Form Lifecycle & Initialization

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateModeDisplay();
            StartNewGame();
        }

        private void EnableDoubleBuffering(Control control)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, control, new object[] { true });
        }

        private void CalculateBoardSize()
        {
            int requiredWidth = MARGIN_X * 2 + BOARD_COLS * CELL_SIZE;
            int requiredHeight = MARGIN_Y * 2 + BOARD_ROWS * CELL_SIZE;
            pnlBoard.Size = new Size(requiredWidth, requiredHeight);

            // Căn giữa panel bàn cờ trong container
            pnlBoard.Location = new Point(
                Math.Max(10, (pnlBoardContainer.ClientSize.Width - requiredWidth) / 2),
                Math.Max(10, (pnlBoardContainer.ClientSize.Height - requiredHeight) / 2)
            );
        }

        private void UpdateModeDisplay()
        {
            string modeName = (gameMode == GameMode.PvP) ? "2 Người Chơi (PvP)" : "Đấu Với Máy (PvE)";
            string diffName = "";
            if (gameMode == GameMode.PvE)
            {
                switch (aiMode)
                {
                    case AIMode.Easy: diffName = " - Dễ ⭐"; break;
                    case AIMode.Medium: diffName = " - Trung Bình ⭐⭐"; break;
                    case AIMode.Hard: diffName = " - Cao Thủ ⭐⭐⭐"; break;
                }
            }
            string ruleName = (gameRule == GameRule.VietnameseCaro) ? " (Luật VN)" : " (Tự Do)";
            lblGameModeBadge.Text = modeName + diffName + ruleName;

            lblP1Name.Text = "Người chơi 1";
            lblP2Name.Text = (gameMode == GameMode.PvP) ? "Người chơi 2" : "Máy (" + aiMode + ")";
        }

        #endregion

        #region Game Flow

        private void StartNewGame()
        {
            board.Reset();
            isGameOver = false;
            isThinking = false;
            hintPoint = null;
            hoverPoint = null;

            currentPlayer = firstPlayer;
            UpdatePlayerCards();
            ResetTurnTimer();

            pnlBoard.Invalidate();

            // Nếu máy đi trước trong PvE
            if (gameMode == GameMode.PvE && currentPlayer == 2)
            {
                TriggerAIMove();
            }
        }

        private void ResetTurnTimer()
        {
            turnTimer.Stop();
            timeLeft = MAX_TURN_TIME;
            prgTimer.Maximum = MAX_TURN_TIME;
            prgTimer.Value = MAX_TURN_TIME;
            lblTimerCount.Text = "⏱ " + timeLeft + "s";

            if (!isGameOver)
            {
                turnTimer.Start();
            }
        }

        private void UpdatePlayerCards()
        {
            // Cập nhật thẻ người chơi đang đến lượt (Glow effect)
            if (currentPlayer == 1)
            {
                cardPlayer1.BackColor = Color.FromArgb(50, 65, 95);
                cardPlayer2.BackColor = Color.FromArgb(40, 45, 62);
                lblTurnStatus.Text = "Lượt: " + lblP1Name.Text;
                lblTurnStatus.ForeColor = Color.FromArgb(30, 144, 255);
            }
            else
            {
                cardPlayer1.BackColor = Color.FromArgb(40, 45, 62);
                cardPlayer2.BackColor = Color.FromArgb(70, 45, 55);
                lblTurnStatus.Text = (gameMode == GameMode.PvE && isThinking) ? "Máy đang suy nghĩ..." : "Lượt: " + lblP2Name.Text;
                lblTurnStatus.ForeColor = Color.FromArgb(255, 75, 75);
            }

            lblP1Score.Text = "Thắng: " + p1Wins;
            lblP2Score.Text = "Thắng: " + p2Wins;
            lblScoreDetail.Text = p1Wins + "  -  " + drawCount + "  -  " + p2Wins;
        }

        private void PlayAudioBeep(bool isWinning = false)
        {
            if (!soundEnabled) return;

            try
            {
                if (isWinning)
                {
                    SystemSounds.Asterisk.Play();
                }
                else
                {
                    SystemSounds.Beep.Play();
                }
            }
            catch
            {
                // Bỏ qua nếu môi trường không có thiết bị phát âm thanh
            }
        }

        #endregion

        #region Board Painting (GDI+ DoubleBuffered)

        private void pnlBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;

            int boardWidth = BOARD_COLS * CELL_SIZE;
            int boardHeight = BOARD_ROWS * CELL_SIZE;

            // 1. Vẽ nền gỗ bàn cờ sang trọng với Gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0), new Point(pnlBoard.Width, pnlBoard.Height),
                Color.FromArgb(245, 222, 179), Color.FromArgb(222, 184, 135)))
            {
                g.FillRectangle(brush, 0, 0, pnlBoard.Width, pnlBoard.Height);
            }

            // Viền gỗ ngoài
            using (Pen borderPen = new Pen(Color.FromArgb(139, 90, 43), 3))
            {
                g.DrawRectangle(borderPen, 2, 2, pnlBoard.Width - 4, pnlBoard.Height - 4);
            }

            // 2. Tọa độ hàng (1, 2, 3...) và cột (A, B, C...)
            using (Font coordFont = new Font("Segoe UI", 8f, FontStyle.Bold))
            using (Brush coordBrush = new SolidBrush(Color.FromArgb(120, 80, 40)))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                // Cột (A, B, C...)
                for (int c = 0; c < BOARD_COLS; c++)
                {
                    string colLetter = ((char)('A' + c)).ToString();
                    float x = MARGIN_X + c * CELL_SIZE + CELL_SIZE / 2f;
                    g.DrawString(colLetter, coordFont, coordBrush, x, MARGIN_Y / 2f, sf);
                    g.DrawString(colLetter, coordFont, coordBrush, x, MARGIN_Y + boardHeight + MARGIN_Y / 2f, sf);
                }

                // Hàng (1, 2, 3...)
                for (int r = 0; r < BOARD_ROWS; r++)
                {
                    string rowNumber = (r + 1).ToString();
                    float y = MARGIN_Y + r * CELL_SIZE + CELL_SIZE / 2f;
                    g.DrawString(rowNumber, coordFont, coordBrush, MARGIN_X / 2f, y, sf);
                    g.DrawString(rowNumber, coordFont, coordBrush, MARGIN_X + boardWidth + MARGIN_X / 2f, y, sf);
                }
            }

            // 3. Kẻ lưới ô cờ
            using (Pen gridPen = new Pen(Color.FromArgb(160, 110, 60), 1))
            {
                for (int r = 0; r <= BOARD_ROWS; r++)
                {
                    int y = MARGIN_Y + r * CELL_SIZE;
                    g.DrawLine(gridPen, MARGIN_X, y, MARGIN_X + boardWidth, y);
                }
                for (int c = 0; c <= BOARD_COLS; c++)
                {
                    int x = MARGIN_X + c * CELL_SIZE;
                    g.DrawLine(gridPen, x, MARGIN_Y, x, MARGIN_Y + boardHeight);
                }
            }

            // 4. Các điểm sao (Star Points - Thiên nguyên) tạo cảm giác bàn cờ chuyên nghiệp
            DrawStarPoints(g);

            // 5. Vẽ bóng mờ (Hover Ghost Piece) khi rê chuột
            if (!isGameOver && !isThinking && hoverPoint.HasValue)
            {
                int hr = hoverPoint.Value.Y;
                int hc = hoverPoint.Value.X;
                if (board.InBoard(hr, hc) && board.Grid[hr, hc] == 0)
                {
                    int hx = MARGIN_X + hc * CELL_SIZE;
                    int hy = MARGIN_Y + hr * CELL_SIZE;
                    using (SolidBrush hoverBg = new SolidBrush(Color.FromArgb(35, 255, 255, 255)))
                    {
                        g.FillRectangle(hoverBg, hx + 1, hy + 1, CELL_SIZE - 1, CELL_SIZE - 1);
                    }
                    DrawPiece(g, hx, hy, currentPlayer, isGhost: true);
                }
            }

            // 6. Vẽ gợi ý nước đi (Hint) nếu có
            if (hintPoint.HasValue)
            {
                int hx = MARGIN_X + hintPoint.Value.X * CELL_SIZE;
                int hy = MARGIN_Y + hintPoint.Value.Y * CELL_SIZE;
                using (Pen hintPen = new Pen(Color.FromArgb(255, 140, 0), 2.5f))
                {
                    hintPen.DashStyle = DashStyle.Dash;
                    g.DrawRectangle(hintPen, hx + 2, hy + 2, CELL_SIZE - 4, CELL_SIZE - 4);
                }
            }

            // 7. Vẽ các quân cờ đã đánh
            for (int r = 0; r < BOARD_ROWS; r++)
            {
                for (int c = 0; c < BOARD_COLS; c++)
                {
                    int player = board.Grid[r, c];
                    if (player != 0)
                    {
                        int px = MARGIN_X + c * CELL_SIZE;
                        int py = MARGIN_Y + r * CELL_SIZE;
                        DrawPiece(g, px, py, player, isGhost: false);
                    }
                }
            }

            // 8. Đánh dấu nước đi gần nhất (Last Move Marker)
            if (board.LastMove.HasValue)
            {
                Point last = board.LastMove.Value;
                int lx = MARGIN_X + last.X * CELL_SIZE;
                int ly = MARGIN_Y + last.Y * CELL_SIZE;

                // Vòng tròn highlight tâm điểm
                using (Pen lastPen = new Pen(Color.FromArgb(255, 215, 0), 2f))
                {
                    g.DrawEllipse(lastPen, lx + CELL_SIZE / 2f - 4, ly + CELL_SIZE / 2f - 4, 8, 8);
                }
            }

            // 9. Vẽ đường nối thắng cuộc (Winning Line)
            if (board.LastWinningLine != null && board.LastWinningLine.Count >= 5)
            {
                DrawWinningLine(g);
            }
        }

        private void DrawStarPoints(Graphics g)
        {
            int[] starRows = new int[] { 4, BOARD_ROWS / 2, BOARD_ROWS - 5 };
            int[] starCols = new int[] { 5, BOARD_COLS / 2, BOARD_COLS - 6 };

            using (Brush starBrush = new SolidBrush(Color.FromArgb(139, 90, 43)))
            {
                foreach (int r in starRows)
                {
                    foreach (int c in starCols)
                    {
                        if (r < BOARD_ROWS && c < BOARD_COLS)
                        {
                            int x = MARGIN_X + c * CELL_SIZE;
                            int y = MARGIN_Y + r * CELL_SIZE;
                            g.FillEllipse(starBrush, x - 3.5f, y - 3.5f, 7, 7);
                        }
                    }
                }
            }
        }

        private void DrawPiece(Graphics g, int x, int y, int player, bool isGhost)
        {
            int padding = 6;
            int size = CELL_SIZE - padding * 2;
            int alpha = isGhost ? 90 : 255;

            if (player == 1) // Quân X (Sapphire Blue)
            {
                Color xColor = Color.FromArgb(alpha, 30, 144, 255);
                using (Pen pen = new Pen(xColor, 3.5f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    g.DrawLine(pen, x + padding, y + padding, x + padding + size, y + padding + size);
                    g.DrawLine(pen, x + padding + size, y + padding, x + padding, y + padding + size);
                }
            }
            else if (player == 2) // Quân O (Coral Red)
            {
                Color oColor = Color.FromArgb(alpha, 255, 75, 75);
                using (Pen pen = new Pen(oColor, 3.5f))
                {
                    g.DrawEllipse(pen, x + padding, y + padding, size, size);
                }
            }
        }

        private void DrawWinningLine(Graphics g)
        {
            var pts = board.LastWinningLine;
            if (pts.Count < 2) return;

            // Highlight vòng hào quang quanh từng quân thắng
            using (Pen haloPen = new Pen(Color.FromArgb(255, 215, 0), 2.5f))
            {
                foreach (var p in pts)
                {
                    int x = MARGIN_X + p.X * CELL_SIZE;
                    int y = MARGIN_Y + p.Y * CELL_SIZE;
                    g.DrawRectangle(haloPen, x + 1, y + 1, CELL_SIZE - 2, CELL_SIZE - 2);
                }
            }

            // Kẻ đường gạch nối liền 5 quân
            Point start = pts[0];
            Point end = pts[pts.Count - 1];

            float x1 = MARGIN_X + start.X * CELL_SIZE + CELL_SIZE / 2f;
            float y1 = MARGIN_Y + start.Y * CELL_SIZE + CELL_SIZE / 2f;
            float x2 = MARGIN_X + end.X * CELL_SIZE + CELL_SIZE / 2f;
            float y2 = MARGIN_Y + end.Y * CELL_SIZE + CELL_SIZE / 2f;

            using (Pen winLinePen = new Pen(Color.FromArgb(255, 215, 0), 4f))
            {
                winLinePen.StartCap = LineCap.Round;
                winLinePen.EndCap = LineCap.Round;
                g.DrawLine(winLinePen, x1, y1, x2, y2);
            }
        }

        #endregion

        #region Mouse Event Handlers

        private void pnlBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (isGameOver || isThinking) return;

            int col = (e.X - MARGIN_X) / CELL_SIZE;
            int row = (e.Y - MARGIN_Y) / CELL_SIZE;

            if (board.InBoard(row, col))
            {
                if (!hoverPoint.HasValue || hoverPoint.Value.X != col || hoverPoint.Value.Y != row)
                {
                    hoverPoint = new Point(col, row);
                    pnlBoard.Invalidate();
                }
            }
            else if (hoverPoint.HasValue)
            {
                hoverPoint = null;
                pnlBoard.Invalidate();
            }
        }

        private void pnlBoard_MouseLeave(object sender, EventArgs e)
        {
            if (hoverPoint.HasValue)
            {
                hoverPoint = null;
                pnlBoard.Invalidate();
            }
        }

        private void pnlBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (isGameOver || isThinking) return;

            // Nếu đang trong chế độ PvE và đến lượt máy thì không cho click
            if (gameMode == GameMode.PvE && currentPlayer == 2) return;

            int col = (e.X - MARGIN_X) / CELL_SIZE;
            int row = (e.Y - MARGIN_Y) / CELL_SIZE;

            if (!board.IsValidMove(row, col)) return;

            ExecuteMove(row, col);
        }

        #endregion

        #region Move Execution & Turn Handling

        private void ExecuteMove(int row, int col)
        {
            var move = board.MakeMove(row, col, currentPlayer);
            if (move == null) return;

            hintPoint = null;
            PlayAudioBeep(isWinning: false);
            pnlBoard.Invalidate();

            // Kiểm tra Thắng/Thua
            List<Point> winLine;
            if (board.CheckWin(row, col, out winLine))
            {
                HandleGameOver(isWin: true, winner: currentPlayer);
                return;
            }

            // Kiểm tra Hòa
            if (board.IsFull())
            {
                HandleGameOver(isWin: false, winner: 0);
                return;
            }

            // Chuyển lượt
            currentPlayer = (currentPlayer == 1) ? 2 : 1;
            UpdatePlayerCards();
            ResetTurnTimer();

            // Nếu đến lượt Máy trong PvE
            if (gameMode == GameMode.PvE && currentPlayer == 2)
            {
                TriggerAIMove();
            }
        }

        private async void TriggerAIMove()
        {
            isThinking = true;
            UpdatePlayerCards();
            pnlBoard.Invalidate();

            // Chờ một khoảng nhỏ để tạo cảm giác tự nhiên như đối thủ đang suy nghĩ
            await Task.Delay(300);

            // Tính toán nước cờ tốt nhất trong nền để không giật đơ giao diện
            Point aiMove = await Task.Run(() => CaroAI.FindBestMove(board, 2, aiMode));

            isThinking = false;

            if (!isGameOver && board.IsValidMove(aiMove.Y, aiMove.X))
            {
                ExecuteMove(aiMove.Y, aiMove.X);
            }
        }

        private void HandleGameOver(bool isWin, int winner)
        {
            isGameOver = true;
            turnTimer.Stop();
            pnlBoard.Invalidate();

            if (isWin)
            {
                PlayAudioBeep(isWinning: true);

                string winnerName = (winner == 1) ? lblP1Name.Text : lblP2Name.Text;
                if (winner == 1) p1Wins++; else p2Wins++;
                UpdatePlayerCards();

                MessageBox.Show(string.Format("Chúc mừng! {0} đã giành chiến thắng ngoạn mục!", winnerName),
                    "Kết Thúc Ván Đấu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                drawCount++;
                UpdatePlayerCards();
                MessageBox.Show("Bàn cờ đã đầy! Trận đấu kết thúc với kết quả Hòa!",
                    "Hòa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Toolbar Action Buttons

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            if (!isGameOver && board.UndoHistory.Count > 0)
            {
                var dr = MessageBox.Show("Bạn có chắc chắn muốn hủy ván cờ hiện tại và bắt đầu ván mới?",
                    "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.Yes) return;
            }

            StartNewGame();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (isThinking) return;

            if (board.UndoHistory.Count == 0)
            {
                MessageBox.Show("Chưa có nước đi nào để hoàn tác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            hintPoint = null;

            if (gameMode == GameMode.PvE)
            {
                // Ở chế độ PvE, hoàn tác cả 2 nước (nước của máy + nước của người chơi)
                if (board.UndoHistory.Count >= 2)
                {
                    board.Undo(); // Lùi nước của máy
                    board.Undo(); // Lùi nước của người chơi
                    currentPlayer = 1;
                }
                else if (board.UndoHistory.Count == 1)
                {
                    board.Undo();
                    currentPlayer = firstPlayer;
                }
            }
            else // PvP
            {
                var undone = board.Undo();
                if (undone != null)
                {
                    currentPlayer = undone.Player;
                }
            }

            isGameOver = false;
            UpdatePlayerCards();
            ResetTurnTimer();
            pnlBoard.Invalidate();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            if (isThinking || isGameOver) return;

            if (board.RedoHistory.Count == 0)
            {
                MessageBox.Show("Không có nước đi nào để đi lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            hintPoint = null;

            if (gameMode == GameMode.PvE)
            {
                // Phục hồi lại 2 nước
                if (board.RedoHistory.Count >= 2)
                {
                    board.Redo();
                    board.Redo();
                    currentPlayer = 1;
                }
                else
                {
                    board.Redo();
                }
            }
            else // PvP
            {
                var redone = board.Redo();
                if (redone != null)
                {
                    currentPlayer = (redone.Player == 1) ? 2 : 1;
                }
            }

            UpdatePlayerCards();
            ResetTurnTimer();
            pnlBoard.Invalidate();
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            if (isGameOver || isThinking) return;

            Point? hint = CaroAI.GetHint(board, currentPlayer);
            if (hint.HasValue)
            {
                hintPoint = hint.Value;
                pnlBoard.Invalidate();
                PlayAudioBeep(isWinning: false);
            }
            else
            {
                MessageBox.Show("Không tìm thấy gợi ý phù hợp!", "Gợi Ý", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSound_Click(object sender, EventArgs e)
        {
            soundEnabled = !soundEnabled;
            btnSound.Text = soundEnabled ? "🔊 Âm Thanh: BẬT" : "🔇 Âm Thanh: TẮT";
            btnSound.BackColor = soundEnabled ? Color.FromArgb(41, 128, 185) : Color.FromArgb(100, 110, 120);
        }

        private void btnBackMenu_Click(object sender, EventArgs e)
        {
            turnTimer.Stop();

            if (MenuForm != null && !MenuForm.IsDisposed)
            {
                MenuForm.Show();
                this.Hide();
            }
            else
            {
                Menu newMenu = new Menu();
                newMenu.Show();
                this.Hide();
            }
        }

        private void turnTimer_Tick(object sender, EventArgs e)
        {
            if (isGameOver || isThinking) return;

            timeLeft--;
            prgTimer.Value = Math.Max(0, timeLeft);
            lblTimerCount.Text = "⏱ " + timeLeft + "s";

            // Đổi màu cảnh báo thanh thời gian khi sắp hết giờ
            if (timeLeft <= 5)
            {
                lblTimerCount.ForeColor = Color.FromArgb(255, 75, 75);
            }
            else
            {
                lblTimerCount.ForeColor = Color.FromArgb(255, 215, 0);
            }

            if (timeLeft <= 0)
            {
                turnTimer.Stop();
                string timeoutPlayer = (currentPlayer == 1) ? lblP1Name.Text : lblP2Name.Text;
                int opponent = (currentPlayer == 1) ? 2 : 1;

                MessageBox.Show(string.Format("Hết thời gian lượt đi! {0} đã bị xử thua vì quá giờ.", timeoutPlayer),
                    "Hết Giờ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                HandleGameOver(isWin: true, winner: opponent);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            turnTimer.Stop();
            if (MenuForm != null && !MenuForm.IsDisposed)
            {
                MenuForm.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        #endregion
    }
}

