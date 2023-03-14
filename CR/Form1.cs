using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {


            

            // Маска телефона
            bool telef = Regex.IsMatch(maskedTextBox2.Text, @"^7\d{3}-\d{3}-\d{4}$");


            // Маска почты 
            bool gmail = Regex.IsMatch(maskedTextBox1.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");


            // Смысловые значения маска
            bool smisl1 = Regex.IsMatch(textBox1.Text, @"[а-яА-Я]");
            bool smisl2 = Regex.IsMatch(textBox2.Text, @"[а-яА-Я]");
            bool smisl3 = Regex.IsMatch(textBox3.Text, @"[а-яА-Я]");


            // Фамилия, Имя, Отчество, каптча, наименование учреждения
            if (String.IsNullOrEmpty(textBox1.Text) || String.IsNullOrEmpty(textBox2.Text) || String.IsNullOrEmpty(textBox3.Text) || String.IsNullOrEmpty(textBox7.Text) || String.IsNullOrEmpty(textBox9.Text) || String.IsNullOrEmpty(maskedTextBox1.Text) || String.IsNullOrEmpty(maskedTextBox2.Text))
            {
                MessageBox.Show("Ошибка пустого значения! Заполните поля!", "Ошибка пустого значения");
            }
            // Возраст
            if (numericUpDown2.Value <= 14 || numericUpDown2.Value >= 21 )
            {
                MessageBox.Show("Участниками олимпиады могут быть студенты колледжей в\r\nвозрасте от 15 от 20 лет включительно!", "Ошибка возраста");
            }
            // Курс
            if (numericUpDown1.Value >= 5)
            {
                MessageBox.Show("Участниками олимпиады могут быть студенты на курсе 1 - 4!", "Ошибка курса");
            }
            // Почта
            if (!gmail)
            {
                MessageBox.Show("Не правильно указана почта! Исправь!", "Ошибка почты");
            }
            // Номер
            if (!telef)
            {
                MessageBox.Show("Введите правильно номер!", "Ошибка номера");
            }
            
            // Смысловые значения
            if (!smisl1  || !smisl2 || !smisl3)
            {
                MessageBox.Show("Заполните правильно строки!", "Ошибка не правильного значения");
            }

            // Каптча
            if (textBox9.Text != "9")
            {
                MessageBox.Show("Попробуйте ввести заново CAPTCHA!", "Ошибка ввода \"CAPTCHA\"");
            }

            // Субъект
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Вы не указали свой субъект РФ!", "Ошибка не указанного субъекта");
            }

            // Специальность
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("Вы не выбрали специальность!", "Ошибка не указанной специальности");
            }

            else
            {
                students st = new students()
                {
                    Фамилия = textBox1.Text,
                    Имя = textBox2.Text,
                    Отчество = textBox3.Text,
                    Почта = maskedTextBox1.Text,
                    Телефон = maskedTextBox2.Text,
                    Возраст = Convert.ToInt32(numericUpDown2.Value),
                    Субъект = comboBox1.SelectedItem.ToString(),
                    Учреждение = textBox7.Text,
                    Специальность = (radioButton1.Checked) ? radioButton1.Text : radioButton2.Text,
                    Курс = Convert.ToInt32(numericUpDown1.Value)
                };

                Student.inf.Add(st);
                Form2 f = new Form2();
                f.Show();
            }
        }

    
        private void открытьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image;
            OpenFileDialog openImg = new OpenFileDialog();
            if (openImg.ShowDialog() == DialogResult.OK)
            {
                    image = new Bitmap(openImg.FileName);
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
             }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти ?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else { }
        }
    }
}
