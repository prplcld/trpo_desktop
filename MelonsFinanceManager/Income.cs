using System;

namespace DatabaseApp
{
    class Income 
    {
        public Income(int id, decimal amount, DateTime date, string currency)
        {
            this.id = id;
            this.amount = amount;
            this.date = date;
            this.currency = currency;
        }

        public Income()
        {
        }

        public int id { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public string currency { get; set; }
        
        public override string ToString()
        {
            return "Айди: " + id + "\nКолличество: " + amount + "\nВалюта: " + currency+ "\nДата: " + date;
        }
    }
}
