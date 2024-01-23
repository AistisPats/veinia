using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.Rendering.Universal;

public class PlayerActionsManager : MonoBehaviour
{
    public float MaxHearts;
    public float LightHeartDrainRate;
    public float LightIntensifyingRate;
    public float LightDimmingRate;
    public float MinLightIntensity;
    public float MaxLightIntensity;
    public Light2D StrongLight;

    private float Hearts;

    private bool usingLight = false;

    void Start()
    {
        Hearts = MaxHearts;
        

    }


    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Hearts > 0)
        {
            usingLight = true;
        }
        else
        {
            usingLight = false;
        }
        if (usingLight)
        {
            if(StrongLight.intensity < MaxLightIntensity)
            {
                StrongLight.intensity += Time.deltaTime * LightIntensifyingRate;
            }
            //StrongLight.enabled = true;
            Hearts -= LightHeartDrainRate * Time.deltaTime;
        }
        else
        {
            if(StrongLight.intensity > MinLightIntensity)
            {
                StrongLight.intensity -= Time.deltaTime * LightDimmingRate;
            }
            //StrongLight.enabled = false;
        }
    }
}
