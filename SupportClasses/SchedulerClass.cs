﻿using MailSendLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace SupportClasses
{
    /// <summary>
    /// Класс планировщик, который создает расписание, следит за его выполнением и напоминает о событиях
    /// Также помогает автоматизировать рассылку писем в соответствии с расписанием
    /// </summary>
    public class SchedulerClass
    {
        DispatcherTimer _timer = new DispatcherTimer(); // таймер
        EmailSendService _emailSender; // экземпляр класса, отвечающего за отправку писем
        DateTime _dtSend; // дата и время отправки
        ObservableCollection<Recepient> _emails; // коллекция email'ов адресатов

        /// <summary>
        /// Метод который превращаем строку из текстбокса tbTimePicker в TimeSpan
        /// </summary>
        /// <param name="strSendTime"></param>
        /// <returns></returns>
        public TimeSpan GetSendTime( string strSendTime )
        {
            TimeSpan tsSendTime = new TimeSpan();
            try
            {
                tsSendTime = TimeSpan.Parse( strSendTime );
            }
            catch
            {
            }

            return tsSendTime;
        }

        /// <summary>
        /// Непосредственно отправка писем
        /// </summary>
        /// <param name="dtSend"></param>
        /// <param name="emailSender"></param>
        /// <param name="emails"></param>
        public void SendEmails( DateTime dtSend, EmailSendService emailSender, ObservableCollection<Recepient> emails )
        {
            _emailSender = emailSender; // Экземпляр класса, отвечающего за отправку писем присваиваем
            _dtSend = dtSend;
            _emails = emails;
            _timer.Tick += Timer_Tick;
            _timer.Interval = new TimeSpan( 0, 0, 1 );
            _timer.Start();
        }

        private void Timer_Tick( object sender, EventArgs e )
        {
            if ( _dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString() )
            {
                _emailSender.SendMailMessages( _emails );
                _timer.Stop();
                MessageBox.Show( "Письма отправлены." );
            }
        }

        Dictionary<DateTime, string> dicDates = new Dictionary<DateTime, string>();

        public Dictionary<DateTime, string> DatesEmailTexts
        {
            get { return dicDates; }
            set
            {
                dicDates = value;
                dicDates = dicDates.OrderBy( pair => pair.Key ).ToDictionary( pair => pair.Key, pair => pair.Value );
            }
        }
    }
}
