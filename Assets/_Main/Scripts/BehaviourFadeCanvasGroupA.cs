using UnityEngine;
using DG.Tweening;

public class BehaviourFadeCanvasGroupA : MonoBehaviour
{
    public enum EnumEaseMode { InOutSine, InOutCubic, InOutQuint, InOutCirc }

    public EnumEaseMode EaseMode;

    [SerializeField] protected CanvasGroup _canvasGroupThis;
    
    public virtual void ShowCanvasGroup(bool isShow, float fDuration)
    {
        DOTween.Kill("ShowCanvasGroup" + gameObject.GetInstanceID());

        if (isShow)
        {
            _canvasGroupThis.DOFade(1, fDuration).SetEase(GetEase()).SetId("ShowCanvasGroup" + gameObject.GetInstanceID()).OnComplete(() =>
            {
                SetInteractable(true);
            });
        }
        else
        {
            SetInteractable(false);

            _canvasGroupThis.DOFade(0, fDuration).SetEase(GetEase()).SetId("ShowCanvasGroup" + gameObject.GetInstanceID());
        }
    }

    public virtual void SetInteractable(bool setInteractable)
    {
        _canvasGroupThis.interactable = setInteractable;
        _canvasGroupThis.blocksRaycasts = setInteractable;
    }

    protected Ease GetEase()
    {
        switch (EaseMode)
        {
            case EnumEaseMode.InOutSine:
                return Ease.InOutSine;
            case EnumEaseMode.InOutCubic:
                return Ease.InOutCubic;
            case EnumEaseMode.InOutQuint:
                return Ease.InOutQuint;
            default:
                return Ease.InOutCirc;
        }
    }
}
