namespace FormalConceptAnalysis;

public class FormalContext
{
    /// <summary>
    /// Structures for keeping information about formal context.
    /// </summary>
    internal string[] ObjectsNames { get; set; }
    internal string[] AttributeNames { get; set; }
    internal string[] Incidence { get; set; }

    /// <summary>
    /// Constructor from 3 strings.
    /// like ObjectNames: obj1, ..., objN
    /// AttributeNames: att1, ..., attN
    /// Incidence: 0: 1,2; ...; N: 2,3
    /// </summary>
    public FormalContext(string objectsNames, string attributeNames, string incidence)
    {
        ObjectsNames = objectsNames.Replace(", ", ",").Split(separator: ',');
        AttributeNames = attributeNames.Replace(", ", ",").Split(separator: ',');
        Incidence = incidence.Replace("; ", ";").Split(separator: ';');
    }
    
}