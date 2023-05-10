using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Leaderboard
{
    internal class Squares
    {
        Random rnd = new Random();
        Game game;
        Player player;
        bool doubleClick;
        internal Panel p { get; set; }
        internal int zivotnost;
        public Squares(Game game, Player player) {
            this.game = game;
            this.player = player;
            CreateSquare(game);
            this.doubleClick = Chance();
            this.zivotnost = 10000;
        }
        bool Chance()
        {
            return rnd.Next(2) == 1;
        }
        void CreateSquare(Game game) { 
            p = new Panel();
            p.Size = GenerateSize();
            p.Location = GeneratePoint(game, p);
            p.BackColor = Color.Red;
            game.panel_gamePanel.Controls.Add(p);
            p.Click += P_Click;
        }

        private void P_Click(object? sender, EventArgs e)
        {
            for (int i = game.list.Count - 1; i >= 0; i--)
            {
                Squares item = game.list[i];
                if (item.p is Panel panel && panel == sender)
                {
                    if (item.doubleClick)
                    {
                        item.doubleClick = false;
                    }
                    else
                    {
                        if (Chance())
                        {
                            player.score += 2;
                            game.label_scoreCount.Text = player.score.ToString();
                        }
                        else
                        {
                            game.label_scoreCount.Text = (++player.score).ToString();
                        }
                        
                        game.list.RemoveAt(i);
                        game.panel_gamePanel.Controls.Remove(panel);

                        if (game.time > 1000)
                        {
                            game.time -= 5;
                        }
                    }
                    break;
                }
            }

        }

        Point GeneratePoint(Game game, Panel p) { 
            int x = rnd.Next(0, game.panel_gamePanel.Width - p.Width);
            int y = rnd.Next(0, game.panel_gamePanel.Height - p.Height);
            return new Point(x, y);
        }
        Size GenerateSize() {
            int size = rnd.Next(20, 50);
            int width = size;
            int height = size;
            return new Size(width, height);
        }
    }
}
