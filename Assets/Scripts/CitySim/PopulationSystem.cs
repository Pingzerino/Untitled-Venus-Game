using System;

public class PopulationSystem
{
    // References City to interact with other systems whenever things happen
    private City _city;

    // Fields for the population
    public int maxCivs;
    public int currentCivs;

    public int maxRobots;
    public int currentRobots;

    // Default values that the game starts with
    private const int DEFAULTMAXCIVS = 25;
    private const int DEFAULTCIVS = 25;
    private const int DEFAULTMAXROBOTS = 15;
    private const int DEFAULTROBOTS = 5;


    public PopulationSystem(City city)
	{
        _city = city;
        maxCivs = DEFAULTMAXCIVS;
        currentCivs = DEFAULTCIVS;
        maxRobots = DEFAULTMAXROBOTS;
        currentRobots = DEFAULTROBOTS;
	}
}
