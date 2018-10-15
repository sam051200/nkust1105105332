using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ConsoleApp1.Model;
//1012
namespace ConsoleApp1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("1105105332-張祈安");
            var nodes = findopendata();
            showopendata(nodes);
            Console.ReadKey();
        }

        private static void showopendata(List<Class1> nodes)
        {
            Console.WriteLine(string.Format("共收到{0}筆的資料", nodes.Count));
            for (int i = 0; i < nodes.Count; i++)
            {
                //var message = $"服務分類:{key},共有{groupDatas.Count()}筆資料";
                var message = $"年度[{nodes[i]._y}]\n\t平均年齡-男[{nodes[i]._m}]\n\t平均年齡-女[{nodes[i]._g}]";
                Console.WriteLine(message);
            }
            /*
            nodes.GroupBy(node => node._y).ToList()
                .ForEach(group =>
                {
                    var key = group.Key;
                    var groupDatas = group.ToList();

                });*/
        }
        static List<ConsoleApp1.Model.Class1> findopendata()
        {
            List<ConsoleApp1.Model.Class1> result = new List<Class1>();
            var xml = XElement.Load(@"C:\Users\sam\Desktop\軟體工程\1005\ConsoleApp1\data.xml");
            //var xml = XElement.Load(@"/data.xml");

            var nodes = xml.Descendants("row").ToList();
            /*
            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                ConsoleApp1.Model.Class1 item = new ConsoleApp1.Model.Class1();
                item._y = getvalue(node, "Col1");
                item._m = getvalue(node, "Col2");
                item._g = getvalue(node, "Col3");
                result.Add(item);
            }*/
            nodes.ToList()
                          .ForEach(node =>
                          {
                              Class1 item = new Class1();
                              item._y = getvalue(node, "Col1");
                              item._m = getvalue(node, "Col2");
                              item._g = getvalue(node, "Col3");
                              result.Add(item);
                          });
           
            return result;
        }
        private static string getvalue(XElement node, string v)
        {
            return node.Element(v)?.Value?.Trim();
        }

    }
}
/*nodes.ToList()
               .ForEach(node =>
               {
                   OpenData item = new OpenData();
                   item.id = int.Parse(getValue(node, "id"));
                   item.資料集名稱 = getValue(node, "資料集名稱");
                   item.主要欄位說明 = getValue(node, "主要欄位說明");
                   item.服務分類 = getValue(node, "服務分類");
                   result.Add(item);
               });
*/
/*
result = nodes.ToList()
                .Select(node =>
                {
    OpenData item = new OpenData();

    item.id = int.Parse(getValue(node, "id"));
    item.資料集名稱 = getValue(node, "資料集名稱");
    item.主要欄位說明 = getValue(node, "主要欄位說明");
    item.服務分類 = getValue(node, "服務分類");
    return item;
}).ToList();
result.Where(x => x.服務分類 != null).ToList();
*/