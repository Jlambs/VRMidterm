using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Thanks to https://answers.unity.com/questions/1273054/change-text-value.html

public class StageManager : MonoBehaviour
{
    public int stageNum;

    public GameObject hidingText;
    public float hidingTime = 30f;

    private Text hdTxt;

    // Start is called before the first frame update
    void Start()
    {
        hdTxt = hidingText.GetComponent<Text>();

        stageNum = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        switch (stageNum)
        {
            // Hiding phase
            case 0:
                
                hidingTime -= Time.deltaTime;

                hdTxt.text = "Hiding time: " + Mathf.Ceil(hidingTime).ToString();

                if (hidingTime < 5)
                {
                    hdTxt.color = Color.red;
                }

                if (hidingTime < 0)
                {
                    stageNum = 1;
                    hidingText.SetActive(false);
                }

                break;

            // Seeking phase
            case 1:
                // Nothing actually needs to happen here
                break;
        }
    }
}
