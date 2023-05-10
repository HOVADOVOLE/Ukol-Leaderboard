using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leaderboard
{
    public partial class Game : Form
    {
        Player player;
        public int time = 2000;
        internal List<Squares>? list { get; set; } = new List<Squares>();
        public Game(Form1 form)
        {
            InitializeComponent();
            timer1.Interval = time;
            player = form.player;
            lblUsername.Text = $"Username: {player.jmeno}";
        }

        private void Game_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            NactiZivoty();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GenerateSquare();
            OdebiraniZivotnosti();
            UpdateSquares();
        }
        void GenerateSquare() {
            list.Add(new Squares(this, player));
        }
        void UpdateSquares() {
            foreach (Squares item in list.ToList())
            {
                if (item.zivotnost >= 5000)
                {
                    item.p.BackColor = Color.Green;
                }
                else if (item.zivotnost >= 3000)
                {
                    item.p.BackColor = Color.Yellow;
                }
                else if (item.zivotnost > 0)
                {
                    item.p.BackColor = Color.Red;
                }
                else
                {
                    panel_gamePanel.Controls.Remove(item.p);
                    list.Remove(item);
                    OdebraniZivotu();
                }
            }
        }

        void OdebraniZivotu()
        {
            player.lives--;
            KontrolaZivotu();
            NactiZivoty();
        }
        void NactiZivoty()
        {
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < player.lives; i++)
            {
                PictureBox p = new PictureBox();
                p.Load("./images/favicon-16x16.png");
                p.Height = flowLayoutPanel1.Height;
                p.Width = 20;
                p.SizeMode = PictureBoxSizeMode.StretchImage;
                this.flowLayoutPanel1.Controls.Add(p);
            }
        }

        void OdebiraniZivotnosti()
        {
            foreach (var item in list.ToList())
            {
                item.zivotnost -= timer1.Interval;
            }
        }

        void KontrolaZivotu() 
        {
            if (player.lives == 0)
            {
                GameOverForm gm = new GameOverForm();
                this.Hide();
                gm.Show();
            }
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}