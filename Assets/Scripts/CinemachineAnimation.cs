using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineAnimation : MonoBehaviour
{

    [SerializeField] public CinemachineFreeLook cinemachineFreeLook;
    public float yvalue = 0.93f, index=0;
    bool isActive = false;


    void Start(){
        Events.current.onStartGame += ActivateAnimation;
    }

    void Update(){
        if(isActive){
            while(cinemachineFreeLook.m_YAxis.Value< yvalue){
                cinemachineFreeLook.m_YAxis.Value = index;               
                index += 0.1f;
            }
        }
    }

    void ActivateAnimation() {
        isActive=true;
             
    }
}