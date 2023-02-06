using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingJournal : MonoBehaviour
{
    [SerializeField] GameObject end1;
    [SerializeField] GameObject end2;
    [SerializeField] GameObject end3;
    private GameObject manager;
    [SerializeField] GameObject sorryNote;
    
    // Start is called before the first frame update
    void Start()
    {
        //ending(s) u got before
        if(PlayerPrefs.GetInt("end1") == 1) {
            end1.SetActive(true);
        }
        if(PlayerPrefs.GetInt("end2") == 1) {
            //print("already has end2");
            end2.SetActive(true);
        }
        if(PlayerPrefs.GetInt("end3") == 1) {
            end3.SetActive(true);
        }

        if(PlayerPrefs.GetString("firstTime").Equals("true") || !PlayerPrefs.HasKey("firstTime")) {
            PlayerPrefs.SetString("firstTime", "false");
            Refresh();
        }
    }

    // Update is called once per frame
    void Awake()
    {
        
    }

    public void Refresh() {

        if(manager == null) manager = GameObject.FindGameObjectWithTag("manager").gameObject;
        
        //print(manager);
        //current ending unlocked
        double score = manager.GetComponent<Manager>().getScore();
        print("score: " + score);
        
        //print("aaaaa " + score);

        //0 - 3: ending 1
        //4 - 8: ending 2
        //9 - 12: ending 3
        if(score <= 3) {
            end1.SetActive(true);
            if(PlayerPrefs.GetInt("end1") == 1) SucksToBeYou();
            PlayerPrefs.SetInt("end1", 1);
        }else if(score <= 8) {
            print("end 2 active fs");
            end2.SetActive(true);
            if(PlayerPrefs.GetInt("end2") == 1) SucksToBeYou();
            PlayerPrefs.SetInt("end2", 1);
        }else {
            end3.SetActive(true);
            if(PlayerPrefs.GetInt("end3") == 1) SucksToBeYou();
            PlayerPrefs.SetInt("end3", 1);
        }


    }

    private void SucksToBeYou() {
        if(PlayerPrefs.HasKey("sorryNoteShown")) return;

        PlayerPrefs.SetInt("sorryNoteShown", 1);
        sorryNote.SetActive(true);
    }
}
