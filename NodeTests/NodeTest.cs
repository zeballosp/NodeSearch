using NodeSearcher;

namespace NodeTests
{
    [TestClass]
    public class NodeTest
    {
        [TestMethod]
        public void ValueIsFound_In_CircularGraph()
        {
            Node n1 = new(1);
            Node n2 = new(5);
            Node n3 = new(32);
            Node n4 = new(51);
            Node n5 = new(9);
            Node n6 = new(11);
            Node n7 = new(4);
            Node n8 = new(2);

            n1.Children.Add(n2);
            n1.Children.Add(n3);
            n2.Children.Add(n6);
            n3.Children.Add(n4);
            n3.Children.Add(n5);
            n4.Children.Add(n7);
            n5.Children.Add(n7);
            //Creates a circular graph
            n5.Children.Add(n1);
            n6.Children.Add(n8);
            n7.Children.Add(n8);

            HashSet<Node> hashIds = [];
            Node expectedn8 = new(2);

            var result = Node.FindTarget(hashIds, n2, 2);

            Assert.AreEqual(expectedn8.Value, result?.Value, "Node value");
            Assert.AreEqual(expectedn8.Children.Count, result?.Children.Count, "Node children count");
        }

        [TestMethod]
        public void ValueIsNOTFound_In_CircularGraph()
        {
            Node n1 = new(1);
            Node n2 = new(5);
            Node n3 = new(32);
            Node n4 = new(51);
            Node n5 = new(9);
            Node n6 = new(11);
            Node n7 = new(4);
            Node n8 = new(2);

            n1.Children.Add(n2);
            n1.Children.Add(n3);
            n2.Children.Add(n6);
            n3.Children.Add(n4);
            n3.Children.Add(n5);
            n4.Children.Add(n7);
            n5.Children.Add(n7);
            //Creates a circular graph
            n5.Children.Add(n1);
            n6.Children.Add(n8);
            n7.Children.Add(n8);

            HashSet<Node> hashIds = [];
            Node? expectednullNode = null;
            //Non existing value
            int valueToFind = 1000;

            var result = Node.FindTarget(hashIds, n2, valueToFind);

            Assert.AreEqual(expectednullNode?.Value, result?.Value, "Node value");
            Assert.AreEqual(expectednullNode?.Children.Count, result?.Children.Count, "Node children count");
        }

        [TestMethod]
        public void ValueIsFound_In_NonCircularGraph()
        {
            Node n1 = new(1);
            Node n2 = new(5);
            Node n3 = new(32);
            Node n4 = new(51);
            Node n5 = new(9);

            n1.Children.Add(n2);
            n1.Children.Add(n3);
            n2.Children.Add(n3);
            n3.Children.Add(n4);
            n3.Children.Add(n5);
            n4.Children.Add(n5);

            HashSet<Node> hashIds = [];
            int valueToFind = 32;
            Node expectedn3 = new(valueToFind);
            expectedn3.Children.Add(n4);
            expectedn3.Children.Add(n5);

            var result = Node.FindTarget(hashIds, n1, valueToFind);

            Assert.AreEqual(expectedn3.Value, result?.Value, "Node value");
            Assert.AreEqual(expectedn3.Children.Count, result?.Children.Count, "Node children count");
        }

        [TestMethod]
        public void ValueIsNOTFound_In_NonCircularGraph()
        {
            Node n1 = new(1);
            Node n2 = new(5);
            Node n3 = new(32);
            Node n4 = new(51);
            Node n5 = new(9);

            n1.Children.Add(n2);
            n1.Children.Add(n3);
            n2.Children.Add(n3);
            n3.Children.Add(n4);
            n3.Children.Add(n5);
            n4.Children.Add(n5);

            HashSet<Node> hashIds = [];
            Node? expectednullNode = null;
            //Non existing value
            int valueToFind = 5000;

            var result = Node.FindTarget(hashIds, n3, valueToFind);

            Assert.AreEqual(expectednullNode?.Value, result?.Value, "Node value");
            Assert.AreEqual(expectednullNode?.Children.Count, result?.Children.Count, "Node children count");
        }
    }
}