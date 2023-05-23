using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {

        public Register()
        {
            InitializeComponent();
        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UserName.Text;
            string password = Password.Text;
            string id = ID.Text;

            bool flag = false;
            string errorMessage = " ";


            if (!flag && UserExists(username))
            {
                errorMessage = "User Already Exists";
                flag = true;
            }

            if (!flag && (!Regex.IsMatch(id, @"^[0-9]+$") || id.Length != 9))
            {
                errorMessage = "ID should only contain numbers and contain 8-9 digits";
                flag = true;
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
            {
                errorMessage = "username should contain only letters and numbers";
                flag = true;
            }


            if (!flag && ((username.Length < 6 || username.Length > 8) || username.Count(c => Char.IsNumber(c)) > 2))
            {
                errorMessage = "Username Length is not Legal it should be 6-8 letters and up to 2 numbers";
                flag = true;
            }

            if (!flag && (password.Length < 8 || password.Length > 10))
            {
                errorMessage = "Password Length is not Legal it should be 8-10 characters";
                flag = true;
            }

            if (!flag && (!Regex.IsMatch(password, @"[a-zA-Z]") || !Regex.IsMatch(password, @"[0-9]") || !Regex.IsMatch(password, @"[@_!#$%^&*()<>?/|}{~:]")))
            {
                errorMessage = "Password should contain at least a number and a letter and a symbol";
                flag = true;
            }

            if (flag)
            {

                /*MessageBox.Show(errorMessage, caption, button, icon, MessageBoxResult.Yes);*/
                ErrorBlock.Text = errorMessage;
            }
            else
            {
                ErrorBlock.Text = "";
                Registiration(username, password, id);
                Login log = new Login();
                log.Show();
                this.Close();
            }
        }

        private void Registiration(string user, string pass, string id)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string filePath = @"..\..\Users.xlsx";
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Find the next empty row
                int newRow = worksheet.Dimension.End.Row + 1;

                // Write the data
                worksheet.Cells[newRow, 1].Value = user;
                worksheet.Cells[newRow, 2].Value = pass;
                worksheet.Cells[newRow, 3].Value = id;


                // Save the changes
                package.Save();
            }
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }

        private bool UserExists(string username)
        {
            var filePath = @"..\..\Users.xlsx";
            var data = ReadUsernamesAndPasswords(filePath);

            // Write data to the Excel file
            if (data.ContainsKey(username))
                return true;
            return false;
        }
        private Dictionary<string, string> ReadUsernamesAndPasswords(string filePath)
        {
            var data = new Dictionary<string, string>();

            // Set the EPPlus License context (needed for version 5 and later)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];

                // Assuming the data starts at row 2 to skip the header row
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    string username = worksheet.Cells[row, 1].Value?.ToString();
                    string password = worksheet.Cells[row, 2].Value?.ToString();
                    if (username != null && password != null)
                        data.Add(username, password);
                }
            }

            return data;
        }

        private void ChangeColor(object sender, TextChangedEventArgs args)
        {

            var bc = new BrushConverter();
            if (UserName.Text.Length == 0)
            {
                UserName.Background = Brushes.Transparent;
                ErrorBlock.Text = "";
            }
            else
            {

                string errorMessage = "";
                string username = UserName.Text;
                string password = Password.Text;
                bool flag = false;
                if (!flag && UserExists(username))
                {
                    errorMessage = "User Already Exists";
                    flag = true;
                }


                if (!Regex.IsMatch(username, @"^[a-zA-Z0-9]+$"))
                {
                    errorMessage = "username should contain only letters and numbers";
                    flag = true;
                }


                if (!flag && ((username.Length < 6 || username.Length > 8) || username.Count(c => Char.IsNumber(c)) > 2))
                {
                    errorMessage = "Username Length is not Legal it should be 6-8 letters and up to 2 numbers";
                    flag = true;
                }



                if (flag)
                {

                    ErrorBlock.Text = errorMessage;
                    UserName.BorderBrush = Brushes.Red;
                    UserName.Background = (Brush)bc.ConvertFrom("#ff726f");
                }
                else
                {

                    ErrorBlock.Text = "";
                    UserName.BorderBrush = Brushes.Orange;
                    UserName.Background = Brushes.Transparent;

                }

            }


        }

        private void ChangeColors(object sender, RoutedEventArgs args)
        {
            var bc = new BrushConverter();

            string username = UserName.Text;
            string password = Password.Text;
            bool flag1 = false;

            string errorMessage = "";



            if (!flag1 && (password.Length < 8 || password.Length > 10))
            {
                errorMessage = "Password Length is not Legal it should be 8-10 characters";
                flag1 = true;
            }

            if (!flag1 && (!Regex.IsMatch(password, @"[a-zA-Z]") || !Regex.IsMatch(password, @"[0-9]") || !Regex.IsMatch(password, @"[@_!#$%^&*()<>?/|}{~:]")))
            {
                errorMessage = "Password should contain at leas a number and a letter and a symbol";
                flag1 = true;
            }


            if (flag1)
            {
                ErrorBlock.Text = errorMessage;
                Password.BorderBrush = Brushes.Red;
                Password.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {
                ErrorBlock.Text = "";
                Password.BorderBrush = Brushes.Orange;
                Password.Background = Brushes.Transparent;
            }

        }

        private void ChangeColorID(object sender, TextChangedEventArgs args)
        {
            var bc = new BrushConverter();
            if (ID.Text.Length == 0)
            {
                ID.Background = Brushes.Transparent;
                ErrorBlock.Text = "";
            }
            string id = ID.Text;

            bool flag = false;
            string errorMessage = " ";



            /*if(!flag && UserExists(username))
            {
                errorMessage = "User Already Exists";
                flag = true;
            }*/

            if (!flag && (!Regex.IsMatch(id, @"^[0-9]+$") || id.Length != 9))
            {
                errorMessage = "ID should only contain numbers and contain 8-9 digits";
                flag = true;
            }

            if (flag)
            {
                ErrorBlock.Text = errorMessage;
                ID.BorderBrush = Brushes.Red;
                ID.Background = (Brush)bc.ConvertFrom("#ff726f");
            }
            else
            {
                ErrorBlock.Text = "";
                ID.BorderBrush = Brushes.Orange;
                ID.Background = Brushes.Transparent;
            }
        }
    }
}
