using System;
using System.Collections;
using UnityEngine;

public class FireworksSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject particleSystemGMRight;
    [SerializeField] private GameObject particleSystemGMLeft;

    private ParticleSystem particleSystemRight, particleSystemLeft;
    ParticleSystem.Particle[] m_ParticlesRight, m_ParticlesLeft;

    IEnumerator Start() {
        particleSystemRight = particleSystemGMRight.GetComponent<ParticleSystem>();
        particleSystemLeft = particleSystemGMLeft.GetComponent<ParticleSystem>();
        Events.current.onPressRightButton += EmitParticleRight;
        Events.current.onPressLeftButton += EmitParticleLeft;
        yield return StartCoroutine(SubrotinaFogos(2.0f));

    }

    IEnumerator SubrotinaFogos(float waitTime) {
        while(true){
        System.Random random = new System.Random(); 
        if (random.NextDouble() > 0.5) {
            EmitParticleRight();
        } else {
            EmitParticleLeft();
        }
        yield return new WaitForSeconds(waitTime);
        }
    }

    void EmitParticleRight(){
        Events.current.EmitFireworksRight(configureFireworks(false));
        particleSystemLeft.startLifetime = 1.0f;
        particleSystemRight.Emit(1);
    }

    void EmitParticleLeft(){
        Events.current.EmitFireworksLeft(configureFireworks(true));
        particleSystemLeft.startLifetime = 1.0f;
        particleSystemLeft.Emit(1);
    }

    private Fireworks configureFireworks(bool isLeft){
        return new Fireworks(1.0f, new Color(UnityEngine.Random.Range(0F,1F), UnityEngine.Random.Range(0, 1F), UnityEngine.Random.Range(0, 1F)),isLeft);
    }


}
