using System;
using UnityEngine;
using UnityEngine.Events;
using Utils;

public class SoundListener : MonoBehaviour
{
    
    private AudioSource audioSource;
    public SoundEventSO[] soSoundDatas;

    //public UnityAction action;
    [Serializable] public class SoundEvent : UnityEvent<SoundType> { }
    public SoundEvent response;

    private void OnEnable()
    {
        foreach(var e in soSoundDatas)
            e.RegisterListener(this);
    }
    private void OnDisable()
    {
        foreach(var e in soSoundDatas)
            e.UnRegisterListener(this);
    }

    public void OnEventRaised(SoundType type)
    {
        response.Invoke(type);
    }
    public void SoundPlaySFX(SoundType type)
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(soSoundDatas[(int)type].clip);
    }
    public void SoundPlayBGM(SoundType type)
    {
        if (type != SoundType.MainBGM && type != SoundType.SecondBGM)
            return;

        audioSource = GetComponent<AudioSource>();
        var bgmClips = soSoundDatas[(int)type].clip;
        if (audioSource.clip != null)
            audioSource.Stop();

        audioSource.clip = bgmClips;
        audioSource.loop = true;
        audioSource.Play();
    }
}