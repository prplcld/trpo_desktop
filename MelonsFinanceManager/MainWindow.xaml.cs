using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Newtonsoft.Json;

namespace DatabaseApp
{
    public partial class MainWindow : Window
    {
        private ToolTip _loginToolTip;
        private ToolTip _password1ToolTip;
        private ToolTip _password2ToolTip;
        private ToolTip _passwordComparisonToolTip;
        private ToolTip _emailToolTip;
        private bool _loginToolTipChecker;
        private bool _password1ToolTipChecker;
        private bool _password2ToolTipChecker;
        private bool _passwordComparisonToolTipChecker;
        private bool _emailToolTipChecker;

        private readonly string _accountsFilePath =
            @"D://prog//MelonsFinanceManager//MelonsFinanceManager//MelonsFinanceManager//accounts_File.txt";

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Set_TextBox_Unvisible(TextBoxLogin);
            Set_PasswordBox_Unvisible(TextBoxPassword1);
            Set_PasswordBox_Unvisible(TextBoxPassword2);
            Set_TextBox_Unvisible(TextBoxEmail);
            Set_Button_Unvisible(ActionButton);
        }

        public void Set_ToolTip_Visible(ToolTip tp)
        {
            tp.Visibility = Visibility.Visible;
        }

        public void Set_ToolTip_Unvisible(ToolTip tp)
        {
            tp.Visibility = Visibility.Hidden;
        }

        public void Set_TextBox_Visible(TextBox tb)
        {
            tb.Visibility = Visibility.Visible;
        }

        public void Set_TextBox_Unvisible(TextBox tb)
        {
            tb.Visibility = Visibility.Hidden;
        }

        public void Set_PasswordBox_Visible(PasswordBox pb)
        {
            pb.Visibility = Visibility.Visible;
        }

        public void Set_PasswordBox_Unvisible(PasswordBox pb)
        {
            pb.Visibility = Visibility.Hidden;
        }

        public void Set_Button_Visible(Button b)
        {
            b.Visibility = Visibility.Visible;
        }

        public void Set_Button_Unvisible(Button b)
        {
            b.Visibility = Visibility.Hidden;
        }

        public void Reset_TextBoxt_Content(TextBox tb)
        {
            tb.Text = "";
        }

        public void Reset_PasswordBox_Content(PasswordBox pb)
        {
            pb.Password = "";
        }

        public void Set_Button_Content(Button b, string s)
        {
            b.Content = s;
        }

        public void Set_TextBox_Default_Color(TextBox tb)
        {
            tb.Background = Brushes.Lavender;
        }

        public void Set_TextBox_Alert_Color(TextBox tb)
        {
            tb.Background = Brushes.Pink;
        }

        public void Set_PasswordBox_Default_Color(PasswordBox pb)
        {
            pb.Background = Brushes.Lavender;
        }

        public void Set_PasswordBox_Alert_Color(PasswordBox pb)
        {
            pb.Background = Brushes.Pink;
        }

        public void Activate_Checker(bool b)
        {
            b = true;
        }

        public void Deactivate_Checker(bool b)
        {
            b = false;
        }

        public string Get_Button_Content(Button b)
        {
            return (string) b.Content;
        }

        public string Get_TextBox_Content(TextBox tb)
        {
            return (string) tb.Text.Trim().ToLower();
        }

        public string Get_PasswordBox_Content(PasswordBox pb)
        {
            return (string) pb.Password.Trim();
        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            Set_Button_Content(ActionButton, "Зарегестрироваться");
            Set_Button_Visible(ActionButton);

            Reset_TextBoxt_Content(TextBoxLogin);
            Set_TextBox_Visible(TextBoxLogin);

            Reset_PasswordBox_Content(TextBoxPassword1);
            Set_PasswordBox_Visible(TextBoxPassword1);

            Reset_PasswordBox_Content(TextBoxPassword2);
            Set_PasswordBox_Visible(TextBoxPassword2);

            Reset_TextBoxt_Content(TextBoxEmail);
            Set_TextBox_Visible(TextBoxEmail);

            if (_loginToolTipChecker)
            {
                Deactivate_Checker(_loginToolTipChecker);
                Set_ToolTip_Unvisible(_loginToolTip);
            }

            Set_TextBox_Default_Color(TextBoxLogin);

            if (_password1ToolTipChecker)
            {
                Deactivate_Checker(_password1ToolTipChecker);
                Set_ToolTip_Unvisible(_password1ToolTip);
            }

            Set_PasswordBox_Default_Color(TextBoxPassword1);

            if (_password2ToolTipChecker)
            {
                Deactivate_Checker(_password2ToolTipChecker);
                Set_ToolTip_Unvisible(_password2ToolTip);
            }

            Set_PasswordBox_Default_Color(TextBoxPassword2);

            if (_passwordComparisonToolTipChecker)
            {
                Deactivate_Checker(_passwordComparisonToolTipChecker);
                Set_ToolTip_Unvisible(_passwordComparisonToolTip);
            }

            Set_PasswordBox_Default_Color(TextBoxPassword2);

            if (_emailToolTipChecker)
            {
                Deactivate_Checker(_emailToolTipChecker);
                Set_ToolTip_Unvisible(_emailToolTip);
            }

            Set_TextBox_Default_Color(TextBoxEmail);
        }

        private void authorizationButton_Click(object sender, RoutedEventArgs e)
        {
            Set_Button_Content(ActionButton, "Авторизоваться");
            Set_Button_Visible(ActionButton);

            Reset_TextBoxt_Content(TextBoxLogin);
            Set_TextBox_Visible(TextBoxLogin);

            Reset_PasswordBox_Content(TextBoxPassword1);
            Set_PasswordBox_Visible(TextBoxPassword1);

            Reset_PasswordBox_Content(TextBoxPassword2);
            Set_PasswordBox_Unvisible(TextBoxPassword2);

            Reset_TextBoxt_Content(TextBoxEmail);
            Set_TextBox_Unvisible(TextBoxEmail);

            if (_loginToolTipChecker)
            {
                Deactivate_Checker(_loginToolTipChecker);
                Set_ToolTip_Unvisible(_loginToolTip);
            }

            Set_TextBox_Default_Color(TextBoxLogin);

            if (_password1ToolTipChecker)
            {
                Deactivate_Checker(_password1ToolTipChecker);
                Set_ToolTip_Unvisible(_password1ToolTip);
            }

            Set_PasswordBox_Default_Color(TextBoxPassword1);
        }

        private void Action_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Get_Button_Content(ActionButton) == "Авторизоваться")
            {
                Authorization_Action_Button_Click(sender, e);
            }

            if (Get_Button_Content(ActionButton) == "Зарегестрироваться")
            {
                Registration_Action_Button_Click(sender, e);
            }
        }

        private string login = "";
        private string password = "";
        private bool logedIn = false;

        private async void Authorization_Action_Button_Click(object sender, RoutedEventArgs e)
        {
            login = Get_TextBox_Content(TextBoxLogin);
            password = Get_PasswordBox_Content(TextBoxPassword1);
            Dictionary<string, string> postData = new Dictionary<string, string>();
            postData.Add("username", login);
            postData.Add("password", password);
            using (var client = new HttpClient())
            {
                using (var content = new FormUrlEncodedContent(postData))
                {
                    client.BaseAddress = new Uri("http://localhost:8080/");
                    client.DefaultRequestHeaders.Clear();
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    HttpResponseMessage Res = await client.PostAsync("login", content);
                    if (Res.IsSuccessStatusCode)
                    {
                        var Response = Res.Content.ReadAsStringAsync().Result;
                        Tokens tokens = JsonConvert.DeserializeObject<Tokens>(Response);
                        
                        this.Hide();
                        Window1 window1 = new Window1(tokens.refresh_token);
                        window1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неверный логин или пароль");
                    }
                }
            }
        }

        private async void Registration_Action_Button_Click(object sender, RoutedEventArgs e)
        {
            Set_TextBox_Default_Color(TextBoxLogin);
            Set_PasswordBox_Default_Color(TextBoxPassword1);
            Set_PasswordBox_Default_Color(TextBoxPassword2);
            Set_TextBox_Default_Color(TextBoxEmail);

            string login = Get_TextBox_Content(TextBoxLogin);
            string password_1 = Get_PasswordBox_Content(TextBoxPassword1);
            string password_2 = Get_PasswordBox_Content(TextBoxPassword2);
            string email = Get_TextBox_Content(TextBoxEmail);

            if (login.Length < 2)
            {
                Activate_Checker(_loginToolTipChecker);
                _loginToolTip = new ToolTip();
                _loginToolTip.Content = "Это поле введено некорректно!";
                Set_ToolTip_Visible(_loginToolTip);
                TextBoxLogin.ToolTip = _loginToolTip;
                Set_TextBox_Alert_Color(TextBoxLogin);
            }

            else if (login.Length >= 2 && _loginToolTipChecker)
            {
                Set_ToolTip_Unvisible(_loginToolTip);
                Deactivate_Checker(_loginToolTipChecker);
            }

            if (password_2.Length < 8)
            {
                Activate_Checker(_password1ToolTipChecker);
                _password2ToolTip = new ToolTip();
                _password2ToolTip.Content = "Пароль слишком короткий!";
                Set_ToolTip_Visible(_password2ToolTip);
                TextBoxPassword2.ToolTip = _password1ToolTip;
                Set_PasswordBox_Alert_Color(TextBoxPassword2);
            }

            else if (password_2.Length >= 8 && _password2ToolTipChecker)
            {
                Set_ToolTip_Unvisible(_password2ToolTip);
                Deactivate_Checker(_password2ToolTipChecker);
            }

            if (password_1 != password_2)
            {
                Activate_Checker(_passwordComparisonToolTipChecker);
                _passwordComparisonToolTip = new ToolTip();
                _passwordComparisonToolTip.Content = "Пароли не совпадают!";
                Set_ToolTip_Visible(_passwordComparisonToolTip);
                TextBoxPassword2.ToolTip = _passwordComparisonToolTip;
                Set_PasswordBox_Alert_Color(TextBoxPassword2);
            }

            else if (password_1 == password_2 && _passwordComparisonToolTipChecker)
            {
                Set_ToolTip_Unvisible(_passwordComparisonToolTip);
                Deactivate_Checker(_passwordComparisonToolTipChecker);
            }

            if (password_1.Length < 8)
            {
                Activate_Checker(_password1ToolTipChecker);
                _password1ToolTip = new ToolTip();
                _password1ToolTip.Content = "Пароль слишком короткий!";
                Set_ToolTip_Visible(_password1ToolTip);
                TextBoxPassword1.ToolTip = _password1ToolTip;
                Set_PasswordBox_Alert_Color(TextBoxPassword1);
            }

            else if (password_1.Length >= 8 && _password1ToolTipChecker)
            {
                Set_ToolTip_Unvisible(_password1ToolTip);
                Deactivate_Checker(_password1ToolTipChecker);
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                Activate_Checker(_emailToolTipChecker);
                _emailToolTip = new ToolTip();
                _emailToolTip.Content = "Почта введена некорректно!";
                Set_ToolTip_Visible(_emailToolTip);
                TextBoxEmail.ToolTip = _emailToolTip;
                Set_TextBox_Alert_Color(TextBoxEmail);
            }

            else if (email.Contains("@") && email.Contains(".") && _emailToolTipChecker)
            {
                Set_ToolTip_Unvisible(_emailToolTip);
                Deactivate_Checker(_emailToolTipChecker);
            }

            if (password_1 == password_2 && password_1.Length >= 8 && login.Length >= 2 && email.Contains("@") &&
                email.Contains("."))
            {
                Info info = new Info(login, password_1, email);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:8080/");
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.PostAsJsonAsync("users/register", info);
                    if (Res.IsSuccessStatusCode)
                    {
                        MessageBox.Show(login, "Регистрация прошла успешно!");
                    }
                    else
                    {
                        MessageBox.Show(login, "Ошибка регистрации!");
                    }
                }
                
            }
        }

        private void Mellon1_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start(@"C:\Users\kek\AppData\Local\Programs\Opera GX\opera.exe",
                "https://vk.com/biletdovichuganskapozhaluista");
            Process.Start(@"C:\Users\kek\AppData\Local\Programs\Opera GX\opera.exe",
                "https://vk.com/prplcld");
            Process.Start(@"C:\Users\kek\AppData\Local\Programs\Opera GX\opera.exe",
                "https://vk.com/technodwarf");
        }
    }
}