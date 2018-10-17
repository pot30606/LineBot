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
        private string anonymous = "U99cad2819e3b6a3903ca2ee9882e58a0";
        private string anonymousIssue = "6h94g9LnHeVJ9LHD/b3bnwq1KNMiOXVeLbCtG/IjVNjnMi6zIXiDJl7+sF7NPoW+hbj5hp4pu+Fshh442TfM5QAa8nMhndeOLpLFPo/gxkQiFzrcZqyhEJqVp6hBsfNeg1uo5g+nyeJR+UrH08wyQAdB04t89/1O/w1cDnyilFU=";
        private string anonymousJason = "U6f0f1251d93a2f88ace156d3d2db8b38";
        private string anonymousIssueJason = "szHHj+oEk9xaifXctnOSAzYCmbl8zSl9ZchX8umeUrDheBZGlIYypyrvRcDWBampHVOFrSak7odcN9937f3PEO4DtQ+Lhg1TNZGwG5Eer5PURst4U++NglfOIx8uwk/XnPEzwr7xAaJo8Os0rrIxQAdB04t89/1O/w1cDnyilFU=";
        private string myapp = "U5a14415c05f1250f6841bc879f4129de";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(anonymousIssue);
            bot.PushMessage(anonymous, "testMessage");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(anonymousIssue);
            bot.PushMessage(anonymous, 2, 20);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(anonymousIssue);
            bot.PushMessage(anonymous, new Uri("https://img.appledaily.com.tw/images/ReNews/20160418/640_e30054f5853ecc3409611a0f3f3ab25f.jpg"));
        }
    }
}