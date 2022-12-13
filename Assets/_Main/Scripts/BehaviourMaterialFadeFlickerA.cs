using UnityEngine;
using DG.Tweening;

public class BehaviourMaterialFadeFlickerA : MonoBehaviour
{
    public enum EnumEaseMode { InOutSine, InOutCubic, InOutQuint, InOutCirc }

    public EnumEaseMode EaseMode;

    [SerializeField] private float _fFlickerTime = 1f;

    [SerializeField] private MeshRenderer _meshRendThis;

    public MeshRenderer MeshRendThis
    {
        set
        {
            _meshRendThis = value;
        }
    }

    public void StartFlicker()
    {
        FlickerOut();
    }

    public void StopFlicker()
    {
        FlickerIn(false);
    }

    public void ForceStopFlicker()
    {
        KillTweens();

        Color color_materialthis = _meshRendThis.material.color;
        color_materialthis.a = 1f;
        _meshRendThis.material.color = color_materialthis;
    }

    private void KillTweens()
    {
        DOTween.Kill("BehaviourMaterialFadeFlickerA FlickerIn " + gameObject.GetInstanceID());
        DOTween.Kill("BehaviourMaterialFadeFlickerA FlickerOut " + gameObject.GetInstanceID());
    }

    private void FlickerIn(bool isFlicker)
    {
        KillTweens();

        _meshRendThis.material.DOFade(1, _fFlickerTime / 2f).SetEase(GetEase()).SetId("BehaviourMaterialFadeFlickerA FlickerIn " + gameObject.GetInstanceID()).OnComplete(() =>
        {
            if (isFlicker) FlickerOut();
            else KillTweens();
        });
    }

    private void FlickerOut()
    {
        KillTweens();

        _meshRendThis.material.DOFade(0, _fFlickerTime / 2f).SetEase(GetEase()).SetId("BehaviourMaterialFadeFlickerA FlickerOut " + gameObject.GetInstanceID()).OnComplete(() =>
        {
            FlickerIn(true);
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

    private void OnDisable()
    {
        KillTweens();
    }
}


