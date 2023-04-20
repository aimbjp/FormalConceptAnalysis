namespace FormalConceptAnalysis.Tests;

public class NodeTests
{
    [Test]
    public void Objects_GetSet()
    {
        var node = new Node();
        var expected = new List<int>() { 1, 2, 3 };

        node.Objects = expected;
        var actual = node.Objects;

        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Attributes_GetSet()
    {
        var node = new Node();
        var expected = new List<int>() { 4, 5, 6 };

        node.Attributes = expected;
        var actual = node.Attributes;

        CollectionAssert.AreEqual(expected, actual);
    }

    [Test]
    public void Id_GetSet()
    {
        var node = new Node();
        var expected = 10;

        node.Id = expected;
        var actual = node.Id;

        Assert.AreEqual(expected, actual);
    }
    [Test]
    public void Node_DefaultConstructor_SetsPropertiesCorrectly()
    {
        var expectedObjects = new List<int>();
        var expectedAttributes = new List<int>();
        var expectedId = -1;
        var node = new Node();
        
        var actualObjects = node.Objects;
        var actualAttributes = node.Attributes;
        var actualId = node.Id;
        
        Assert.AreEqual(expectedObjects, actualObjects);
        Assert.AreEqual(expectedAttributes, actualAttributes);
        Assert.AreEqual(expectedId, actualId);
    }

    [Test]
    public void Node_Constructor_SetsPropertiesCorrectly()
    {
        var expectedObjects = new List<int> { 1, 2, 3 };
        var expectedAttributes = new List<int> { 4, 5, 6 };
        var expectedId = 7;
        var node = new Node(expectedObjects, expectedAttributes, expectedId);
        
        var actualObjects = node.Objects;
        var actualAttributes = node.Attributes;
        var actualId = node.Id;
        
        Assert.AreEqual(expectedObjects, actualObjects);
        Assert.AreEqual(expectedAttributes, actualAttributes);
        Assert.AreEqual(expectedId, actualId);
    }
}