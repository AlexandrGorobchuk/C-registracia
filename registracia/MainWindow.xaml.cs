using registracia.viev;
using System;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;


namespace registracia
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowPasword(CheckBox checkBox)
        {
            if (checkBox.IsChecked == true)
            {
                PasswordBox.Visibility = Visibility.Collapsed;
                string pass = PasswordBox.Password;
                PasswordUnmask.Text = pass;
                PasswordUnmask.Visibility = Visibility.Visible;
            }
            else
            {
                string pass = PasswordUnmask.Text;
                PasswordBox.Password = pass;
                PasswordUnmask.Visibility = Visibility.Collapsed;
                PasswordBox.Visibility = Visibility.Visible;
            }

        }

        private void CheckBox_Checked(object sender, EventArgs e)
        {
            ShowPasword((CheckBox)sender);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ShowPasword((CheckBox)sender);
        }

        private void CreateAccauntCheckBox_Checked(object sender, EventArgs e)
        {
            CreateAccauntShowPasword((CheckBox)sender);
        }

        private void CreateAccauntCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CreateAccauntShowPasword((CheckBox)sender);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            int passLenght = PasswordBox.Password.Length;
            if (passLenght > 0)
                CheckBoks_showPasword.IsEnabled = true;
            else
                CheckBoks_showPasword.IsEnabled = false;
        }

        private void СCteateAccauntPasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            int passLenght = CreateAccountPasswordBox.Password.Length;
            int repeatPAss = RepeatCreateAccountPasswordBox.Password.Length;
            if (passLenght > 0 || repeatPAss > 0)
                RepeatCreateAccountCheckBoks_showPasword.IsEnabled = true;
            else
                RepeatCreateAccountCheckBoks_showPasword.IsEnabled = false;
        }

        private async void Create_Accaunt(object sender, RoutedEventArgs e)
        {
            for (double i = 0.00; i < 1; i += 0.10)
            {
                StackPanelLogIn.Opacity = 1 - i;
                await Task.Delay(1);
            }
            StackPanelLogIn.Margin = new Thickness(0, 0, 600, 0);
            StackPanelCreateAccount.Margin = new Thickness(0, 120, 0, 0);
            for (double i = 0.00; i < 1; i += 0.10)
            {
                StackPanelCreateAccount.Opacity = 0.00 + i;
                await Task.Delay(1);
            }

        }

        private async void CreatingAccautn_Sign_in(object sender, RoutedEventArgs e)
        {
            for (double i = 0.01; i < 1; i += 0.1)
            {
                StackPanelCreateAccount.Opacity = 1 - i;
                await Task.Delay(4);
            }
            StackPanelLogIn.Margin = new Thickness(0, 0, 0, 0);
            StackPanelCreateAccount.Margin = new Thickness(600, 80, 0, 0);


            for (double i = 0.00; i < 1; i += 0.10)
            {
                StackPanelLogIn.Opacity = 0.00 + i;
                await Task.Delay(1);
            }
        }

        private void CreateAccauntCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CreateAccauntShowPasword((CheckBox)sender);
        }

        private void CreateAccauntShowPasword(CheckBox checkBox)
        {
            if (checkBox.IsChecked == true)
            {
                CreateAccountPasswordUnmask.Text = CreateAccountPasswordBox.Password;
                RepeatCreateAccountPasswordUnmask.Text = RepeatCreateAccountPasswordBox.Password;
                CreateAccountPasswordUnmask.Visibility = Visibility.Visible;
                RepeatCreateAccountPasswordUnmask.Visibility = Visibility.Visible;
                CreateAccountPasswordBox.Visibility = Visibility.Collapsed;
                RepeatCreateAccountPasswordBox.Visibility = Visibility.Collapsed;

            }
            else
            {
                CreateAccountPasswordBox.Password = CreateAccountPasswordUnmask.Text;
                RepeatCreateAccountPasswordBox.Password = RepeatCreateAccountPasswordUnmask.Text;
                CreateAccountPasswordUnmask.Visibility = Visibility.Collapsed;
                RepeatCreateAccountPasswordUnmask.Visibility = Visibility.Collapsed;
                CreateAccountPasswordBox.Visibility = Visibility.Visible;
                RepeatCreateAccountPasswordBox.Visibility = Visibility.Visible;
            }

        }

        private void CreateNewUser(object sender, RoutedEventArgs e)
        {
            String name = CreateAccountName.Text.Trim();
            String email = CreateAccountEmail.Text;
            String pass;
            String repeatpass;

            char[] x = name.ToCharArray();
            string z = "";



            for (int i = 0; i < x.Length; i++)
            {
                if (i == 0)
                {
                    string y = Convert.ToString(x[i]);
                    y = y.ToUpper();
                    x[i] = Convert.ToChar(y);
                }
                else if (Convert.ToString(x[i]) == " ") {
                    string y = Convert.ToString(x[i + 1]);
                    y = y.ToUpper();
                    x[i + 1] = Convert.ToChar(y);
                }
            }

            bool checkName = (name.Length > 0) ? true : false;
            bool checkPass;
            bool checkEmail;

            Brush defoulBorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");

            if (RepeatCreateAccountCheckBoks_showPasword.IsChecked == true)
            {
                pass = CreateAccountPasswordUnmask.Text;
                repeatpass = RepeatCreateAccountPasswordUnmask.Text;
            }
            else
            {
                pass = CreateAccountPasswordBox.Password;
                repeatpass = RepeatCreateAccountPasswordBox.Password;
            }

            checkPass = (pass.Contains(repeatpass) && pass.Length > 0 && repeatpass.Length > 0) ? true : false;

            try
            {
                email = new MailAddress(email).Address;
                checkEmail = true;
            }
            catch
            {
                checkEmail = false;
            }

            if (checkName == false)
            {
                CreateAccountName.BorderBrush = Brushes.Red;
            }
            else
            {
                CreateAccountName.BorderBrush = defoulBorderBrush;
            }

            if (checkEmail == false)
            {
                CreateAccountEmail.BorderBrush = Brushes.Red;
            }
            else
            {
                CreateAccountEmail.BorderBrush = defoulBorderBrush;
            }

            if (checkPass == false)
            {
                CreateAccountPasswordBox.BorderBrush = Brushes.Red;
                RepeatCreateAccountPasswordBox.BorderBrush = Brushes.Red;
                CreateAccountPasswordUnmask.BorderBrush = Brushes.Red;
                RepeatCreateAccountPasswordUnmask.BorderBrush = Brushes.Red;
            }
            else
            {

                CreateAccountPasswordBox.BorderBrush = defoulBorderBrush;
                RepeatCreateAccountPasswordBox.BorderBrush = defoulBorderBrush;
                CreateAccountPasswordUnmask.BorderBrush = defoulBorderBrush;
                RepeatCreateAccountPasswordUnmask.BorderBrush = defoulBorderBrush;
            }


            if (checkName == true && checkEmail == true && checkPass == true)
            {
                MessageBox.Show("GOOD");


                try
                {
                    User user = new User().NewUser(name, email, pass);
                    MessageBox.Show($"Create User. Id = {user.Id}");
                }
                catch (Exception ex) {
                    MessageBox.Show($"{ex.Message}");

                }

            }
            else
            {
                if (checkName == false)
                    MessageBox.Show("Enter correct name");
                else if (checkEmail == false)
                    MessageBox.Show("Enter correct email");
                else if (checkPass == false)
                    MessageBox.Show("Enter correct password");
                else
                    MessageBox.Show("Чnо то пошло не так");
            }
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            String email = LogInEmail.Text;
            String pass = (CheckBoks_showPasword.IsChecked == true) ? PasswordUnmask.Text : PasswordBox.Password;

            bool checkEmail;
            bool checkPass = (pass.Length > 0) ? true : false;

            Brush defoulBorderBrush = (Brush)new BrushConverter().ConvertFrom("#89000000");

            try
            {
                email = new MailAddress(email).Address;
                checkEmail = true;
            }
            catch
            {
                checkEmail = false;
            }

            if (checkEmail == false)
            {
                LogInEmail.BorderBrush = Brushes.Red;
            }
            else
            {
                LogInEmail.BorderBrush = defoulBorderBrush;
            }

            if (checkPass == false)
            {
                PasswordBox.BorderBrush = Brushes.Red;
                PasswordUnmask.BorderBrush = Brushes.Red;
            }
            else
            {
                PasswordBox.BorderBrush = defoulBorderBrush;
                PasswordUnmask.BorderBrush = defoulBorderBrush;
            }

            if (checkEmail == true && checkPass == true)
            {
                try
                {
                    User user = new User();
                    user.CheckUser(email, pass);
                    MessageBox.Show($"Юзер такой есть, имя его: {user.Name}");
                    
                }
                catch (Exception ex) {
                    MessageBox.Show($"{ex.Message}");
                }
                
            }
            else
            {
                if (checkEmail == false)
                {
                    MessageBox.Show("Enter correct email");
                }
                else if (checkPass == false)
                {
                    MessageBox.Show("Enter correct password");
                }
                else
                {
                    MessageBox.Show("Alyarm");
                }
            }


        }
    }
}
