using System;
using System.Collections.Generic;
using SimpleTCP;

namespace Leaderboard
{
    public partial class Zebricek : Form
    {
        SimpleTcpClient client;

        public Zebricek()
        {
            InitializeComponent();


            client = new SimpleTcpClient();
            client.StringEncoder = System.Text.Encoding.UTF8;
            client.DataReceived += (sender, args) =>
            {
                string response = args.MessageString;
                MessageBox.Show(response);
                UpdateLeaderboard(response);
            };

            client.Connect("127.0.0.1", 80);
            client.WriteLine("get top ten");
        }
        void UpdateLeaderboard(string data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(UpdateLeaderboard), data);
            }
            else
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(data.Split('\n'));
            }
        }
    }
}
