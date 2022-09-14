namespace Lab1
{
    public partial class Form1 : Form
    {
        public const int n = 5; // ������ ���������� �������
        public int[,] matrix = new int[n, n];
        public int numberLeft;
        public int numberRight;
        
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;  // ����� ����� �� ������ ������    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // �������� ����� 5 �� 5 � dataGridView
            dataGridView1.ColumnCount = n;
            dataGridView1.RowCount = n;
            label4.Text = "";
            label5.Text = "";
        }

        // ��������� ������� � dataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "") // �������� �� ������������� ������
                {
                    MessageBox.Show("������� c ������ � �� ������ ����� ����� ������������� �������!", "������");
                    return;
                }

                numberRight = Convert.ToInt32(textBox1.Text);
                numberLeft = Convert.ToInt32(textBox2.Text);

                if (numberRight < numberLeft) // �������� �� ���� ������
                {
                    MessageBox.Show("������ ������� �� ����� ���� ������ �����!", "������");
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
                        if (dataGridView1.Rows[i].Cells[j].Value == null) // ��������, ���� �� ����� � dataGridView
                        {
                            MessageBox.Show("��������� ��� ����� � �������!", "������");
                            return;
                        }

                        if (!int.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out matrix[i, j])) // ��������, ���� ��
                        {
                            MessageBox.Show("���-�� ���� ������� ����� � �������!", "������");
                            return;
                        }

                        //if (Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) < 0.000000000000001)
                        //{
                        //    MessageBox.Show("���-�� ���� 0 ��� ������������� �����.", "������");
                        //    return;
                        //}
                    }
                }
                //  ���� ������������� ���������� ������� ������� 5.
                //  ������� ������������ ������� ����� ���������, �������
                //  ���� ������� ���������, � ������������ ������� �����
                //  ���������, ������� ���� ������� ���������, ��������� �� �������.
                long maxDown = -999999999999999999;
                long maxUp = -999999999999999999;
                for (int i = 0; i < n; ++i)
                {
                    for (int j = 0; j < n; ++j)
                    {
                        if (j < i && matrix[i, j] > maxDown) // ������ ���������
                        {
                            maxDown = matrix[i, j];
                            matrix[i, j] = 1;
                        }
                        if (j > i && matrix[i, j] > maxUp) // ������� ���������
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