using System;
using UnityEngine;
using DG.Tweening;

public class BehaviourMoveTransformA : MonoBehaviour
{
    public enum EnumEaseMode { InOutSine, InOutCubic, InOutQuint, InOutCirc }

    public EnumEaseMode EaseMode;

    [SerializeField] protected Transform _transformThis;

    public virtual void MovePosition(Vector3 v3Pos, float fDuration)
    {
        DOTween.Kill("MovePosition" + gameObject.GetInstanceID());

        _transformThis.DOMove(v3Pos, fDuration).SetEase(GetEase()).SetId("MovePosition" + gameObject.GetInstanceID());
    }

    public virtual void MovePosition(Vector3 v3Pos, float fDuration, Action actResponse)
    {
        DOTween.Kill("MovePosition" + gameObject.GetInstanceID());

        _transformThis.DOMove(v3Pos, fDuration).SetEase(GetEase()).SetId("MovePosition" + gameObject.GetInstanceID()).OnComplete(() =>
        {
            actResponse();
        });
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

