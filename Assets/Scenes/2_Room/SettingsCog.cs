using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsCog : MonoBehaviour
{
    
    void Start()
    {
        GameObject[] e = GameObject.FindGameObjectsWithTag("settings");
        if(e.Length > 1) {
            Destroy(e[0]);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
