namespace VLCTest
{
    public partial class Form1 : Form
    {
        VlcClient.VLCPlayer player;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSearchVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "MP4 files (*.mp4)|*.mp4";
            openFileDialog1.FilterIndex = 0;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            player = new VlcClient.VLCPlayer(openFileDialog1.FileName);
            tabPage1.Controls.Clear();
            tabPage1.Controls.Add(player);
            tabPage1.Controls[0].Width = tabPage1.Width;
            tabPage1.Controls[0].Height = tabPage1.Height;
        }
    }
}