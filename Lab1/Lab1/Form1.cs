namespace Lab1
{
    public partial class Form1 : Form
    {
        public const int n = 5; // Размер квадратной матрицы
        public int[,] matrix = new int[n, n];
        public int numberLeft;
        public int numberRight;
        
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;  // Вывод формы по центру экрана    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создание ячеек 5 на 5 в dataGridView
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
            label4.Text = "";
            label5.Text = "";
        }

        // Генерация матрицы в dataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "") // Проверка на заполненность границ
                {
                    MessageBox.Show("Введите c какого и до какого числа будет сгенерирована матрица!", "Ошибка");
                    return;
                }

                numberRight = Convert.ToInt32(textBox1.Text);
                numberLeft = Convert.ToInt32(textBox2.Text);

                if (numberRight < numberLeft) // Проверка на ввод границ
                {
                    MessageBox.Show("Правая граница не может быть больше левой!", "Ошибка");
                    return;
                }

                Random random = new Random();
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        matrix[i, j] = random.Next(numberLeft, numberRight + 1);
                        dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value == null) // Проверка, есть ли числа в dataGridView
                        {
                            MessageBox.Show("Заполните все числа в матрице!", "Ошибка");
                            return;
                        }

                        if (!int.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out matrix[i, j])) // Проверка, есть ли
                        {
                            MessageBox.Show("Где-то есть дробные числа в матрице!", "Ошибка");
                            return;
                        }

                        //if (Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) < 0.000000000000001)
                        //{
                        //    MessageBox.Show("Где-то есть 0 или отрицательное число.", "Ошибка");
                        //    return;
                        //}
                    }
                }
                //  Дана целочисленная квадратная матрица порядка 5.
                //  Найдите максимальный элемент среди элементов, лежащих
                //  ниже главной диагонали, и максимальный элемент среди
                //  элементов, лежащих выше главной диагонали, поменяйте их местами.
                long maxDown = -999999999999999999;
                long maxUp = -999999999999999999;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (j < i && matrix[i, j] > maxDown) // Нижняя диагональ
                        {
                            maxDown = matrix[i, j];
                            matrix[i, j] = 1;
                        }
                        if (j > i && matrix[i, j] > maxUp) // Верхняя диагональ
                        {
                            maxUp = matrix[i, j];
                        }
                        long temp;
                        temp = maxDown;
                        maxDown = maxUp;
                        maxUp = temp;
                        dataGridView1.Rows[i].Cells[j].Value = matrix[i, j];
                    }

                }

                label4.Text = Convert.ToString(maxDown);
                label5.Text = Convert.ToString(maxUp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}