using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private Text textlabel;
    [SerializeField] private DialogueObj testDialogue;
    [SerializeField] private GameObject dialogueBox;

    private TypeWrite typeWrite;

    private void Start()
    {
        typeWrite = GetComponent<TypeWrite>();
        CloseDialogue();
        ShowDialogue(testDialogue);
        

    }

    public void ShowDialogue(DialogueObj dialogueObj) {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObj));
    }

    private IEnumerator StepThroughDialogue(DialogueObj dialogueObj) {
        yield return new WaitForSecondsRealtime(5f);
        foreach (string dialogue in dialogueObj.Dialogue) {
            yield return typeWrite.Run(dialogue, textlabel);
            yield return new WaitForSecondsRealtime(7f);
        }
        CloseDialogue();
    }

    private void CloseDialogue() {
        dialogueBox.SetActive(false);
        textlabel.text = string.Empty;
    }
}
