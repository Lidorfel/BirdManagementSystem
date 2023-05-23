//using Microsoft.Office.Interop.Excel;
using MaterialDesignColors.Recommended;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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
using System.Xml;
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using OfficeOpenXml;

namespace BirdManagementSystem
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            // Read data from the Excel file
            Trace.WriteLine("hello world");
            string username = UserName.Text;
            string password = Password.Password;

            bool flag = false;
            string errorMessage = "";



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
                errorMessage = "Password should contain at leas a number and a letter and a symbol";
                flag = true;
            }

            if (flag)
            {

                ErrorBlock.Text = errorMessage;
            }
            else
            {
                ErrorBlock.Text = "";
                bool isValid = ValidateUser(username, password);
                if (isValid)
                {
                    HomePage home = new HomePage();
                    home.Show();
                    this.Close();
                }
                else
                {
                    ErrorBlock.Text = "Wrong Credintials Try Again";
                }
            }

        }

        private void RegisterBtn_Click(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Close();
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private bool ValidateUser(string username, string password)
        {
            var filePath = @"..\..\Users.xlsx";
            var data = ReadUsernamesAndPasswords(filePath);

            // Write data to the Excel file
            if (data.ContainsKey(username))
            {
                if (data[username] == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

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
                    if(username!=null && password!=null)
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

                string username = UserName.Text;
                string password = Password.Password;
                bool flag1 = false;
                bool flag = false;
                string errorMessage = "";

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
            string password = Password.Password;
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
    }
}
