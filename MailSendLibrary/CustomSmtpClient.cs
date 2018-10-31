using System.Collections.ObjectModel;

namespace MailSendLibrary
{
    public class MailServers
    {
        public static readonly ObservableCollection<CustomSmtpClient> Servers = new ObservableCollection<CustomSmtpClient>(new[]
        {
            new CustomSmtpClient("Yandex","smtp.yandex.ru", 25),
            new CustomSmtpClient("Google","smtp.gmail.com", 58),
            new CustomSmtpClient("MailRu","smtp.mail.ruu", 25),
        });
    }

    public class CustomSmtpClient
    {
        public string Name { get; private set; }
        public string SmtpServer { get; private set; }
        public int Port { get; private set; }

        public CustomSmtpClient( string name, string smtpServer, int port )
        {
            Name = name;
            SmtpServer = smtpServer;
            Port = port;
        }
    }
}
