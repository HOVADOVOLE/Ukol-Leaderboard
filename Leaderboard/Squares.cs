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
        internal Panel p { get; set; }
        internal int zivotnost;
        public Squares(Game game, Player player) {
            this.game = game;
            this.player = player;
            CreateSquare(game);
            
            this.zivotnost = 10000;
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
            game.label_scoreCount.Text = "" + ++player.score;
            game.panel_gamePanel.Controls.Remove(sender as Panel);
            foreach (var item in game.list)
            {
                if (item.p == sender as Panel)
                {
                    game.list.Remove(item);
                    break;
                }
            }

            if(game.time > 1000)
            {
                game.time -= 5;
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
