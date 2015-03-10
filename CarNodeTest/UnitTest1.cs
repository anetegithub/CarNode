using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarNodeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FindPathGraph()
        {
            //2 3 5 4 6
            List<Tuple<string, string, int>> nodes = new List<Tuple<string, string, int>>();
            nodes.Add(new Tuple<string, string, int>((2).ToString(), (3).ToString(), 5));
            nodes.Add(new Tuple<string, string, int>((3).ToString(), (5).ToString(), 3));
            nodes.Add(new Tuple<string, string, int>((4).ToString(), (6).ToString(), 4));
            nodes.Add(new Tuple<string, string, int>((5).ToString(), (4).ToString(), 4));
            nodes.Add(new Tuple<string, string, int>((6).ToString(), (0).ToString(), 4));


            var path = CarNode.Alg.GetShortPath("2", "6", nodes);

            Assert.AreEqual(5, path.Count);
            Assert.AreEqual((2).ToString(), path[0]);
            Assert.AreEqual((3).ToString(), path[1]);
            Assert.AreEqual((5).ToString(), path[2]);
            Assert.AreEqual((4).ToString(), path[3]);
            Assert.AreEqual((6).ToString(), path[4]);
        }
    }
}
