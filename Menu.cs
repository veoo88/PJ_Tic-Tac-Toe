using System;
using System.Windows.Forms;

namespace Tic_Tac_toe_1
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Mặc định chọn chế độ Đấu với Máy (PvE), độ khó Cao Thủ
            radioPvE.Checked = true;
            radioHard.Checked = true;
            radioFirstX.Checked = true;
            radioRuleVN.Checked = true;

            UpdateDifficultyState();
        }

        private void radioMode_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDifficultyState();
        }

        private void UpdateDifficultyState()
        {
            bool isPvE = radioPvE.Checked;
            grpDifficulty.Enabled = isPvE;

            if (isPvE)
            {
                radioFirstO.Text = "🔴 Quân O (Máy đi trước)";
            }
            else
            {
                radioFirstO.Text = "🔴 Quân O (Người 2 đi trước)";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            GameMode mode = radioPvE.Checked ? GameMode.PvE : GameMode.PvP;

            AIMode ai = AIMode.Hard;
            if (radioEasy.Checked) ai = AIMode.Easy;
            else if (radioMedium.Checked) ai = AIMode.Medium;

            GameRule rule = radioRuleVN.Checked ? GameRule.VietnameseCaro : GameRule.FreeGomoku;
            FirstTurn firstTurn = radioFirstX.Checked ? FirstTurn.Player1 : FirstTurn.Player2;

            Form1 gameForm = new Form1(mode, ai, rule, firstTurn, this);
            gameForm.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}