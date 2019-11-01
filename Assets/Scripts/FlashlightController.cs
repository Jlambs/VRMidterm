using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public float maxBrightness = 1f;

    private bool isOn;
    private Light lt;

    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light>();
        lt.intensity = 0;
        isOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Toggle flashlight
        if (Input.GetButtonUp("Fire1"))
        {
            if (isOn)
            {
                lt.intensity = 0;
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
