using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ConsoleApp1.source
{
    class Class2
    {
      
        public  List<ConsoleApp1.Model.Class1> findopendata()
        {
            List<ConsoleApp1.Model.Class1> result = new List<Class1>();
            var xml = XElement.Load(@"C:\Users\sam\Desktop\軟體工程\1005\ConsoleApp1\data.xml");
            //var xml = XElement.Load(@"/data.xml");

            var nodes = xml.Descendants("row").ToList();

            for (var i = 0; i < nodes.Count; i++)
            {
                var node = nodes[i];
                ConsoleApp1.Model.Class1 item = new ConsoleApp1.Model.Class1();
                item._y = getvalue(node, "Col1");
                item._m = getvalue(node, "Col2");
                item._g = getvalue(node, "Col3");
                result.Add(item);
            }
            return result;
        }
        public void ImportToDb(List<Class1> openDatas)
        {
            Repository.OpenDataReository Repository = new Repository.OpenDataReository();
            openDatas.ForEach(item =>
            {
                Repository.Insert(item);
            });
        }
        private static string getvalue(XElement node, string v)
        {
            return node.Element(v)?.Value?.Trim();
        }
    }
}
