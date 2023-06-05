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
using System.Collections.ObjectModel;

namespace DemoD
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public static DemoEntities connection = new DemoEntities();

        public static ObservableCollection<Product> Products { get; set; }

        private Product set_pr = null;

        public Admin()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>(connection.Product.ToList());
            DataContext = this;
            LoadMan();
        }


        private void LoadMan()
        {
            var man = connection.Manufacturer.ToList();
            foreach (var m in man)
            {
                ManP_TB.Items.Add(m.Name);

            }
        }

        private void ADDP_BTN_Click(object sender, RoutedEventArgs e)
        {
            set_pr = new Product();
            set_pr.Name = NameP_TB.Text;
            set_pr.Description = DesP_TB.Text;
            set_pr.Cost = Convert.ToDecimal(CostP_TB.Text);
            set_pr.CountDiscount = DisP_TB.Text;
            set_pr.Manufacturer = ManP_TB.Text;
            connection.Product.Add(set_pr);
            connection.SaveChanges();
            MessageBox.Show("Данные успешно добавлены");
            Products.Add(set_pr);
            ListP.SelectedItem = set_pr;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            set_pr = ListP.SelectedItem as Product;
            if (ListP.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите товар!");
                return;
            }

            else
            {
                if (set_pr != null)
                {

                    connection.Product.Remove(set_pr);
                    Products.Remove(set_pr);
                    connection.SaveChanges();
                    MessageBox.Show("Изменения сохранены");



                }
            }
        }

        private void Ord_Move_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Move.orderpage);
        }
    }
}
