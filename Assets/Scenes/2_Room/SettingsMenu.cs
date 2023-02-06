using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;

    void Awake() {
        GameObject[] e = GameObject.FindGameObjectsWithTag("settings");
        if(e.Length > 1) {
            Destroy(this.gameObject);
        }

        if(SceneManager.GetActiveScene().name != "Start") {
            //print("yummy!");
            DontDestroyOnLoad(this.gameObject);
        }
        //i don't think it was doing anything :(
    }
    public void SetMusicVolume(float volume) {
        //mainMixer.setFloat("volume", volume);
        mainMixer.SetFloat("musicvol", Mathf.Log10(volume) * 20); 
    }
    public void SetSFXVolume(float volume) {
        //mainMixer.setFloat("volume", volume);
        mainMixer.SetFloat("sfxvol", Mathf.Log10(volume) * 20); 
    }

    public void SetQuality(int quality) {
        QualitySettings.SetQualityLevel(quality);
        GameObject spark = GameObject.Find("Sparky");
        //print(spark);
        if(spark != null) {
            spark.gameObject.GetComponent<Spark>().UpdateQualitySettings();
        }
    }

    public void SetFullScreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void DeleteData() {
        PlayerPrefs.DeleteKey("chapter");
        PlayerPrefs.DeleteKey("end1");
        PlayerPrefs.DeleteKey("end2");
        PlayerPrefs.DeleteKey("end3");
        PlayerPrefs.SetString("firstTime", "true");
        PlayerPrefs.DeleteKey("objects");
        PlayerPrefs.DeleteKey("score");
        PlayerPrefs.DeleteKey("sorryNoteShown");

        SceneManager.LoadScene("Start");
    }

}
