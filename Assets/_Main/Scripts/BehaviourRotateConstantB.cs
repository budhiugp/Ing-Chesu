using UnityEngine;

public class BehaviourRotateConstantB : BehaviourRotateConstantA
{
    [Header("Rotate Constant, Self Transform, Custom Rotate Speed")]
    [SerializeField] private float _fRotateSpeed;

    public void StartRotateConstant()
    {
        StopRotateConstant();

        _corRotateConstant = StartCoroutine(CorRotateConstant(_fRotateSpeed));
    }
}
