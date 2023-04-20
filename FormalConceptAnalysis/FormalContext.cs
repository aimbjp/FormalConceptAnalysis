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
    
    public Dictionary<string, int> ObjectsNamesNumbers { get; set; }
    public Dictionary<string, int> AttributesNamesNumbers { get; set; }
    internal Dictionary<string, List<int>> IncidenceSeparated { get; set; }

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
        IncidenceSeparated = new Dictionary<string, List<int>>();
        ObjectsNamesNumbers = new Dictionary<string, int>();
        AttributesNamesNumbers = new Dictionary<string, int>();

        var counter = 0;
        foreach (var VARIABLE in incidence)
        {
            ObjectsNamesNumbers.Add( objectsNames[counter] , counter++);
            var strAttrNums = VARIABLE.Split(":")[1].Trim().Split(',');
            var lstAttribute = new List<int>();
            foreach (var v in strAttrNums)
            {
                lstAttribute.Add(int.Parse(v));
            }
            IncidenceSeparated.Add(VARIABLE.Split(":")[0], lstAttribute);
        }

        counter = 0;
        foreach (var VARIABLE in attributeNames)
        {
            AttributesNamesNumbers.Add( VARIABLE , counter++);
        }
    }
};
    

    
