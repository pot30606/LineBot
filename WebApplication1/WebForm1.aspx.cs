using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string accessToken = ConfigurationManager.AppSettings["Line:ChannelAccessToken"];
        private string anonymous = "U3c2655e0d3e1e331fe35df961eaa070b";
        private string anonymousIssue = "yFDByTuynZGQnMEe7cUXmGWwkNIJpWzFEREFUtbLEj8NU2jXjgdYPyo29fsC/40A4eOXWxf2mmAfCLN7bkCRxvnzi5YeQMysj5cit9LG0z0eIjIgIiow77XFJwHsPMbKMvw3sXKoANx5XlDoLNUDowdB04t89/1O/w1cDnyilFU=";
        private string myapp = "U5a14415c05f1250f6841bc879f4129de";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(accessToken);
            bot.PushMessage(myapp, "testMessage");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(accessToken);
            bot.PushMessage(myapp, 2, 20);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(anonymousIssue);
            bot.PushMessage(anonymous, new Uri("https://img.appledaily.com.tw/images/ReNews/20160418/640_e30054f5853ecc3409611a0f3f3ab25f.jpg"));
        }
    }
}