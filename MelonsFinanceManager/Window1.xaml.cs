using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MelonsFinanceManager;
using Newtonsoft.Json;

namespace DatabaseApp
{
    public partial class Window1 : Window
    {
        public void CollectGarbage(object obj)
        {
            GC.Collect(GC.GetGeneration(obj));
        }

        public void ClearListViewItems(ListView l)
        {
            l.Items.Clear();
        }
        
        
        public Window1(string access_token)
        {
            InitializeComponent();
            this.WindowState = WindowState.Normal;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            token = access_token;
        }

        private string token;
        private async void Show_Button_Click(object sender, RoutedEventArgs e)
        {
            List<object> list = new List<object>();
            
            switch (SwitchCombobox.SelectedIndex)
            {
                case 1: //средства
                {
                    ClearListViewItems(Listview);
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:8080/");
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage Res = await client.GetAsync("incomes");
                        if (Res.IsSuccessStatusCode)
                        {
                            var Response = Res.Content.ReadAsStringAsync().Result;
                            List<Income> incomes = JsonConvert.DeserializeObject<List<Income>>(Response);
                            foreach (var i in incomes)
                            {
                                Listview.Items.Add(i.ToString());
                            }
                        }
                    }
                    break;
                }
                
                case 0: //расходы
                {
                    Listview.Items.Clear();

                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:8080/");
                        client.DefaultRequestHeaders.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage Res = await client.GetAsync("expenses");
                        if (Res.IsSuccessStatusCode)
                        {
                            var Response = Res.Content.ReadAsStringAsync().Result;
                            List<Expense> expenses = JsonConvert.DeserializeObject<List<Expense>>(Response);
                            foreach (var ex in expenses)
                            {
                                Listview.Items.Add(ex.ToString());
                            }
                        }
                    }
                    
                    break;
                }
            }
            
            list.Clear();
            CollectGarbage(list);
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            AddForm aF = new AddForm(token);
            aF.Show();
        }

        private void MySelectionChanged(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (!Listview.Items.IsEmpty)
            {
                EditForm Ef = new EditForm(Listview.SelectedItem.ToString());
                Ef.Show();
                //MessageBox.Show(Listview.SelectedItem.ToString());
            }
        }

        private void js_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void Converts_Button_Click(object sender, RoutedEventArgs e)
        {
            Listview.Items.Clear();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8080/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage Res = await client.GetAsync("incomes/converts");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    List<Income> incomes = JsonConvert.DeserializeObject<List<Income>>(Response);
                    decimal sum = incomes.Sum(income => income.amount);
                    Convert convert1 = new Convert();
                    convert1.name = "конверт сбережений";
                    convert1.description = "на инвестирование";
                    convert1.amount = sum * (decimal) 0.1;

                    sum = sum * (decimal) 0.9;
                    sum = sum / 4;
                    Convert convert2 = new Convert();
                    convert2.name = "первый конверт";
                    convert2.description = "сумма на первую неделю";
                    convert2.amount = sum;
                    Convert convert3 = new Convert();
                    convert3.name = "второй конверт";
                    convert3.description = "сумма на вторую неделю";
                    convert3.amount = sum;
                    Convert convert4 = new Convert();
                    convert4.name = "третий конверт";
                    convert4.description = "сумма на третью неделю";
                    convert4.amount = sum;
                    Convert convert5 = new Convert();
                    convert5.name = "четвертый конверт";
                    convert5.description = "сумма на четвертую неделю";
                    convert5.amount = sum;
                    Listview.Items.Add(convert1.ToString());
                    Listview.Items.Add(convert2.ToString());
                    Listview.Items.Add(convert3.ToString());
                    Listview.Items.Add(convert4.ToString());
                    Listview.Items.Add(convert5.ToString());
                }
            }
        }
    }
}