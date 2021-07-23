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
    public event Action<Fireworks> onEmitFireworks;
    public event Action<bool> onExplodeFireworks;

    public void EmitFireworks(Fireworks fireworks){
        onEmitFireworks?.Invoke(fireworks);
    }

        public void ExplodeFireworks(bool success){
        onExplodeFireworks?.Invoke(success);
    }   

}
