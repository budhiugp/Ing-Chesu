using UnityEngine;
using UnityEngine.Events;

public class ManagerSceneBoard : MonoBehaviour
{
    [Header("UnityEvents")]
    [SerializeField] private UnityEvent _uniEvStartLogin;
    [SerializeField] private UnityEvent _uniEvStartMenu;
    [SerializeField] private UnityEvent _uniEvStartBoard;

    void Start()
    {
        _uniEvStartLogin.Invoke();
    }

    public void OnLogin()
    {
        _uniEvStartMenu.Invoke();
    }

    public void OnStartBoard()
    {
        _uniEvStartBoard.Invoke();
    }
}
