using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Dialog : MonoBehaviour
{
    [SerializeField] TextAsset textAsset;
    [SerializeField] TMPro.TextMeshProUGUI textElement;
    [SerializeField] float showTextDelay;
    public UnityEvent onEndDialog;
    int textIndex = 0;
    bool isWritingText = false;
    void Start()
    {

    }

    void Update()
    {

    }
    public void TriggerDialog()
    {
        if (isWritingText)
        {
            isWritingText = false;
            return;
        }
        string loadedText = LoadPartOfText(textAsset.text, textIndex);
        if (loadedText == "")
        {
            onEndDialog.Invoke();
            return;
        }
        textIndex += loadedText.Length;
        StartCoroutine(ShowText(loadedText, textElement, showTextDelay));
    }
    string LoadPartOfText(string text, int startAtIndex = 0, string breakSequence = "---")
    {
        if (startAtIndex + breakSequence.Length < text.Length && text.Substring(startAtIndex, breakSequence.Length) == breakSequence)
            startAtIndex += breakSequence.Length;
        string loadedText = "";
        for (int i = startAtIndex; i < textAsset.text.Length; i++)
        {
            if (i + breakSequence.Length < text.Length && text.Substring(i, breakSequence.Length) == breakSequence)
                break;
            loadedText += textAsset.text[i];
        }
        return loadedText;
    }
    IEnumerator ShowText(string text, TMPro.TextMeshProUGUI textElement, float delay)
    {
        isWritingText = true;
        textElement.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            textElement.text += text[i];
            if (isWritingText)
                yield return new WaitForSeconds(delay);
        }
        isWritingText = false;
    }
}


