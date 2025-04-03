using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(number1.Text, out int task1) ||
                !int.TryParse(number2.Text, out int task2) ||
                !int.TryParse(number3.Text, out int task3) ||
                !int.TryParse(number4.Text, out int task4))
            {
                result.Text = "Введены некорректные значения";
                return;
            }

            const int MAX_POINTS_TASK1 = 10;
            const int MAX_POINTS_TASK2 = 50;
            const int MAX_POINTS_TASK3 = 30;
            const int MAX_POINTS_TASK4 = 10;

            if (task1 > MAX_POINTS_TASK1 || task2 > MAX_POINTS_TASK2 || 
                task3 > MAX_POINTS_TASK3 || task4 > MAX_POINTS_TASK4 || 
                task1 < 0 || task2 < 0 || task3 < 0 || task4 < 0)
            {
                result.Text = "Введены некорректные значения";
                return;
            }

            int totalPoints = task1 + task2 + task3 + task4;

            string grade;
            if (totalPoints >= 70) grade = "5 (отлично)";
            else if (totalPoints >= 40) grade = "4 (хорошо)";
            else if (totalPoints >= 20) grade = "3 (удовлетворительно)";
            else grade = "2 (неудовлетворительно)";

            result.Text = $"Оценка: {grade}\nНабрано баллов: {totalPoints} из 100";
        }
    }
}
