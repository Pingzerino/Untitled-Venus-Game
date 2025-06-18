using System;
using System.Collections.Generic;

// This class manages all of the resources in the game. It should include adding resources, decreasing them,
// and potentially handle passive drain/increases per update.
public class ResourceSystem
{
    // References City to interact with other systems whenever things happen
    private City _city;
	// These two dictionaries will store a string to the resource type, and then resource type to string.
    private Dictionary<string, ResourceType> Types;
    private Dictionary<ResourceType, int> balances;

	public ResourceSystem(City city)
	{
		_city = city;
		Types = new Dictionary<string, ResourceType>();
		balances = new Dictionary<ResourceType, int>();

		AddResourceType("water", "Water");
        //AddResourceType(new ResourceType("wood", "Wood"));
        //AddResourceType(new ResourceType("stone", "Stone"));
        //AddResourceType();
    }

    // Private helper to add a resource to the resource type dictionary
    // and the dictionary holding the amounts associated to each resource
    private ResourceType AddResourceType(string id, string name)
	{
        if (Types.ContainsKey(id)) {
            Console.WriteLine("Resource already exists!");
            return Types[id];
        }
        ResourceType type = new ResourceType(id, name);
        Types[type.Id] = type;
        balances[type] = 0;
        return type;
    }
    
    // Private helper to find if a type associated with id exists in the Types dictionary
    private bool TypeExists(string id)
    {
        return Types.ContainsKey(id);
    }


    // Increases the resource with id by i amount
    public void increaseResource(string id, int i)
    {
        if (!TypeExists(id)) {
            Console.WriteLine("Resource does not exist");
        } else
        {
            ResourceType type = Types[id];
            balances[type] = balances[type] + i; 
        }
    }
}
