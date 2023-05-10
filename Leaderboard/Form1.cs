namespace Leaderboard
{
    public partial class KlikaciHraDominikVins : Form
    {
        internal Player player { get; set; }
        public KlikaciHraDominikVins()
        {
            this.Show();
            InitializeComponent();
            this.Name = "Klikací hra - Dominik Vinš";
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
                MessageBox.Show("Vyplò username(Alespoò 6 znakù)");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //exit
            Application.Exit();
        }
    }
}