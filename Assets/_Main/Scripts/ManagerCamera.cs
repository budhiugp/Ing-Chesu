using UnityEngine;

public class ManagerCamera : MonoBehaviour
{
    [Header("Classes")]
    [SerializeField] private BehaviourRotateConstantB _csBehaviourRotateConstantB;
    //[SerializeField] private beha

    public void StartCameraOrbitView()
    {
        _csBehaviourRotateConstantB.StartRotateConstant();
    }

    public void StopCameraOrbitView()
    {
        _csBehaviourRotateConstantB.StopRotateConstant();
    }
}
