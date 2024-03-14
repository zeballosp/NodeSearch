namespace NodeSearcher
{
    public class Node
    {

        // Properties
        public int Value { get; set; }

        public List<Node> Children { get; } = [];

        // Constructor
        public Node(int value) { Value = value; }
        public override string ToString()
        {
            return Value.ToString();
        }

        public static Node? FindTarget(HashSet<Node> visited, Node node, int valueToFind)
        {
            if (node.Value == valueToFind)
            {
                return node;
            }

            foreach (var child in node.Children)
            {
                if (visited.Add(child))
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
