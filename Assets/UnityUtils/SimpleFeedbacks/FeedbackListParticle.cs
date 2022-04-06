using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackListParticle : BaseFeedback
{
    public ParticleSystem[] particles;

    protected override void OnTrigger()
    {
        isPlaying = false;

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Play();
        }
    }

    public override void Stop()
    {
        base.Stop();

        for (int i = 0; i < particles.Length; i++)
        {
            particles[i].Stop();
        }
    }

}
