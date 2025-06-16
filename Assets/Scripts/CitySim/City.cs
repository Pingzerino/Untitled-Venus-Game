using System;

/* This class City stores all relevant information for the city.
 * Buildings, streets, special constructions, the existence of platforms, all of them.
 * Specifically, platforms will store buildings' info.
 * We also have resources.
 * And population.
 */
public class City
{
    

	// Dimensions of the city, in hexagon tiles.
	// Width +1 is the maximum hexagon width of the entire map.
	// Height +1 means the number of columns.
    public int Width { get; }
    public int Height { get; }

    // System for managing the platform land and storing their values
    // This will be a 2D array because there are multiple platforms across.
    // This is tiered in a hexagon pattern:
    /*
	 * 0,0      
	 * 0,1   1,0  
	 * 0,2   1,1   
	 * 0,3   1,2
	 * 0,4   1,3
	 * 
	 * Where we do columns and such.
     */
    public PlatformSystem Platform { get; private set; }
	
	// System for managing resources and storing their values
	// These will be updated and changed as other methods need.
	public ResourceSystem Resources { get; private set; }

    // System for managing the population of the city and storing values.
    public PopulationSystem Population { get; set; }

    // System for managing the events that occur in the game.
	// Not to be confused with things like user input events.
	// These are things like weather storms, random events, etc.
    public EventManager Events { get; set; }

	// Constructor to initialize all of the data of the city.
    public City(int w, int h)
	{
		Width = w;
		Height = h;
		Platform = new PlatformSystem(this, w, h);
		Resources = new ResourceSystem(this);
		Population = new PopulationSystem(this);
		Events = new EventManager(this);


    }
	// Ticks the city's state forward one tick.
	public void Tick()
	{
        // Platform.Tick();
        // Resources.Tick();
    }
}
