using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBg : MonoBehaviour
{
    [SerializeField] Sprite coolbg;
    
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("end1") == 1 && PlayerPrefs.GetInt("end2") == 1 && PlayerPrefs.GetInt("end3") == 1) {
            GetComponent<SpriteRenderer>().sprite = coolbg;
        }
    }

}
