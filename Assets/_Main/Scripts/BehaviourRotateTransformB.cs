using System;
using UnityEngine;

public class BehaviourRotateTransformB : BehaviourRotateTransformA
{
    [Header("Custom Duration")]
    [SerializeField] private float _fDuration = 0.5f;

    public void RotateTransform(Vector3 v3Pos)
    {
        RotateTransform(v3Pos, _fDuration);
    }

    public void RotateTransform(Vector3 v3Pos, Action actResponse)
    {
        RotateTransform(v3Pos, _fDuration, actResponse);
    }
}
