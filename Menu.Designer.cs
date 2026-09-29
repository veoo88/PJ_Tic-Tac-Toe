namespace Tic_Tac_toe_1
{
    partial class Menu
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.grpMode = new System.Windows.Forms.GroupBox();
            this.radioPvP = new System.Windows.Forms.RadioButton();
            this.radioPvE = new System.Windows.Forms.RadioButton();
            this.grpDifficulty = new System.Windows.Forms.GroupBox();
            this.radioEasy = new System.Windows.Forms.RadioButton();
            this.radioMedium = new System.Windows.Forms.RadioButton();
            this.radioHard = new System.Windows.Forms.RadioButton();
            this.grpFirstTurn = new System.Windows.Forms.GroupBox();
            this.radioFirstX = new System.Windows.Forms.RadioButton();
            this.radioFirstO = new System.Windows.Forms.RadioButton();
            this.grpRule = new System.Windows.Forms.GroupBox();
            this.radioRuleVN = new System.Windows.Forms.RadioButton();
            this.radioRuleFree = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.grpMode.SuspendLayout();
            this.grpDifficulty.SuspendLayout();
            this.grpFirstTurn.SuspendLayout();
            this.grpRule.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(45)))));
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblSubtitle);
            this.pnlMain.Controls.Add(this.grpMode);
            this.pnlMain.Controls.Add(this.grpDifficulty);
            this.pnlMain.Controls.Add(this.grpFirstTurn);
            this.pnlMain.Controls.Add(this.grpRule);
            this.pnlMain.Controls.Add(this.btnStart);
            this.pnlMain.Controls.Add(this.btnExit);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlMain.Size = new System.Drawing.Size(680, 560);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(620, 55);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CARO PRO";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(175)))), ((int)(((byte)(200)))));
            this.lblSubtitle.Location = new System.Drawing.Point(30, 75);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(620, 26);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Cờ Caro Đỉnh Cao Trí Tuệ • Đồ Họa Mượt Mà";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpMode
            // 
            this.grpMode.Controls.Add(this.radioPvP);
            this.grpMode.Controls.Add(this.radioPvE);
            this.grpMode.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.grpMode.Location = new System.Drawing.Point(50, 115);
            this.grpMode.Name = "grpMode";
            this.grpMode.Size = new System.Drawing.Size(275, 105);
            this.grpMode.TabIndex = 2;
            this.grpMode.TabStop = false;
            this.grpMode.Text = " 🎮 Chế Độ Chơi ";
            // 
            // radioPvP
            // 
            this.radioPvP.AutoSize = true;
            this.radioPvP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioPvP.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioPvP.ForeColor = System.Drawing.Color.White;
            this.radioPvP.Location = new System.Drawing.Point(20, 32);
            this.radioPvP.Name = "radioPvP";
            this.radioPvP.Size = new System.Drawing.Size(161, 27);
            this.radioPvP.TabIndex = 0;
            this.radioPvP.TabStop = true;
            this.radioPvP.Text = "👥 2 Người (PvP)";
            this.radioPvP.UseVisualStyleBackColor = true;
            this.radioPvP.CheckedChanged += new System.EventHandler(this.radioMode_CheckedChanged);
            // 
            // radioPvE
            // 
            this.radioPvE.AutoSize = true;
            this.radioPvE.Checked = true;
            this.radioPvE.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioPvE.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioPvE.ForeColor = System.Drawing.Color.White;
            this.radioPvE.Location = new System.Drawing.Point(20, 65);
            this.radioPvE.Name = "radioPvE";
            this.radioPvE.Size = new System.Drawing.Size(189, 27);
            this.radioPvE.TabIndex = 1;
            this.radioPvE.TabStop = true;
            this.radioPvE.Text = "🤖 Đấu Với Máy (PvE)";
            this.radioPvE.UseVisualStyleBackColor = true;
            this.radioPvE.CheckedChanged += new System.EventHandler(this.radioMode_CheckedChanged);
            // 
            // grpDifficulty
            // 
            this.grpDifficulty.Controls.Add(this.radioEasy);
            this.grpDifficulty.Controls.Add(this.radioMedium);
            this.grpDifficulty.Controls.Add(this.radioHard);
            this.grpDifficulty.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpDifficulty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.grpDifficulty.Location = new System.Drawing.Point(355, 115);
            this.grpDifficulty.Name = "grpDifficulty";
            this.grpDifficulty.Size = new System.Drawing.Size(275, 105);
            this.grpDifficulty.TabIndex = 3;
            this.grpDifficulty.TabStop = false;
            this.grpDifficulty.Text = " 🧠 Độ Khó AI ";
            // 
            // radioEasy
            // 
            this.radioEasy.AutoSize = true;
            this.radioEasy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioEasy.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.radioEasy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.radioEasy.Location = new System.Drawing.Point(18, 25);
            this.radioEasy.Name = "radioEasy";
            this.radioEasy.Size = new System.Drawing.Size(89, 25);
            this.radioEasy.TabIndex = 0;
            this.radioEasy.Text = "⭐ Dễ";
            this.radioEasy.UseVisualStyleBackColor = true;
            // 
            // radioMedium
            // 
            this.radioMedium.AutoSize = true;
            this.radioMedium.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioMedium.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.radioMedium.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.radioMedium.Location = new System.Drawing.Point(18, 50);
            this.radioMedium.Name = "radioMedium";
            this.radioMedium.Size = new System.Drawing.Size(147, 25);
            this.radioMedium.TabIndex = 1;
            this.radioMedium.Text = "⭐⭐ Trung Bình";
            this.radioMedium.UseVisualStyleBackColor = true;
            // 
            // radioHard
            // 
            this.radioHard.AutoSize = true;
            this.radioHard.Checked = true;
            this.radioHard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioHard.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.radioHard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.radioHard.Location = new System.Drawing.Point(18, 75);
            this.radioHard.Name = "radioHard";
            this.radioHard.Size = new System.Drawing.Size(155, 25);
            this.radioHard.TabIndex = 2;
            this.radioHard.TabStop = true;
            this.radioHard.Text = "⭐⭐⭐ Cao Thủ";
            this.radioHard.UseVisualStyleBackColor = true;
            // 
            // grpFirstTurn
            // 
            this.grpFirstTurn.Controls.Add(this.radioFirstX);
            this.grpFirstTurn.Controls.Add(this.radioFirstO);
            this.grpFirstTurn.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpFirstTurn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.grpFirstTurn.Location = new System.Drawing.Point(50, 235);
            this.grpFirstTurn.Name = "grpFirstTurn";
            this.grpFirstTurn.Size = new System.Drawing.Size(275, 105);
            this.grpFirstTurn.TabIndex = 4;
            this.grpFirstTurn.TabStop = false;
            this.grpFirstTurn.Text = " 🚩 Ai Đi Trước ";
            // 
            // radioFirstX
            // 
            this.radioFirstX.AutoSize = true;
            this.radioFirstX.Checked = true;
            this.radioFirstX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioFirstX.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioFirstX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(144)))), ((int)(((byte)(255)))));
            this.radioFirstX.Location = new System.Drawing.Point(20, 32);
            this.radioFirstX.Name = "radioFirstX";
            this.radioFirstX.Size = new System.Drawing.Size(193, 27);
            this.radioFirstX.TabIndex = 0;
            this.radioFirstX.TabStop = true;
            this.radioFirstX.Text = "🔵 Quân X (Đi trước)";
            this.radioFirstX.UseVisualStyleBackColor = true;
            // 
            // radioFirstO
            // 
            this.radioFirstO.AutoSize = true;
            this.radioFirstO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioFirstO.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.radioFirstO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.radioFirstO.Location = new System.Drawing.Point(20, 65);
            this.radioFirstO.Name = "radioFirstO";
            this.radioFirstO.Size = new System.Drawing.Size(217, 27);
            this.radioFirstO.TabIndex = 1;
            this.radioFirstO.Text = "🔴 Quân O (Máy đi trước)";
            this.radioFirstO.UseVisualStyleBackColor = true;
            // 
            // grpRule
            // 
            this.grpRule.Controls.Add(this.radioRuleVN);
            this.grpRule.Controls.Add(this.radioRuleFree);
            this.grpRule.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.grpRule.Location = new System.Drawing.Point(355, 235);
            this.grpRule.Name = "grpRule";
            this.grpRule.Size = new System.Drawing.Size(275, 105);
            this.grpRule.TabIndex = 5;
            this.grpRule.TabStop = false;
            this.grpRule.Text = " 📜 Luật Chơi ";
            // 
            // radioRuleVN
            // 
            this.radioRuleVN.AutoSize = true;
            this.radioRuleVN.Checked = true;
            this.radioRuleVN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioRuleVN.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.radioRuleVN.ForeColor = System.Drawing.Color.White;
            this.radioRuleVN.Location = new System.Drawing.Point(18, 32);
            this.radioRuleVN.Name = "radioRuleVN";
            this.radioRuleVN.Size = new System.Drawing.Size(232, 25);
            this.radioRuleVN.TabIndex = 0;
            this.radioRuleVN.TabStop = true;
            this.radioRuleVN.Text = "⚖️ Luật VN (Chặn 2 đầu ko)";
            this.radioRuleVN.UseVisualStyleBackColor = true;
            // 
            // radioRuleFree
            // 
            this.radioRuleFree.AutoSize = true;
            this.radioRuleFree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioRuleFree.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.radioRuleFree.ForeColor = System.Drawing.Color.White;
            this.radioRuleFree.Location = new System.Drawing.Point(18, 65);
            this.radioRuleFree.Name = "radioRuleFree";
            this.radioRuleFree.Size = new System.Drawing.Size(227, 25);
            this.radioRuleFree.TabIndex = 1;
            this.radioRuleFree.Text = "⚡ Luật Tự Do (Gomoku 5)";
            this.radioRuleFree.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(150, 375);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(380, 52);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "▶ BẮT ĐẦU TRẬN ĐẤU";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(65)))), ((int)(((byte)(80)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(210, 440);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(260, 40);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "❌ Thoát Game";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 560);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caro Pro - Menu Chính";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.pnlMain.ResumeLayout(false);
            this.grpMode.ResumeLayout(false);
            this.grpMode.PerformLayout();
            this.grpDifficulty.ResumeLayout(false);
            this.grpDifficulty.PerformLayout();
            this.grpFirstTurn.ResumeLayout(false);
            this.grpFirstTurn.PerformLayout();
            this.grpRule.ResumeLayout(false);
            this.grpRule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.GroupBox grpMode;
        private System.Windows.Forms.RadioButton radioPvP;
        private System.Windows.Forms.RadioButton radioPvE;
        private System.Windows.Forms.GroupBox grpDifficulty;
        private System.Windows.Forms.RadioButton radioEasy;
        private System.Windows.Forms.RadioButton radioMedium;
        private System.Windows.Forms.RadioButton radioHard;
        private System.Windows.Forms.GroupBox grpFirstTurn;
        private System.Windows.Forms.RadioButton radioFirstX;
        private System.Windows.Forms.RadioButton radioFirstO;
        private System.Windows.Forms.GroupBox grpRule;
        private System.Windows.Forms.RadioButton radioRuleVN;
        private System.Windows.Forms.RadioButton radioRuleFree;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnExit;
    }
}