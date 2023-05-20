using System;
using System.Collections.Generic;
using SuperSimpleTcp;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Leaderboard
{
    public partial class Game : Form
    {
        static SimpleTcpClient client;
        Player player;

        public int time = 2000;
        internal List<Squares> list { get; set; } = new List<Squares>();

        public Game(Form1 form)
        {
            InitializeComponent();

            client = new SimpleTcpClient("127.0.0.1:80");
            client.Connect();

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

        void GenerateSquare()
        {
            list.Add(new Squares(this, player));
        }

        void UpdateSquares()
        {
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
                string data = $"{player.jmeno};{player.score}";
                client.Send(data);

                GameOverForm gm = new GameOverForm(player.score, player.jmeno);
                this.Hide();
                gm.Show();
            }
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect();
        }
    }
}
