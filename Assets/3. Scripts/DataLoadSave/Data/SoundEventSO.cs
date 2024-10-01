using System.Collections.Generic;
using UnityEngine;
using Utils;

[CreateAssetMenu(menuName = "ScriptableObjects/SoundEventSO")]
public class SoundEventSO : ScriptableObject
{
    [SerializeField] public AudioClip clip;
    [SerializeField] public SoundType soundType;

    private List<SoundListener> listeners = new List<SoundListener>();

    public void RegisterListener(SoundListener listener)
    {
        listeners.Add(listener);
    }
    public void UnRegisterListener(SoundListener listener)
    {
        listeners.Remove(listener);
    }
    public void Raise()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventRaised(soundType);
        }
    }
}