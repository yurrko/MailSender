﻿using System;
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

        DispatcherTimer timer = new DispatcherTimer(); // таймер
        EmailSendServiceClass emailSender ; // экземпляр класса, отвечающего за отправку писем
        DateTime dtSend ; // дата и время отправки
        IQueryable<Recepient> emails ; // коллекция email'ов адресатов
                                        /// <summary>
                                        /// Методе который превращаем строку из текстбокса tbTimePicker в TimeSpan
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
            catch { }
            return tsSendTime;
        }
        /// <summary>
        //// Непосредственно отправка писем
        /// </summary>
        /// <param name="dtSend"></param>
        /// <param name="emailSender"></param>
        /// <param name="emails"></param>
        public void SendEmails( DateTime dtSend, EmailSendServiceClass emailSender, IQueryable<Recepient> emails )
        {
            this.emailSender = emailSender; // Экземпляр класса, отвечающего за отправку писем присваиваем
            this.dtSend = dtSend;
            this.emails = emails;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan( 0, 0, 1 );
            timer.Start();
        }
        private void Timer_Tick( object sender, EventArgs e )
        {
            if ( dtSend.ToShortTimeString() == DateTime.Now.ToShortTimeString() )
            {
                emailSender.SendMailMessages( emails );
                timer.Stop();
                MessageBox.Show( "Письма отправлены." );
            }
        }
    }
}
