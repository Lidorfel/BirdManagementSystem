using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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


            string caption = "Word Processor";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

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
            string fileNmae = "User.xlsx";
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileNmae);

            //"C:\Users\LasTa\source\repos\LoginExerciseing\LoginExerciseing\Users.xlsx"
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Users.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand("INSERT INTO [Sheet1$] ([Username], [Password],[ID]) VALUES (@Username, @Password,@ID)", connection);
                command1.Parameters.AddWithValue("@Username", user); // replace "newuser" with the actual username you want to insert
                command1.Parameters.AddWithValue("@Password", pass);
                command1.Parameters.AddWithValue("@ID", id);
                // replace "newpassword" with the actual password you want to insert
                int rowsAffected = command1.ExecuteNonQuery();
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
            string fileNmae = "User.xlsx";
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileNmae);
            string excelPath = @"C:\Users\LasTa\Desktop\Users.xlsx";
            //"C:\Users\LasTa\source\repos\LoginExerciseing\LoginExerciseing\Users.xlsx"
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\Users.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'";



            // Create the connection object
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create the command object with the SQL query to read data from the worksheet
                OleDbCommand command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);



                // Create the data adapter object to fill a DataTable with the data from the worksheet
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();

                // Fill the DataTable with the data from the worksheet
                dataAdapter.Fill(dataTable);

                // Loop through the rows in the DataTable and process the data
                foreach (DataRow row in dataTable.Rows)
                {
                    string value1 = row["Username"].ToString();
                    if (username == value1)
                    {
                        connection.Close();
                        return true;

                    }
                    // Do something with the values...
                }
                connection.Close();
            }
            return false; // If no match found, return false
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
