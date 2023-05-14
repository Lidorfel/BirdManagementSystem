using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BirdManagementSystem
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : System.Windows.Window
    {
        public HomePage()
        {
            InitializeComponent();
            HatchDate.DisplayDateEnd = DateTime.Now;
        }
        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {

            Login page = new Login();
            page.Show();
            this.Close();
        }


        private void validateDate(object sender,
                DatePickerDateValidationErrorEventArgs e)
        {
            Console.WriteLine("ho");
        }

        private void ChangeTheSubSpecies(object sender, EventArgs args)
        {
            List<string> choices;
            Trace.WriteLine(BirdSpecies.SelectedIndex);
            if (BirdSpecies.SelectedIndex == 0)
            {
                Trace.WriteLine("entered goldian american");
                choices = new List<string> { "North America", "Central America", "South America" };

            }
            else if (BirdSpecies.SelectedIndex == 1)
            {
                //BirdSubspecies = new ComboBox();
                choices = new List<string> { "Eastern Europe", "Western Europe" };

            }
            else
            {
                choices = new List<string> { "Central Australia", "Coastal Cities" };
            }
            BirdSubspecies.ItemsSource = choices;

        }

        private void BirdSerialChanged(object sender, TextChangedEventArgs args)
        {
            var bc = new BrushConverter();
            bool flag = false;
            if (BirdSerialNumber.Text.Length == 0)
            {
                BirdSerialNumber.Background = Brushes.Transparent;
                SerialError.Text = "";
                flag = false;
            }

            if (!Regex.IsMatch(this.BirdSerialNumber.Text, @"^[0-9]+$"))
            {
                this.SerialError.Text = "Serial Number consists of only numbers";
                flag = true;
            }
            if (flag)
            {


                BirdSerialNumber.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {

                this.SerialError.Text = "";
                BirdSerialNumber.BorderBrush = Brushes.Orange;
                BirdSerialNumber.Background = Brushes.Transparent;

            }
        }
        private void CageSerialChanged(object sender, TextChangedEventArgs args)
        {
            var bc = new BrushConverter();
            bool flag = false;
            if (CageSerial.Text.Length == 0)
            {
                CageSerial.Background = Brushes.Transparent;
                CageError.Text = "";
            }
            if (!Regex.IsMatch(this.CageSerial.Text, @"^[a-zA-Z0-9]+$"))
            {
                this.CageError.Text = "Cage Serial Number consists of only numbers and letters";
                flag = true;
            }
            if (flag)
            {


                CageSerial.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {

                this.CageError.Text = "";
                CageSerial.BorderBrush = Brushes.Orange;
                CageSerial.Background = Brushes.Transparent;

            }
        }
        private void FatherSerialChanged(object sender, TextChangedEventArgs args)
        {
            var bc = new BrushConverter();
            bool flag = false;
            if (FatherSerial.Text.Length == 0)
            {
                FatherSerial.Background = Brushes.Transparent;
                FatherError.Text = "";
            }

            if (!Regex.IsMatch(this.FatherSerial.Text, @"^[0-9]+$"))
            {
                this.FatherError.Text = "Father Serial Number consists of only numbers";
                flag = true;
            }
            if (flag)
            {


                FatherSerial.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {

                this.FatherError.Text = "";
                FatherSerial.BorderBrush = Brushes.Orange;
                FatherSerial.Background = Brushes.Transparent;

            }
        }
        private void MotherSerialChanged(object sender, TextChangedEventArgs args)
        {
            var bc = new BrushConverter();
            bool flag = false;
            if (MotherSerial.Text.Length == 0)
            {
                MotherSerial.Background = Brushes.Transparent;
                MotherError.Text = "";
            }
            if (!Regex.IsMatch(this.MotherSerial.Text, @"^[0-9]+$"))
            {
                this.MotherError.Text = "Mother Serial Number consists of only numbers";
                flag = true;
            }
            if (flag)
            {



                MotherSerial.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {

                this.MotherError.Text = "";
                MotherSerial.BorderBrush = Brushes.Orange;
                MotherSerial.Background = Brushes.Transparent;

            }

        }

        private void AddBirdBtn_Click(object sender, RoutedEventArgs e)
        {
            string[] spec = new string[] { "Goldian American", "Goldian European", "Goldian Australian" };
            string[] gend = new string[] { "Male", "Female" };
            if (this.CageError.Text != "" || this.FatherError.Text != "" || this.MotherError.Text != "" || this.SerialError.Text != "")
            {
                //dont add the bird some input is illegal show error
            }
            else
            {
                string newSerialNumber = BirdSerialNumber.Text;
                string newSpecies = spec[BirdSpecies.SelectedIndex];
                string newSubSpecies = BirdSubspecies.SelectedItem.ToString();
                string newGender = gend[BirdGender.SelectedIndex];
                string newCageSerialNumber = CageSerial.Text;
                string newFather = FatherSerial.Text;
                string newMother = MotherSerial.Text;
                DateTime newDate = (DateTime)HatchDate.SelectedDate;
                Nullable<System.DateTime> d = new Nullable<System.DateTime>(newDate);
                //Add the bird
                BirdManagementDBEntities db = new BirdManagementDBEntities();
                Bird newBird = new Bird()
                {
                    SerialNumber = newSerialNumber,
                    Species = newSpecies,
                    SubSpecies = newSubSpecies,
                    HatchDate = d,
                    Gender = newGender,
                    Cage = newCageSerialNumber,
                    Mother = newMother,
                    Father = newFather,
                };
                try
                {
                    // Add a new Bird object to the context and save changes
                    db.Birds.Add(newBird);
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    // Iterate over the validation errors and print them to the console
                    foreach (var entityValidationResult in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationResult.ValidationErrors)
                        {
                            Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }

                //clear all the fields
                this.BirdSerialNumber.Text = "";
                BirdSerialNumber.Background = Brushes.Transparent;
                SerialError.Text = "";
                this.CageSerial.Text = "";
                CageSerial.Background = Brushes.Transparent;
                CageError.Text = "";
                this.FatherSerial.Text = "";
                FatherSerial.Background = Brushes.Transparent;
                FatherError.Text = "";
                this.MotherSerial.Text = "";
                MotherSerial.Background = Brushes.Transparent;
                MotherError.Text = "";
                this.BirdGender.Text = "";
                this.BirdSpecies.Text = "";
                this.BirdSubspecies.Text = "";
                HatchDate.Text = "";
            }
        }
        private void NewCageSerialNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            var bc = new BrushConverter();
            string serialNumber = NewCageSerialNumber.Text;
            bool flag1 = false;
            string errorMessage = "";
            if (!flag1 && !checkCageSerialNumberValidation(serialNumber) && serialNumber != "")
            {
                errorMessage = "Serial Number should contain numbers and letters only!";
                flag1 = true;
            }
            if (flag1)
            {
                NewCageSerialNumberError.Text = errorMessage;
                NewCageSerialNumber.BorderBrush = Brushes.Red;
                NewCageSerialNumber.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {
                NewCageSerialNumberError.Text = "";
                NewCageSerialNumber.BorderBrush = Brushes.Orange;
                NewCageSerialNumber.Background = Brushes.Transparent;
            }

        }
        private void addNewCageBtn_Click(object sender, RoutedEventArgs e)
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
            if (flag)
            {
                string matChoice = matChoiceArr[NewCageMaterialSelect.SelectedIndex];
                Double.TryParse(cageWidthText, out newCageWidth);
                Double.TryParse(cageHeightText, out newCageHeight);
                Double.TryParse(cageLengthText, out newCageLength);
                BirdManagementDBEntities db = new BirdManagementDBEntities();
                Cage newCage = new Cage()
                {
                    SerialNumber = newSerialNumber,
                    Width = newCageWidth,
                    Length = newCageLength,
                    Height = newCageHeight,
                    CageMaterial = matChoice
                };
                db.Cages.Add(newCage);
                db.SaveChanges();
                addNewCageSuccess.Text = "Cage Added Successfully!";
                NewCageSerialNumber.Text = "";
                NewCageWidth.Text = "";
                NewCageLength.Text = "";
                NewCageHeight.Text = "";
                NewCageMaterialSelect.SelectedIndex = -1;

            }
        }
        private bool checkCageSerialNumberValidation(string sn)
        {
            return sn.All(c => Char.IsLetter(c) || Char.IsNumber(c)) && sn.Any(Char.IsLetter) && sn.Any(Char.IsNumber);
        }

        private void SearchCageBtn_Click(object sender, RoutedEventArgs e)
        {

            bool InfoFound = false;
            string SelectedCageMat;
            bool notBoth = true;
            ComboBoxItem typeItem = (ComboBoxItem)SearchCageMaterial.SelectedItem;
            Trace.WriteLine(typeItem);
            if (typeItem != null)
                SelectedCageMat = typeItem.Content.ToString();
            else
                SelectedCageMat = null;

            string SelectedCageSerial = SearchCageSN.Text;
            Trace.WriteLine(SelectedCageSerial);
            BirdManagementDBEntities db = new BirdManagementDBEntities();
            var cages = from d in db.Cages
                        select d;

            //this.CageSearchTable.ItemsSource = new LinkedList<Cage>();
            List<Cage> ReactiveList = new List<Cage>(); ;

            foreach (var item in cages)
            {
                //Cage info
                String cageMaterial = item.CageMaterial;
                String CageSerialNum = item.SerialNumber.ToString();


                //check if input is inserted
                if (SelectedCageMat == null)
                {
                    //we do the search with serial number
                    if (SelectedCageSerial == "")
                    {
                        //we show all the results
                        InfoFound = true;
                        notBoth = false;
                        this.CageSearchTable.ItemsSource = cages.ToList();
                        this.CageSearchTable.IsReadOnly = true;
                        CageSearchTable.Visibility = Visibility.Visible;
                    }
                    else
                    {


                        //we show according to cage serial number
                        if (CageSerialNum == SelectedCageSerial)
                        {

                            InfoFound = true;
                            ReactiveList.Add(item);
                        }

                    }
                }
                else
                {

                    //we show according to cage material but we also check if there is cage serial
                    if (SelectedCageSerial == "")
                    {

                        //we show according to cage material
                        if (cageMaterial == SelectedCageMat)
                        {
                            InfoFound = true;
                            ReactiveList.Add(item);
                        }
                    }
                    else
                    {
                        //we show according to both cage serial and material
                        if (cageMaterial == SelectedCageMat && CageSerialNum == SelectedCageSerial)
                        {
                            InfoFound = true;
                            ReactiveList.Add(item);

                        }
                    }
                }

            }

            if (ReactiveList != null)
            {
                ReactiveList.Sort((c1, c2) => c2.SerialNumber.CompareTo(c1.SerialNumber));
            }
            if (!InfoFound)
            {
                CageSearchTable.Visibility = Visibility.Collapsed;
                NoResultsFound.Visibility = Visibility.Visible;
            }
            else
            {
                CageSearchTable.Visibility = Visibility.Visible;
                NoResultsFound.Visibility = Visibility.Collapsed;
            }
            if (notBoth)
            {
                this.CageSearchTable.ItemsSource = ReactiveList;
                this.CageSearchTable.IsReadOnly = true;
            }
            else
            {
                List<Cage> newList = new List<Cage>();
                newList = cages.ToList();
                newList.Sort((c1, c2) => c2.SerialNumber.CompareTo(c1.SerialNumber));
                this.CageSearchTable.ItemsSource = newList;
                this.CageSearchTable.IsReadOnly = true;
            }
        }

        private void SearchBirdBtn_Click(object sender, RoutedEventArgs e)
        {
            bool InfoFound = false;
            string SelectedBirdSpecies;
            string SelectedBirdGender;
            string BirdSN = SearchBirdSN.Text;
            DateTime? newDate = BirdHatchDate.SelectedDate as DateTime?;

            //Nullable<System.DateTime> d = new Nullable<System.DateTime>(newDate);
            bool notAll = true;

            ComboBoxItem typeItem = (ComboBoxItem)BirdSpeciesFind.SelectedItem;
            Trace.WriteLine(typeItem);
            if (typeItem != null)
                SelectedBirdSpecies = typeItem.Content.ToString();
            else
                SelectedBirdSpecies = "";



            ComboBoxItem typeItem1 = (ComboBoxItem)BirdGenderFind.SelectedItem;
            Trace.WriteLine(typeItem);
            if (typeItem1 != null)
                SelectedBirdGender = typeItem1.Content.ToString();
            else
                SelectedBirdGender = "";

            BirdManagementDBEntities db = new BirdManagementDBEntities();
            var birds = from b in db.Birds
                        select b;

            //this.CageSearchTable.ItemsSource = new LinkedList<Cage>();
            List<Bird> ReactiveList = new List<Bird>(); ;

            foreach (var item in birds)
            {
                if (newDate == null)
                    Trace.WriteLine("New Date is" + newDate);
                if (BirdSN == null)
                    Trace.WriteLine("birdsn is null");
                if (SelectedBirdSpecies == null)
                    Trace.WriteLine("birdspecies is null");
                if (newDate == null && BirdSN == "" && SelectedBirdSpecies == "" && SelectedBirdGender == "")
                {
                    Trace.WriteLine("entered the if&&&&&&");
                    //search to all fields
                    InfoFound = true;
                    notAll = false;
                    this.BirdSearchTable.ItemsSource = birds.ToList();
                    this.BirdSearchTable.IsReadOnly = true;
                    BirdSearchTable.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
