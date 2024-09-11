using DataLoader.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public enum SoundType
    {
        BGM,        
        EFFECT,     
        NONE,      
    }
    
    [Serializable]
    public struct AudioClips
    {
        public string ID;       
        public AudioClip clip; 
    }

    public class SoundManager : MonoBehaviour
    {
        private PlayerData playerData;
        public static SoundManager Instance;
        
        [SerializeField] AudioSource[] audioSources = new AudioSource[Enum.GetValues(typeof(SoundType)).Length];

        [SerializeField] private List<AudioClips> bgmClips;
        [SerializeField] private List<AudioClips> effectClips;

        public void Awake()
        {
            Instance = this;
            //DataLoad
        }

        private void Start()
        {
            BGMClear();
        }

        private void ChangeBGM(int sceneName)
        {
            var data = SaveManager.Instance.GetPlayerData();
            //if(data!= null && data.isBGM == false)
            //    return;
            audioSources[(int)SoundType.BGM].clip = bgmClips[sceneName].clip;
            audioSources[(int)SoundType.BGM].loop = true;   
            audioSources[(int)SoundType.BGM].Play();
        }
        public void ChangeBGM(int sceneName, bool pause)
        {
            if (pause == false)
            {
                BGMClear();
            }
            else
                ChangeBGM(sceneName);
        }
        public void BGMClear()
        {
            if (audioSources == null)
                return;
            foreach (var source in audioSources)
            {
                source.clip = null;
                source.Stop();
            }
        }

        public void EffectClear()
        {
            AudioSource effectSource = audioSources[(int)SoundType.EFFECT];
            effectSource.clip = null;
            effectSource.Stop();
        }

        public void Play(string name, SoundType type = SoundType.EFFECT, float volume = 0.5f)
        {
            playerData = SaveManager.Instance.GetPlayerData();
            AudioClip clip = GetAudioClip(name, type);
            switch(type)
            {
                case SoundType.BGM:
                    AudioSource bgmSource = audioSources[(int)SoundType.BGM];
                    if (bgmSource.isPlaying)
                    {
                        bgmSource.Stop();
                    }
                    //if(playerData != null && playerData.isBGM)
                    //    AudioSourcePlay(bgmSource, clip, volume);
                    break;
                case SoundType.EFFECT:
                    AudioSource effectSource = audioSources[(int)SoundType.EFFECT];
                    //if (playerData != null && playerData.isEffect)
                    //    AudioSourcePlay(effectSource, clip, volume);
                    break;
            }
        }

        private void AudioSourcePlay(AudioSource source, AudioClip clip, float volume = 0)
        {
            source.volume = volume;
            source.clip = clip;
            source.Play();
        }
        
        private AudioClip GetAudioClip(string name, SoundType type = SoundType.EFFECT)
        {
            List<AudioClips> currentClipList = null;

            switch(type)
            {
                case SoundType.BGM:
                    currentClipList = bgmClips;
                    break;
                case SoundType.EFFECT:
                    currentClipList = effectClips;
                    break;
            }

            AudioClip currentClip = currentClipList.Find(x => x.ID.Equals(name)).clip;
            return currentClip;
        }
    }
}