using System;

public class ResourceType
{
	public string Id { get; }
	public string Name { get; }
	public string IconPath { get; } // Path to sprite
    public ResourceType(string id, string displayName, string path = "")
	{
		Id = id;
		Name = displayName;
		IconPath = path;
	}
}
