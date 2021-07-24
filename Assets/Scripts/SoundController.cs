using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    //Background Music
    [SerializeField] private AudioSource BackgroundMusic;

    //Consonant Sounds
    [SerializeField] private AudioSource D5Sound;
    [SerializeField] private AudioSource A5Sound;
    [SerializeField] private AudioSource C5Sound;
    [SerializeField] private AudioSource F5Sound;
    [SerializeField] private AudioSource G5Sound;
    //Dissonant Sounds
    [SerializeField] private AudioSource E5Sound;
    [SerializeField] private AudioSource B5Sound;
    private float BPM = 70;
    private float MusicTimeTick;

    // Start is called before the first frame update
    void Start()
    {
        Events.current.onExplodeFireworks += PlaySound;
        Events.current.onStartGame += StartBackGroundMusic;
        MusicTimeTick = 60/BPM;
    }

    void StartBackGroundMusic()
    {
        BackgroundMusic.Play();
    }

    public void PlaySound(bool sucess)
    {
        if (sucess)
        {
            PlaySucessSound();
        }
        else
        {
            PlayErrorSound();
        }
    }

    void PlaySucessSound()
    {
        System.Random random = new System.Random();
        int card = random.Next(99);
        if (card >= 0 && card < 20)
        {
            D5Sound.Play();
        }
        else if (card >= 20 && card < 40)
        {
            A5Sound.Play();
        }
        else if (card >= 40 && card < 60)
        {
            C5Sound.Play();
        }
        else if (card >= 60 && card < 80)
        {
            F5Sound.Play();
        }
        else
        {
            G5Sound.Play();
        }
    }

    void PlayErrorSound()
    {
        E5Sound.Play();
    }
}
