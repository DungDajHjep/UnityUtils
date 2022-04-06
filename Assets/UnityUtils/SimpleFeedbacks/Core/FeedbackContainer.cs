using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackContainer : MonoBehaviour
{
    public List<FeedbackList> feedbacks;

    public bool TryGetValue(string key, out FeedbackList feedback)
    {
        foreach (var item in feedbacks)
        {
            if (item.key.Equals(key))
            {
                feedback = item;
                return true;
            }
        }

        feedback = null;
        return false;
    }

    public void Trigger(string key)
    {
        if (TryGetValue(key, out var feedback))
            feedback.Trigger();
    }

    public void Stop(string key)
    {
        if (TryGetValue(key, out var feedback))
            feedback.Stop();
    }
}