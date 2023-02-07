using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupController : MonoBehaviour
{
    private CanvasGroup _itsCanvasGroup;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ShowCanvas(bool isShow)
    {
        _itsCanvasGroup = GetComponent<CanvasGroup>();
        _itsCanvasGroup.alpha = isShow ? 1f : 0f;
        _itsCanvasGroup.blocksRaycasts = isShow;
        _itsCanvasGroup.interactable = isShow;
    }
}
