using Newtonsoft.Json;

namespace FormalConceptAnalysis;
[Serializable]
public class FormalContext
{
    /// <summary>
    /// Structures for keeping information about formal context.
    /// </summary>
    [JsonProperty("objects"), ]
    public string[] ObjectsNames { get; set; }
    [JsonProperty("attributes"), ]
    public string[] AttributeNames { get; set; }
    [JsonProperty("incidences"), ]
    public string[] Incidence { get; set; }
    
    internal Dictionary<string, string[]> IncidenceSeparated { get; set; }

    /// <summary>
    /// Constructor from 3 strings.
    /// like ObjectNames: obj1, ..., objN
    /// AttributeNames: att1, ..., attN
    /// Incidence: 0: 1,2; ...; N: 2,3
    /// </summary>
    public FormalContext(string[] objectsNames, string[] attributeNames, string[] incidence)
    {
        ObjectsNames = objectsNames;
        AttributeNames = attributeNames;
        Incidence = incidence;
        IncidenceSeparated = new Dictionary<string, string[]>();
        foreach (var VARIABLE in incidence)
        {
            IncidenceSeparated.Add(VARIABLE.Split(":")[0], VARIABLE.Split(":")[1].Trim().Split(','));
        }
    }
};
    

    
