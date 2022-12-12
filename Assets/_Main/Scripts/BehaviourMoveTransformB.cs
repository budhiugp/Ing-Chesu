using System;
using UnityEngine;

public class BehaviourMoveTransformB : BehaviourMoveTransformA
{
    [Header("Custom Duration")]
    [SerializeField] private float _fDuration = 0.5f;

    public void MovePosition(Vector3 v3Pos)
    {
        MovePosition(v3Pos, _fDuration);
    }

    public void MovePosition(Vector3 v3Pos, Action actResponse)
    {
        MovePosition(v3Pos, _fDuration, actResponse);
    }
}
