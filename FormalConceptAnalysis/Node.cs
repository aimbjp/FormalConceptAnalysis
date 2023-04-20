namespace FormalConceptAnalysis;

public class Node
{
    public List<int> Objects { get; set; }
    public List<int> Attributes { get; set; }
    public int Id { get; set; }
    // public List<int> ParentsId { get; set; }
    // public List<int> Children { get; set; }

    public Node()
    {
        Objects = new List<int>();
        Attributes = new List<int>();
        Id = -1;
        // ParentsId = new List<int>();
        // Children = new List<int>();
    }
    
    public Node(List<int> Objects, List<int> Attributes, int ID)
    {
        this.Objects = Objects;
        this.Attributes = Attributes;
        this.Id = ID;
        // this.ParentsId = ParentID;
        // this.Children = Childrens;
    }

    
}