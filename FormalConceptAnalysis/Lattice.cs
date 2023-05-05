using Newtonsoft.Json;

namespace FormalConceptAnalysis;
[Serializable]
public class Lattice
{
    public List<Node> nodes;
    public List<Link> links;

    [System.Text.Json.Serialization.JsonConstructor, JsonConstructor]
    public Lattice(List<Node> nodes, List<Link> links)
    {
        this.nodes = nodes;
        this.links = links;
    }
    
    public Lattice(FormalContext formalContext, string algorithm = "addintent")
    {
        nodes = new List<Node>();
        links = new List<Link>();
        
        switch (algorithm.ToLower())
        {
            case "addatom":
                AddAtom(formalContext);
                break;
            case "addintent":
                AddIntent(formalContext);
                break;
        }
    }

    private void AddAtom(FormalContext formalContext)
    {
        var id = 0;
        var counter = 0;
        var bottomConcept = new Node();
        for (var index = 0; index < formalContext.AttributeNames.Length; index++)
        {
            bottomConcept.Attributes.Add(index);
        }
        bottomConcept.Id = 0;
        
        nodes.Add(bottomConcept);

        
        foreach (var g in formalContext.ObjectsNamesNumbers.Values)
        {
            List<int> intents = formalContext.IncidenceSeparated[g.ToString()];
            Add(intents, g, bottomConcept);
        }

        var count = 0;
        int l0 = 1;
        foreach (var link in links)
        {
            if (link.LinkedTo == 0)
            {
                count++;
                l0 = link.Id;
            }
        }

        if (count == 1 && nodes[0].Attributes.SequenceEqual(nodes[l0].Attributes))
        {
            var linksCopy = links.ToList();
            foreach (var link in links)
            {
                if (link.LinkedTo == 0)
                {
                    linksCopy.Remove(link);
                }
            }
            links = linksCopy;
            foreach (var link in links)
            {
                link.Id--;
                link.LinkedTo--;
            }

            foreach (var node in nodes)
            {
                node.Id--;
            }
            nodes.RemoveAt(0);
        }
        
        Node Add(List<int> intents, int numObject, Node generatorConcept)
        {
            var candidateParents = GetParents(generatorConcept);
            List<Node> NodePeaks = new List<Node>();
            foreach (var candidate in candidateParents)
            {
                var newIntents = candidate.Attributes.Intersect(intents).ToList();
                var peak = GetPeak(newIntents, candidate);
                if (!peak.Attributes.SequenceEqual(newIntents)) peak = Add(newIntents, numObject, peak);//peak.Attributes != newIntents
                else AddObjectParents(numObject, peak);

                if(!peak.Objects.Contains(numObject)) peak.Objects.Add(numObject);
                if (newIntents.SequenceEqual(intents)) return peak;
                var addPeak = true;
                var nodePeaksCopy = NodePeaks.ToList();
                foreach (var nodePeak in NodePeaks)
                {
                    if (peak.Attributes.Union(nodePeak.Attributes).Count() == nodePeak.Attributes.Count())  addPeak = false;
                    else if (nodePeak.Attributes.Union(peak.Attributes).Count() == peak.Attributes.Count())
                        nodePeaksCopy.Remove(nodePeak);
                }
                NodePeaks = nodePeaksCopy;
                if(addPeak) NodePeaks.Add(peak);
            }

            var lstExtents = new List<int>();
            lstExtents.AddRange(generatorConcept.Objects);
            if (!generatorConcept.Objects.Contains(numObject))
            {
                lstExtents.Add(numObject);
            }
            
            var newConcept = new Node(lstExtents.ToList(), intents, ++id); 
            nodes.Add(newConcept);
            foreach (var nodePeak in NodePeaks)
            {
                var linksCopy = links.ToList();
                foreach (var link in links)
                {
                    if (link.Id == nodePeak.Id && link.LinkedTo == generatorConcept.Id)
                    {
                        linksCopy.Remove(link);
                    }
                }
                links = linksCopy;
                links.Add(new Link(nodePeak.Id, newConcept.Id));
            }
            links.Add(new Link(newConcept.Id, generatorConcept.Id));
            return newConcept;
        }
        void AddObjectParents(int obj, Node peak)
        {
            if (!peak.Objects.Contains(obj)) peak.Objects.Add(obj);
            foreach (var link in links)
            {
                if (link.LinkedTo == peak.Id)
                {
                    AddObjectParents(obj, nodes[link.Id]);
                }
            }
        }

        Node GetPeak(List<int> attributes, Node node)
        {
            var parentIsPeak = true;
            while (parentIsPeak)
            {
                parentIsPeak = false;
                var parents = GetParents(node);
                foreach (var parent in parents.Where(parent => 
                             (parent.Attributes).Union(attributes).Count() == parent.Attributes.Count))
                {
                    node = parent;
                    parentIsPeak = true;
                }
            }
            return node;
        }
        
        List<Node> GetParents(Node generatorConcept)
        {
            List<Node> parents = new List<Node>();
            foreach (var link in links)
            {
                if (link.LinkedTo == generatorConcept.Id)
                {
                    parents.Add(nodes[link.Id]);
                }
            }
            return parents;
        }
    }

    

    private void AddIntent(FormalContext formalContext)
    {
        var id = 0;
        var bottomConcept = new Node();
        for (var index = 0; index < formalContext.AttributeNames.Length; index++)
        {
            bottomConcept.Attributes.Add(index);
        }
        bottomConcept.Id = 0;
        
        nodes.Add(bottomConcept);
        
        foreach (var g in formalContext.ObjectsNamesNumbers.Values)
        {
            List<int> intents = formalContext.IncidenceSeparated[g.ToString()];
            var objectConcept = Add(intents, bottomConcept);
            AddObjectParents(g, objectConcept);
        }
        
        Node Add(List<int> ints, Node node)
        {
            var nodeCopy = new List<int>();
            nodeCopy.AddRange(node.Objects);
            node.Objects = nodeCopy;
            Node probablyParent = GetPeak(ints, node);
            if (probablyParent.Attributes.SequenceEqual(ints)) return probablyParent;
            var generatorParents = GetParents(probablyParent);
            List<Node> NewParents = new List<Node>();
            // for (var candidate in generatorParents)
            // {
            //     if (candidate.Attributes.Except(ints).Any())
            //         candidate = Add(candidate.Attributes.Intersect(ints).ToList(), candidate);
            // }
            for (int i = 0; i < generatorParents.Count; i++)
            {
                if (generatorParents[i].Attributes.Except(ints).Any())
                    generatorParents[i] = Add(generatorParents[i].Attributes.Intersect(ints).ToList(), generatorParents[i]);
                var addParent = true;
                var NewParentsCopy = NewParents.ToList();
                // for (int j = 0; j < NewParents.Count; j++)
                // {
                //     if (generatorParents[i].Attributes.Union(NewParents[j].Attributes).Count() ==
                //         NewParents[j].Attributes.Count()) addParent = false;
                //     else if (NewParents[j].Attributes.Union(generatorParents[i].Attributes).Count() == generatorParents[i].Attributes.Count()) NewParents.RemoveAt(j);
                // }
                foreach (var parent in NewParents)
                {
                    if (generatorParents[i].Attributes.Union(parent.Attributes).Count() ==
                        parent.Attributes.Count()) addParent = false;
                    else if (parent.Attributes.Union(generatorParents[i].Attributes).Count() == generatorParents[i].Attributes.Count()) NewParentsCopy.Remove(parent);
                }
                NewParents = NewParentsCopy;
                
                if (addParent) NewParents.Add(generatorParents[i]);
            }
            var newConcept = new Node(probablyParent.Objects.ToList(), ints, ++id);
            nodes.Add(newConcept);
            foreach (var parent in NewParents)
            {
                var linksCopy = links.ToList();
                foreach (var link in links)
                {
                    if (link.Id == parent.Id && link.LinkedTo == probablyParent.Id)
                    {
                        linksCopy.Remove(link);
                    }
                }
                links = linksCopy;
                links.Add(new Link(parent.Id, newConcept.Id));
            }
            links.Add(new Link(newConcept.Id, probablyParent.Id));
            return newConcept;
        }
        
        Node GetPeak(List<int> attributes, Node node)
        {
            var parentIsPeak = true;
            while (parentIsPeak)
            {
                parentIsPeak = false;
                var parents = GetParents(node);
                foreach (var parent in parents.Where(parent => 
                             (parent.Attributes).Union(attributes).Count() == parent.Attributes.Count))
                {
                    node = parent;
                    parentIsPeak = true;
                }
            }
            return node;
        }
        List<Node> GetParents(Node generatorConcept)
        {
            List<Node> parents = new List<Node>();
            foreach (var link in links)
            {
                if (link.LinkedTo == generatorConcept.Id)
                {
                    parents.Add(nodes[link.Id]);
                }
            }
            return parents;
        }
        void AddObjectParents(int obj, Node node)
        {
            if (!node.Objects.Contains(obj)) node.Objects.Add(obj);
            foreach (var link in links)
            {
                if (link.LinkedTo == node.Id)
                {
                    AddObjectParents(obj, nodes[link.Id]);
                }
            }
        }
    }
}