using UnityEngine;

public class BehaviourFadeCanvasGroupB : BehaviourFadeCanvasGroupA
{
    [Header("Custom Duration")]
    [SerializeField] private float _fDuration = 0.5f;

    public void ShowCanvasGroup(bool isShow)
    {
        ShowCanvasGroup(isShow, _fDuration);
    }
}
