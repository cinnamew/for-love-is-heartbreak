using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SleepButton : MonoBehaviour
{
    private Button button;
    private Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene);
        manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
    }

    IEnumerator sceneSwitch() {
        manager.Fade();
        yield return new WaitForSeconds(5);

        switch(manager.getUnlockedScenes()) {
            case 0:
                SceneManager.LoadScene("3_ch1");
                break;
            case 1:
                SceneManager.LoadScene("4_ch2");
                break;
            case 2:
                SceneManager.LoadScene("5_ch3");
                break;
            default:
                print("no more dreams 😔");
                break;
            
        }

        manager.UnFade();

    }
    void SwitchScene() {
        StartCoroutine(sceneSwitch());
        /*if(manager.getUnlockedScenes() == 0) {
            SceneManager.LoadScene("3_ch1");
        }else if(manager.getUnlockedScenes() == 1) {
            SceneManager.LoadScene("4_ch2");
        }else if(manager.getUnlockedScenes() == 2) {
            SceneManager.LoadScene("4_ch2");
        }else {
            print("no more dreams 😔");
        }*/
    }
}
