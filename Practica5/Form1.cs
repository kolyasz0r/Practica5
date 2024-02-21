namespace Practica5
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<Keys, int> keyPressCount = new Dictionary<Keys, int>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void PressKey(Keys key)
        {
            if (keyPressCount.ContainsKey(key))
            {
                keyPressCount[key]++;
            }
            else
            {
                keyPressCount[key] = 1;
            }

            UpdateResultsLabel();
            SendKeys.SendWait("{" + key + "}");
        }
        private void UpdateResultsLabel()
        {

            label.Text = GetKeyCountsString();
        }

        private void ReleaseKey(Keys key)
        {
            SendKeys.SendWait("^{" + key + "}");
        }

        private void StopProgram()
        {
            Close();
        }
        private void PrintKeyCounts()
        {
            MessageBox.Show("Статистика нажатий:\n" + GetKeyCountsString());
        }

        private string GetKeyCountsString()
        {
            string countsString = string.Empty;
            foreach (var kvp in keyPressCount)
            {
                countsString += $"Количество нажатий: {kvp.Value} раз\n";
            }
            return countsString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PressKey(Keys.A);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReleaseKey(Keys.A);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StopProgram();
            PrintKeyCounts();

        }
    }
}

