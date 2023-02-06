using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStuff : MonoBehaviour
{
    public void playSoundOnce(AudioClip clip) {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = clip;
        source.Play();
    }

    void Awake() {
        GameObject[] e = GameObject.FindGameObjectsWithTag("music");
        if(e.Length > 1) {
            Destroy(this.gameObject);
        }
        //DontDestroyOnLoad(this.gameObject);
    }

    public void pauseOtherAudio() {   //maybe can pause instead of removing
        AudioSource e = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
        e.Pause();
    }

    public void playOtherAudio() {
        AudioSource e = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
        e.Play();
    }
}
