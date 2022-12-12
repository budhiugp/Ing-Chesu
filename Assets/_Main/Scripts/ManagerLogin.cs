using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ManagerLogin : MonoBehaviour
{
    [Header("Repositories")]
    [SerializeField] private RepositoryUser _scrObjRepoUser;

    [Header("UI")]
    [SerializeField] private InputField _inputFieldUserName;

    [Header("Classes")]
    [SerializeField] private CustomDebug _csCustomDebug;

    [Header("Other")]
    private const string _sUserNamePrefKey = "UserName";

    [Header("UnityEvents")]
    [SerializeField] private UnityEvent _uniEvOnLogin;

    private void Start()
    {
        _scrObjRepoUser.ClearData();

        if (PlayerPrefs.HasKey(_sUserNamePrefKey))
        {
            string s_username = PlayerPrefs.GetString(_sUserNamePrefKey);

            _inputFieldUserName.text = s_username;

            _scrObjRepoUser.CsDataUser.SUserName = s_username;
        }
    }

    public void Login()
    {
        Debug.Log(_csCustomDebug.DebugColor(this.name + " Login") + " Begin _inputFieldUserName.text = " + _inputFieldUserName.text.Trim());

        string s_username = _inputFieldUserName.text.Trim();

        if (s_username != "")
        {
            _scrObjRepoUser.CsDataUser.SUserName = s_username;

            PlayerPrefs.SetString(_sUserNamePrefKey, s_username);

            _uniEvOnLogin.Invoke();
        }
        else
        {
            Debug.LogWarning("Login UserName is Empty");
        }
    }
}
