using System;
using System.Collections;
using UnityEngine;

public class FireworksSystem : MonoBehaviour
{
    [SerializeField] private GameObject particleSystemGMRight;
    [SerializeField] private GameObject particleSystemGMLeft;
    [SerializeField] private ParticleLifetimeEvents particleEventsLeft;
    [SerializeField] private ParticleLifetimeEvents particleEventsRight;
    [SerializeField] private SoundController soundController;
    [SerializeField] private ParticleSystem badExplosionLeft;
    [SerializeField] private ParticleSystem goodExplosionLeft;
    [SerializeField] private ParticleSystem badExplosionRight;
    [SerializeField] private ParticleSystem goodExplosionRight;
    [SerializeField] private LevelProgression levelProgression;
    private ParticleSystem particleSystemRight, particleSystemLeft;
    private bool gameStarted = false, successLeftFireworks = false, successRightFireworks = false;

    void Start()
    {
        particleSystemLeft = particleSystemGMLeft.GetComponent<ParticleSystem>();
        particleSystemRight = particleSystemGMRight.GetComponent<ParticleSystem>();
        particleEventsLeft.ParticleDied += ParticleDiedLeft;
        particleEventsRight.ParticleDied += ParticleDiedRight;
        Events.current.onStartGame += StartGame;
        Events.current.onEndGame += SetEndGame;
        Events.current.onHitButtonRightTime += configureFireworksExplosion;
        StartCoroutine(SubrotinaFogos(2.0f));
    }

    void StartGame()
    {
        gameStarted = true;
    }

    void SetEndGame()
    {
        gameStarted = false;
    }

    IEnumerator SubrotinaFogos(float waitTime)
    {
        while (true)
        {
            Level actualLevel = levelProgression.GetActualLevel();
            waitTime = actualLevel.fireworkLaunchRatio;
            if (gameStarted)
            {
                System.Random random = new System.Random();
                if (random.NextDouble() > 0.5)
                {
                    EmitParticle(false);
                }
                else
                {
                    EmitParticle(true);
                }
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    void EmitParticle(bool isLeft)
    {
        Fireworks currentFirework = configureFireworks(isLeft);
        Events.current.EmitFireworks(currentFirework);
        alterFireworksStatus(currentFirework);
        EmitFireworks(currentFirework);
    }

    void ParticleDiedLeft()
    {
        if (successLeftFireworks)
        {
            particleSystemLeft.subEmitters.SetSubEmitterSystem(1, goodExplosionLeft);
            Events.current.ExplodeFireworks(true);

        }
        else
        {
            particleSystemLeft.subEmitters.SetSubEmitterSystem(1, badExplosionLeft);
            Events.current.ExplodeFireworks(false);
        }
        successLeftFireworks = false;
    }

    void ParticleDiedRight()
    {
        if (successRightFireworks)
        {
            particleSystemRight.subEmitters.SetSubEmitterSystem(1, goodExplosionRight);
            Events.current.ExplodeFireworks(true);

        }
        else
        {
            particleSystemRight.subEmitters.SetSubEmitterSystem(1, badExplosionRight);
            Events.current.ExplodeFireworks(false);
        }
        successRightFireworks = false;
    }
    private void alterFireworksStatus(Fireworks currentFirework)    
    {
        float explodeSize = 0.5f * (levelProgression.GetLevel());     

        if (currentFirework.isLeft)
        {
            //particleSystemLeft.startLifetime = currentFirework.speed;
            particleSystemLeft.startColor = currentFirework.color;
            goodExplosionLeft.startSpeed = 1 * levelProgression.GetLevel();
            goodExplosionLeft.startColor = currentFirework.color;
            goodExplosionLeft.startSize = explodeSize;

        }
        else
        {
            //particleSystemRight.startLifetime = currentFirework.speed;
            particleSystemRight.startColor = currentFirework.color;
            goodExplosionRight.startSpeed = 1 * levelProgression.GetLevel();
            goodExplosionRight.startColor = currentFirework.color;
            goodExplosionRight.startSize = explodeSize;
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
        Level actualLevel = levelProgression.GetActualLevel(); 
        return new Fireworks(actualLevel.fireworkSpeed, new Color(UnityEngine.Random.Range(0F, 1F), UnityEngine.Random.Range(0, 1F), UnityEngine.Random.Range(0, 1F)), isLeft);
    }

    private void configureFireworksExplosion(bool isLeft)
    {
        if (isLeft)
        {
            successLeftFireworks = true;
        }
        successRightFireworks = true;
    }

}
