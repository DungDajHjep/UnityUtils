using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackSound : BaseFeedback
{
    [Header("Volume")]
    public Vector2 minMaxVolume = Vector2.one;
    public Vector2 minMaxPitch = Vector2.one;
    public AudioSource audioSource;

    [Header("Random Sound")]
    /// an array to pick a random sfx from
    public AudioClip[] randomSfx;


    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
                audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    protected override void OnTrigger()
    {
        if (audioSource == null) return;

        isPlaying = false;

        float volume = minMaxVolume.x < minMaxVolume.y ? Random.Range(minMaxVolume.x, minMaxVolume.y) : minMaxVolume.x;
        float pitch = minMaxPitch.x < minMaxPitch.y ? Random.Range(minMaxPitch.x, minMaxPitch.y) : minMaxPitch.x;

        audioSource.pitch = pitch;
        var clip = randomSfx[Random.Range(0, randomSfx.Length)];
        audioSource.PlayOneShot(clip, volume);
    }
}
