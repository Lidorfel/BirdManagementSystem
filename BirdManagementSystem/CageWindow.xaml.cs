using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
            UpdateCageBtn.Visibility = Visibility.Visible;
            UpdateFieldsGrid.Visibility=Visibility.Collapsed;
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
        private bool checkCageSerialNumberValidation(string sn)
        {
            return sn.All(c => Char.IsLetter(c) || Char.IsNumber(c)) && sn.Any(Char.IsLetter) && sn.Any(Char.IsNumber);
        }
        private bool cageExists(string cageSerial)
        {
            BirdManagementDBEntities db = new BirdManagementDBEntities();
            var cages = from c in db.Cages
                        where c.SerialNumber == cageSerial
                        select c;
            List<Cage> check = cages.ToList();
            return check.Count > 0;

        }
        private void UpdateCageBtn_Click(object sender, RoutedEventArgs e)
        {
            BirdsInCageGrid.Visibility = Visibility.Collapsed;
            NewCageSerialNumber.Text=self.SerialNumber.ToString();
            NewCageWidth.Text = self.Width.ToString();
            NewCageHeight.Text = self.Height.ToString();
            NewCageLength.Text = self.Length.ToString();
            UpdateCageBtn.Visibility = Visibility.Collapsed;
            UpdateFieldsGrid.Visibility = Visibility.Visible;
            NewCageSerialNumber.Text= self.SerialNumber.ToString();
            NewCageHeight.Text= self.Height.ToString();
            NewCageLength.Text= self.Length.ToString();
            NewCageWidth.Text= self.Width.ToString();
            if (self.CageMaterial == "Iron")
            {
                NewCageMaterialSelect.SelectedIndex = 0;
            }
            else if(self.CageMaterial == "Wood")
            {
                NewCageMaterialSelect.SelectedIndex = 1;

            }
            else
            {
                NewCageMaterialSelect.SelectedIndex = 2;

            }
        }
        private void UpdateDetails_Click(object sender, RoutedEventArgs e)
        {
            string[] matChoiceArr = { "Iron", "Wood", "Plastic" };
            NewCageMaterialSelectError.Text = "";
            NewCageDimensionError.Text = "";
            NewCageSerialNumberError.Text = "";
            string newSerialNumber = NewCageSerialNumber.Text;
            string cageWidthText = NewCageWidth.Text;
            string cageLengthText = NewCageLength.Text;
            string cageHeightText = NewCageHeight.Text;
            double newCageWidth, newCageHeight, newCageLength;
            bool flag = true;
            if (!checkCageSerialNumberValidation(newSerialNumber) || newSerialNumber == "")
            {
                NewCageSerialNumberError.Text = "Serial Number should contain numbers and letters only!";
                flag = false;
            }
            if (!(Double.TryParse(cageWidthText, out newCageWidth) && Double.TryParse(cageHeightText, out newCageHeight) && Double.TryParse(cageLengthText, out newCageLength)))
            {
                NewCageDimensionError.Text = "Dimension must be a number!";
                flag = false;
            }
            if (NewCageMaterialSelect.SelectedIndex == -1)
            {
                NewCageMaterialSelectError.Text = "You must choose the cage's material!";
                flag = false;
            }
            if (cageExists(newSerialNumber) && newSerialNumber != self.SerialNumber)
            {
                flag = false;
                NewCageMaterialSelectError.Text = "Cage Exists!";
            }
            if (flag)
            {
                string matChoice = matChoiceArr[NewCageMaterialSelect.SelectedIndex];
                Double.TryParse(cageWidthText, out newCageWidth);
                Double.TryParse(cageHeightText, out newCageHeight);
                Double.TryParse(cageLengthText, out newCageLength);
                if (!goodDimension(newCageWidth, newCageHeight, newCageLength))
                {
                    NewCageDimensionError.Text = "Dimension must be a number between 15 to 2000!";
                    return;
                }
                BirdManagementDBEntities db = new BirdManagementDBEntities();
                var birdsInCage = from b in db.Birds
                                  where b.Cage == self.SerialNumber
                                  select b;
                foreach (Bird bird in birdsInCage.ToList()) {
                    bird.Cage = newSerialNumber;
                }
                var CageToUpdate = from c in db.Cages
                                   where c.Id==self.Id
                                   select c;
                Cage cage=CageToUpdate.FirstOrDefault();
                if (cage!=null)
                {
                    cage.SerialNumber = newSerialNumber;
                    cage.Width = newCageWidth;
                    cage.Height = newCageHeight;
                    cage.Length = newCageLength;
                    cage.CageMaterial = matChoice;
                }
                db.SaveChanges();
                CageWindow page = new CageWindow(cage);
                page.Show();
                this.Close();
            }
        }
        private void BirdsInCageGrid_AutoGenerationColumn(Object sender,DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
            {
                e.Cancel=true;
            }
        }
        private bool goodDimension(double d1, double d2, double d3)
        {
            return (d1 >= 15 && d1 <= 2000) && (d2 >= 15 && d2 <= 2000) && (d2 >= 15 && d2 <= 2000);
        }
    }
}
