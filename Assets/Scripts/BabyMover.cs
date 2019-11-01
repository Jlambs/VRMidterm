using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thanks to https://forum.unity.com/threads/changing-a-material-at-runtime-on-a-meshrenderer.540890/

public class BabyMover : MonoBehaviour
{
    // Keep track of whether the baby is currently being moved
    public bool isTrolling;

    public GameObject stageManager;
    public GameObject powerupManager;

    public Material horrorDollMaterial;
    public GameObject horrorDoll;
    public Material[] oldMaterials; // For keeping track of what object was replaced
    private Material[] newMaterials;

    public float timeBetweenTrolls = 10f;
    private float timeSinceTroll = 0f;

    private MeshRenderer mshrndr;

    public GameObject powerupObject1;
    public GameObject powerupObject2;
    public GameObject powerupObject3;
    public GameObject powerupObject4;
    public GameObject powerupObject5;
    public GameObject powerupObject6;

    private MeshRenderer meshRenderer1;
    private MeshRenderer meshRenderer2;
    private MeshRenderer meshRenderer3;
    private MeshRenderer meshRenderer4;
    private MeshRenderer meshRenderer5;
    private MeshRenderer meshRenderer6;

    public int objectPicked;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure this starts as false
        isTrolling = false;

        meshRenderer1 = powerupObject1.GetComponent<MeshRenderer>();
        meshRenderer2 = powerupObject2.GetComponent<MeshRenderer>();
        meshRenderer3 = powerupObject3.GetComponent<MeshRenderer>();
        meshRenderer4 = powerupObject4.GetComponent<MeshRenderer>();
        meshRenderer5 = powerupObject5.GetComponent<MeshRenderer>();
        meshRenderer6 = powerupObject6.GetComponent<MeshRenderer>();

        newMaterials = meshRenderer1.materials;
        newMaterials[0] = horrorDollMaterial;

    }

    // Update is called once per frame
    void Update()
    {
        int stage = stageManager.GetComponent<StageManager>().stageNum;

        // Don't troll during the hiding phase
        if (stage > 0 && !isTrolling)
        {
            // Add to time since last spawn was seen
            timeSinceTroll += Time.deltaTime;
        }

        if (timeSinceTroll > timeBetweenTrolls)
        {
            // Pick a random object of the 6 powerup objects to move baby to
            objectPicked = Random.Range(1, 7);
            // Make sure we don't move the baby to an object being used as a powerup
            while (objectPicked == powerupManager.GetComponent<PowerupManager>().objectPicked)
            {
                objectPicked = Random.Range(1, 7);
            }

            // Hide real doll
            horrorDoll.SetActive(false);

            switch (objectPicked)
            {
                case 1:
                    oldMaterials = meshRenderer1.materials;
                    meshRenderer1.materials = newMaterials;
                    powerupObject1.tag = "Troll Doll";
                    powerupObject1.GetComponent<AudioSource>().Play();
                    break;

                case 2:
                    oldMaterials = meshRenderer2.materials;
                    meshRenderer2.materials = newMaterials;
                    powerupObject2.tag = "Troll Doll";
                    powerupObject2.GetComponent<AudioSource>().Play();
                    break;

                case 3:
                    oldMaterials = meshRenderer3.materials;
                    meshRenderer3.materials = newMaterials;
                    powerupObject3.tag = "Troll Doll";
                    powerupObject3.GetComponent<AudioSource>().Play();
                    break;

                case 4:
                    oldMaterials = meshRenderer4.materials;
                    meshRenderer4.materials = newMaterials;
                    powerupObject4.tag = "Troll Doll";
                    powerupObject4.GetComponent<AudioSource>().Play();
                    break;

                case 5:
                    oldMaterials = meshRenderer5.materials;
                    meshRenderer5.materials = newMaterials;
                    powerupObject5.tag = "Troll Doll";
                    powerupObject5.GetComponent<AudioSource>().Play();
                    break;

                case 6:
                    oldMaterials = meshRenderer6.materials;
                    meshRenderer6.materials = newMaterials;
                    powerupObject6.tag = "Troll Doll";
                    powerupObject6.GetComponent<AudioSource>().Play();
                    break;
            }

            Debug.Log("Spawned baby at " + objectPicked.ToString());

            // Reset troll variables
            timeSinceTroll = 0f;
            isTrolling = true;
        }

    }
}
