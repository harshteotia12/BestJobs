using BusinessLogicLayer.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace xUnitRepoTest
{
    public class HrRepoTest
    {
        public ClassToTest classToTest;

        [Theory]
        [InlineData(2,3,5)]
        [InlineData(int.MaxValue,0,int.MaxValue)]

        public void Add_simpleAddTest(int a, int b, int c)
        {
            classToTest = new ClassToTest();
            var act = classToTest.Add(a, b);
            Assert.Equal(c, act.Item1);
        }
        public List<int> SquareGenerator(List<int> list)
        {
            for(int i = 0; i < list.Count; i++) 
            {
                list[i]=list[i]*list[i];
            }
            return list;
        }
        [Fact]
        public void Test_ListSquareMethod()
        {
            classToTest = new ClassToTest();
            var exp = SquareGenerator(new List<int> { 1, 2, 3, 4, 5 });
            var actual = classToTest.ListSquareMethod(new List<int> { 1, 2, 3, 4, 5 });
            Assert.Equal(exp.Count,actual.Count);
            for(int i = 0; i < exp.Count; i++)
            {
                Assert.Equal(exp[i],actual[i]);
            }
        }
        [Fact]
        public void Name_isNullCheckTest()
        {
            classToTest = new ClassToTest();
            string name = "harsh";
            Assert.Throws<ArgumentNullException>(()=>classToTest.NameChechker(name));
        }

    }
}
