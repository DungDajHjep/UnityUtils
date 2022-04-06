using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public static class ExtensionMethods
{
    public static void SetVolume(this AudioMixer audioMixer, string _name, float _v)
    {
        audioMixer.SetFloat(_name, Mathf.Log10(_v) * 20);
    }

    public static float Angle360Vector2Rad(Vector2 vec1, Vector2 vec2)
    {
        return Angle360Vector2Deg(vec1, vec2) * Mathf.Deg2Rad; ;
    }

    public static float Angle360Vector2Deg(Vector2 vec1, Vector2 vec2)
    {
        float angle = Vector2.SignedAngle(vec1, vec2);
        if (angle < 0)
            angle = 360 + angle;
        return angle;
    }

    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        return Quaternion.Euler(0, 0, degrees) * v;
    }

    public static bool Contains(this LayerMask layerMask, int layer)
    {
        if (((1 << layer) & layerMask) != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ContainsIgnoreCase(this string s, string v)
    {
        return s.IndexOf(v, System.StringComparison.CurrentCultureIgnoreCase) >= 0;
    }

    public static bool PercentSystem(float percent)
    {
        if (percent == 1f)
            return true;

        if (percent == 0f)
            return false;

        Random.InitState(Mathf.CeilToInt(Random.value * 1000));

        float randomValue = Random.value;

        if (randomValue <= percent)
            return true;

        return false;
    }

    public static float Choose(float[] probs)
    {
        float total = 0;

        foreach (float elem in probs)
        {
            total += elem;
        }

        float randomPoint = Random.value * total;

        for (int i = 0; i < probs.Length; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Length - 1;
    }

    public static void Swap<T>(this IList<T> list, int i, int j)
    {
        var temporary = list[i];
        list[i] = list[j];
        list[j] = temporary;
    }

    /// <summary>
    /// Shuffles a list randomly
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    public static void Shuffle<T>(this IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list.Swap(i, Random.Range(i, list.Count));
        }
    }
}
