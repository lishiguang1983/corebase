using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kdb.platform.commons.helper
{
    /// <summary>
    /// 邮件发送Helper
    /// </summary>
    public class EmailHelper
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="dicToEmail"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <param name="fromEmail"></param>
        /// <returns></returns>
        public static bool SendEmail(Dictionary<string, string> dicToEmail, string title, string content, string name = "flyliao", string fromEmail = "", string host = "smtp.qq.com", int port = 587, string userName = "", string userPwd = "")
        {
            var isOk = false;
            try
            {
                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content)) { return isOk; }

                //设置基本信息
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(name, fromEmail));
                foreach (var item in dicToEmail.Keys)
                {
                    message.To.Add(new MailboxAddress(item, dicToEmail[item]));
                }
                message.Subject = title;
                message.Body = new TextPart("html")
                {
                    Text = content
                };

                //链接发送
                using (var client = new SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    //采用qq邮箱服务器发送邮件
                    client.Connect(host, port, false);

                    // Note: since we don't have an OAuth2 token, disable
                    // the XOAUTH2 authentication mechanism.
                    client.AuthenticationMechanisms.Remove("XOAUTH2");

                    //qq邮箱，密码(安全设置短信获取后的密码)  ufiaszkkulbabejh
                    client.Authenticate(userName, userPwd);

                    client.Send(message);
                    client.Disconnect(true);
                }
                isOk = true;
            }
            catch (Exception)
            {

            }
            return isOk;
        }
    }
}
