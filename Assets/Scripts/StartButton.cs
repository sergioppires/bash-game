using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject controllerSystem;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        Events.current.StartGame();
        controllerSystem.SetActive(true);
        startButton.SetActive(false);
    }


}
