using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject lightGM;

    private bool isActive = false;
    private float index = 0f;
    private float rotation = 0.01f, maxRotation = 100.0f;
    private Transform originalTransform;
    void Start()
    {
        originalTransform = lightGM.transform;
        Events.current.onStartGame += ActivateDay;
        Events.current.onEndGame += DeactivateDay;
    }
    void FixedUpdate()
    {        
        if(isActive){
            lightGM.transform.Rotate(0.0f, rotation, 0.0f, Space.Self);
            index = index + rotation;
            if(index>=maxRotation){
                isActive = false;
            }
        }
    }

    void ActivateDay(){
        isActive = true;
    }

    void DeactivateDay(){
        isActive = false;
        lightGM.transform.position = originalTransform.position;
        lightGM.transform.rotation = originalTransform.rotation;
    }
}
