using System;
using UnityEngine;
using UnityEngine.UI;
using VIDE_Data;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [SerializeField] private CanvasGroupController _dialogueContainer;
    [SerializeField] private CanvasGroupController _playerChoiceContainer;
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _dialogueText;
    [SerializeField] private GameObject _choiceButtonPrefab;
    [SerializeField] private Transform _choiceParent;

    private PlayerControl _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueContainer.ShowCanvas(false);
        _playerChoiceContainer.ShowCanvas(false);

        _playerController = FindObjectOfType<PlayerControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (VD.isActive)
        {
            _playerController.enabled = false;

            if (Input.GetKeyDown(KeyCode.F))
            {
                VD.Next();
            }
        }
        else
        {
            _playerController.enabled = true;
        }
    }

    private void OnDisable()
    {
        if (_dialogueContainer != null) End(null);
    }

    private void UpdateUI(VD.NodeData data)
    {
        _dialogueContainer.ShowCanvas(false);
        _playerChoiceContainer.ShowCanvas(false);

        if (data.isPlayer)
        {
            InstantiatePlayerChoices(data);
        }
        else
        {
            WriteComment(data);
        }
    }

    private void End(VD.NodeData data)
    {
        _dialogueContainer.ShowCanvas(false);
        _playerChoiceContainer.ShowCanvas(false);

        VD.OnNodeChange -= UpdateUI;
        VD.OnEnd -= End;
        VD.EndDialogue();
    }

    private void InstantiatePlayerChoices(VD.NodeData data)
    {
        _playerChoiceContainer.ShowCanvas(true);
        // destroy previous choices if any
        if (_choiceParent.childCount > 0)
        {
            foreach (Transform child in _choiceParent)
            {
                Destroy(child);
            }
        }

        for (int i = 0; i < data.comments.Length; i++)
        {
            GameObject choice = Instantiate(_choiceButtonPrefab);
            choice.transform.SetParent(_choiceParent);
            choice.GetComponent<TMP_Text>().text = data.comments[i];
            choice.GetComponent<Button>().onClick.AddListener(() => SetPlayerChoice(i));
        }
    }

    private void WriteComment(VD.NodeData data)
    {
        _dialogueContainer.ShowCanvas(true);
        _dialogueText.text = data.comments[data.commentIndex];

        string name_string = data.extraData[data.commentIndex];
        var name_empty = string.IsNullOrEmpty(name_string) || string.Equals(name_string, "ExtraData");
        _nameText.text = name_empty ? "" : name_string;
    }

    private void SetPlayerChoice(int choiceIndex)
    {
        VD.nodeData.commentIndex = choiceIndex;
        VD.Next();
    }

    public void Begin(string dialogueName)
    {
        VD.OnNodeChange += UpdateUI;
        VD.OnEnd += End;

        var assigned_vide = GetComponent<VIDE_Assign>();
        assigned_vide.assignedDialogue = dialogueName;

        if (Array.Exists(VD.GetDialogues(), x => x.Equals(dialogueName)))
        {
            VD.BeginDialogue(assigned_vide);
        }
        else
        {
            Debug.Log("Dialogue Name not found");
        }
    }
}
