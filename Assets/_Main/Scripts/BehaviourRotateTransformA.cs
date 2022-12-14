using System;
using UnityEngine;
using DG.Tweening;

public class BehaviourRotateTransformA : MonoBehaviour
{
    public enum EnumEaseMode { InOutSine, InOutCubic, InOutQuint, InOutCirc }

    public EnumEaseMode EaseMode;

    public virtual void RotateTransform(Vector3 v3Rot, float fDuration)
    {
        KillTween();

        transform.DORotate(v3Rot, fDuration).SetEase(GetEase()).SetId("RotateTransform" + gameObject.GetInstanceID());
    }

    public virtual void RotateTransform(Vector3 v3Rot, float fDuration, Action actResponse)
    {
        KillTween();

        transform.DORotate(v3Rot, fDuration).SetEase(GetEase()).SetId("RotateTransform" + gameObject.GetInstanceID()).OnComplete(() =>
        {
            actResponse();
        });
    }

    protected void KillTween()
    {
        DOTween.Kill("RotateTransform" + gameObject.GetInstanceID());
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

