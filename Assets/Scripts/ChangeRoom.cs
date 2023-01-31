using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] private SpawnPointType _itsPointType;

    [Header("Property on below no need to fill if it's a Dependent Type")]
    [SerializeField] private ChangeRoom _itsPairPoint;
    public TransitionBehaviour transitionBackground;

    private bool _transitionInProgress;

    // Start is called before the first frame update
    void Start()
    {
        if (_itsPointType == SpawnPointType.Independent)
        {
            _itsPairPoint.SetOnDependentPair(this);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // The line below actually changed to activate can move Room notif
            Debug.Log("Can Move to another room");

            if (Input.GetButton("Submit") && !_transitionInProgress)
            {
                Debug.Log("Change Room");
                _transitionInProgress = true;
                // other.transform.position = _itsPairPoint.transform.position;
                StartCoroutine(MoveRoom(other));
            }
        }
    }

    private IEnumerator MoveRoom(Collider2D other)
    {
        transitionBackground.SetTransitionFill(true);
        yield return new WaitUntil(() => transitionBackground.backgroundImage.fillAmount > 0.99f);

        other.transform.position = _itsPairPoint.transform.position;

        yield return new WaitForSeconds(1f);

        transitionBackground.SetTransitionFill(false);
        yield return new WaitUntil(() => transitionBackground.backgroundImage.fillAmount < 0.01f);

        _transitionInProgress = false;
    }

    public void SetOnDependentPair(ChangeRoom thePair)
    {
        if (_itsPointType == SpawnPointType.Dependent)
        {
            _itsPairPoint = thePair;
            transitionBackground = thePair.transitionBackground;
        }
    }
}

public enum SpawnPointType
{
    Independent, Dependent
}
