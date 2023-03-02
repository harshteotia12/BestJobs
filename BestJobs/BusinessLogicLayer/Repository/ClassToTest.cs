using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class ClassToTest
    {
        public (int,int) Add(int a, int b)
        {
            return (a + b,a+b);
        }
        public List<int> ListSquareMethod(List<int> list)
        {
            list = list.Select(x=>x*x).ToList();
            return list;
        }
        public string NameChechker(string name)
        {
            if(name == null)
            {
                throw new ArgumentNullException(name);
            }
            else
                return name;
        }
    }
}
