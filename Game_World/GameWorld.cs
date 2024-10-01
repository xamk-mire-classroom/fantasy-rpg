using System;
using System.Collections.Generic;

public class GameWorld
{
    private static GameWorld _instance;  // Holds the single instance of GameWorld
    private static readonly object _lock = new object();  // Lock object for thread safety

    // Game state variables
    public string TimeOfDay { get; private set; }
    public string Weather { get; private set; }
    public List<string> Npcs { get; private set; }  // List to store NPCs
    public string[,] WorldMap { get; private set; }  // 2D array for the world map

    // Private constructor to prevent instantiation from outside the class
    private GameWorld()
    {
        TimeOfDay = "Day";  // Default values
        Weather = "Sunny";
        Npcs = new List<string>();
        WorldMap = CreateWorldMap();
    }

    // Public property to provide global access to the instance
    public static GameWorld Instance
    {
        get
        {
            if (_instance == null)  // Check if instance is null
            {
                lock (_lock)  // Lock to prevent multiple threads from creating an instance
                {
                    if (_instance == null)  // Double-check to ensure instance is still null
                    {
                        _instance = new GameWorld();  // Create the instance
                    }
                }
            }
            return _instance;  // Return the singleton instance
        }
    }

    // Method to create a basic world map (e.g., a grid)
    private string[,] CreateWorldMap()
    {
        return new string[10, 10];  // 10x10 grid
    }

    // Method to add an NPC to the game world
    public void AddNpc(string npc)
    {
        Npcs.Add(npc);
    }

    // Method to update game state variables
    public void UpdateGameState(string timeOfDay, string weather)
    {
        TimeOfDay = timeOfDay;
        Weather = weather;
    }
}
