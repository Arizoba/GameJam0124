using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    public bool choices;
    private bool chosen = false;

    float keypresscd = 0.2f;
    float lasskeypress;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        lasskeypress = Time.time;
        StartDialogue();
        if (choices == false)
        {
            chosen = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time-lasskeypress > keypresscd)
        {
            lasskeypress = Time.time;
            if (Input.GetKey("e"))
            {
                //Debug.Log("pressed e");
                NextLine();

            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];   
                
            }
        }

        if (choices)
        {
            if (Input.GetKey("1"))
            {
                Debug.Log("pressed 1");
                chosen = true;

            }
            if (Input.GetKey("2"))
            {
                Debug.Log("pressed 2");
                chosen = true;

            }

        }

    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        
            foreach (char c in lines[index].ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
            }
        
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            if (chosen)
            {
                gameObject.SetActive(false);

            }
        }
    }
}
