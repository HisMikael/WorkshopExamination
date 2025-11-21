using UnityEngine;
using System.Collections;
public class Dialog : MonoBehaviour
{
    [SerializeField] TextAsset textAsset;
    [SerializeField] TMPro.TextMeshPro textElement;
    [SerializeField] float showTextDelay;
    int textIndex = 0;
    void Start()
    {

    }

    void Update()
    {

    }
    public void TriggerDialog()
    {
        string loadedText = LoadPartOfText(textAsset.text, textIndex);
        textIndex += loadedText.Length;
        StartCoroutine(ShowText(loadedText, textElement, showTextDelay));
    }
    string LoadPartOfText(string text, int startAtIndex = 0, string breakSequence = "\n\n")
    {
        string loadedText = "";
        for (int i = startAtIndex; i < textAsset.text.Length; i++)
        {
            if (i + breakSequence.Length < text.Length && text.Substring(i, breakSequence.Length) == breakSequence)
                break;
            loadedText += textAsset.text[i];
        }
        return loadedText;
    }
    IEnumerator ShowText(string text, TMPro.TextMeshPro textElement, float delay)
    {
        textElement.text = "";
        for (int i = 0; i < text.Length; i++)
        {
            textElement.text += text[i];
            yield return new WaitForSeconds(delay);
        }
    }
}


