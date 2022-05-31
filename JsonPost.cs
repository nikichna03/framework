using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Test2.sourse
{
    internal class JsonPost
    {
        public string way;
        public JsonPost(string Way) 
        {
            this.way = Way; 
        }

        public struct Info
        {
            public string Email;
            public string Password;
            public string Recipient;
        }

        public string JsonMail(int num, int mailinfonum)
        {
            Info info = new Info();
            using (StreamReader jsonread = new StreamReader(way))
            {
                string json = jsonread.ReadToEnd();
                List<Info> items = JsonConvert.DeserializeObject<List<Info>>(json);

                switch (way)
                {
                    case "jsonMail.json":
                        info.Recipient = items[num].Recipient.ToString();
                        goto case "jsonShop";
                    case "jsonShop":
                        info.Email = items[num].Email.ToString();
                        info.Password = items[num].Password.ToString();
                        break;          
                }
            }
            switch (mailinfonum)
            {
                case 0:
                    return info.Email;
                case 1:
                    return info.Password;
                case 2:
                    return info.Recipient;
            }
            return null;
        }
    }
}
