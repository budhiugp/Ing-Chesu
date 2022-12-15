using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DisplayerPhase : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Text _textPhaseDesc;

    [Header("Other")]
    [SerializeField] private float _fDelay = 0.3f;
    [SerializeField] private float _fDurationShow = 0.8f;

    private Coroutine _courStartPhase;

    [Header("UnityEvents")]
    [SerializeField] private UnityEvent _uniEvShowDisplay;
    [SerializeField] private UnityEvent _uniEvHideDisplay;

    public void StartPhase(string sPhaseName, Action actResponse)
    {
        if (_courStartPhase != null) StopCoroutine(_courStartPhase);

        _courStartPhase = StartCoroutine(CourStartPhase(sPhaseName, _fDelay, _fDurationShow, actResponse));
    }

    private IEnumerator CourStartPhase(string sPhaseName, float fDelay, float fDurationShow, Action actResponse)
    {
        _textPhaseDesc.text = sPhaseName;
        
        yield return new WaitForSeconds(fDelay);

        _uniEvShowDisplay.Invoke();

        yield return new WaitForSeconds(fDurationShow);

        _uniEvHideDisplay.Invoke();

        yield return new WaitForSeconds(fDelay);

        actResponse();
    }
}

