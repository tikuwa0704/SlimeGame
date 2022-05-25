using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class IceAudio : MonoBehaviour
{
    [SerializeField] AudioClip[] clips;
    [SerializeField] AudioClip iceClips;
    [SerializeField] AudioClip iceBreakClips;
    [SerializeField] bool randomizePitch = true;
    [SerializeField] float pitchRange = 0.1f;

    protected AudioSource source;

    private void Awake()
    {
        // アタッチしたオーディオソースのうち1番目を使用する
        source = GetComponents<AudioSource>()[0];
    }

    public void PlayFootstepSE()
    {
        if (randomizePitch)
            source.pitch = 1.0f + Random.Range(-pitchRange, pitchRange);

        source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
    }

    public void PlayIceSE()
    {
        source.PlayOneShot(iceClips);
    }

    public void PlayIceBreakSE()
    {
        source.PlayOneShot(iceBreakClips);
    }

}
