using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> particles = new List<ParticleSystem>();

    public void PlayParticle(Transform transformParticle,ParticleType type)
    {
        switch(type)
        {
            case ParticleType.Blast:
                particles[0].transform.position = transformParticle.position;
                particles[0].Emit(1);
                break;
            case ParticleType.Smiley:
                particles[1].transform.position = transformParticle.position+Vector3.up*2f;
                particles[1].Play();
                break;
        }
    }
}
public enum ParticleType
{
    Blast,
    Smiley
}
