namespace DatabaseApp
{
    class Convert
    {
        public string name { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }

        public override string ToString()
        {
            return "Название: " + name + "\nОписание: " + description + "\nСумма: " + amount;
        }
    }
}