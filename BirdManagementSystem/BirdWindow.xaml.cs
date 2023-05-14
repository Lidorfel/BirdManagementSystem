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
        }
        private bool checkSN(string s)
        {
            return s.All(Char.IsDigit)&& s!="";
        }
        private void addNewChickBtn_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
