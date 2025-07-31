using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameComponent;
    public GameObject faceComponent;

    public float textSpeed;
    public int conversation;


    private int index;
    private bool pressed;
    private string[] readLines;
    private bool HiddenNameB;
    private string nameDisplay;
    private string fname;
    private int unhideAt;

    void Start()
    {
        
    }

    // Update is called once per frame

    public void StartDialogue(string[] lines, string FName, bool hasHiddenName, int revealNameAt, Sprite faceSprite)
    {
        // name
        textComponent.text = string.Empty;
        fname = FName;
        HiddenNameB = hasHiddenName;
        unhideAt = revealNameAt;
        if (HiddenNameB)
        {
            HiddenNameDisplay();
        } else
        {
            nameDisplay = fname;
        }

        // set side image
        faceComponent.GetComponent<Image>().sprite = faceSprite;
        
        // read lines
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
        nameComponent.text = nameDisplay;

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
            if (HiddenNameB)
            {
                HiddenNameDisplay();
            }
            StartCoroutine(TypeLine());
        }
        else
        {
            textComponent.text = string.Empty;
            nameComponent.text = string.Empty;
            gameObject.SetActive(false);
        }
    }

    void HiddenNameDisplay()
    {
        if (index >= unhideAt && unhideAt != -1)
        {
            nameDisplay = fname; 
        } else
        {
            nameDisplay = "???";
        }
    }
}
