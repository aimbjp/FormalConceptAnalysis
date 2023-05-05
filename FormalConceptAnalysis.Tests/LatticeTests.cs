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
    
        // new FormalContext(new string[] { "A", "B", "C", "D", "E", "f" },
        //     new string[] { "a1", "1", "X", "Y", "Z", "d"},
        //     new string[] { "0: 1,4", "1: 0,3", "2: 0,1,2,4", "3: 0,2,3,4 ", "4: 2,3,4", "5: 2,3,4" });
    
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
        var counter = 0;
        foreach (var node in latticeAtom1.nodes)
        {
            foreach (var nodeInt in latticeIntent1.nodes)
            {
                if (nodeInt.Objects.SequenceEqual(node.Objects) &&
                    nodeInt.Attributes.SequenceEqual(node.Attributes)) counter++;
            }
        }
        Assert.AreEqual(latticeAtom1.nodes.Count, counter, latticeIntent1.nodes.Count);
        Assert.AreEqual(latticeIntent1.links.Count, latticeAtom1.links.Count);
    
         counter = 0;
        foreach (var node in latticeAtom2.nodes)
        {
            foreach (var nodeInt in latticeIntent2.nodes)
            {
                if (nodeInt.Objects.SequenceEqual(node.Objects) &&
                    nodeInt.Attributes.SequenceEqual(node.Attributes)) counter++;
            }
        }
        Assert.AreEqual(latticeAtom2.nodes.Count, counter, latticeIntent2.nodes.Count);
        Assert.AreEqual(latticeIntent2.links.Count, latticeAtom2.links.Count);
        
         counter = 0;
        foreach (var node in latticeAtom3.nodes)
        {
            foreach (var nodeInt in latticeIntent3.nodes)
            {
                if (nodeInt.Objects.SequenceEqual(node.Objects) &&
                    nodeInt.Attributes.SequenceEqual(node.Attributes)) counter++;
            }
        }
        Assert.AreEqual(latticeAtom3.nodes.Count, counter, latticeIntent3.nodes.Count);
        Assert.AreEqual(latticeIntent3.links.Count, latticeAtom3.links.Count);
        
        counter = 0;
        foreach (var node in latticeAtom4.nodes)
        {
            foreach (var nodeInt in latticeIntent4.nodes)
            {
                if (nodeInt.Objects.SequenceEqual(node.Objects) &&
                    nodeInt.Attributes.SequenceEqual(node.Attributes)) counter++;
            }
        }
        Assert.AreEqual(latticeAtom4.nodes.Count, counter, latticeIntent4.nodes.Count);
        Assert.AreEqual(latticeIntent4.links.Count, latticeAtom4.links.Count);
    }
    
    [Test]
    public void AddAtom_Compare_AddIntent_Random()
    {
        var random = new Random();
        for (int i = 0; i < 5000; i++)
        {
            var amountObj = random.Next(0,20);
            var amountAtr = random.Next(0,20);
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
            var counter = 0;
            foreach (var node in latticeAtom.nodes)
            {
                foreach (var nodeInt in latticeIntent.nodes)
                {
                    if (nodeInt.Objects.SequenceEqual(node.Objects) &&
                        nodeInt.Attributes.SequenceEqual(node.Attributes)) counter++;
                }
            }
            Assert.AreEqual(latticeAtom.nodes.Count, counter, latticeIntent.nodes.Count);
            Assert.AreEqual(latticeAtom.links.Count, latticeIntent.links.Count);
    
        }
    }

    [Test]
    public void AddAtom_Compare_AddIntent_Ref()
    {
        //Решетка AddAtom
        var fileContentAddAtom = File.ReadAllText("example/latticeAddAtom.json");
        var latticeAddAtom = JsonConvert.DeserializeObject<Lattice>(@fileContentAddAtom);
        //Решетка AddIntent
        var fileContentAddIntent = File.ReadAllText("example/latticeAddIntent.json");
        var latticeAddIntent = JsonConvert.DeserializeObject<Lattice>(@fileContentAddAtom);
        //Решетка из примера с сайта
        var fileContentRef = File.ReadAllText("example/refLattice.json");
        var latticeRef = JsonConvert.DeserializeObject<Lattice>(@fileContentAddAtom);
    
        //Счетчики совпадений
        var atomCount = (from node in latticeAddAtom.nodes 
                                from nodeInt in latticeRef.nodes 
                                where nodeInt.Objects.SequenceEqual(node.Objects) && nodeInt.Attributes.SequenceEqual(node.Attributes) 
                                select node).Count();
    
        var intentCount = (from node in latticeAddIntent.nodes 
                                from nodeInt in latticeRef.nodes 
                                where nodeInt.Objects.SequenceEqual(node.Objects) && nodeInt.Attributes.SequenceEqual(node.Attributes) 
                                select node).Count();
    
        Assert.AreEqual(atomCount, intentCount, latticeAddAtom.nodes.Count);
    
        atomCount = (from link in latticeAddAtom.links 
                        from linkRef in latticeRef.links 
                        where linkRef.Id == link.Id && linkRef.LinkedTo == link.LinkedTo 
                        select link).Count();
    
        intentCount = (from link in latticeAddIntent.links 
                        from linkRef in latticeRef.links 
                        where linkRef.Id == link.Id && linkRef.LinkedTo == link.LinkedTo 
                        select link).Count();
    
        Assert.AreEqual(atomCount, intentCount, latticeAddAtom.nodes.Count);
    }
}