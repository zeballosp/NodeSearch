using NodeSearcher;

namespace FindNodeCSharp
{
    public class Program
    {
        static void Main()
        {
            Node n1 = new(1,1);
            Node n2 = new(2,5);
            Node n3 = new(3,32);
            Node n4 = new(4,51);
            Node n5 = new(5,9);
            Node n6 = new(6,11);
            Node n7 = new(7,4);
            Node n8 = new(8,2);

            n1.Children.Add(n2);
            n1.Children.Add(n3);
            n2.Children.Add(n6);
            n3.Children.Add(n4);
            n3.Children.Add(n5);
            n4.Children.Add(n7);
            n5.Children.Add(n7);
            n5.Children.Add(n1);
            n6.Children.Add(n8);
            n7.Children.Add(n8);

            HashSet<int> hashIds = [];
            var result = Node.FindTarget(hashIds, n2, 2);

            if (result != null)
            {
                Console.WriteLine(result.ToString());
            }
            else
            {
                Console.WriteLine("Value not found");
            }
        }

    }
}
