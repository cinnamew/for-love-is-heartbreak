using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ImGoingToEndSomebody : MonoBehaviour
{
    [SerializeField] string whatAreYou;
    [SerializeField] Fungus.Flowchart flowchart;
    [SerializeField] GameObject imGay;
    [SerializeField] GameObject[] paragraphs;
    private int currParagraph = 0;

    void Start() {
        //ik this is bad code but idc
        if(PlayerPrefs.GetInt("chapter") == 0 && PlayerPrefs.GetInt("end1") != 1 && PlayerPrefs.GetInt("end2") != 1 && PlayerPrefs.GetInt("end3") != 1) {
                
            }else if(whatAreYou == "intro") {
                flowchart.ExecuteBlock("loona deserves better");
                gameObject.SetActive(false);
            }
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!Input.GetMouseButtonDown(0)) return;
        if(whatAreYou == "intro") {
            if(PlayerPrefs.GetInt("chapter") == 0 && PlayerPrefs.GetInt("end1") != 1 && PlayerPrefs.GetInt("end2") != 1 && PlayerPrefs.GetInt("end3") != 1) {
                flowchart.ExecuteBlock("stan loona but not start blokc");
            }
        }else if(whatAreYou == "a disappointment") {    //??????????? what???? 😭😭😭😭 WHAT IS THIS FOR im so confused
            imGay.SetActive(false); //THIS DOES NOT HELP
        }else if(whatAreYou == "no words fr") {
            
        }
    }
}
