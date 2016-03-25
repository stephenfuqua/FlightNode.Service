﻿using System;

namespace FlightNode.Common.Utility
{
    public interface IEmailNotifier
    {
        void Send(NotificationModel notification);
    }

    /// <summary>
    /// A simple adapter for sending e-mail to individuals.
    /// </summary>
    public class EmailNotifier : IEmailNotifier
    {
        private readonly IEmailFactory _factory;

        public EmailNotifier(IEmailFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("factory");
            }

            _factory = factory;
        }

        /// <summary>
        /// Performs an asynchronous e-mail delivery.
        /// </summary>
        /// <param name="notification">E-mail parameters and content</param>
        /// <returns>A <see cref="Task"/></returns>
        public void Send(NotificationModel notification)
        {
            var message = _factory.CreateMessage();
            message.AddTo(notification.To);
            message.From = new System.Net.Mail.MailAddress(notification.FromEmail, notification.FromName);
            message.Subject = notification.Subject;
            message.Text = notification.Body;


            var transportWeb = _factory.CreateTransport();

            transportWeb.DeliverAsync(message);
        }
    }

}
