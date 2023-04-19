namespace FormalConceptAnalysis;

public class Link
{
    public int Id { get; set; }
    public int LinkedTo { get; set;}

    public Link()
    {
        Id = -1;
        LinkedTo = -1;
    }
    
    public Link(int id, int linkedTo)
    {
        Id = id;
        LinkedTo = linkedTo;
    }
}