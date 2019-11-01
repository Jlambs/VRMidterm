using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private GameObject grabbedObject;

    public float maxBrightness = 3f;
    public float drainRate = 0.001f; // power drained per frame

    public float startPower = 0.75f;  // 0->1
    private float currentPower;
    public float powerupRestoreAmount = 1f;

    private int powerupLayer = 1 << 9; // Layer 9 (Powerups)
    private int trollDollLayer = 1 << 10; // Layer 10 (Troll dolls)

    public float grabDistance = 3f;
 
    private float volume = 0.1f;

    private AudioSource audioclip;
    private GameObject lightObject;
    private Light lt;

    private bool isOn;
    private Light flshlt;

    private GameObject trollObject;

    public GameObject battery0; // Empty
    public GameObject battery1; // 1/4
    public GameObject battery2; // 1/2
    public GameObject battery3; // 3/4
    public GameObject battery4; // Full

    public GameObject babyMover;
    public GameObject horrorDoll;

    private void Start()
    {
        battery0.SetActive(false);
        battery1.SetActive(false);
        battery2.SetActive(false);
        battery3.SetActive(false);
        battery4.SetActive(false);

        currentPower = startPower;
        flshlt = GetComponent<Light>();
        flshlt.intensity = 0;
    }

    private void Update()
    {
        // If flashlight is on, drain power
        if (isOn)
        {
            currentPower -= drainRate;
            Debug.Log(currentPower);
        }
        if (currentPower < 0)
        {
            flshlt.intensity = 0f;
            currentPower = 0f;
            isOn = false;
        }

        // Set battery graphic
        if (currentPower == 0)
        {
            battery0.SetActive(true);
            battery1.SetActive(false);
            battery2.SetActive(false);
            battery3.SetActive(false);
            battery4.SetActive(false);
        }
        else if (currentPower < 0.25)
        {
            battery0.SetActive(false);
            battery1.SetActive(true);
            battery2.SetActive(false);
            battery3.SetActive(false);
            battery4.SetActive(false);
        }
        else if (currentPower < .5)
        {
            battery0.SetActive(false);
            battery1.SetActive(false);
            battery2.SetActive(true);
            battery3.SetActive(false);
            battery4.SetActive(false);
        }
        else if (currentPower < .75)
        {
            battery0.SetActive(false);
            battery1.SetActive(false);
            battery2.SetActive(false);
            battery3.SetActive(true);
            battery4.SetActive(false);
        }
        else
        {
            battery0.SetActive(false);
            battery1.SetActive(false);
            battery2.SetActive(false);
            battery3.SetActive(false);
            battery4.SetActive(true);
        }

        // Toggle flashlight when trigger is pressed
        if (Input.GetButtonUp("Fire1"))
        {
            // Only turn it on if the battery level is high enough
            if (!isOn && (currentPower > 0))
            {
                flshlt.intensity = maxBrightness;
                isOn = true;
            }
            else
            {
                flshlt.intensity = 0;
                isOn = false;
            }
        }

        // See if the player is trying to grab a powerup
        if (Input.GetButtonDown("Grab"))
        {
            // The Unity raycast hit object, which will store the output of our raycast
            RaycastHit hit;

            // Parameters: position to start the ray, direction to project the ray, output for raycast, limit of ray length, and layer mask
            if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, powerupLayer))
            {

                // Grabble up that GameObject
                grabbedObject = hit.collider.gameObject;

                // Set audio
                audioclip = grabbedObject.GetComponent<AudioSource>();

                // Update log text
                Debug.Log("Grabbing " + grabbedObject.name);

                // Delete grabbed object's light
                lightObject = GameObject.FindGameObjectWithTag("Active Powerup");
                lt = lightObject.GetComponent<Light>();
                lt.intensity = 0f;
                lightObject.tag = "Untagged";

                // Play sound
                audioclip.Play();

                // Juice up power
                currentPower += powerupRestoreAmount;

            }

            // Parameters: position to start the ray, direction to project the ray, output for raycast, limit of ray length, and layer mask
            if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, trollDollLayer))
            {

                // Grabble up that GameObject
                grabbedObject = hit.collider.gameObject;

                // Set audio
                audioclip = grabbedObject.GetComponent<AudioSource>();

                // Update log text
                Debug.Log("Grabbing " + grabbedObject.name);

                // Delete troll object and replace with old model
                trollObject = GameObject.FindGameObjectWithTag("Troll Doll");
                trollObject.tag = "Untagged";
                trollObject.GetComponent<MeshRenderer>().materials = babyMover.GetComponent<BabyMover>().oldMaterials;

                // Restore real baby's model
                horrorDoll.SetActive(true);
                babyMover.GetComponent<BabyMover>().isTrolling = false;

            }
        }
    }
}
