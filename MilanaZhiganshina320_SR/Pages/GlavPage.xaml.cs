using MilanaZhiganshina320_SR.DB;
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

namespace MilanaZhiganshina320_SR.Pages
{
    /// <summary>
    /// Логика взаимодействия для GlavPage.xaml
    /// </summary>
    public partial class GlavPage : Page
    {
        public static List<Role> roles { get; set; }
        public static List<Pet> pets { get; set; }

        public static List<Photo> photos { get; set; }

        public static Role role1;
        public GlavPage(Role role)
        {
            InitializeComponent();

            role1 = role;

            roles = new List<Role>(DbConnection.PM_SREntities.Role.ToList());
            pets = new List<Pet>(DbConnection.PM_SREntities.Pet.Where(i => i.Id_role == role1.Id_role));
            this.DataContext = this;
            EmployeeLV.ItemsSource = DbConnection.PM_SREntities.Pet.Where(i => i.Id_role == role1.Id_role).ToList();
        }


        private void ExitBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PlusFotoPage(role1));
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void SearchBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
