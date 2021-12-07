using System;

namespace DatabaseApp
{
    public class Expense
    {
        public Expense(int id, decimal amount, string description, string location, DateTime date, string currency, string category, string username)
        {
            this.id = id;
            this.amount = amount;
            this.description = description;
            this.location = location;
            this.date = date;
            this.currency = currency;
            this.category = category;
            this.username = username;
        }

        public Expense()
        {
        }

        public int id { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public DateTime date { get; set; }
        public string currency { get; set; }
        public string category { get; set; }
        public string username{ get; set; }
        
        public override string ToString()
        {
            return "Id: " + id+ "\nОписание: " + description + "\nКоличество: " + amount + "\nВалюта: " + currency + "\nДата: " + date + "\nМесто: " + location + "\nКатегория: " + category;
        }
    }
}