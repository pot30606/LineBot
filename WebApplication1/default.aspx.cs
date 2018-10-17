using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _default : System.Web.UI.Page
    {
        const string channelAccessToken = "c8ylZLjfzJ6UlKkigzilaXjZ5UG6l1VSDAnSM1N6tpiOTCP7IvaMQag4YtzT5209TPqfTWmHT3c33j1SwnPbPdaXJFMrMzt5PRk/h/5GWvifIkMIzEoKJoiE5L9cFy9DfxjJ0wSTmx+r5YhC4g0REgdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId = "U5a14415c05f1250f6841bc879f4129de";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, $"測試 {DateTime.Now.ToString()} ! ");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            bot.PushMessage(AdminUserId, 1,2);
        }
    }
}