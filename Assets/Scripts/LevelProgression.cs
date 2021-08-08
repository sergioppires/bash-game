using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelProgression : MonoBehaviour
{

    private Level levelObject;
    private float timeToLevelUp = 15f;
    private int Level;
    private float fireworkSpeedBase;
    private float fireworkLaunchRatioBase;
    private float lightRangeBase;

    void Start()
    {
        Events.current.onStartGame += StartLevelProgression;
        Events.current.onEndGame += ResetLevelUpProgression;
        Level = 1;  
        fireworkSpeedBase = 1.0f;
        fireworkLaunchRatioBase = 3.5f;
        lightRangeBase = 10;
    }

    void StartLevelProgression()
    {
        StartCoroutine(LevelUpLogic(timeToLevelUp));
    }

    IEnumerator LevelUpLogic(float time)
    {
        yield return new WaitForSeconds(time);
        Level = Level + 1;
        Debug.Log("Level: " + Level);
        if (Level<=5) {
            Events.current.LevelUp(GetActualLevel());
            StartCoroutine(LevelUpLogic(timeToLevelUp));
        }
    }

    void ResetLevelUpProgression()
    {
        Level = 1;
        Events.current.LevelUp(GetActualLevel());
        StopAllCoroutines();
    }

    public Level GetActualLevel(){
        float speed = fireworkSpeedBase + (Level * 0.5f);
        float launchratio = (fireworkLaunchRatioBase - (Level * 0.5f));
        float lightRage = lightRangeBase * (Level*10);
        return new Level(speed,launchratio, lightRage);

    }

    
}


