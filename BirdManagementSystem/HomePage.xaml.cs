using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
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
            if (this.CageError.Text != "" || this.FatherError.Text != "" || this.MotherError.Text != "" || this.SerialError.Text != "")
            {
                //dont add the bird some input is illegal show error
            }
            else
            {
                //Add the bird


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
            string serialNumber = NewCageSerialNumber.Text;
            string cageWidthText = NewCageWidth.Text;
            string cageLengthText = NewCageLength.Text;
            string cageHeightText = NewCageHeight.Text;
            double cageWidth, cageLength, cageHeight;
            bool flag = true;
            if (!checkCageSerialNumberValidation(serialNumber) || serialNumber == "")
            {
                NewCageSerialNumberError.Text = "Serial Number should contain numbers and letters only!";
                flag = false;
            }
            if (!(Double.TryParse(cageWidthText, out cageWidth) && Double.TryParse(cageHeightText, out cageHeight) && Double.TryParse(cageLengthText, out cageLength)))
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
                //TODO
                //add cage to db
                //TODO
                addNewCageSuccess.Text = "Cage Added Successfully!";
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(5);
                /*timer.Tick += (sender, e) =>
                {
                    addNewCageSuccess.Text = "";
                };
                timer.Start();*/
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
    }
}
