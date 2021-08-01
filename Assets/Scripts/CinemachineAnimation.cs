using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineAnimation : MonoBehaviour
{

    [SerializeField] public CinemachineFreeLook cinemachineFreeLook;

    public float yvalue = 0.93f, index = 0;
    bool isActive = false;

    private AxisState initialValueX;

    void Start()
    {
        Events.current.onStartGame += ActivateAnimation;
        Events.current.onEndGame += DeactivateAnimation;
        initialValueX = cinemachineFreeLook.m_YAxis;
    }

    void Update()
    {
        if (isActive)
        {
            cinemachineFreeLook.m_XAxis = initialValueX;
            cinemachineFreeLook.m_YAxis.Value = yvalue;
        } else {
            cinemachineFreeLook.m_XAxis.Value = 0.1f;
        }

    }

    void ActivateAnimation()
    {
        isActive = true;
    }

    void DeactivateAnimation()
    {
        isActive = false;
    }
}