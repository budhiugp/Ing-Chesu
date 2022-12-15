using UnityEngine;

public class ManagerCamera : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryUser _scrObjRepoUser;

    [Header("Classes")]
    [SerializeField] private BehaviourRotateConstantB _csBehaviourRotateConstantB;
    [SerializeField] private BehaviourRotateTransformB _csBehaviourRotateTransformB;

    [Header("Other")]
    [SerializeField] private Vector3 _v3RotViewAsWhite;
    [SerializeField] private Vector3 _v3RotViewAsBlack;

    public void StartCameraOrbitView()
    {
        _csBehaviourRotateConstantB.StartRotateConstant();
    }

    private void StopCameraOrbitView()
    {
        _csBehaviourRotateConstantB.StopRotateConstant();
    }

    public void ChangeViewCamera()
    {
        StopCameraOrbitView();

        if(_scrObjRepoUser.CsDataUserPlayer.IsWhite)
        {
            _csBehaviourRotateTransformB.RotateTransform(_v3RotViewAsWhite);
        } else 
        {
            _csBehaviourRotateTransformB.RotateTransform(_v3RotViewAsBlack);
        }
        
    }
}
