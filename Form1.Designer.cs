namespace Tic_Tac_toe_1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.lblGameModeBadge = new System.Windows.Forms.Label();
            this.cardPlayer1 = new System.Windows.Forms.Panel();
            this.lblP1Symbol = new System.Windows.Forms.Label();
            this.lblP1Name = new System.Windows.Forms.Label();
            this.lblP1Score = new System.Windows.Forms.Label();
            this.cardPlayer2 = new System.Windows.Forms.Panel();
            this.lblP2Symbol = new System.Windows.Forms.Label();
            this.lblP2Name = new System.Windows.Forms.Label();
            this.lblP2Score = new System.Windows.Forms.Label();
            this.cardTimer = new System.Windows.Forms.Panel();
            this.lblTurnStatus = new System.Windows.Forms.Label();
            this.lblTimerCount = new System.Windows.Forms.Label();
            this.prgTimer = new System.Windows.Forms.ProgressBar();
            this.pnlScoreBoard = new System.Windows.Forms.Panel();
            this.lblScoreTitle = new System.Windows.Forms.Label();
            this.lblScoreDetail = new System.Windows.Forms.Label();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnHint = new System.Windows.Forms.Button();
            this.btnSound = new System.Windows.Forms.Button();
            this.btnBackMenu = new System.Windows.Forms.Button();
            this.pnlBoardContainer = new System.Windows.Forms.Panel();
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.turnTimer = new System.Windows.Forms.Timer(this.components);
            this.pnlSidebar.SuspendLayout();
            this.cardPlayer1.SuspendLayout();
            this.cardPlayer2.SuspendLayout();
            this.cardTimer.SuspendLayout();
            this.pnlScoreBoard.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.pnlBoardContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.pnlSidebar.Controls.Add(this.lblGameTitle);
            this.pnlSidebar.Controls.Add(this.lblGameModeBadge);
            this.pnlSidebar.Controls.Add(this.cardPlayer1);
            this.pnlSidebar.Controls.Add(this.cardPlayer2);
            this.pnlSidebar.Controls.Add(this.cardTimer);
            this.pnlSidebar.Controls.Add(this.pnlScoreBoard);
            this.pnlSidebar.Controls.Add(this.pnlButtons);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(16);
            this.pnlSidebar.Size = new System.Drawing.Size(290, 720);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGameTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblGameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblGameTitle.Location = new System.Drawing.Point(16, 16);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(258, 45);
            this.lblGameTitle.TabIndex = 0;
            this.lblGameTitle.Text = "CARO PRO";
            this.lblGameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGameModeBadge
            // 
            this.lblGameModeBadge.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblGameModeBadge.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular);
            this.lblGameModeBadge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(190)))));
            this.lblGameModeBadge.Location = new System.Drawing.Point(16, 61);
            this.lblGameModeBadge.Name = "lblGameModeBadge";
            this.lblGameModeBadge.Size = new System.Drawing.Size(258, 26);
            this.lblGameModeBadge.TabIndex = 1;
            this.lblGameModeBadge.Text = "PvE - Độ khó: Cao Thủ";
            this.lblGameModeBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cardPlayer1
            // 
            this.cardPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.cardPlayer1.Controls.Add(this.lblP1Symbol);
            this.cardPlayer1.Controls.Add(this.lblP1Name);
            this.cardPlayer1.Controls.Add(this.lblP1Score);
            this.cardPlayer1.Location = new System.Drawing.Point(16, 95);
            this.cardPlayer1.Name = "cardPlayer1";
            this.cardPlayer1.Size = new System.Drawing.Size(258, 62);
            this.cardPlayer1.TabIndex = 2;
            // 
            // lblP1Symbol
            // 
            this.lblP1Symbol.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblP1Symbol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblP1Symbol.Location = new System.Drawing.Point(8, 6);
            this.lblP1Symbol.Name = "lblP1Symbol";
            this.lblP1Symbol.Size = new System.Drawing.Size(46, 50);
            this.lblP1Symbol.TabIndex = 0;
            this.lblP1Symbol.Text = "✕";
            this.lblP1Symbol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP1Name
            // 
            this.lblP1Name.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblP1Name.ForeColor = System.Drawing.Color.White;
            this.lblP1Name.Location = new System.Drawing.Point(60, 10);
            this.lblP1Name.Name = "lblP1Name";
            this.lblP1Name.Size = new System.Drawing.Size(125, 22);
            this.lblP1Name.TabIndex = 1;
            this.lblP1Name.Text = "Người chơi 1";
            // 
            // lblP1Score
            // 
            this.lblP1Score.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblP1Score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblP1Score.Location = new System.Drawing.Point(60, 32);
            this.lblP1Score.Name = "lblP1Score";
            this.lblP1Score.Size = new System.Drawing.Size(125, 20);
            this.lblP1Score.TabIndex = 2;
            this.lblP1Score.Text = "Thắng: 0";
            // 
            // cardPlayer2
            // 
            this.cardPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(45)))), ((int)(((byte)(62)))));
            this.cardPlayer2.Controls.Add(this.lblP2Symbol);
            this.cardPlayer2.Controls.Add(this.lblP2Name);
            this.cardPlayer2.Controls.Add(this.lblP2Score);
            this.cardPlayer2.Location = new System.Drawing.Point(16, 165);
            this.cardPlayer2.Name = "cardPlayer2";
            this.cardPlayer2.Size = new System.Drawing.Size(258, 62);
            this.cardPlayer2.TabIndex = 3;
            // 
            // lblP2Symbol
            // 
            this.lblP2Symbol.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblP2Symbol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.lblP2Symbol.Location = new System.Drawing.Point(8, 6);
            this.lblP2Symbol.Name = "lblP2Symbol";
            this.lblP2Symbol.Size = new System.Drawing.Size(46, 50);
            this.lblP2Symbol.TabIndex = 0;
            this.lblP2Symbol.Text = "◯";
            this.lblP2Symbol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP2Name
            // 
            this.lblP2Name.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblP2Name.ForeColor = System.Drawing.Color.White;
            this.lblP2Name.Location = new System.Drawing.Point(60, 10);
            this.lblP2Name.Name = "lblP2Name";
            this.lblP2Name.Size = new System.Drawing.Size(125, 22);
            this.lblP2Name.TabIndex = 1;
            this.lblP2Name.Text = "Máy";
            // 
            // lblP2Score
            // 
            this.lblP2Score.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblP2Score.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(150)))), ((int)(((byte)(170)))));
            this.lblP2Score.Location = new System.Drawing.Point(60, 32);
            this.lblP2Score.Name = "lblP2Score";
            this.lblP2Score.Size = new System.Drawing.Size(125, 20);
            this.lblP2Score.TabIndex = 2;
            this.lblP2Score.Text = "Thắng: 0";
            // 
            // cardTimer
            // 
            this.cardTimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.cardTimer.Controls.Add(this.lblTurnStatus);
            this.cardTimer.Controls.Add(this.lblTimerCount);
            this.cardTimer.Controls.Add(this.prgTimer);
            this.cardTimer.Location = new System.Drawing.Point(16, 238);
            this.cardTimer.Name = "cardTimer";
            this.cardTimer.Padding = new System.Windows.Forms.Padding(10);
            this.cardTimer.Size = new System.Drawing.Size(258, 80);
            this.cardTimer.TabIndex = 4;
            // 
            // lblTurnStatus
            // 
            this.lblTurnStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTurnStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.lblTurnStatus.Location = new System.Drawing.Point(10, 8);
            this.lblTurnStatus.Name = "lblTurnStatus";
            this.lblTurnStatus.Size = new System.Drawing.Size(165, 24);
            this.lblTurnStatus.TabIndex = 0;
            this.lblTurnStatus.Text = "Lượt: Người chơi 1";
            // 
            // lblTimerCount
            // 
            this.lblTimerCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTimerCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblTimerCount.Location = new System.Drawing.Point(175, 5);
            this.lblTimerCount.Name = "lblTimerCount";
            this.lblTimerCount.Size = new System.Drawing.Size(73, 26);
            this.lblTimerCount.TabIndex = 1;
            this.lblTimerCount.Text = "⏱ 20s";
            this.lblTimerCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // prgTimer
            // 
            this.prgTimer.Location = new System.Drawing.Point(10, 42);
            this.prgTimer.Maximum = 20;
            this.prgTimer.Name = "prgTimer";
            this.prgTimer.Size = new System.Drawing.Size(238, 12);
            this.prgTimer.TabIndex = 2;
            this.prgTimer.Value = 20;
            // 
            // pnlScoreBoard
            // 
            this.pnlScoreBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(54)))));
            this.pnlScoreBoard.Controls.Add(this.lblScoreTitle);
            this.pnlScoreBoard.Controls.Add(this.lblScoreDetail);
            this.pnlScoreBoard.Location = new System.Drawing.Point(16, 328);
            this.pnlScoreBoard.Name = "pnlScoreBoard";
            this.pnlScoreBoard.Padding = new System.Windows.Forms.Padding(10);
            this.pnlScoreBoard.Size = new System.Drawing.Size(258, 62);
            this.pnlScoreBoard.TabIndex = 5;
            // 
            // lblScoreTitle
            // 
            this.lblScoreTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblScoreTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(170)))), ((int)(((byte)(190)))));
            this.lblScoreTitle.Location = new System.Drawing.Point(10, 8);
            this.lblScoreTitle.Name = "lblScoreTitle";
            this.lblScoreTitle.Size = new System.Drawing.Size(238, 18);
            this.lblScoreTitle.TabIndex = 0;
            this.lblScoreTitle.Text = "TỔNG TỈ SỐ TRẬN ĐẤU";
            this.lblScoreTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblScoreDetail
            // 
            this.lblScoreDetail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblScoreDetail.ForeColor = System.Drawing.Color.White;
            this.lblScoreDetail.Location = new System.Drawing.Point(10, 28);
            this.lblScoreDetail.Name = "lblScoreDetail";
            this.lblScoreDetail.Size = new System.Drawing.Size(238, 24);
            this.lblScoreDetail.TabIndex = 1;
            this.lblScoreDetail.Text = "0  -  0  -  0";
            this.lblScoreDetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnNewGame);
            this.pnlButtons.Controls.Add(this.btnUndo);
            this.pnlButtons.Controls.Add(this.btnRedo);
            this.pnlButtons.Controls.Add(this.btnHint);
            this.pnlButtons.Controls.Add(this.btnSound);
            this.pnlButtons.Controls.Add(this.btnBackMenu);
            this.pnlButtons.Location = new System.Drawing.Point(16, 405);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(258, 290);
            this.pnlButtons.TabIndex = 6;
            // 
            // btnNewGame
            // 
            this.btnNewGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnNewGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewGame.FlatAppearance.BorderSize = 0;
            this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewGame.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnNewGame.ForeColor = System.Drawing.Color.White;
            this.btnNewGame.Location = new System.Drawing.Point(0, 0);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(258, 42);
            this.btnNewGame.TabIndex = 0;
            this.btnNewGame.Text = "🔄 Ván Mới";
            this.btnNewGame.UseVisualStyleBackColor = false;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnUndo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUndo.ForeColor = System.Drawing.Color.White;
            this.btnUndo.Location = new System.Drawing.Point(0, 48);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(124, 38);
            this.btnUndo.TabIndex = 1;
            this.btnUndo.Text = "↩ Hoàn Tác";
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.btnRedo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRedo.FlatAppearance.BorderSize = 0;
            this.btnRedo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRedo.ForeColor = System.Drawing.Color.White;
            this.btnRedo.Location = new System.Drawing.Point(134, 48);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(124, 38);
            this.btnRedo.TabIndex = 2;
            this.btnRedo.Text = "↪ Đi Lại";
            this.btnRedo.UseVisualStyleBackColor = false;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnHint
            // 
            this.btnHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(84)))), ((int)(((byte)(0)))));
            this.btnHint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHint.FlatAppearance.BorderSize = 0;
            this.btnHint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHint.ForeColor = System.Drawing.Color.White;
            this.btnHint.Location = new System.Drawing.Point(0, 94);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(258, 38);
            this.btnHint.TabIndex = 3;
            this.btnHint.Text = "💡 Gợi Ý Nước Đi";
            this.btnHint.UseVisualStyleBackColor = false;
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // btnSound
            // 
            this.btnSound.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnSound.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSound.FlatAppearance.BorderSize = 0;
            this.btnSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSound.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSound.ForeColor = System.Drawing.Color.White;
            this.btnSound.Location = new System.Drawing.Point(0, 140);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(258, 38);
            this.btnSound.TabIndex = 4;
            this.btnSound.Text = "🔊 Âm Thanh: BẬT";
            this.btnSound.UseVisualStyleBackColor = false;
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            // 
            // btnBackMenu
            // 
            this.btnBackMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnBackMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackMenu.FlatAppearance.BorderSize = 0;
            this.btnBackMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackMenu.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBackMenu.ForeColor = System.Drawing.Color.White;
            this.btnBackMenu.Location = new System.Drawing.Point(0, 186);
            this.btnBackMenu.Name = "btnBackMenu";
            this.btnBackMenu.Size = new System.Drawing.Size(258, 38);
            this.btnBackMenu.TabIndex = 5;
            this.btnBackMenu.Text = "🚪 Về Menu Chính";
            this.btnBackMenu.UseVisualStyleBackColor = false;
            this.btnBackMenu.Click += new System.EventHandler(this.btnBackMenu_Click);
            // 
            // pnlBoardContainer
            // 
            this.pnlBoardContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.pnlBoardContainer.Controls.Add(this.pnlBoard);
            this.pnlBoardContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBoardContainer.Location = new System.Drawing.Point(290, 0);
            this.pnlBoardContainer.Name = "pnlBoardContainer";
            this.pnlBoardContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBoardContainer.Size = new System.Drawing.Size(890, 720);
            this.pnlBoardContainer.TabIndex = 1;
            // 
            // pnlBoard
            // 
            this.pnlBoard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(217)))), ((int)(((byte)(181)))));
            this.pnlBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlBoard.Location = new System.Drawing.Point(40, 30);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(800, 640);
            this.pnlBoard.TabIndex = 0;
            this.pnlBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBoard_Paint);
            this.pnlBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseClick);
            this.pnlBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlBoard_MouseMove);
            this.pnlBoard.MouseLeave += new System.EventHandler(this.pnlBoard_MouseLeave);
            // 
            // turnTimer
            // 
            this.turnTimer.Interval = 1000;
            this.turnTimer.Tick += new System.EventHandler(this.turnTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1180, 720);
            this.Controls.Add(this.pnlBoardContainer);
            this.Controls.Add(this.pnlSidebar);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro Pro - Đỉnh Cao Trí Tuệ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.cardPlayer1.ResumeLayout(false);
            this.cardPlayer2.ResumeLayout(false);
            this.cardTimer.ResumeLayout(false);
            this.pnlScoreBoard.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlBoardContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.Label lblGameModeBadge;
        private System.Windows.Forms.Panel cardPlayer1;
        private System.Windows.Forms.Label lblP1Symbol;
        private System.Windows.Forms.Label lblP1Name;
        private System.Windows.Forms.Label lblP1Score;
        private System.Windows.Forms.Panel cardPlayer2;
        private System.Windows.Forms.Label lblP2Symbol;
        private System.Windows.Forms.Label lblP2Name;
        private System.Windows.Forms.Label lblP2Score;
        private System.Windows.Forms.Panel cardTimer;
        private System.Windows.Forms.Label lblTurnStatus;
        private System.Windows.Forms.Label lblTimerCount;
        private System.Windows.Forms.ProgressBar prgTimer;
        private System.Windows.Forms.Panel pnlScoreBoard;
        private System.Windows.Forms.Label lblScoreTitle;
        private System.Windows.Forms.Label lblScoreDetail;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnHint;
        private System.Windows.Forms.Button btnSound;
        private System.Windows.Forms.Button btnBackMenu;
        private System.Windows.Forms.Panel pnlBoardContainer;
        private System.Windows.Forms.Panel pnlBoard;
        private System.Windows.Forms.Timer turnTimer;
    }
}

