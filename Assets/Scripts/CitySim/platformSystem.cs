using System;

public class PlatformSystem
{
	// Default values
    public static float DEFAULTHEALTH = 300f;
    public static float DEFAULTMAXHEALTH = 300f;

	public static int DEFAULTGRIDSIZE = 11;
    // These two fields manage the health of the platform. If it ever hits zero, the platform collapses. Goodbye!
    public float currentHealth;
	public float maxHealth;
	// This represents the platform's location.
	public Tuple<int, int> Position;

    public BuildingGridSystem buildingGridSystem { get; private set; }

    public PlatformSystem(int x, int y)
	{
		currentHealth = DEFAULTHEALTH;
		maxHealth = DEFAULTMAXHEALTH;
		Position = new Tuple<int, int>(x, y);
		buildingGridSystem = new BuildingGridSystem(DEFAULTGRIDSIZE, DEFAULTGRIDSIZE);

    }
}
