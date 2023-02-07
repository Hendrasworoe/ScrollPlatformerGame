using UnityEngine;

public class CommentableObject : MonoBehaviour, iInteractable
{
    [SerializeField] private string _dialogueDescName;

    public void IntractIt()
    {
        DialogueManager.Instance.dialogueSystem.Begin(_dialogueDescName);
    }
}
