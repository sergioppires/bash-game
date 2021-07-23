using System;
using System.Collections;
using UnityEngine;

public class FireworksSystem : MonoBehaviour
{
    [SerializeField] private GameObject particleSystemGMRight;
    [SerializeField] private GameObject particleSystemGMLeft;
    [SerializeField] private ParticleLifetimeEvents particleEventsLeft;
    [SerializeField] private SoundController soundController;
    private ParticleSystem particleSystemRight, particleSystemLeft;
    void Start()
    {
        particleSystemLeft = particleSystemGMLeft.GetComponent<ParticleSystem>();
        particleSystemRight = particleSystemGMRight.GetComponent<ParticleSystem>();
        particleEventsLeft.ParticleDied += ParticleDied;
        StartCoroutine(SubrotinaFogos(2.0f));
    }

    IEnumerator SubrotinaFogos(float waitTime) {
        while (true) {
            System.Random random = new System.Random();
            if (random.NextDouble() > 0.5) {
                EmitParticle(false);
            } else {
                EmitParticle(true);
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    void EmitParticle(bool isLeft)
    {
        Fireworks currentFirework = configureFireworks(isLeft);
        Events.current.EmitFireworks(currentFirework);
        configureFireworks(currentFirework);
        EmitFireworks(currentFirework);
    }    

    void ParticleDied(){
        soundController.PlaySound(true);
    }

    private void configureFireworks(Fireworks currentFirework)
    {
        if (currentFirework.isLeft)
        {
            particleSystemLeft.startLifetime = currentFirework.speed;
            particleSystemLeft.startColor = currentFirework.color;
        }
        else
        {
            particleSystemRight.startLifetime = currentFirework.speed;
            particleSystemRight.startColor = currentFirework.color;
        }
    }

    private void EmitFireworks(Fireworks fireworks)
    {
        if (fireworks.isLeft)
        {
            particleSystemLeft.Emit(1);
        }
        else
        {
            particleSystemRight.Emit(1);
        }
    }
    private Fireworks configureFireworks(bool isLeft)
    {
        return new Fireworks(1.0f, new Color(UnityEngine.Random.Range(0F, 1F), UnityEngine.Random.Range(0, 1F), UnityEngine.Random.Range(0, 1F)), isLeft);
    }


}
