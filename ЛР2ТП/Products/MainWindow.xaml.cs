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
using System.IO;
using Microsoft.Win32;
using ЛР2Console.Model;
using ЛР2Console.Kontroler;

namespace Products
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[] p;
        int[] s;
        public List<interfaceprodukte> choise = new List<interfaceprodukte>();
        public List<int> bestchoise = new List<int>();

        public void ChooseFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog opfidi = new OpenFileDialog();
                opfidi.ShowDialog();
                List<string> list = new List<string>();
                string productString;
                if (opfidi.FileName != "")
                {
                    productString = File.ReadAllText(opfidi.FileName);
                    list.AddRange(productString.Split('\n'));
                }
                p = new int[list.Count];
                s = new int[list.Count];
                choise.Clear();
                ProduktList.ItemsSource = null;
                for (int i = 0; i < list.Count; i++)
                {
                    string[] odd = new string[4];
                    odd = list[i].Split(':');
                    choise.Add(item: new classprodukte() { kategorie = odd[0], name = odd[1], preis = Convert.ToInt32(odd[2]), nutzbarkeit = Convert.ToInt32(odd[3]) });
                    s[i] = Convert.ToInt32(odd[2]);
                    p[i] = Convert.ToInt32(odd[3]);
                }
                ProduktList.ItemsSource = choise;
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите другой файл");
            }
        }

        public void Itogo_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(Money.Text) <= 0)
            {
                MessageBox.Show("Введите корректно сумму денег");
            }
            else
            try
            {
                int i = 0;
                ItogoList.Items.Clear();
                int money = Math.Abs(Convert.ToInt32(Money.Text));
                bestchoise = knapsack_problem.knapsack(s, p, money);
                for (i = 0; i < (bestchoise.Count - 1); i++)
                    ItogoList.Items.Add(choise[bestchoise[i]].name);
                ItogoList.Items.Add("Итоговая полезность: " + bestchoise[i]);
            }
            catch (Exception)
            { 
                MessageBox.Show("Введите корректно сумму денег");
            }
        }

        private void ItogoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
