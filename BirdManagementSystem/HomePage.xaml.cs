using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data;

namespace BirdManagementSystem
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : System.Windows.Window
    {
        
        private bool BirdCantAdvance = true;
        private bool BirdCantAdvance1 = true;
        private bool BirdCantAdvance2 = true;
        private bool BirdCantAdvance3 = true;
        private bool BirdCantAdvance4 = true;
        
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
                BirdCantAdvance4 = false;

            }
            else if (BirdSpecies.SelectedIndex == 1)
            {
                //BirdSubspecies = new ComboBox();
                choices = new List<string> { "Eastern Europe", "Western Europe" };
                BirdCantAdvance4 = false;

            }
            else
            {
                BirdCantAdvance4 = false;
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
            else if (birdExists(BirdSerialNumber.Text))
            {
                SerialError.Text = "Bird already Exist!";
                flag = true;
            }
            if (flag)
            {
                BirdSerialNumber.Background = (Brush)bc.ConvertFrom("#ff726f");
                BirdCantAdvance = true;
            }
            else
            {
                BirdCantAdvance = false;
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
                flag = false;
              
            }
            if (!Regex.IsMatch(this.CageSerial.Text, @"^[a-zA-Z0-9]+$"))
            {
                this.CageError.Text = "Cage Serial Number consists of only numbers and letters";
                flag = true;
               
            }
            if (!cageExists(CageSerial.Text))
            {
                this.CageError.Text = "Cage does'nt exist";
                flag = true;
              
            }
            if (flag)
            {

                BirdCantAdvance1 = true;
                CageSerial.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {
                BirdCantAdvance1 = false;
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
                flag = false;
               
            }

            if (!Regex.IsMatch(this.FatherSerial.Text, @"^[0-9]+$"))
            {
                this.FatherError.Text = "Father Serial Number consists of only numbers";
                flag = true;
            
            }
            if (!birdExists(FatherSerial.Text))
            {
                this.FatherError.Text = "Bird doesn't exist!";
                flag = true;
            }
            else
            {
                if (getBirdGender(FatherSerial.Text) != "Male")
                {
                    this.FatherError.Text = "Bird should be male";
                    flag = true;
                }
            }
            if (flag)
            {

                BirdCantAdvance2 = true;
                FatherSerial.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {
                BirdCantAdvance2 = false;
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
                flag = false;
             
            }
            if (!Regex.IsMatch(this.MotherSerial.Text, @"^[0-9]+$"))
            {
                this.MotherError.Text = "Mother Serial Number consists of only numbers";
                flag = true;
            
            }
            if (!birdExists(MotherSerial.Text))
            {
                this.MotherError.Text = "Bird doesn't exist!";
                flag = true;
            }
            else
            {
                if (getBirdGender(MotherSerial.Text) != "Female")
                {
                    this.MotherError.Text = "Bird should be female";
                    flag = true;
                }
            }
            if (flag)
            { 
                MotherSerial.Background = (Brush)bc.ConvertFrom("#ff726f");
                BirdCantAdvance3 = true;
            }
            else
            {
                BirdCantAdvance3 = false;
                this.MotherError.Text = "";
                MotherSerial.BorderBrush = Brushes.Orange;
                MotherSerial.Background = Brushes.Transparent;

            }

        }

        private void AddBirdBtn_Click(object sender, RoutedEventArgs e)
        {
            bool cantAdvanceHere = true;
            string[] spec = new string[] { "Goldian American", "Goldian European", "Goldian Australian" };
            string[] gend = new string[] { "Male", "Female" };
            DateTime? newDate = HatchDate.SelectedDate as DateTime?;
            if (BirdCantAdvance || BirdCantAdvance1 || BirdCantAdvance2 || BirdCantAdvance3 || BirdCantAdvance4)
            {
                //dont add the bird some input is illegal show error
                if(newDate == null)
                {
                    DateError.Text = "please enter hatch date";
                    
                }
            }
            else
            {
                string newSerialNumber = BirdSerialNumber.Text;
                string newSpecies = spec[BirdSpecies.SelectedIndex];
               if(BirdSubspecies.SelectedItem != null) { 
                    string newSubSpecies = BirdSubspecies.SelectedItem.ToString();
                    cantAdvanceHere = false;
               }

                string newGender = gend[BirdGender.SelectedIndex];
                string newCageSerialNumber = CageSerial.Text;
                string newFather = FatherSerial.Text;
                string newMother = MotherSerial.Text;
                
                if (newDate == null)
                    cantAdvanceHere = true;
                else
                {
                    //Nullable<System.DateTime> d = new Nullable<System.DateTime>(newDate);
                }
                //Add the bird
                if (!cantAdvanceHere)
                {
                    DateError.Text = "";
                    string newSubSpecies = BirdSubspecies.SelectedItem.ToString();
                    if (cageExists(newCageSerialNumber))
                    {

                        BirdManagementDBEntities db = new BirdManagementDBEntities();
                        Bird newBird = new Bird()
                        {
                            SerialNumber = newSerialNumber,
                            Species = newSpecies,
                            SubSpecies = newSubSpecies,
                            HatchDate = newDate,
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
            if (!flag1 && !checkCageSerialNumberValidation(serialNumber) && serialNumber != "" && cageExists(serialNumber))
            {
                errorMessage = "Cage does not exist";
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
            if (cageExists(newSerialNumber))
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
                if(!goodDimension(newCageWidth, newCageHeight, newCageLength))
                {
                    NewCageDimensionError.Text = "Dimension must be a number between 15 to 2000!";
                    return;
                }
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
            return sn.All(c => Char.IsLetter(c) || Char.IsNumber(c)) && sn.Any(Char.IsLetter) && sn.Any(Char.IsNumber) ;
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
            List<Cage> ReactiveList = new List<Cage>();

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
                        /*                        this.CageSearchTable.ItemsSource = cages.ToList();
                                                this.CageSearchTable.IsReadOnly = true;
                                                CageSearchTable.Visibility = Visibility.Visible;*/
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

            if (ReactiveList.Count > 0)
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
                if (notBoth)
                {
                    if (ReactiveList.Count > 1 && ReactiveList.Count!=0)
                    {
                            
                            this.CageSearchTable.ItemsSource = ReactiveList;

                            this.CageSearchTable.IsReadOnly = true;
                    }
                    else
                    {
                        Cage c = ((Cage)ReactiveList[0]);
                        CageWindow page = new CageWindow(c);
                        page.Show();
                        this.Close();
                    }

                }
                else
                {
                    List<Cage> newList = new List<Cage>();
                    newList = cages.ToList();
                    if (newList.Count > 1 && newList.Count != 0)
                    {
                        newList.Sort((c1, c2) => c2.SerialNumber.CompareTo(c1.SerialNumber));
                        
                        this.CageSearchTable.ItemsSource = newList;
                        this.CageSearchTable.IsReadOnly = true;
                    }
                    else
                    {
                        Cage c = ((Cage)newList[0]);
                        CageWindow page = new CageWindow(c);
                        page.Show();
                        this.Close();
                    }
                }

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
            {
                if (typeItem.Content != null)
                    SelectedBirdSpecies = typeItem.Content.ToString();
                else
                    SelectedBirdSpecies = "";
            }
            else
                SelectedBirdSpecies = "";



            ComboBoxItem typeItem1 = (ComboBoxItem)BirdGenderFind.SelectedItem;
            Trace.WriteLine(typeItem);
            if (typeItem1 != null)
            {
                if (typeItem1.Content != null)
                    SelectedBirdGender = typeItem1.Content.ToString();
                else
                    SelectedBirdGender = "";
            }
            else
                SelectedBirdGender = "";

            BirdManagementDBEntities db = new BirdManagementDBEntities();
            var birds = from b in db.Birds
                        select b;

            //this.CageSearchTable.ItemsSource = new LinkedList<Cage>();
            List<Bird> ReactiveList = new List<Bird>(); 

            /*foreach (var item in birds)
            {*/
             
            /*if (newDate == null && BirdSN == "" && SelectedBirdSpecies == "" && SelectedBirdGender == "")
            {
                    
                    //search to all fields
                  InfoFound = true;
            }
            else if(newDate == null && BirdSN == "" && SelectedBirdSpecies != "" && SelectedBirdGender == "") {
                InfoFound= true;
                var birdsL = from c in db.Birds
                             where c.Species== SelectedBirdSpecies
                            select c ;
                
                ReactiveList = birdsL.ToList();
                if (ReactiveList.Count == 0)
                    InfoFound = false;
                ReactiveList.Sort((c1, c2) => c2.SerialNumber.CompareTo(c1.SerialNumber));
                
            }*/
            if (newDate == null && BirdSN == "" && SelectedBirdSpecies == "" && SelectedBirdGender == "")
            {
                // search all records
                ReactiveList = db.Birds.ToList();
                InfoFound = true;
            }
            else if (newDate != null && BirdSN == "" && SelectedBirdSpecies == "" && SelectedBirdGender == "")
            {
                // search by hatch date
                var birdsL = from c in db.Birds
                             where c.HatchDate == newDate
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate == null && BirdSN != "" && SelectedBirdSpecies == "" && SelectedBirdGender == "")
            {
                // search by serial number
                var birdsL = from c in db.Birds
                             where c.SerialNumber == BirdSN
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate == null && BirdSN == "" && SelectedBirdSpecies != "" && SelectedBirdGender == "")
            {
                // search by bird species
                var birdsL = from c in db.Birds
                             where c.Species == SelectedBirdSpecies
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate == null && BirdSN == "" && SelectedBirdSpecies == "" && SelectedBirdGender != "")
            {
                // search by bird gender
                var birdsL = from c in db.Birds
                             where c.Gender == SelectedBirdGender
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate != null && BirdSN != "" && SelectedBirdSpecies == "" && SelectedBirdGender == "")
            {
                // search by hatch date and serial number
                var birdsL = from c in db.Birds
                             where c.HatchDate == newDate && c.SerialNumber == BirdSN
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate != null && BirdSN == "" && SelectedBirdSpecies != "" && SelectedBirdGender == "")
            {
                // search by hatch date and bird species
                var birdsL = from c in db.Birds
                             where c.HatchDate == newDate && c.Species == SelectedBirdSpecies
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate != null && BirdSN == "" && SelectedBirdSpecies == "" && SelectedBirdGender != "")
            {
                // search by hatch date and bird gender
                var birdsL = from c in db.Birds
                             where c.HatchDate == newDate && c.Gender == SelectedBirdGender
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate == null && BirdSN != "" && SelectedBirdSpecies != "" && SelectedBirdGender == "")
            {
                // search by serial number and bird species
                var birdsL = from c in db.Birds
                             where c.SerialNumber == BirdSN && c.Species == SelectedBirdSpecies
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate == null && BirdSN != "" && SelectedBirdSpecies == "" && SelectedBirdGender != "")
            {
                // search by serial number and bird gender
                var birdsL = from c in db.Birds
                             where c.SerialNumber == BirdSN && c.Gender == SelectedBirdGender
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate == null && BirdSN == "" && SelectedBirdSpecies != "" && SelectedBirdGender != "")
            {
                // search by bird species and bird gender
                var birdsL = from c in db.Birds
                             where c.Species == SelectedBirdSpecies && c.Gender == SelectedBirdGender
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate != null && BirdSN != "" && SelectedBirdSpecies != "" && SelectedBirdGender == "")
            {
                // search by hatch date, serial number, and bird species
                var birdsL = from c in db.Birds
                             where c.HatchDate == newDate && c.SerialNumber == BirdSN && c.Species == SelectedBirdSpecies
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate != null && BirdSN != "" && SelectedBirdSpecies == "" && SelectedBirdGender != "")
            {
                // search by hatch date, serial number, and bird gender
                var birdsL = from c in db.Birds
                             where c.HatchDate == newDate && c.SerialNumber == BirdSN && c.Gender == SelectedBirdGender
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate != null && BirdSN == "" && SelectedBirdSpecies != "" && SelectedBirdGender != "")
            {
                // search by hatch date, bird species, and bird gender
                var birdsL = from c in db.Birds
                             where c.HatchDate == newDate && c.Species == SelectedBirdSpecies && c.Gender == SelectedBirdGender
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate == null && BirdSN != "" && SelectedBirdSpecies != "" && SelectedBirdGender != "")
            {
                // search by serial number, bird species, and bird gender
                var birdsL = from c in db.Birds
                             where c.SerialNumber == BirdSN && c.Species == SelectedBirdSpecies && c.Gender == SelectedBirdGender
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }
            else if (newDate != null && BirdSN != "" && SelectedBirdSpecies != "" && SelectedBirdGender != "")
            {
                // search by all criteria
                var birdsL = from c in db.Birds
                             where c.HatchDate == newDate && c.SerialNumber == BirdSN && c.Species == SelectedBirdSpecies && c.Gender == SelectedBirdGender
                             select c;
                ReactiveList = birdsL.ToList();
                InfoFound = ReactiveList.Count > 0;
            }

            // sort the list by serial number
            ReactiveList.Sort((c1, c2) => Int32.Parse(c2.SerialNumber).CompareTo(Int32.Parse(c1.SerialNumber)));
            if (!InfoFound)
            {
               
                BirdSearchTable.Visibility = Visibility.Collapsed;
                NoResultsFoundB.Visibility = Visibility.Visible;
            }
            else
            {
                if (ReactiveList.Count > 1)
                {
                    
                    this.BirdSearchTable.ItemsSource = ReactiveList;
                    this.BirdSearchTable.IsReadOnly = true;
                    BirdSearchTable.Visibility = Visibility.Visible;
                    NoResultsFoundB.Visibility = Visibility.Collapsed;
                }
                else if (ReactiveList.Count == 0)
                {
                    BirdSearchTable.Visibility = Visibility.Collapsed;
                    NoResultsFoundB.Visibility = Visibility.Visible;
                }
                else
                {
                    Bird b = ((Bird)ReactiveList[0]);
                    BirdWindow page= new BirdWindow(b);
                    page.Show();
                    this.Close();
                }
            }
            
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
        private bool birdExists(string birdSerial)
        {
            BirdManagementDBEntities db = new BirdManagementDBEntities();
            var birds = from b in db.Birds
                        where b.SerialNumber == birdSerial
                        select b;
            List<Bird> check = birds.ToList();
            return check.Count > 0;
        }
        private string getBirdGender(string birdSN)
        {
            BirdManagementDBEntities db = new BirdManagementDBEntities();
            var birds = from b in db.Birds
                        where b.SerialNumber == birdSN
                        select b;
            List<Bird> check = birds.ToList();
            return check[0].Gender;
        }

        private void CageSearchTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.CageSearchTable.SelectedIndex >= 0 && this.CageSearchTable.SelectedItems.Count >= 0)
            {
                if (this.CageSearchTable.SelectedItems[0].GetType() == typeof(Cage))
                {
                    Cage t = (Cage)this.CageSearchTable.SelectedItems[0];
                    CageWindow page = new CageWindow(t);

                    // Set the content of a Frame control on the parent window or page
                    page.Show();
                    this.Close();
                    /*mainPage.mainFrame.Content = page;*/
                }
            }
        }

        private void BirdSearchTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.BirdSearchTable.SelectedIndex >= 0 && this.BirdSearchTable.SelectedItems.Count >= 0)
            {
                if (this.BirdSearchTable.SelectedItems[0].GetType() == typeof(Bird))
                {
                    Bird b = (Bird)this.BirdSearchTable.SelectedItems[0];
                    BirdWindow page = new BirdWindow(b);

                    // Set the content of a Frame control on the parent window or page
                    page.Show();
                    this.Close();
                    /*mainPage.mainFrame.Content = page;*/
                }
            }
        }
        private void BirdsInCageGrid_AutoGenerationColumn(Object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName == "Id")
            {
                e.Cancel = true;
            }
        }
        private bool goodDimension(double d1,double d2,double d3)
        {
            return (d1 >= 15 && d1 <= 2000) && (d2 >= 15 && d2 <= 2000) && (d2 >= 15 && d2 <= 2000);
        }
    }
}
