using System;
using System.Collections.Generic;

public class ResourceSystem
{
	private Dictionary<ResourceType, int> balances;


	public ResourceSystem()
	{
		balances = new Dictionary<ResourceType, int>();
	}
}
