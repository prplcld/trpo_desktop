using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Windows;
using DatabaseApp;
using Newtonsoft.Json;

namespace MelonsFinanceManager
{
    public partial class AddForm : Window
    {
        private string token = "";

        public AddForm(string token_)
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            token = token_;
        }

        private async void _2button_OnClick(object sender, RoutedEventArgs e)
        {
            switch (AddFormSwitchCombobox.SelectedIndex)
            {
                case 1: //в дропбоксе выбраны средства
                {
                    Income income = new Income();
                    income.amount = Decimal.Parse(tb2.Text);
                    income.currency = tb3.Text;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:8080/");
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage Res = await client.PostAsJsonAsync("incomes", income);
                    }
                    break;
                }

                case 0: //в дропбоксе выбраны расходы
                {
                    Expense expense = new Expense();
                    expense.amount = Decimal.Parse(tb2.Text);
                    expense.description = tb3.Text;
                    expense.location = tb4.Text;
                    expense.currency = tb5.Text;
                    expense.category = tb6.Text;
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:8080/");
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage Res = await client.PostAsJsonAsync("expenses", expense);
                    }
                    break;
                }
            }

            this.Close();
        }

        private void Ac_button_OnClick(object sender, RoutedEventArgs e)
        {
            switch (AddFormSwitchCombobox.SelectedIndex)
            {
                case 1: //в дропбоксе выбраны средства
                {
                    //3
                    button2.Content = "Добавить денежное поступление на счёт";
                    tb2label.Content = "Сумма";
                    tb3label.Content = "Валюта";
                    //дату выставлять автоматически при добавлении
                    tb4.Visibility = Visibility.Hidden;
                    tb4label.Visibility = Visibility.Hidden;
                    tb5label.Visibility = Visibility.Hidden;
                    tb5.Visibility = Visibility.Hidden;
                    tb6label.Visibility = Visibility.Hidden;
                    tb6.Visibility = Visibility.Hidden;
                    
                    break;
                }

                case 0: //в дропбоксе выбраны расходы
                {
                    //5
                    tb2label.Content = "Колличество";
                    tb3label.Content = "Описание";
                    tb4label.Content = "Место";
                    tb5label.Content = "Валюта";
                    tb6label.Content = "Категория";
                    button2.Content = "Добавить расходы";
                    tb4.Visibility = Visibility.Visible;
                    tb4label.Visibility = Visibility.Visible;
                    tb5label.Visibility = Visibility.Visible;
                    tb5.Visibility = Visibility.Visible;
                    tb6label.Visibility = Visibility.Visible;
                    tb6.Visibility = Visibility.Visible;
                    break;
                }
                    
            }
        }
    }
}