using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class LineBotWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        const string channelAccessToken = "c8ylZLjfzJ6UlKkigzilaXjZ5UG6l1VSDAnSM1N6tpiOTCP7IvaMQag4YtzT5209TPqfTWmHT3c33j1SwnPbPdaXJFMrMzt5PRk/h/5GWvifIkMIzEoKJoiE5L9cFy9DfxjJ0wSTmx+r5YhC4g0REgdB04t89/1O/w1cDnyilFU=";
        const string AdminUserId= "U5a14415c05f1250f6841bc879f4129de";
        const string LuisAppId = "8958572a-d95b-45b3-a857-b7fdfabff7d0";
        const string LuisAppKey = "d2fdf5f8f15e4447876bfcd0632634e2";
        const string Luisdomain = "westus";

        [Route("api/LineWebHookSample")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //設定ChannelAccessToken(或抓取Web.Config)
                this.ChannelAccessToken = channelAccessToken;
                //取得Line Event(範例，只取第一個)
                var LineEvent = this.ReceivedMessage.events.FirstOrDefault();
                //配合Line verify 
                if (LineEvent.replyToken == "00000000000000000000000000000000") return Ok();
                //回覆訊息
                if (LineEvent.type == "message")
                {
                    if (LineEvent.message.type == "text") //收到文字
                    {
                        
                        string repmsg = "";
                        
                        //建立LuisClient
                        Microsoft.Cognitive.LUIS.LuisClient lc = new Microsoft.Cognitive.LUIS.LuisClient(LuisAppId, LuisAppKey, true, Luisdomain);
                        //Call Luis API 查詢
                        var ret = lc.Predict(LineEvent.message.text).Result;
                        if (ret.Intents.Count() <= 0)
                            repmsg = $"你說了 '{LineEvent.message.text}' ，但我看不懂喔!";
                        else if (ret.TopScoringIntent.Name == "None")
                            repmsg = $"你說了 '{LineEvent.message.text}' ，但不在我的服務範圍內喔!";
                        else
                        {
                            repmsg = $"你想的是 '{ret.TopScoringIntent.Name}'";
                            if (ret.Entities.Count > 0)
                            {
                                foreach(var item in ret.Entities)
                                {
                                    repmsg += $"\n關鍵字 '{ item.Key  }'  ,  '{ item.Value.FirstOrDefault().Value}' ";
                                    
                                }
                            }
                               // repmsg += $"想要的是 '{ ret.Entities.FirstOrDefault().Value.FirstOrDefault().Value}' ";
                        }
                        

                        
                        bool flag = true;
                        /*
                        var repo = new Finance();
                        var UserInput = LineEvent.message.text;
                        if(UserInput.Substring(0,4) == "我要記帳")
                        {
                            try
                            {
                            
                            var n = UserInput.Split(',');
                            var accounting = new Accounting();

                            accounting.MemberID = 1;
                            accounting.AccountingName = n[1];
                                string format = "yyyy-MM-dd HH:mm:ss";

                                accounting.AccountingTime = DateTime.ParseExact(n[2], "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces);
                                accounting.AccountingCost = Convert.ToDecimal(n[3]);


                                repo.AccountingToDatabase(accounting);
                                repmsg = "你記錄了:" + accounting.AccountingName + " " + accounting.AccountingCost + " 元 , 在 " + accounting.AccountingTime + "購買的";

                            }
                            catch
                            {
                                repmsg = "紀錄時發生錯誤";
                            }
                        }
                        else if(UserInput.Substring(0, 8) == "我要查詢所有紀錄")
                        {
                            try
                            {
                                var result = repo.GetAllRecord();
                                foreach(var item in result)
                                {
                                    repmsg = "購買了:" + item.AccountingName + " " + item.AccountingCost + " 元 , 在 " + item.AccountingTime + "購買的";
                                    this.PushMessage(AdminUserId, repmsg);
                                    flag = false;
                                }
                            }
                            catch
                            {
                                repmsg = "查詢時發生錯誤 , 可能是您沒有紀錄";
                            }
                        }
                        else
                        {
                            repmsg = $"你說了 '{LineEvent.message.text}' ，但不在我的服務範圍內喔!";
                        }
                        */

                        //回覆
                        if(flag)
                        {
                            this.PushMessage(AdminUserId, repmsg);
                        }
                        
                    }

                    if (LineEvent.message.type == "sticker") //收到貼圖
                        this.ReplyMessage(LineEvent.replyToken, 1, 2);
                    if (LineEvent.message.type == "location")
                        this.ReplyMessage(LineEvent.replyToken, $"你的位置在\n{LineEvent.message.latitude} , {LineEvent.message.longitude} , {LineEvent.message.address}");
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //如果發生錯誤，傳訊息給Admin
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}
