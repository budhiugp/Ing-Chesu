using UnityEngine;
using DG.Tweening;

public class BehaviourMaterialFlickerA : MonoBehaviour
{
    public enum EnumEaseMode { InOutSine, InOutCubic, InOutQuint, InOutCirc }

    public EnumEaseMode EaseMode;

    [SerializeField] private float _fFlickerTime = 1f;

    [SerializeField] private MeshRenderer _meshRendThis;

    [SerializeField] private Color _colorInto;
    private Color _colorInit;

    public MeshRenderer MeshRendThis
    {
        set
        {
            _meshRendThis = value;
            _colorInit = _meshRendThis.material.color;
        }
    }

    public Color ColorInto
    {
        set
        {
            _colorInto = value;
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

        _meshRendThis.material.color = _colorInit;
    }

    private void KillTweens()
    {
        DOTween.Kill("BehaviourMaterialFlickerA FlickerIn " + gameObject.GetInstanceID());
        DOTween.Kill("BehaviourMaterialFlickerA FlickerOut " + gameObject.GetInstanceID());
    }

    private void FlickerIn(bool isFlicker)
    {
        KillTweens();

        _meshRendThis.material.DOColor(_colorInit, _fFlickerTime / 2f).SetEase(GetEase()).SetId("BehaviourMaterialFlickerA FlickerIn " + gameObject.GetInstanceID()).OnComplete(() =>
        {
            if (isFlicker) FlickerOut();
            else KillTweens();
        });
    }

    private void FlickerOut()
    {
        KillTweens();

        _meshRendThis.material.DOColor(_colorInto, _fFlickerTime / 2f).SetEase(GetEase()).SetId("BehaviourMaterialFlickerA FlickerOut " + gameObject.GetInstanceID()).OnComplete(() =>
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

