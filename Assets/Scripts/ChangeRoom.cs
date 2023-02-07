using System.Collections;
using UnityEngine;

public class ChangeRoom : MonoBehaviour
{
    [SerializeField] private SpawnPointType _itsPointType;

    [Header("Property on below no need to fill if it's a Dependent Type")]
    [SerializeField] private ChangeRoom _itsPairPoint;
    public GameObject canMoveIndicator;
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
        if (other.CompareTag("Player"))
        {
            canMoveIndicator.SetActive(true);

            if (Input.GetButton("Submit") && !_transitionInProgress)
            {
                Debug.Log("Change Room");
                _transitionInProgress = true;
                // other.transform.position = _itsPairPoint.transform.position;
                StartCoroutine(MoveRoom(other));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canMoveIndicator.SetActive(false);
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
            canMoveIndicator = thePair.canMoveIndicator;
            transitionBackground = thePair.transitionBackground;
        }
    }
}

public enum SpawnPointType
{
    Independent, Dependent
}
