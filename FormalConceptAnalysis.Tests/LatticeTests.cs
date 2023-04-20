using Newtonsoft.Json;
using NUnit.Framework.Internal;

namespace FormalConceptAnalysis.Tests;

public class LatticeTests
{
    FormalContext formalContext1;
    FormalContext formalContext2;
    FormalContext formalContext3;
    FormalContext formalContext4;

    
    Lattice latticeAtom1;
    Lattice latticeAtom2;
    Lattice latticeAtom3;
    Lattice latticeAtom4;
    Lattice latticeIntent1;
    Lattice latticeIntent2;
    Lattice latticeIntent3;
    Lattice latticeIntent4;

    [SetUp]
    public void SetUp()
    {
        formalContext1 = new FormalContext(new string[] { "A", "B", "C" },
            new string[] { "a1", "1", "X" },
                new string[] { "0: 2", "1: 0,2", "2: 1,2" });
        formalContext2 = new FormalContext(new string[] { "A", "B", "C" },
            new string[] { "a1", "1", "X" },
            new string[] { "0: 0,2", "1: 0,1", "2: 1,2" });
        formalContext3 = new FormalContext(new string[] { "A", "B", "C", "D", "E" },
            new string[] { "a1", "a2", "a3", "a4", "a5" },
            new string[] { "0: 0,3,4", "1: 0,1,2,3", "2: 0,2,4", "3: 1,3", "4: 2,4" });
        formalContext4 = new FormalContext(new string[] { "A", "B", "C", "D", "E", "F" },
            new string[] { "a1", "1", "X", "Y", "Z"},
                new string[] { "0: 0,2,4", "1: 0,1,5", "2: 2,3,4", "3: 0,3,5 ", "4: 1,4" });


        latticeAtom1 = new Lattice(formalContext1, "addatom");
        latticeAtom2 = new Lattice(formalContext2, "addatom");
        latticeAtom3 = new Lattice(formalContext3, "addatom");
        latticeAtom4 = new Lattice(formalContext4, "addatom");
        latticeIntent1 = new Lattice(formalContext1, "addintent");
        latticeIntent2 = new Lattice(formalContext2, "addintent");
        latticeIntent3 = new Lattice(formalContext3, "addintent");
        latticeIntent4 = new Lattice(formalContext4, "addintent");
    }
    
    [Test]
    public void AddAtom_AddsNodeToList()
    {
        Assert.AreEqual(4, latticeAtom1.nodes.Count);
        Assert.AreEqual(8, latticeAtom2.nodes.Count);
        Assert.AreEqual(14, latticeAtom3.nodes.Count);
    }

    [Test]
    public void AddAtom_AddsLinksToList()
    {
        Assert.AreEqual(4, latticeAtom1.links.Count);
        Assert.AreEqual(12, latticeAtom2.links.Count);
        Assert.AreEqual(24, latticeAtom3.links.Count);
    }

    [Test]
    public void AddAtom_NodeValues()
    {
        Assert.AreEqual(latticeAtom1.nodes[0].Objects, new List<int>());
        Assert.AreEqual(latticeAtom1.nodes[0].Attributes, new  List<int>(){0,1,2}); 
        Assert.AreEqual(latticeAtom1.nodes[0].Id, 0);
        Assert.AreEqual(latticeAtom1.nodes[1].Objects, new List<int>(){0, 1, 2});
        Assert.AreEqual(latticeAtom1.nodes[1].Attributes, new  List<int>(){2}); 
        Assert.AreEqual(latticeAtom1.nodes[1].Id, 1);
        Assert.AreEqual(latticeAtom1.nodes[2].Objects, new List<int>(){1});
        Assert.AreEqual(latticeAtom1.nodes[2].Attributes, new  List<int>{0, 2}); 
        Assert.AreEqual(latticeAtom1.nodes[2].Id, 2);
        Assert.AreEqual(latticeAtom1.nodes[3].Objects, new List<int>(){2});
        Assert.AreEqual(latticeAtom1.nodes[3].Attributes, new  List<int>{1,2}); 
        Assert.AreEqual(latticeAtom1.nodes[3].Id, 3);
    }

    [Test]
    public void AddAtom_LinksValues()
    {
        Assert.AreEqual(latticeAtom1.links[0].Id, 1);
        Assert.AreEqual(latticeAtom1.links[0].LinkedTo, 2);
        Assert.AreEqual(latticeAtom1.links[1].Id, 2);
        Assert.AreEqual(latticeAtom1.links[1].LinkedTo, 0);
        Assert.AreEqual(latticeAtom1.links[2].Id, 1);
        Assert.AreEqual(latticeAtom1.links[2].LinkedTo, 3);
        Assert.AreEqual(latticeAtom1.links[3].Id, 3);
        Assert.AreEqual(latticeAtom1.links[3].LinkedTo, 0);
    }

    [Test]
    public void AddIntent_AddsNodeToList()
    {
        Assert.AreEqual(4, latticeIntent1.nodes.Count);
        Assert.AreEqual(8, latticeIntent2.nodes.Count);
        Assert.AreEqual(14, latticeIntent3.nodes.Count);
    }
    
    [Test]
    public void AddIntent_AddsLinksToList()
    {
        Assert.AreEqual(4, latticeIntent1.links.Count);
        Assert.AreEqual(12, latticeIntent2.links.Count);
        Assert.AreEqual(24, latticeIntent3.links.Count);
    }
    
    [Test]
    public void AddIntent_NodeValues()
    {
        Assert.AreEqual(latticeIntent1.nodes[0].Objects, new List<int>());
        Assert.AreEqual(latticeIntent1.nodes[0].Attributes, new  List<int>(){0,1,2}); 
        Assert.AreEqual(latticeIntent1.nodes[0].Id, 0);
        Assert.AreEqual(latticeIntent1.nodes[1].Objects, new List<int>(){0, 1, 2});
        Assert.AreEqual(latticeIntent1.nodes[1].Attributes, new  List<int>(){2}); 
        Assert.AreEqual(latticeIntent1.nodes[1].Id, 1);
        Assert.AreEqual(latticeIntent1.nodes[2].Objects, new List<int>(){1});
        Assert.AreEqual(latticeIntent1.nodes[2].Attributes, new  List<int>{0, 2}); 
        Assert.AreEqual(latticeIntent1.nodes[2].Id, 2);
        Assert.AreEqual(latticeIntent1.nodes[3].Objects, new List<int>(){2});
        Assert.AreEqual(latticeIntent1.nodes[3].Attributes, new  List<int>{1,2}); 
        Assert.AreEqual(latticeIntent1.nodes[3].Id, 3);
    }
    
    [Test]
    public void AddIntent_LinksValues()
    {
        Assert.AreEqual(latticeIntent1.links[0].Id, 1);
        Assert.AreEqual(latticeIntent1.links[0].LinkedTo, 2);
        Assert.AreEqual(latticeIntent1.links[1].Id, 2);
        Assert.AreEqual(latticeIntent1.links[1].LinkedTo, 0);
        Assert.AreEqual(latticeIntent1.links[2].Id, 1);
        Assert.AreEqual(latticeIntent1.links[2].LinkedTo, 3);
        Assert.AreEqual(latticeIntent1.links[3].Id, 3);
        Assert.AreEqual(latticeIntent1.links[3].LinkedTo, 0);
    }

    [Test]
    public void AddAtom_Compare_AddIntent()
    {
        for (int i = 0; i < latticeAtom1.links.Count; i++)
        {
            Assert.AreEqual(latticeAtom1.links[i].Id, latticeIntent1.links[i].Id);
            Assert.AreEqual(latticeAtom1.links[i].LinkedTo, latticeIntent1.links[i].LinkedTo);
        }
        for (int i = 0; i < latticeAtom1.nodes.Count; i++)
        {
            Assert.AreEqual(latticeAtom1.nodes[i].Id, latticeIntent1.nodes[i].Id);
            Assert.AreEqual(latticeAtom1.nodes[i].Objects, latticeIntent1.nodes[i].Objects);
            Assert.AreEqual(latticeAtom1.nodes[i].Attributes, latticeIntent1.nodes[i].Attributes);
        }
        for (int i = 0; i < latticeAtom2.links.Count; i++)
        {
            Assert.AreEqual(latticeAtom2.links[i].Id, latticeIntent2.links[i].Id);
            Assert.AreEqual(latticeAtom2.links[i].LinkedTo, latticeIntent2.links[i].LinkedTo);
        }
        for (int i = 0; i < latticeAtom2.nodes.Count; i++)
        {
            Assert.AreEqual(latticeAtom2.nodes[i].Id, latticeIntent2.nodes[i].Id);
            Assert.AreEqual(latticeAtom2.nodes[i].Objects, latticeIntent2.nodes[i].Objects);
            Assert.AreEqual(latticeAtom2.nodes[i].Attributes, latticeIntent2.nodes[i].Attributes);
        }
        for (int i = 0; i < latticeAtom3.links.Count; i++)
        {
            Assert.AreEqual(latticeAtom3.links[i].Id, latticeIntent3.links[i].Id);
            Assert.AreEqual(latticeAtom3.links[i].LinkedTo, latticeIntent3.links[i].LinkedTo);
        }
        for (int i = 0; i < latticeAtom3.nodes.Count; i++)
        {
            Assert.AreEqual(latticeAtom3.nodes[i].Id, latticeIntent3.nodes[i].Id);
            Assert.AreEqual(latticeAtom3.nodes[i].Objects, latticeIntent3.nodes[i].Objects);
            Assert.AreEqual(latticeAtom3.nodes[i].Attributes, latticeIntent3.nodes[i].Attributes);
        }
        for (int i = 0; i < latticeAtom4.links.Count; i++)
        {
            Assert.AreEqual(latticeAtom4.links[i].Id, latticeIntent4.links[i].Id);
            Assert.AreEqual(latticeAtom4.links[i].LinkedTo, latticeIntent4.links[i].LinkedTo);
        }
        for (int i = 0; i < latticeAtom4.nodes.Count; i++)
        {
            Assert.AreEqual(latticeAtom4.nodes[i].Id, latticeIntent4.nodes[i].Id);
            Assert.AreEqual(latticeAtom4.nodes[i].Objects, latticeIntent4.nodes[i].Objects);
            Assert.AreEqual(latticeAtom4.nodes[i].Attributes, latticeIntent4.nodes[i].Attributes);
        }
    }

    [Test]
    public void AddAtom_Compare_AddIntent_Random()
    {
        var random = new Random();
        for (int i = 0; i < 2000; i++)
        {

            var amountObj = random.Next(2,21);
            var amountAtr = random.Next(2,15);
            string[] strObj = new string[amountObj];
            string[] strAtr = new string[amountAtr];
            string[] strInc = new string[amountObj];
            for (int j = 0; j < amountObj; j++)
            {
                strObj[j] = j.ToString();
                strInc[j] = j + ": ";
                for (int k = 0; k < amountAtr; k++)
                {
                    if (random.Next(1,1000) % 2 ==0)
                    {
                        strInc[j] += k + ",";
                    }
                }
                if (strInc[j][strInc[j].Length-1] == ',') strInc[j] = strInc[j].Substring(0, strInc[j].Length - 1);
                
            }
            for (int j = 0; j < amountAtr; j++)
            {
                strAtr[j] = j.ToString();
            }
            
            var fc = new FormalContext(strObj, strAtr, strInc);
            var latticeAtom = new Lattice(fc, "addatom");
            var latticeIntent = new Lattice(fc, "addintent");
            string jsonAtom = JsonConvert.SerializeObject(latticeAtom, Formatting.Indented);
            string jsonIntent = JsonConvert.SerializeObject(latticeIntent, Formatting.Indented);
            if (jsonAtom != jsonIntent)
            {
                continue;
            }
            Assert.AreEqual(jsonAtom, jsonIntent);
        }
    }
}