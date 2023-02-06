using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    
    [SerializeField] List<GameObject> creditThings = new List<GameObject>();
    private int currCreditThing = 0;

    // Update is called once per frame
    void Update()
    {
        if(currCreditThing >= creditThings.Count) {
            if(PlayerPrefs.GetInt("end1") == 1 && PlayerPrefs.GetInt("end2") == 1 && PlayerPrefs.GetInt("end3") == 1) SceneManager.LoadScene("epilogue");
            else SceneManager.LoadScene("Room");
        }
        
        if(Input.GetMouseButtonDown(0)) {
            if(currCreditThing < creditThings.Count) creditThings[currCreditThing].SetActive(true);
            currCreditThing++;
        }

        
    }
}
