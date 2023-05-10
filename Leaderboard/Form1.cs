namespace Leaderboard
{
    public partial class KlikaciHraDominikVins : Form
    {
        internal Player player { get; set; }
        public KlikaciHraDominikVins()
        {
            this.Show();
            InitializeComponent();
            this.Name = "Klikac� hra - Dominik Vin�";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //play
            if (textBox1.Text.Length >= 6 && textBox1.Text.Length < 16)
            {
                player = new Player(textBox1.Text);
                this.Hide();
                Game game = new Game(this);
                game.Show();
            }
            else {
                MessageBox.Show("Vypl� username(Alespo� 6 znak�)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }
    }
}