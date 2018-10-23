using System.Collections.Generic;

namespace Denisevich_MailSender.SupportClasses
{
    public static class MyConst
    {
        public static readonly CustomSmtpClient Yandex = new CustomSmtpClient("smtp.yandex.ru", 25);
        public static readonly CustomSmtpClient Google = new CustomSmtpClient("smtp.gmail.com", 58);
        public static readonly CustomSmtpClient MailRu = new CustomSmtpClient("smtp.mail.ru", 25);

        public const string MailSubject = "Тема письма";
        public const string MailBody = "Текст письма";

        public const string MailSender = "yurrko@yandex.ru";
        public static readonly List<string> AddressList = new List<string>()
        {
            "x-play-scooby@mail.ru",
            "iyurrko@mail.ru",
        };

        public const string ErrorMessage = "Произошла ошибка";

        public const string Success = "Письмо успешно отправлено";
    }
}
