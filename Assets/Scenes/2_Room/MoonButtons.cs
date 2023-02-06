using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fungus;

public class MoonButtons : MonoBehaviour
{
    private Manager manager;
    public int dreamNum;
    private Button button;
    [SerializeField] bool isEnding;
    [SerializeField] Flowchart flowchart;

    [SerializeField] AudioSource audioSource;
    
    void Start() {
        manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
        if(dreamNum > manager.getUnlockedScenes() && !isEnding) this.gameObject.SetActive(false);
        else if(!isEnding) {
            this.gameObject.SetActive(true);
        }

        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene);
        //print("yes " + manager.getUnlockedScenes());
    }

    IEnumerator sceneSwitch() {
        StartCoroutine(StartFade(3f));
        manager.Fade();
        flowchart.ExecuteBlock("switching scenes");
        yield return new WaitForSeconds(4.5f);

        switch(dreamNum) {
            case 0:
                SceneManager.LoadScene("3_ch1");
                //print("hi");
                break;
            case 1:
                SceneManager.LoadScene("4_ch2");
                break;
            case 2:
                SceneManager.LoadScene("5_ch3");
                break;
            case 3:
                SceneManager.LoadScene("6_ch4");
                break;
            case 4:
                SceneManager.LoadScene("7_ch5");
                break;
            case 5:
                SceneManager.LoadScene("8_ch6");
                break;
            case 6:
                SceneManager.LoadScene("9_ch7");
                break;
            case 7:
                SceneManager.LoadScene("10_ch8");
                break;
            case 8:
                SceneManager.LoadScene("end_stay");
                break;
            case 9:
                SceneManager.LoadScene("end_almost");
                break;
            case 10:
                SceneManager.LoadScene("end_goodbye");
                break;
            default:
                print("no more dreams 😔");
                break;
            
        }
        //manager.FastUnFade();
        //print("hi");

        if(manager.getUnlockedScenes() == dreamNum + 1) manager.backFromNewScene = true;

    }
    void SwitchScene() {
        StartCoroutine(sceneSwitch());
    }


    public IEnumerator StartFade(float duration)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
