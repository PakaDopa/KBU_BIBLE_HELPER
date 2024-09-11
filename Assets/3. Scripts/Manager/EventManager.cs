using JetBrains.Annotations;
using System;
using System.Collections.Generic;

using UnityEngine;

using Utils;

[Serializable]
public class TransformEventArgs : EventArgs
{
    public Transform transform;
    public object[] value;
    public TransformEventArgs(Transform transform, params object[] value)
    {
        this.transform = transform;
        this.value = value;
    }
}
[Serializable] //이쁜 누나는 나중에 구현~
public class TriggerEventArgs : EventArgs
{
    public TriggerZoneEventType eventType;
    public string properUserInput; //사용자가 입력해야 하는 텍스트
    
    public TriggerEventArgs(TriggerZoneEventType eventType, string properUserInput)
    {
        this.eventType = eventType;
        this.properUserInput = properUserInput;
    }
}

[Serializable]
public class JumpEventArgs : TriggerEventArgs
{
    public JumpEventArgs(TriggerZoneEventType eventType, string properUserInput) : base(eventType, properUserInput)
    { }
}
[Serializable]
public class CrawlEventArgs : TriggerEventArgs
{
    public CrawlEventArgs(TriggerZoneEventType eventType, string properUserInput) : base(eventType, properUserInput)
    { }
}
[Serializable]
public class TurnEventArgs : TriggerEventArgs
{
    public int toLineIndex = 0;
    public float toLineNormalizedPos = 0.0f;
    public TurnEventArgs(TriggerZoneEventType eventType, string properUserInput, int toLineIndex, float toLineNormalizedPos) : base(eventType, properUserInput)
    {
        this.toLineIndex = toLineIndex;
        this.toLineNormalizedPos = toLineNormalizedPos; 
    }
}

[Serializable]
public class EndGameEventArgs : TriggerEventArgs
{
    public float time;
    public EndGameEventArgs(TriggerZoneEventType eventType, string properUserInput) : base(eventType, properUserInput) { }
}

[Serializable]
public class TypingEventArgs : EventArgs
{
    public TriggerZoneEventType eventType;
    public string playerInputText;
    
    public TypingEventArgs(TriggerZoneEventType eventType, string playerInputText)
    {
        this.eventType = eventType;
        this.playerInputText = playerInputText;
    }
}


public class EventManager : Singleton<EventManager>
{
    protected EventManager() { }

    // 대리자 선언
    public delegate void OnEvent(MEventType MEventType, Component Sender, EventArgs args = null);
    private Dictionary<MEventType, List<OnEvent>> Listeners = new Dictionary<MEventType, List<OnEvent>>();

    public void AddListener(MEventType MEventType, OnEvent Listener)
    {
        List<OnEvent> ListenList = null;

        if (Listeners.TryGetValue(MEventType, out ListenList))
        {
            ListenList.Add(Listener);
            return;
        }

        ListenList = new List<OnEvent>
        {
            Listener
        };
        Listeners.Add(MEventType, ListenList);
    }

    public void PostNotification(MEventType MEventType, Component Sender, EventArgs args = null)
    {
        List<OnEvent> ListenList = null;

        if (!Listeners.TryGetValue(MEventType, out ListenList))
            return;
        
        for (int i = 0; i < ListenList.Count; i++)
        {
            if (ListenList[i].Target.ToString() == "null")
                continue;
            ListenList[i](MEventType, Sender, args);
        }
    }
    
    public void RemoveListener(MEventType MEventType, object target)
    {
        if (Listeners.ContainsKey(MEventType) == false)
            return;

        foreach (OnEvent ev in Listeners[MEventType])
        {
            if (target == ev.Target)
            {
                Listeners[MEventType].Remove(ev);
                //Debug.Log("Event Delete Success");
                return;
            }
        }

        //Debug.Log("Event Delete Fail");
        return;
    }
    public void RemoveEvent(MEventType MEventType) => Listeners.Remove(MEventType);
    public void RemoveRedundancies()
    {
        Dictionary<MEventType, List<OnEvent>> newListeners = new Dictionary<MEventType, List<OnEvent>>();

        foreach (KeyValuePair<MEventType, List<OnEvent>> Item in Listeners)
        {
            for (int i = Item.Value.Count - 1; i >= 0; i--)
            {
                if (Item.Value[i].Equals(null))
                    Item.Value.RemoveAt(i);
            }

            if (Item.Value.Count > 0)
                newListeners.Add(Item.Key, Item.Value);
        }

        Listeners = newListeners;
    }

    void OnLevelWasLoaded()
    {
        RemoveRedundancies();
    }

    public override void Init()
    {
        Debug.Log("EventManager.cs Init Complete!");
    }
}
