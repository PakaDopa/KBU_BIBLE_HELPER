using Manager;
using System;
using UnityEngine;
using Utils;

public class MainGameParticleSystem : MonoBehaviour
{
    [Header("GameManager")]
    [SerializeField] private GameManager gameManager;

    [Header("Effect Prefabs ")]
    [SerializeField] private GameObject solvedEffect;
    [SerializeField] private GameObject unsolvedEffect;

    [Header("Combo Effect")]
    [SerializeField] private GameObject container;
    [SerializeField] float[] effectSizes;

    [Header("Effect Event")]
    [SerializeField] SoundEventSO soEvent;
    private bool isShotEffect = false;

    // Start is called before the first frame update
    private void Awake()
    {
        EventManager.Instance.AddListener(MEventType.GameEffect, ShotEffect);
    }

    private void ShotEffect(MEventType MEventType, Component Sender, EventArgs args)
    {
        var tArgs = args as TransformEventArgs;
        if (tArgs != null)
            Debug.Log(tArgs.value[0].ToString());

        //정답일 때
        if (bool.Parse(tArgs.value[0].ToString()) == true)
            ParticleManager.Instance.Play(solvedEffect);

        //combo에 맞춰서 밑에 콤보 수치 바꾸기
        int combo = gameManager.Combo;
        
        Debug.Log("combo: " + combo);
        StopComboEffect();
        if (combo >= 5)
        {
            if(combo == 5)
                soEvent.Raise();
            ShotComboEffect(1);
        }
        if (combo >= 10)
        {
            if (combo == 10)
                soEvent.Raise();
            ShotComboEffect(2);
            ShotComboEffect(3);
        }
    }
    private void StopComboEffect()
    {
        for(int i = 1; i < container.transform.childCount; i++)
        {
            var main = container.transform.GetChild(i).GetComponent<ParticleSystem>().main;
            main.startLifetime = 0f; 
        }
    }
    private void ShotComboEffect(int index)
    {
        var particle = container.transform.GetChild(index).GetComponent<ParticleSystem>().main;
        particle.startLifetime = effectSizes[index];
    }
}
