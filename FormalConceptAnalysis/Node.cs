namespace FormalConceptAnalysis;

public abstract class Node
{
    public List<int> Objects { get; set; }
    public List<int> Attributes { get; set; }
    public int Id { get; set; }
    public int ParentId { get; set; }
    public List<int> Children { get; set; }

    public Node()
    {
        Objects = new List<int>();
        Attributes = new List<int>();
        Id = -1;
        ParentId = -1;
        Children = new List<int>();
    }
    
    public Node(List<int> Objects, List<int> Attributes, int ID, int ParentID, List<int> Childrens)
    {
        this.Objects = Objects;
        this.Attributes = Attributes;
        this.Id = ID;
        this.ParentId = ParentID;
        this.Children = Childrens;
    }

    
}