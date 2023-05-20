namespace Leaderboard
{
    public partial class GameOverForm : Form
    {
        public GameOverForm(int score, string username)
        {
            InitializeComponent();

            lblUsername.Text = $"Username: {username}";
            lblScore.Text = $"Score: {score}";
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Form1 m = new();
            m.Show();
            this.Hide();
        }
    }
}
