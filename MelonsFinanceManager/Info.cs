namespace DatabaseApp
{
    class Info
    {
        public Info(string username, string password, string email)
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }

        public string username
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
        public string email{
            get;
            set;
        }
    }
}