using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Net;

namespace PPLTestMonitor.ClassLib
{
    public class MailServer
    {
        #region global Variable
        private List<string> receiveAddresses;
        /// <summary>
        /// mail list
        /// <summary>
        public List<string> ReceiveAddresses
        {
            get { return receiveAddresses; }
            set { receiveAddresses = value; }
        }
        private string ccAddress;
        /// <summary>
        /// cc list
        /// </summary>
        public string CcAddress
        {
            get { return ccAddress; }
            set { ccAddress = value; }
        }
        private string senderAddress;
        /// <summary>
        /// sender
        /// </summary>
        public string SenderAddress
        {
            get { return senderAddress; }
            set { senderAddress = value; }
        }
        private string mailSubject;
        /// <summary>
        /// mail subject
        /// </summary>
        public string MailSubject
        {
            get { return mailSubject; }
            set { mailSubject = value; }
        }
        private string mailContent;
        /// <summary>
        /// content
        /// </summary>
        public string MailContent
        {
            get { return mailContent; }
            set { mailContent = value; }
        }
        private string smtpHost;
        /// <summary>
        /// SMTP host
        /// </summary>
        public string SmtpHost
        {
            get { return smtpHost; }
            set { smtpHost = value; }
        }
        private int smtpPort;
        /// <summary>
        /// SMTP port
        /// </summary>
        public int SmtpPort
        {
            get { return smtpPort; }
            set { smtpPort = value; }
        }
        private string smtpPassword;
        /// <summary>
        /// SMTP password
        /// </summary>
        public string Password
        {
            get { return smtpPassword; }
            set { this.smtpPassword = value; }
        }
        #endregion

        public MailServer()
        {
            this.senderAddress = PPLTestMonitor.Properties.mySettings.Default.SmtpUser;
            this.smtpPassword = PPLTestMonitor.Properties.mySettings.Default.SmtpPassword;
            this.smtpHost = PPLTestMonitor.Properties.mySettings.Default.SmtpHost;
            this.smtpPort = PPLTestMonitor.Properties.mySettings.Default.SmtpPort;
            this.ccAddress = PPLTestMonitor.Properties.mySettings.Default.CcAddress;
            this.receiveAddresses = new List<string>();


            //this.receiveAddresses.Add("clabrie@pcgus.com");
            //this.receiveAddresses.Add("jliu@pcgus.com");
            //this.receiveAddresses.Add("emarchion@pcgus.com");
            //this.receiveAddresses.Add("kvempati@pcgus.com");
            //this.receiveAddresses.Add("twexler@pcgus.com");
            //this.receiveAddresses.Add("kgerg@pcgus.com");
            //this.receiveAddresses.Add("vewell@pcgus.com");
            this.receiveAddresses.Add("du_weigang@hoperun.com");
            this.receiveAddresses.Add("jiang_xiaoping@hoperun.com");

        }
        ~MailServer()
        {
        }

        public bool sendMail(string subject, string content)
        {
            if (sendMail(this.receiveAddresses,subject, content))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// send mail
        /// </summary>
        /// <param name="receiverAddess">mail list</param>
        /// <param name="subject">mail subject</param>
        /// <param name="content">mail body</param>
        public bool sendMail(List<string> _receiverAddress, string _subject, string _content)
        {
            if (_receiverAddress.Count < 1)
            {
                return false;
            }
            this.receiveAddresses = _receiverAddress;
            this.mailSubject = _subject;
            this.mailContent = _content;

            #region sending mail
            MailMessage mailMessage = new MailMessage();
            foreach (string adress in receiveAddresses)
            {
                mailMessage.To.Add(adress);
            }
            mailMessage.From = new MailAddress(senderAddress, "HoperunQA PPL");
            mailMessage.Subject = this.mailSubject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = this.mailContent;
            mailMessage.CC.Add(this.ccAddress);
            SmtpClient mailServer = new SmtpClient(this.smtpHost, this.smtpPort);//实例化一个SmtpClient 
            //SmtpClient mailServer = new SmtpClient(this.smtpHost);//实例化一个SmtpClient 
            mailServer.EnableSsl = true;//smtp服务器是否启用SSL加密
            mailServer.Credentials = new NetworkCredential(this.senderAddress, this.smtpPassword);
            try
            {
                mailServer.Send(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
            mailMessage.Dispose();
            //mailMessage.IsBodyHtml = true; //邮件正文是否是HTML格式 
            //mailMessage.BodyEncoding = Encoding.GetEncoding(936); 
            ////邮件正文的编码， 设置不正确， 接收者会收到乱码 
            //mailMessage.Body = "<font color="red">邮件测试，呵呵</font>"; 
            ////邮件正文
            //mailMessage.Attachments.Add( new Attachment( @"d:\a.doc", System.Net.Mime.MediaTypeNames.Application.Rtf ) ); 
            ////添加附件，第二个参数，表示附件的文件类型，可以不用指定 
            ////可以添加多个附件 
            //mailMessage.Attachments.Add( new Attachment( @"d:b.doc") );
            //smtp.Send( mailMessage ); //发送邮件，如果不返回异常

            #endregion
        }
    }
}
