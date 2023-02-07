using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestChangeScene : MonoBehaviour
{
    public void ChangeSceneTo(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
