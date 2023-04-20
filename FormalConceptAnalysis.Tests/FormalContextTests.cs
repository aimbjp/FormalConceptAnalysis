namespace FormalConceptAnalysis.Tests;

public class FormalContextTests
{
    private FormalContext _formalContext;

    [SetUp]
    public void SetUp()
    {
        _formalContext = new FormalContext(
            new string[] { "obj1", "obj2", "obj3" },
            new string[] { "att1", "att2", "att3" },
            new string[] { "0: 1,2", "1: 0,2", "2: 0,1" });
    }

    [Test]
    public void Constructor_CreateObjectWithCorrectObjectsNames()
    {
        Assert.AreEqual(new string[] { "obj1", "obj2", "obj3" }, _formalContext.ObjectsNames);
    }

    [Test]
    public void Constructor_CreateObjectWithCorrectAttributeNames()
    {
        Assert.AreEqual(new string[] { "att1", "att2", "att3" }, _formalContext.AttributeNames);
    }

    [Test]
    public void Constructor_CreateObjectWithCorrectIncidence()
    {
        Assert.AreEqual(new string[] { "0: 1,2", "1: 0,2", "2: 0,1" }, _formalContext.Incidence);
    }

    [Test]
    public void Constructor_CreateObjectWithCorrectObjectsNamesNumbers()
    {
        var expectedDictionary = new Dictionary<string, int>
        {
            { "obj1", 0 },
            { "obj2", 1 },
            { "obj3", 2 }
        };
        Assert.AreEqual(expectedDictionary, _formalContext.ObjectsNamesNumbers);
    }

    [Test]
    public void Constructor_CreateObjectWithCorrectAttributesNamesNumbers()
    {
        var expectedDictionary = new Dictionary<string, int>
        {
            { "att1", 0 },
            { "att2", 1 },
            { "att3", 2 }
        };
        Assert.AreEqual(expectedDictionary, _formalContext.AttributesNamesNumbers);
    }

    [Test]
    public void Constructor_CreateObjectWithCorrectIncidenceSeparated()
    {
        var expectedDictionary = new Dictionary<string, List<int>>
        {
            { "0", new List<int> { 1, 2 } },
            { "1", new List<int> { 0, 2 } },
            { "2", new List<int> { 0, 1 } }
        };
        Assert.AreEqual(expectedDictionary, _formalContext.IncidenceSeparated);
    }
}