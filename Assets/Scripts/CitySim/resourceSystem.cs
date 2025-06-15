using System;
using System.Collections.Generic;

public class ResourceSystem
{
	private City _city;
    private Dictionary<ResourceType, int> balances;

	public ResourceSystem(City city)
	{
		_city = city;
		balances = new Dictionary<ResourceType, int>();

	}
}
