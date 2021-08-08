using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{

    public float fireworkSpeed {get; }  
    public float fireworkLaunchRatio {get; }  
    public float lightRange {get; }

    public Level(float fireworkSpeed, float fireworkLaunchRatio, float lightRage){
        this.fireworkSpeed = fireworkSpeed;
        this.fireworkLaunchRatio = fireworkLaunchRatio;
        this.lightRange = lightRage;
    }

}
