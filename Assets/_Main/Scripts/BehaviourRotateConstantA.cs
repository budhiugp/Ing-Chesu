using System.Collections;
using UnityEngine;

public class BehaviourRotateConstantA : MonoBehaviour
{
    [Header("Rotate Constant, Self Transform")]
    protected Coroutine _corRotateConstant;

    public void StartRotateConstant(float fRotateSpeed)
    {
        StopRotateConstant();

        _corRotateConstant = StartCoroutine(CorRotateConstant(fRotateSpeed));
    }

    public void StopRotateConstant()
    {
        if (_corRotateConstant != null) StopCoroutine(_corRotateConstant);
    }

    protected IEnumerator CorRotateConstant(float fRotateSpeed)
    {
        while (true)
        {
            transform.Rotate(Vector3.up * fRotateSpeed * Time.deltaTime * 10);
            yield return null;
        }
    }
}
