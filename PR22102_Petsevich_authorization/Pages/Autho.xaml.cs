using PR22102_Petsevich_authorization.Models;
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

namespace PR22102_Petsevich_authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        public Autho()
        {
            InitializeComponent();
            
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Password.Trim();
            AuthorizationEntities db = new AuthorizationEntities();

            var user = db.Employees.FirstOrDefault(x => x.Login == login && x.Password == password);

            if (user != null)
            {
                var Role = db.Roles.Find(user.RoleID);
                if (Role != null)
                {
                    Page newPage = null;
                    switch (Role.RoleID)
                    {
                        case 1:
                            MessageBox.Show("Вы вошли с ролью Администратор");
                            break;
                        case 2:
                            MessageBox.Show("Вы вошли с ролью Менеджер");
                            break;
                        case 3:
                            MessageBox.Show("Вы вошли с ролью Программист");
                            break;
                        default:
                            MessageBox.Show("Роль не определена.");
                            return;
                    }
                    if (newPage != null)
                    {
                        MainFrame.Navigate(newPage);
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверно введён логин или пароль");
            }
        }

    }
}
