using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Light lightSystem;
    void Start() {
        Events.current.onLevelUp += UpdateLightAmount;
    }

    void UpdateLightAmount(Level level){
        lightSystem.range = level.lightRange;
    }

}
