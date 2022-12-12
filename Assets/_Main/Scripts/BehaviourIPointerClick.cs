using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BehaviourIPointerClick : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent _uniEvClick;

    public UnityEvent UniEvClick
    {
        get
        {
            return _uniEvClick;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        _uniEvClick.Invoke();
    }
}
