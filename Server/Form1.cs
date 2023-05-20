using SuperSimpleTcp;
using System.Text;

namespace Server
{
    public partial class Form1 : Form
    {
        SimpleTcpServer server;
        public Form1()
        {
            InitializeComponent();

            server = new SimpleTcpServer("127.0.0.1:80");
            server.Start();

            server.Events.DataReceived += Events_DataReceived;
        }

        private void Events_DataReceived(object? sender, DataReceivedEventArgs e)
        {
            MessageBox.Show(Encoding.UTF8.GetString(e.Data));
        }
    }
}