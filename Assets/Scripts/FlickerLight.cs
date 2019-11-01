using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{

    /*
    public float maxTimeOn = 0.5;
    public float minTimeOn = 0.1;  // To avoid crazy strobing

    public float maxTimeOff = 0.1;
    public float minTimeOff = 0.01;
    */
    public float probabilityOfChange = 0.1f;
    public float maxBrightness = 2f;
    public float minBrightness = 0.1f;

    private float roll;
    private bool isOn;

    Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        lt.intensity = maxBrightness;
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        roll = Random.Range(0f, 1f);
        //Debug.Log(roll);


        if (roll < probabilityOfChange)
        {
            if (isOn)
            {
                lt.intensity = minBrightness;
                isOn = false;
            }
            else
            {
                lt.intensity = maxBrightness;
                isOn = true;
            }
        }
    }
}
