using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalArrow : MonoBehaviour
{
    private Manager manager;
    private Button button;
    [SerializeField] GameObject warningPanel;
    [SerializeField] GameObject endingsPanel;

    
    // Start is called before the first frame update
    void Start() {
        manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
        //PlayerPrefs.SetString("firstTime", "true");

        // || PlayerPrefs.HasKey("end1") || PlayerPrefs.HasKey("end2") || PlayerPrefs.HasKey("end3")
        if(manager.getUnlockedScenes() >= 8) this.gameObject.SetActive(true);
        else {
            this.gameObject.SetActive(false);
        }

        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(ShowPanel);

    }

    void ShowPanel() {  //PlayerPrefs.HasKey("firstTime") && 
        Debug.Log(PlayerPrefs.GetString("firstTime"));
        if(!PlayerPrefs.HasKey("firstTime") || PlayerPrefs.GetString("firstTime").Equals("true")) {
            //Debug.Log("BRO I'M SO TIRED IT'S 11 PM");
            //PlayerPrefs.SetString("firstTime", "false");
            warningPanel.SetActive(true);
            //endingsPanel.GetComponent<EndingJournal>().Refresh();
        }else {
            endingsPanel.SetActive(true);
        }
        //print(firstTime);
    }

}
