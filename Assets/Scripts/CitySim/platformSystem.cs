﻿using System;


// PlatformSystem is the class that represents a singular Platform and all its data.
public class PlatformSystem
{
    private City _city;
	// Default constant values
    private const float DEFAULTHEALTH = 300f;
    private const float DEFAULTMAXHEALTH = 300f;
    private const int DEFAULTGRIDSIZE = 11;

    // These two fields manage the health of the platform. If it ever hits zero, the platform collapses. Goodbye!
    public float currentHealth { get; private set; }
	public float maxHealth { get; private set; }

    // This represents the platform's location.
    public Tuple<int, int> Position;

    public BuildingGridSystem buildingGridSystem { get; private set; }

    public PlatformSystem(City city, int x, int y)
	{
        _city = city;
		currentHealth = DEFAULTHEALTH;
		maxHealth = DEFAULTMAXHEALTH;
		Position = new Tuple<int, int>(x, y);
		buildingGridSystem = new BuildingGridSystem(DEFAULTGRIDSIZE, DEFAULTGRIDSIZE);

    }

    // This is specifically meant to be the FIRST and CENTRAL platform built.
    // Because of this, it will include many particular buildings.
    public PlatformSystem(City city, string tutorial)
    {
        if (tutorial == "tutorial")
        {
            _city = city;
            currentHealth = 500;
            maxHealth = 500;
        }
        
    }
}
