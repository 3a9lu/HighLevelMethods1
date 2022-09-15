namespace Lab1_2
{
    public partial class Form1 : Form
    {
        public int i;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;  // Вывод формы по центру экрана    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
               i = Convert.ToInt32(textBox1.Text);

                if (radioButton1.Checked == true)
                {
                    textBox2.Text = Convert.ToString(i, 16);
                }

                else if (radioButton2.Checked == true)
                {
                    textBox2.Text = Convert.ToString(i, 2);
                }
            }
            catch
            {
                MessageBox.Show("Проблема с числом!", "Ошибка");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = Convert.ToString(i, 16);
            }
            catch
            {
                MessageBox.Show("Проблема с числом!", "Ошибка");
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = Convert.ToString(i, 2);
            }
            catch
            {
                MessageBox.Show("Проблема с числом!", "Ошибка");
            }
        }
    }
}