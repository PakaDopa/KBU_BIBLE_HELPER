using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameClear : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    
    public void GameClear()
    {
        int len = gameManager.ProblemCount;
        for (int i = 0; i < len; i++)
            EventManager.Instance.PostNotification(Utils.MEventType.GameNextProblem, this, new TransformEventArgs(transform, true));
    }
}
