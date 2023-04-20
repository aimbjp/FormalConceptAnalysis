namespace FormalConceptAnalysis.Tests;

public class LinkTests
{
    [Test]
    public void Constructor_DefaultValues()
    {
        var link = new Link();

        Assert.AreEqual(-1, link.Id);
        Assert.AreEqual(-1, link.LinkedTo);
    }

    [Test]
    public void Constructor_WithValues()
    {
        var id = 1;
        var linkedTo = 2;

        var link = new Link(id, linkedTo);

        Assert.AreEqual(id, link.Id);
        Assert.AreEqual(linkedTo, link.LinkedTo);
    }
}