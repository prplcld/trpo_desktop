using System.Windows;

namespace MelonsFinanceManager
{
    public partial class EditForm : Window 
    {
        public EditForm(string s)
        {
            InitializeComponent();
            this.WindowState = WindowState.Normal;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.HorizontalAlignment = HorizontalAlignment.Right;
            //Tb.Text = s;
            var temp = s.Split(",");
            foreach (var t in temp)
            {
                tb1.Text += t;
            }
        }


        private void _1button_OnClick(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}