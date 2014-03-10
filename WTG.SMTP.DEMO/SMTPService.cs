using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using WTG.SMTP;

namespace WTG.SMTP.DEMO
{
    public partial class SMTPService : ServiceBase
    {
        private SmtpServer SmtpServer;
        
        public SMTPService()
        {
            InitializeComponent();
            this.ServiceName = "SMTPService";
        }

        private void CreateSMTP()
        {
            SmtpServer = new SmtpServer("localhost.com", IPAddress.Parse("127.0.0.1"));
            SmtpServer.MailReceived += MailReceived;
            SmtpServer.StartListener(25);
        }

        private void MailReceived(object sender, MailReceivedEventArgs e)
        {
            var sb = new StringBuilder();
            sb.AppendLine("ToAddress: " + e.Mail.To.Address);
            sb.AppendLine("FromAddress: " + e.Mail.From.Address);
            sb.AppendLine("ReceivedTime: " + DateTime.Now.ToString());
            sb.AppendLine("Data ----------------------------");
            sb.Append(e.Mail.RawMailData);
            File.WriteAllText("C:\\SMTP\\Mails\\" + Guid.NewGuid().ToString() + ".txt" , sb.ToString()); 
        }

        protected override void OnStart(string[] args)
        {
            CreateSMTP();
        }

        protected override void OnStop()
        {
            SmtpServer.Stop();
        }


    }
}
