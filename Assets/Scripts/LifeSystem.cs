using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesIndicator;

    private int numberOfLifes = 5, defaultLives = 5;
    
    void Start()
    {
        Events.current.onStartGame += SetupLifes;
        Events.current.onExplodeFireworks += CountFireworksError;
    }

    // Update is called once per frame
    void Update()
    {
        livesIndicator.text = numberOfLifes.ToString();
        if(numberOfLifes == 0){
            Finishgame();
            numberOfLifes = -1;
        }
    }

    void Finishgame(){
        Events.current.EndGame();
    }

    void SetupLifes(){
        numberOfLifes = defaultLives;
    }

    void CountFireworksError(bool notHit){
        if(!notHit){
            numberOfLifes = numberOfLifes - 1;
        }
    }



}


