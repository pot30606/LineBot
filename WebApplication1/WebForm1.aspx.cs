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
        private string yochen = "Uac8806571d495b1f45a8d06aa5c36c6f";
        private string yochenIssue = "3bd8MF8wWILK1f3yP4Ls146W6eo5ruNHYmGVQL7ahheyx221uYH222gnZeBRUeIS0myJe49Ld3LSonbyEUv6NbsS9iSDLVC9HrGxfPr3hbF39SIPI2sULfBcxD0QaELXdq0sozA+cZgAfL9jvep3ZQdB04t89/1O/w1cDnyilFU=";
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
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(yochenIssue);
            bot.PushMessage(yochen, new Uri("https://img.appledaily.com.tw/images/ReNews/20160418/640_e30054f5853ecc3409611a0f3f3ab25f.jpg"));
        }
    }
}