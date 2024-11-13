using Timer = System.Windows.Forms.Timer;
namespace Jequiti
{
    internal static class Program
    {

        [STAThread]
        private static async Task Main()
        {
            string imagePath;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;

            string fileName = "jequiti.jpg";

            imagePath = Path.Combine(currentDirectory, fileName);

            while (true)
            {
                ShowImageFullscreen(imagePath);

                await Task.Delay(TimeSpan.FromMinutes(10)); // Exibe a cada 10min
            }
        }

        static void ShowImageFullscreen(string imagePath)
        {
            Form imageForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                BackColor = Color.Black,
                TopMost = true
            };

            PictureBox pictureBox = new PictureBox
            {
                Image = Image.FromFile(imagePath),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };
            imageForm.Controls.Add(pictureBox);

            Timer closeTimer = new Timer { Interval = 500 }; // Exibe por 0,5s
            closeTimer.Tick += (sender, e) =>
            {
                closeTimer.Stop();
                imageForm.Close();
            };

            closeTimer.Start();

            imageForm.ShowDialog();
        }
    }

}