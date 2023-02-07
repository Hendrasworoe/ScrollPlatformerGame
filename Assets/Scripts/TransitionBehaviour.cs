using UnityEngine;
using UnityEngine.UI;

public class TransitionBehaviour : MonoBehaviour
{
    public Image backgroundImage { get; private set; }

    [SerializeField] private float _fillSpeed = 1f;

    private bool _fillUpOnProgress;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_fillUpOnProgress && backgroundImage.fillAmount < 1f)
        {
            backgroundImage.fillAmount += _fillSpeed * Time.deltaTime;
        }

        if (!_fillUpOnProgress && backgroundImage.fillAmount > 0f)
        {
            backgroundImage.fillAmount -= _fillSpeed * Time.deltaTime;
        }
    }

    public void SetTransitionFill(bool isFilling)
    {
        _fillUpOnProgress = isFilling;
    }
}
