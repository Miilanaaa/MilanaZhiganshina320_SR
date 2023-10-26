using Microsoft.Win32;
using MilanaZhiganshina320_SR.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
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
    /// Логика взаимодействия для PlusFotoPage.xaml
    /// </summary>
    public partial class PlusFotoPage : Page
    {
        public static Role role1;
        
        public PlusFotoPage(Role role)
        {
            InitializeComponent();
            role1 = role; 
        }

        private void AddImgBtn_Click(object sender, RoutedEventArgs e)
        {
            var r = DbConnection.PM_SREntities.Pet.Where(a => a.Id_role == role1.Id_role).First();

            Photo photo = new Photo();
            
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg"
            };
            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                var id_pet = 2;
                if (PolCB.Text == "Котенок Ра")
                {
                    id_pet = 1;
                }
                photo.Foto = File.ReadAllBytes(openFileDialog.FileName);
                photo.Opisanie_foto = LTB.Text;
                photo.Id_pet = id_pet;
                TestImg.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                DbConnection.PM_SREntities.Photo.Add(photo);
                DbConnection.PM_SREntities.SaveChanges();
            }
        }

        private void RecordBT_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GlavPage(role1));
        }
    }
}
