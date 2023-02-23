using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour
{
    private bool _on;

    private GameObject lighting;
    private Light lightComp;

    private float timer = 0.0f;
    public float interval = 3.0f;
    public bool doesFlicker = false;


    // Start is called before the first frame update
    void Start()
    {
        // Make a light source
        lighting = new GameObject("Light");

        // Add the light component for the lightsource
        lightComp = lighting.AddComponent<Light>();

        // Set color and position
        lightComp.color = Color.yellow;

        // Set type
        lightComp.type = LightType.Spot;

        // Set angle
        lightComp.spotAngle = 75;



        // Getting the position of this lightpost
        Vector3 pos = gameObject.transform.position;

        // Set the position (or any transform property)
        lighting.transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (doesFlicker)
        {
            //     // FIXED INTERVALS
            //     timer += Time.deltaTime;
            //     if (timer >= interval)
            //     {
            //         timer = 0.0f;
            //         if (_on)
            //         {
            //             _on = false;
            //             lightComp.intensity = 0;
            //         }
            //         else
            //         {
            //             _on = true;
            //             lightComp.intensity = 20;
            //         }
            //     }
            // }

            // RANDOM INTERVALS
            int flicker = Random.Range(1, 100);
            if (flicker == 1)
            {
                if (_on)
                {
                    _on = false;
                    lightComp.intensity = 0;
                }
                else
                {
                    _on = true;
                    lightComp.intensity = 15;
                }
            }
        }
    }
}
