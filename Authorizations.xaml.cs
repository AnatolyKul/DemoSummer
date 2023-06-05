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

namespace DemoD
{
    /// <summary>
    /// Логика взаимодействия для Authorizations.xaml
    /// </summary>
    public partial class Authorizations : Page
    {
        public static DemoEntities connection = new DemoEntities();


        public Authorizations()
        {
            InitializeComponent();
        }

        private void LoginBTN_Click(object sender, RoutedEventArgs e)
        {
            string log = Login_TB.Text;
            string passw = Passw_TB.Password;

            if(log.Length == 0 && passw.Length == 0)
            {
                MessageBox.Show("Все поля пустые");
                return;
            }

            if (log.Length == 0)
            {
                MessageBox.Show("Логин пустой");
                return;
            }

            if (passw.Length == 0)
            {
                MessageBox.Show("Пароль пустой");
                return;
            }

            var roleUs = connection.User.Where(us => us.Login == log && us.Password == passw).FirstOrDefault();
            if (roleUs != null)
            {
                switch (roleUs.Role)
                {
                    case 1:
                        MessageBox.Show("Добро пожаловать, администратор");
                        NavigationService.Navigate(Move.admin);
                        break;

                        case 2:
                        MessageBox.Show("Добро пожаловать, менеджер");
                        NavigationService.Navigate(Move.manager);
                        break;

                        case 3:
                        MessageBox.Show("Добро пожаловать, клиент");
                        NavigationService.Navigate(Move.client);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Введены некорректные данные");
                return;
            }
        }

        private void GuestBTN_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Добро пожаловать, гость");
            NavigationService.Navigate(Move.orderpage);
            return;
        }
    }
}
