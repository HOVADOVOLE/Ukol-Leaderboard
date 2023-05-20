using SuperSimpleTcp;
using System;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server;
        SortedList<int, string> leaderboard;

        public Form1()
        {
            InitializeComponent();

            leaderboard = new SortedList<int, string>(Comparer<int>.Create((x, y) => y.CompareTo(x)));

            server = new SimpleTcpServer("127.0.0.1:80");
            server.Start();

            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            string receivedData = Encoding.UTF8.GetString(e.Data);
            string[] parts = receivedData.Split(';');

            if (parts.Length == 2)
            {
                string username = parts[0];
                int score;
                if (int.TryParse(parts[1], out score))
                {
                    leaderboard[score] = username;

                    Invoke((MethodInvoker)delegate//Bez toho to nefunguje nevím proè, poradilo mi to chat g.p.t
                    {
                        listBox1.Items.Clear();
                        foreach (var item in leaderboard)
                        {
                            listBox1.Items.Add($"{item.Value}: {item.Key}");
                        }
                    });
                }
            }
        }
    }
}
