using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public void ChangeToScene(string s) {
        SceneManager.LoadScene(s);
    }

    //public void CheckAndSwitchEpilogue() {
    //    if(PlayerPrefs.GetInt("end1") == 1 && PlayerPrefs.GetInt("end2") == 1 && PlayerPrefs.GetInt("end3") == 1) {
    //        SceneManager.LoadScene("epilogue");
    //    }
    //}
}
