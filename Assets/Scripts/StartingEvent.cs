using UnityEngine;
using UnityEngine.Events;

public class StartingEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _startEvent;

    // Start is called before the first frame update
    void Start()
    {
        if (_startEvent != null)
        {
            _startEvent.Invoke();
        }
    }
}
