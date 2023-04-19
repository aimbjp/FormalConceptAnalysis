namespace FormalConceptAnalysis;
[Serializable]
public class Lattice
{
    public Node[] nodes;
    public Link[] links;

    public Lattice(FormalContext formalContext, string algorithm)
    {
        switch (algorithm.ToLower())
        {
            case "addatom":
                AddAtom(formalContext);
                break;
            case "addintent":
                AddIntent(formalContext);
                break;
            case "1": 
                AddAtom(formalContext);
                break;
            case "2":
                AddIntent(formalContext);
                break;
        }
    }

    private void AddAtom(FormalContext formalContext)
    {
        throw new NotImplementedException();
    }

    private void AddIntent(FormalContext formalContext)
    {
        throw new NotImplementedException();
    }
}