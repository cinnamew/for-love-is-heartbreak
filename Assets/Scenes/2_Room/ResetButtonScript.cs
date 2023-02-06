using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResetButtonScript : MonoBehaviour
{
    private Button button;
    private Manager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ResetRoom);
        manager = GameObject.FindGameObjectWithTag("manager").gameObject.GetComponent<Manager>();
    }

    void ResetRoom() {
        manager.setUnlockedScenes(0);
        manager.ResetDestroyedObjects();
        PlayerPrefs.SetString("firstTime", "true");
        PlayerPrefs.SetInt("score", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
