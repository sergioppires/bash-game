using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineAnimation : MonoBehaviour
{

    [SerializeField] public CinemachineFreeLook cinemachineFreeLook;
    [SerializeField] private LevelProgression levelProgression;


    public float yvalue = 0.93f, index = 0, xSpeedInitial = 0.1f, xSpeedGame = 0.05f;
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
            cinemachineFreeLook.m_XAxis.Value = xSpeedGame;
            cinemachineFreeLook.m_YAxis.Value = yvalue;
        } else {
            cinemachineFreeLook.m_XAxis.Value = xSpeedInitial;
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