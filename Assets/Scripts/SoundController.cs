using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource D5Sound;
    [SerializeField] private AudioSource B5Sound;

    // Start is called before the first frame update
    void Start()
    {
        Events.current.onExplodeFireworks += PlaySound;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(bool sucess){
        //B5Sound.Play();
        D5Sound.Play();
    }
}
