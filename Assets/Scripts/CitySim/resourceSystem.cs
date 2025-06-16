using System;
using System.Collections.Generic;

// This class manages all of the resources in the game. It should include adding resources, decreasing them,
// and potentially handle passive drain/increases per update.
public class ResourceSystem
{
    // References City to interact with other systems whenever things happen
    private City _city;
	// These two dictionaries will store a string to the resource type, and then resource type to string.
    private Dictionary<string, ResourceType> types;
    private Dictionary<ResourceType, int> balances;

	public ResourceSystem(City city)
	{
		_city = city;
		types = new Dictionary<string, ResourceType>();
		balances = new Dictionary<ResourceType, int>();

		AddResourceType("water", "Water");
        //AddResourceType(new ResourceType("wood", "Wood"));
        //AddResourceType(new ResourceType("stone", "Stone"));
        //AddResourceType();
    }

private ResourceType AddResourceType(string id, string name)
	{
        ResourceType type = new ResourceType(id, name);
        types[type.Id] = type;
        balances[type] = 0;
        return type;

    }
}
