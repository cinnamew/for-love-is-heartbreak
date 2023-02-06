using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using TMPro;

public class DiscardButton : MonoBehaviour
{
    public string discard = "";
    private Button button;
    public TextMeshProUGUI text;
    public Fungus.Flowchart flowchart;
    private Manager manager;

    void Start() {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(Discard);
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>();
    }

    public void Discard() {
        //GameObject.Find(discard).SetActive(false);
        manager.addToDestroyedObjects(discard);
        Destroy(GameObject.Find(discard));

        flowchart.ExecuteBlock("discard " + discard);
        switch(discard) {
            case "school pic":
                manager.addToScore(0.5);
                break;
            case "us pic":
                manager.addToScore(3);
                break;
            case "ipad":
                manager.addToScore(0.5);
                break;
            case "todoroki":
                manager.addToScore(2);
                break;
            case "necklace":
                manager.addToScore(3);
                break;
            case "phone":
                manager.addToScore(3);
                break;
            default:
                break;
        }
        //0 - 3: ending 1
        //4 - 8: ending 2
        //9 - 12: ending 3

    }

    public void setText(string s) {
        //this.gameObject.GetComponent<Button>().GetComponentInChildren<Text>().text = s;
        text.text = s;
    }

    public void setDiscard(string s) {
        discard = s;
    }
}
