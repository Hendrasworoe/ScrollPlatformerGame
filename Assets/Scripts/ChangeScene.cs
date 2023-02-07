using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    public GameObject canMoveIndicator;
    public TransitionBehaviour transitionBackground;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canMoveIndicator.SetActive(true);

            if (Input.GetButton("Submit"))
            {
                StartCoroutine(StartMoveScene());
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

    private IEnumerator StartMoveScene()
    {
        transitionBackground.SetTransitionFill(true);
        yield return new WaitUntil(() => transitionBackground.backgroundImage.fillAmount > 0.99f);

        var load_scene_progress = SceneManager.LoadSceneAsync(_sceneName);
        while (!load_scene_progress.isDone)
        {
            yield return null;
        }
    }
}
