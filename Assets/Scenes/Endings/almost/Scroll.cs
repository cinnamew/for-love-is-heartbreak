using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scroll : MonoBehaviour
{
    private Transform transform;
    [SerializeField] float scale;
    [SerializeField] bool isLetter;
    [SerializeField] GameObject endText;
    [SerializeField] bool isUI;
    private static bool stopScrolling = false;

    // Start is called before the first frame update
    void Start()
    {
        transform = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(stopScrolling) return;
        //small: 806 x 453, big: 2231 x 1255
        //print(Screen.height + " " + Screen.width);

        Vector2 pos = transform.position;
        //print(Input.mouseScrollDelta.y);
        if(!isUI) pos.y -= Input.mouseScrollDelta.y * scale;
        else {
            pos.y -= Input.mouseScrollDelta.y * ((scale/1255f)*Screen.height);
            //print((scale/2231f)*Screen.height);
        }
        transform.position = pos;
        //Debug.Log(Input.mouseScrollDelta.y);

        if(isLetter) {
            //Debug.Log(transform.position.y);
            if(transform.position.y >= -1) {
                //SceneManager.LoadScene("Credits");
                stopScrolling = true;
                //print("should've stopped");
                StartCoroutine(Wait());
                return;
            }

        }

    }

    private IEnumerator Wait() {
        yield return new WaitForSeconds(3);
        endText.SetActive(true);
    }
}
