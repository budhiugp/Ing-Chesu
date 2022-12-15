using System;
using UnityEngine;

public class BehaviourRotateTransformB : BehaviourRotateTransformA
{
    [Header("Custom Duration")]
    [SerializeField] private float _fDuration = 0.5f;

    public void RotateTransform(Vector3 v3Rot)
    {
        RotateTransform(v3Rot, _fDuration);
    }

    public void RotateTransform(Vector3 v3Rot, Action actResponse)
    {
        RotateTransform(v3Rot, _fDuration, actResponse);
    }
}
