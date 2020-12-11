using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteSphere : Collectable
{
   public IEnumerator StartCollectAnimation()
    {
        float timeLapse = 0, totalTime=0.5f;
        while(timeLapse<=totalTime)
        {
            timeLapse += Time.deltaTime;
            yield return null;
        }
        //GameManager.INSTANCE.particleManager.PlayParticle(transform, ParticleType.Blast);
        blastParticle.Play();
        yield return new WaitForSeconds(blastParticle.duration);
        this.gameObject.SetActive(false);
    }
}
