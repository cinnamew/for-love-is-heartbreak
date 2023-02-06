using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private static int unlockedScenes;
    public bool backFromNewScene = true;
    public Fungus.Flowchart flowchart;

    [SerializeField] float score = 0f;
    private static ArrayList namesOfDestroyedObjects = new ArrayList();
    void Start() {

        if(namesOfDestroyedObjects.Count == 0 && PlayerPrefs.HasKey("objects")) {
            //print("has objects key");
            string temp = PlayerPrefs.GetString("objects");
            string[] temp2 = temp.Split('/');
            //print("length of array: " + temp2.Length);
            foreach(var s in temp2) {
                //print(s);
                namesOfDestroyedObjects.Add(s);
            }
        }

        if(namesOfDestroyedObjects.Count>0){
            for (int i = 0; i < namesOfDestroyedObjects.Count; i++) {
                //print((string)namesOfDestroyedObjects[i]);
                if(GameObject.Find((string)namesOfDestroyedObjects[i]) != null) {
                    Destroy(GameObject.Find((string)namesOfDestroyedObjects[i]));
                }
            }
        }

        if(!PlayerPrefs.HasKey("score")) PlayerPrefs.SetFloat("score", 0);
        score = PlayerPrefs.GetFloat("score");
    }

    void Awake() {
        
        GameObject[] e = GameObject.FindGameObjectsWithTag("manager");
        if(e.Length > 1) {
            Destroy(e[0]);
        }else {
            if(!PlayerPrefs.HasKey("chapter")) unlockedScenes = 0;
            else {
                unlockedScenes = PlayerPrefs.GetInt("chapter");
            }
        }
        //Debug.Log(backFromNewScene);
        DontDestroyOnLoad(this.gameObject);
        
        //print(unlockedScenes);
        if(backFromNewScene) {
            flowchart.SetIntegerVariable("unlockedScenes", unlockedScenes);
            switch(unlockedScenes) {
                case 1:
                    flowchart.ExecuteBlock("first");
                    break;
                case 2:
                    flowchart.ExecuteBlock("second");
                    break;
                case 3:
                    flowchart.ExecuteBlock("third");
                    break;
                case 4:
                    flowchart.ExecuteBlock("fourth");
                    break;
                case 5:
                    flowchart.ExecuteBlock("fifth");
                    break;
                case 6:
                    flowchart.ExecuteBlock("sixth");
                    break;
                case 7:
                    flowchart.ExecuteBlock("seventh");
                    break;
                case 8:
                    flowchart.ExecuteBlock("eighth");
                    break;
            }
        }

        backFromNewScene = false;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(Screen.fullScreen) {
                Screen.fullScreen = false;
            }else Screen.fullScreen = true;
        }
    }

    public void ResetDestroyedObjects() {
        namesOfDestroyedObjects = new ArrayList();
        PlayerPrefs.DeleteKey("objects");
    }

    public void addToDestroyedObjects(string o) {
        namesOfDestroyedObjects.Add(o);
        PlayerPrefs.SetString("objects", PlayerPrefs.GetString("objects") + "/" + o);
        
    }
    public double getScore() {
        print("player prefs: " + PlayerPrefs.GetInt("score"));
        return score;
        //return PlayerPrefs.GetInt("score");
    }

    public void addToScore(double s) {
        score += (float)s;
        PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + (float)s);
    }

    public void Fade() {
        flowchart.ExecuteBlock("Fade");
    }

    public void UnFade() {
        flowchart.ExecuteBlock("Unfade");
    }

    public void FastUnFade() {
        flowchart.ExecuteBlock("FastUnfade");
    }

    public void setUnlockedScenes(int aaa) {
        unlockedScenes = aaa;
        PlayerPrefs.SetInt("chapter", aaa);
    }

    public void safeSetUnlockedScenes(int bbb) {
        if(bbb > unlockedScenes) {
            unlockedScenes = bbb;
            backFromNewScene = true;
            PlayerPrefs.SetInt("chapter", bbb);
        }
        //print("changed to " + unlockedScenes);
    }

    public int getUnlockedScenes() {
        return unlockedScenes;
    }
    public void addUnlockedScenes() {
        unlockedScenes++;
    }

    public void ChangeToScene(string s) {
        SceneManager.LoadScene(s);
    }
}
