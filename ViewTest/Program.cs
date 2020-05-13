using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GX;
using Newtonsoft.Json;
using Table;

namespace ViewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var level = -1;
            var enemyCount = -1;
            while (level == -1 || enemyCount == -1)
            {
                Console.WriteLine("请输入等级！");
                if (int.TryParse(Console.ReadLine(), out level) == false)
                    Console.WriteLine("请输入数字！");
                Console.WriteLine("请输入敌人总数！");
                if (int.TryParse(Console.ReadLine(), out enemyCount) == false)
                    Console.WriteLine("请输入数字！");
            }
            JsonExtension.SetJsonHelper(new JsonHelper());
            var path = "D://Dev//ViewTest_20200512//ViewTest//table.TestTable.json";
            if (File.Exists(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                using (var sm = new StreamReader(path))
                {
                    //var str = sm.ReadToEnd();
                    //var obj = JsonConvert.DeserializeObject<TestTable>(str, new MyJsonConverter());
                    Console.Write("");
                }
            }
            else
            {
                Console.WriteLine("文件不存在，检查文件路径！");
                Console.ReadKey();
            }
        }
    }

    public class MyJsonConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }

}
