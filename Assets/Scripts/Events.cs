using System;
using UnityEngine;

public class Events : MonoBehaviour
{

    public static Events current;

    private void Awake() {
        current = this;
    }

    //Button press events
    public event Action onPressRightButton;
    public event Action onPressLeftButton;

    public void PressRightButton(){
        onPressRightButton?.Invoke();
    }

    public void PressLeftButton(){
        onPressLeftButton?.Invoke();
    }


    //Fireworks Emitter Events 
    public event Action<Fireworks> onEmitFireworksRight;
    public event Action<Fireworks> onEmitFireworksLeft;

    public void EmitFireworksRight(Fireworks fireworks){
        onEmitFireworksRight?.Invoke(fireworks);
    }

    public void EmitFireworksLeft(Fireworks fireworks){
        onEmitFireworksLeft?.Invoke(fireworks);
    }
}
