using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FadeInText : MonoBehaviour
{
    private TextMeshProUGUI txt;
    private byte r;
    private byte g;
    private byte b;
    private byte temp = 0;

    [SerializeField] bool needToSwitchScene;
    [SerializeField] string scene;
    [SerializeField] GameObject black;
    [SerializeField] FadeMusic fader;
    [SerializeField] bool needToFadeMusic = false;

    
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
        startFadingText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFadingText() {
        r = (byte)txt.color.r;
        g = (byte)txt.color.g;
        b = (byte)txt.color.b;
        StartCoroutine(FadeTextIn());
    }

    private IEnumerator FadeTextIn() {
        //if(needToFadeMusic) {
        //    FindObjectOfType<FadeMusic>().fadeOut(6);
        //}

        if(black != null) black.SetActive(true);
        //Debug.Log("i'm starting!");
        //GetComponent<GameObject>().SetActive(true);
        txt.color = new Color32(255, 255, 255, 0);

        while(temp < 255) {
            //Debug.Log("r: " + txt.color[0] + "; temp: " + temp);
            temp++;
            txt.color = new Color32(255, 255, 255, temp);
            yield return 0.3;
        }
        if(needToSwitchScene) {
            StartCoroutine(WaitAndSwitchScenes());

        }
        //print("should be all shown! <3");



    }

    private IEnumerator WaitAndSwitchScenes() {
        fader.fadeOut(3);
        yield return new WaitForSeconds(3);
        //print("after 3 secs");

        if(PlayerPrefs.GetInt("end1") == 1 && PlayerPrefs.GetInt("end2") == 1 && PlayerPrefs.GetInt("end3") == 1) {
            SceneManager.LoadScene("epilogue");
        }else {
            SceneManager.LoadScene("Credits");
        }
    }

}
