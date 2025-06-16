using System;
// This is not an enum, because we want to be able to add more on easily. Or potentially do modding! Gotta think about them early. Be bold.
public class ResourceType
{
	public string Id { get; }
	public string Name { get; }

    // Constructor for a resource type.
    public ResourceType(string id, string displayName)
	{
		Id = id;
		Name = displayName;
	}

    // Override	Equals and GetHashCode methods so we can use these in a dictionary
    public override bool Equals(object obj)
    {
        return Equals(obj as ResourceType);
    }

    // Equals method.
    public bool Equals(ResourceType other)
    {
        return ((other != null) && (Id == other.Id) && (Name == other.Name));
    }
    
    //
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

}
