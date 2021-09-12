using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public List<PullForce> Worlds = new List<PullForce>();
    //private List<PullForce> TempWorlds = new List<PullForce>();
    public List<bool> tempbools = new List<bool>();
    private bool updateAllPlanets = false;
    // Start is called before the first frame update
    void Start()
    {
        foreach (PullForce world in Worlds)
        {
            tempbools.Add(world.doesplayerStartOnMe);
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateList();
    }

    private void UpdateList() 
    {
        for (int i = 0; i < Worlds.Count; i++)
        {
            if (Worlds[i].doesplayerStartOnMe != tempbools[i])
            {
                updateAllPlanets = true;
            }
        }

        if (updateAllPlanets)
        { 
            for (int i = 0; i < Worlds.Count; i++)
            {
                Worlds[i].doesplayerStartOnMe = Worlds[i].DoIHaveRat();
                tempbools[i] = Worlds[i].doesplayerStartOnMe;
                ManagerClass.didPlayerSwitchPlanet = false;
            }

            updateAllPlanets = false;
        }
    }
}
