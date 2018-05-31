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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(accessToken);
            bot.PushMessage("U5a14415c05f1250f6841bc879f4129de", "testMessage");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(accessToken);
            bot.PushMessage("U5a14415c05f1250f6841bc879f4129de", 2, 20);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(accessToken);
            bot.PushMessage("U5a14415c05f1250f6841bc879f4129de", new Uri("https://imagelab.nownews.com/?w=1080&q=85&src=https://rssimg.nownews.com/images/597014b70dedeb01b4cf409f_201707201025.png"));
        }
    }
}