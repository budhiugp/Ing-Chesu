using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplayerCheck : MonoBehaviour
{
    [Header("UIs")]
    [SerializeField] private Text _textCheck;

    [Header("UnityEvents")]
    [SerializeField] private float _fShowing = 2f;

    [Header("UnityEvents")]
    [SerializeField] private UnityEvent _uniEvShowDisplayCheck;
    [SerializeField] private UnityEvent _uniEvHideDisplayCheck;

    private Coroutine _corDisplayCheck;

    public void ShowDisplayCheck(string sCheck)
    {
        if(_corDisplayCheck != null) StopCoroutine(_corDisplayCheck);

        _textCheck.text = sCheck;

        _corDisplayCheck = StartCoroutine(CorDisplayCheck());
    }

    private IEnumerator CorDisplayCheck()
    {
        _uniEvShowDisplayCheck.Invoke();

        yield return new WaitForSeconds(_fShowing);

        _uniEvHideDisplayCheck.Invoke();
    }

}
