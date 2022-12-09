using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ManagerBoard : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Other")]
    

    [Header("UnityEvents")]
    [SerializeField] private UnityEvent _uniEvOnStartGame;

    public void StartGame()
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " StartGame") + " Begin");

        _uniEvOnStartGame.Invoke();
    }
}
