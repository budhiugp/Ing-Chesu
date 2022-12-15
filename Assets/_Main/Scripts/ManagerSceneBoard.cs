using UnityEngine;
using UnityEngine.Events;

public class ManagerSceneBoard : MonoBehaviour
{
    [Header("UnityEvents")]
    [SerializeField] private UnityEvent _uniEvInitialization;

    void Start()
    {
        _uniEvInitialization.Invoke();
    }
}
