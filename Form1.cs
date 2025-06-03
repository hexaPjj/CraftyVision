using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace CraftyVision
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProgressT.Start();
        }

        private void ProgressT_Tick(object sender, EventArgs e)
        {
            if (ProgressBar.Value < 100)
            {
                ProgressBar.Value += rand.Next(1, 4); // 1 ile 3 arasýnda artýþ
                if (ProgressBar.Value > 100)
                    ProgressBar.Value = 100;
            }
            else
            {
                ProgressT.Stop();
                this.Hide();
                MainMenu mainmenu = new MainMenu();
                mainmenu.Show();
            }
        }
    }
}
