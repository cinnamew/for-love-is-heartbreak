using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class IntroText : MonoBehaviour
{
    TextMeshProUGUI txt;
    string whatToWrite;
    public GameObject parentCanvas;
    private int temp = 0;
    AudioSource e;
    public float textSpeed = 0.075f;

    public bool typewriter = true;

    public Flowchart flowchart;
    void Awake()
    {
        //e = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
        //e.Pause();
        txt = GetComponent<TextMeshProUGUI>();
        whatToWrite = txt.text;
        txt.text = "";
        if (typewriter) StartCoroutine("TypewriteText");
        //print("done");
    }
    void Update()
    {
        temp++;
    }

    private bool IsPunctuation(char character)
    {
        return character == '.' ||
            character == '?' ||
            character == '!' ||
            character == ',' ||
            character == ':' ||
            character == ';' ||
            character == ')' ||
            character == '\n';
    }

    IEnumerator TypewriteText()
    {
        
        foreach (char c in whatToWrite)
        {
            //print(textSpeed);
            txt.text += c;
            if(IsPunctuation(c)) {
                //print(c);
                yield return new WaitForSeconds(textSpeed*1.5f);
            }
            else yield return new WaitForSeconds(textSpeed);
        }
        //e.UnPause();
        //parentCanvas.SetActive(false);
        //print(temp);
        yield return new WaitForSeconds(2);
        flowchart.ExecuteBlock("Start");
    }
}
