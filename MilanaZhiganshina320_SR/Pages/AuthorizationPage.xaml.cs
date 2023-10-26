using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using MilanaZhiganshina320_SR.DB;
using System.Windows.Shapes;
using System.Diagnostics.Eventing.Reader;

namespace MilanaZhiganshina320_SR.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Role> roles { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();

            roles = new List<Role>(DbConnection.PM_SREntities.Role.ToList());
            Role currentUser = roles.FirstOrDefault(i => i.Login == login && i.Password == password);
            if (currentUser != null)
            {
                    NavigationService.Navigate(new GlavPage(currentUser));
            }    
                
            else
                MessageBox.Show("Неверные данные");

        }
    }
}
