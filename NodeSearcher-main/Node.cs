namespace NodeSearcher
{
    public class Node
    {

        // Properties
        public int Id { get; set; }
        public int Value { get; set; }

        public List<Node> Children { get; } = [];

        // Constructor
        public Node(int id, int value) { Id = id; Value = value; }

        public void Print()
        { 
            Console.WriteLine(Value.ToString());
        }

        public static Node? FindTarget(HashSet<int> visited, Node node, int valueToFind)
        {
            if (node.Value == valueToFind)
            {
                return node;
            }

            foreach (var child in node.Children)
            {
                if (visited.Add(child.Id))
                {
                    var result = FindTarget(visited, child, valueToFind);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }
    }
}
