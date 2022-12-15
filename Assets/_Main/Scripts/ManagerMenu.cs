using UnityEngine;
using UnityEngine.UI;

public class ManagerMenu : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryUser _scrObjRepoUser;

    [Header("UIs")]
    [SerializeField] private Text _textUserName;

    public void SetUserInformation()
    {
        _textUserName.text = _scrObjRepoUser.CsDataUserPlayer.SUserName;
    }
}
