using System;
using System.Collections.Generic;

// This class manages all of the resources in the game. It should include adding resources, decreasing them,
// and potentially handle passive drain/increases per update.

public enum Resource
{
    Water,
    Food,
    BuildingMaterials,
    Metal,
    PowerCells,
    Mercurium,
    Chlorohedra,
    Aphrite
}
public class ResourceSystem
{
    // References City to interact with other systems whenever things happen
    private City _city;
    // These two dictionaries will store resource to count of resources.
    private Dictionary<Resource, int> balances;

    public ResourceSystem(City city)
    {
        _city = city;
        balances = new Dictionary<Resource, int>();

        // Initialize adding resource types in the format of (id, display name).
        AddResourceType(Resource.Water, 50);
        AddResourceType(Resource.Food, 50);
        AddResourceType(Resource.BuildingMaterials, 50);
        AddResourceType(Resource.Metal, 50);
        AddResourceType(Resource.Mercurium, 50);
        AddResourceType(Resource.Chlorohedra, 50);
        AddResourceType(Resource.Aphrite, 50);
    }

    // Private helper to add a resource to the resource type dictionary
    // and the dictionary holding the amounts associated to each resource
    private void AddResourceType(Resource id, int amount)
    {
        if (balances.ContainsKey(id))
        {
            Console.WriteLine("Resource already exists!");
        }
        else
        {
            balances.Add(id, amount);
        }
        
    }

    // Private helper to find if a type associated with id exists in the Types dictionary
    private bool ResourceExists(Resource id)
    {
        return balances.ContainsKey(id);
    }


    // Increases the resource with id by i amount
    public void IncreaseResource(Resource id, int i)
    {
        if (!ResourceExists(id))
        {
            Console.WriteLine("Resource does not exist");
        }
        else
        {
            balances[id] = balances[id] + i;
        }
    }
}
