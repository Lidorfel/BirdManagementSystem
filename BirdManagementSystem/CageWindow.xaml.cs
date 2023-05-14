using System;
using System.Collections;
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
using System.Windows.Shapes;

namespace BirdManagementSystem
{
    /// <summary>
    /// Interaction logic for CageWindow.xaml
    /// </summary>
    public partial class CageWindow : Window
    {
        private Cage self;
        public CageWindow()
        {
            InitializeComponent();
        }
        public CageWindow(Cage c)
        {
            InitializeComponent();
            if (c != null)
            {
                self = c;
                this.CageSN.Text = c.SerialNumber;
                this.CageMaterial.Text = c.CageMaterial;
                string dimension = "W:" + c.Width.ToString() + ", L:" + c.Length.ToString() + ", H:" + c.Height.ToString();
                this.CageDimension.Text = dimension;
            }
        }
        private void ShowBirdsBtn_Click(object sender, RoutedEventArgs e)
        {
            BirdManagementDBEntities db = new BirdManagementDBEntities();
            var docs = from b in db.Birds
                       where b.Cage == self.SerialNumber
                       select b;
            List<Bird> birds = docs.ToList();
            birds.Sort((x, y) => x.SerialNumber.CompareTo(y.SerialNumber));
            BirdsInCageGrid.ItemsSource = birds;
            BirdsInCageGrid.Visibility = Visibility.Visible;
            CagePicture.Visibility = Visibility.Collapsed;
        }

        private void backToHomePage_Click(object sender, RoutedEventArgs e)
        {
            HomePage HP = new HomePage();
            HP.Show();
            this.Close();
        }

        private void BirdsInCageGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.BirdsInCageGrid.SelectedIndex >= 0 && this.BirdsInCageGrid.SelectedItems.Count >= 0)
            {
                if (this.BirdsInCageGrid.SelectedItems[0].GetType() == typeof(Bird))
                {
                    Bird b = (Bird)this.BirdsInCageGrid.SelectedItems[0];
                    BirdWindow page = new BirdWindow(b);

                    // Set the content of a Frame control on the parent window or page
                    page.Show();
                    this.Close();
                    /*mainPage.mainFrame.Content = page;*/
                }
            }
        }

    }
}
