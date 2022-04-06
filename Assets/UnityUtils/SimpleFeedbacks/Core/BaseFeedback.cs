using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFeedback : MonoBehaviour
{
    protected bool isPlaying = false;

    public virtual void Trigger()
    {
        if (isPlaying) return;

        isPlaying = true;

        OnTrigger();
    }

    public virtual void Stop()
    {
        isPlaying = false;
    }

    protected virtual void OnTrigger()
    {

    }

}
