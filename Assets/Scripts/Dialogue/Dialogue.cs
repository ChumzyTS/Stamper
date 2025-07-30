using UnityEngine;
using TMPro;
using System.Collections;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;
    
    public float textSpeed;
    public int conversation;


    private int index;
    private bool pressed;
    private string[] readLines;

    void Start()
    {
        
    }

    // Update is called once per frame

    public void StartDialogue(string[] lines, string FName)
    {
        textComponent.text = string.Empty;
        nameComponent.text = FName;
        readLines = lines;
        index = 0;
        StartCoroutine(TypeLine());

    }
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && pressed == false)
        {
            pressed = true;
            if (textComponent.text == readLines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = readLines[index];
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.F) == false)
            {
                pressed = false;
            }
                
        }
        
    }

    

    IEnumerator TypeLine()
    {
        foreach (char c in readLines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < readLines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            nameComponent.text = string.Empty;
            gameObject.SetActive(false);
        }
    }
}
