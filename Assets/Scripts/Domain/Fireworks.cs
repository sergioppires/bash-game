using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireworks
{

    public bool isLeft  {get;}
    public float speed {get; }
  
    public Color color {get;}

    public Fireworks(float speed, Color color, bool isLeft){
        this.speed = speed;
        this.color = color;
        this.isLeft = isLeft;
    }

}
