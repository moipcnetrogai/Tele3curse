namespace Tele3.Pages
{
    internal class ClientService
    {
        public string name
        {
            get
            {
                return  name;
            }
        }
        public string cost
        {
            get
            {
                return "Цена: " + cost.ToString() + "р.";
            }
        }
        public string minutes
        {
            get
            {
                return "Минуты: " + minutes.ToString();
            }
        }
        public string internet
        {
            get
            {
                return "Интернет: " + internet.ToString() + "Гб.";
            }
        }
        public string messages
        {
            get
            {
                return "Сообщения " + messages;
            }
        }
        public string about
        {
            get
            {
                return about;
            }
        }
    }
}