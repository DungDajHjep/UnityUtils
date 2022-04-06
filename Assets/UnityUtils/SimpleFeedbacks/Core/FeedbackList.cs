using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class FeedbackList
{
    public string key;
    [Space(5)]
    public List<BaseFeedback> listFeedback;

    public void Trigger()
    {
        for (int i = 0; i < listFeedback.Count; i++)
        {
            listFeedback[i].Trigger();
        }
    }

    public void Stop()
    {
        for (int i = 0; i < listFeedback.Count; i++)
        {
            listFeedback[i].Stop();
        }
    }
}
