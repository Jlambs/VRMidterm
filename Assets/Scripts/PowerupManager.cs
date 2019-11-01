using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thanks to https://forum.unity.com/threads/how-to-access-variable-from-other-game-object.405256/

public class PowerupManager : MonoBehaviour
{
    public float timeBetweenSpawns = 15f;

    private float timeSinceSpawn = 0f;

    public float maxBrightness = 2f;

    public int objectPicked;

    public GameObject[] activePowerups;

    public GameObject stageManager;
    public GameObject babyMover;

    public Light powerupLight1;
    public Light powerupLight2;
    public Light powerupLight3;
    public Light powerupLight4;
    public Light powerupLight5;
    public Light powerupLight6;

    // Update is called once per frame
    void Update()
    {

        int stage = stageManager.GetComponent<StageManager>().stageNum;
        bool isTrolling = babyMover.GetComponent<BabyMover>().isTrolling;

        // Don't spawn powerups during the hiding phase or while trolling
        if (stage > 0 && !isTrolling)
        {
            // Add to time since last spawn was seen
            timeSinceSpawn += Time.deltaTime;
        }

        activePowerups = GameObject.FindGameObjectsWithTag("Active Powerup");

        if ((timeSinceSpawn > timeBetweenSpawns) && (activePowerups.Length == 0))
        { 

            // Pick a random object of the 6 powerup objects
            objectPicked = Random.Range(1, 7);

            // Make sure we don't spawn the powerup in an object being used as a troll
            while (objectPicked == babyMover.GetComponent<BabyMover>().objectPicked)
            {
                objectPicked = Random.Range(1, 7);
            }

            switch (objectPicked)
            {
                case 1:

                    powerupLight1.intensity = maxBrightness;
                    powerupLight1.tag = "Active Powerup";
                    break;

                case 2:

                    powerupLight2.intensity = maxBrightness;
                    powerupLight2.tag = "Active Powerup";
                    break;

                case 3:

                    powerupLight3.intensity = maxBrightness;
                    powerupLight3.tag = "Active Powerup";
                    break;

                case 4:

                    powerupLight4.intensity = maxBrightness;
                    powerupLight4.tag = "Active Powerup";
                    break;

                case 5:

                    powerupLight5.intensity = maxBrightness;
                    powerupLight5.tag = "Active Powerup";
                    break;

                case 6:

                    powerupLight6.intensity = maxBrightness;
                    powerupLight6.tag = "Active Powerup";
                    break;
            }

            Debug.Log("Spawned powerup at " + objectPicked.ToString());

            timeSinceSpawn = 0f;
        }
    }
}
