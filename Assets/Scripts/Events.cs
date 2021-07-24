using System;
using UnityEngine;

public class Events : MonoBehaviour
{

    public static Events current;

    private void Awake()
    {
        current = this;
    }
    public event Action onStartGame;
    public void StartGame()
    {
        onStartGame?.Invoke();
    }

    //Button press events
    public event Action onPressRightButton;
    public event Action onPressLeftButton;

    public void PressRightButton()
    {
        onPressRightButton?.Invoke();
    }

    public void PressLeftButton()
    {
        onPressLeftButton?.Invoke();
    }


    //Fireworks Emitter Events 
    public event Action<Fireworks> onEmitFireworks;
    public event Action<bool> onExplodeFireworks;
    public event Action<bool> onHitButtonRightTime;

    public void EmitFireworks(Fireworks fireworks)
    {
        onEmitFireworks?.Invoke(fireworks);
    }

    public void ExplodeFireworks(bool success)
    {
        onExplodeFireworks?.Invoke(success);
    }
    public void HitButtonRightTime(bool isLeft)
    {
        onHitButtonRightTime?.Invoke(isLeft);
    }

}
