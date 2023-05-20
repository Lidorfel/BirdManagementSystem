using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO.Ports;
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

namespace BirdManagementSystem
{
    /// <summary>
    /// Interaction logic for BirdWindow.xaml
    /// </summary>
    public partial class BirdWindow : Window
    {
        private Bird self;
        public BirdWindow()
        {
            InitializeComponent();
        }
        public BirdWindow(Bird b)
        {
            InitializeComponent();
            self = b;
            this.CurrentBirdSN.Text = b.SerialNumber;
            this.CurrentCageSN.Text = b.Cage;
            this.CurrentGender.Text = b.Gender;
            this.CurrentHatchDate.Text = b.HatchDate.Value.ToString("d");
            this.CurrentSpecies.Text = b.Species;
            this.CurrentSubSpecies.Text = b.SubSpecies;
            HatchDate.DisplayDateEnd = DateTime.Now;
        }
        private void AddChickBtn_Click(object sender, RoutedEventArgs e)
        {
            CageSerialUpdateError.Text = "";
            BirdSerialUpdateError.Text = "";
            this.ChickFields.Visibility = Visibility.Visible;
            this.AddChickBtn.Visibility = Visibility.Collapsed;
            if (self.Gender == "Male")
            {

                this.FatherSerial.Visibility = Visibility.Collapsed;
                this.MotherSerial.Visibility = Visibility.Visible;
            }
            else
            {
                this.FatherSerial.Visibility = Visibility.Visible;
                this.MotherSerial.Visibility = Visibility.Collapsed;
            }


            BirdSerialUpdate.Text = "";
            CageSerialUpdate.Text = "";
            BirdSerialUpdate.Visibility = Visibility.Collapsed;
            CageSerialUpdate.Visibility = Visibility.Collapsed;
            UpdateDetails.Visibility = Visibility.Collapsed;
            deleteBird.Visibility = Visibility.Collapsed;
            CurrentBirdSN.Visibility = Visibility.Visible;
            CurrentCageSN.Visibility = Visibility.Visible;
            UpdateBirdBtn.Visibility = Visibility.Visible;
        }
        private bool checkSN(string s)
        {
            return s.All(Char.IsDigit)&& s!="";
        }
        private void addNewChickBtn_Click(object sender, RoutedEventArgs e)
        {
            CageSerialUpdateError.Text = "";
            BirdSerialUpdateError.Text = "";
            bool flag = true;
            this.addNewChickSuccess.Text = "";
            this.GenderError.Text = "";
            this.HatchDateError.Text = "";
            this.ParentError.Text = "";
            this.SerialError.Text = "";
            string sn = this.FatherSerial.Text + this.MotherSerial.Text;
            if (!checkSN(this.BirdSerialNumber.Text) || !(checkSN(sn)) || this.SerialError.Text != "" || !this.HatchDate.SelectedDate.HasValue || this.BirdGender.SelectedIndex == -1)
            {
                if (!this.HatchDate.SelectedDate.HasValue)
                {
                    this.HatchDateError.Text = "Please enter Hatch date";
                }
                if (this.BirdGender.SelectedIndex == -1)
                {
                    this.GenderError.Text = "Please choose the gender";
                }
                if (!checkSN(this.BirdSerialNumber.Text))
                {
                    this.SerialError.Text = "SN must consist only digits";
                }
                if (self.Gender == "Male")
                {
                    if (!(checkSN(this.MotherSerial.Text)))
                    {
                        this.ParentError.Text = "SN must consist only digits";
                    }
                }
                if (self.Gender == "Female")
                {
                    if (!(checkSN(this.FatherSerial.Text))) {
                        this.ParentError.Text = "SN must consist only digits";
                    }
                }
                flag = false;
            }
            if (flag)
            {
                // one of them is ""
                BirdManagementDBEntities db = new BirdManagementDBEntities();
                var docs = from b in db.Birds
                           where b.SerialNumber == sn
                           select b;
                if (docs.ToList().Count() == 0)
                {
                    this.ParentError.Text = "SN not found";
                    flag = false;
                }
                else if(docs.ToList().Count() == 1)
                {
                    if (docs.ToList()[0].Gender == self.Gender)
                    {
                        this.ParentError.Text = "Parent's Gender is not correct";
                        flag = false;
                    }
                }
            }
            if(flag)
            {
                this.HatchDateError.Text = "";
                this.GenderError.Text = "";
                string[] gend = { "Male", "Female" };
                string ParentSN;
                string SecParentSN;
                DateTime newDate = (DateTime)HatchDate.SelectedDate;
                Nullable<System.DateTime> d = new Nullable<System.DateTime>(newDate);
                BirdManagementDBEntities db = new BirdManagementDBEntities();
                Bird newBird;
                if (self.Gender == "Male")
                {
                    ParentSN = self.Father;
                    SecParentSN = this.MotherSerial.Text;
                    newBird = new Bird()
                    {
                        SerialNumber = BirdSerialNumber.Text,
                        Species = self.Species,
                        SubSpecies = self.SubSpecies,
                        HatchDate = d,
                        Gender = gend[this.BirdGender.SelectedIndex],
                        Cage = self.Cage,
                        Mother = SecParentSN,
                        Father = ParentSN,
                    };
                }
                else
                {
                    ParentSN = self.Mother;
                    SecParentSN = this.FatherSerial.Text;
                    newBird = new Bird()
                    {
                        SerialNumber = BirdSerialNumber.Text,
                        Species = self.Species,
                        SubSpecies = self.SubSpecies,
                        HatchDate = d,
                        Gender = gend[this.BirdGender.SelectedIndex],
                        Cage = self.Cage,
                        Mother = ParentSN,
                        Father = SecParentSN,
                    };
                }

                try
                {
                    // Add a new Bird object to the context and save changes
                    db.Birds.Add(newBird);
                    db.SaveChanges();
                    this.addNewChickSuccess.Text = "New Chick Added Successfully";
                    this.BirdSerialNumber.Text = "";
                    this.HatchDate.Text = "";
                    this.FatherSerial.Text = "";
                    this.MotherSerial.Text = "";
                    this.BirdGender.Text = "";
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
            }
        }

        private void BackToHomePage_Click(object sender, RoutedEventArgs e)
        {
            HomePage HP = new HomePage();
            HP.Show();
            this.Close();
        }

        private void UpdateBirdBtn_Click(object sender, RoutedEventArgs e)
        {
            CageSerialUpdateError.Text = "";
            BirdSerialUpdateError.Text = "";
            BirdSerialUpdate.Text = self.SerialNumber.ToString();
            CageSerialUpdate.Text = self.Cage.ToString();
            BirdSerialUpdate.Visibility = Visibility.Visible;
            CageSerialUpdate.Visibility = Visibility.Visible;
            UpdateDetails.Visibility = Visibility.Visible;
            deleteBird.Visibility = Visibility.Visible;
            CurrentBirdSN.Visibility = Visibility.Collapsed;
            CurrentCageSN.Visibility = Visibility.Collapsed;
            UpdateBirdBtn.Visibility = Visibility.Collapsed;
            this.ChickFields.Visibility = Visibility.Collapsed;
            this.AddChickBtn.Visibility = Visibility.Visible;
        }

        private void UpdateDetails_Click(object sender, RoutedEventArgs e)
        {
            string newBirdSN=BirdSerialUpdate.Text;
            string newCageSN=CageSerialUpdate.Text;
            /*bool flag=true;*/
            if (newBirdSN == "")
            {
                BirdSerialUpdateError.Text = "Cannot be empty";
                return;

            }
            if (newBirdSN.All(Char.IsDigit) == false)
            {
                BirdSerialUpdateError.Text = "Bird SN must contain only digits";
                return;
            }
            if (birdExists(newBirdSN))
            {
                if (newBirdSN != self.SerialNumber)
                {
                    BirdSerialUpdateError.Text = "Bird already exist!";
                    return;
                }
            }
            if (newCageSN == "")
            {
                CageSerialUpdateError.Text = "Cannot be empty";
                return;
            }
            if (!checkCageSerialNumberValidation(newCageSN))
            {
                CageSerialUpdateError.Text = "Cage SN must contain letters and digits";
                return;
            }
            if (!cageExists(newCageSN))
            {
                CageSerialUpdateError.Text = "New Cage doesnt exist";
                return;
            }
            BirdManagementDBEntities db = new BirdManagementDBEntities();
            var bird = from b in db.Birds
                       where b.Id == self.Id
                       select b;
            Bird me = bird.ToList()[0];
            me.SerialNumber = newBirdSN;
            me.Cage = newCageSN;
            db.SaveChanges();
            BirdWindow page=new BirdWindow(me);
            page.Show();
            this.Close();
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
        private bool checkCageSerialNumberValidation(string sn)
        {
            return sn.All(c => Char.IsLetter(c) || Char.IsNumber(c)) && sn.Any(Char.IsLetter) && sn.Any(Char.IsNumber);
        }

        private void deleteBird_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete?", "Confirmation", MessageBoxButton.YesNo);

            // Check what the user chose
            if (result == MessageBoxResult.Yes)
            {
                BirdManagementDBEntities db = new BirdManagementDBEntities();
                var rowToDelete = db.Birds.FirstOrDefault(row => row.Id == self.Id);
                // Check if the row exists
                if (rowToDelete != null)
                {
                    // Delete the row
                    db.Birds.Remove(rowToDelete);
                    db.SaveChanges();
                    HomePage page = new HomePage();
                    page.Show();
                    this.Close();
                }
            }
        }
    }
}
