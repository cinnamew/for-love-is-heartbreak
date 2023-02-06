using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutImage : MonoBehaviour
{
    private float target = 0.0f;
    private Image image;
    
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void FadeOut(float s) {
        StartCoroutine(FadeImage(s));
    }

    private IEnumerator FadeImage(float seconds)
    {
        var alpha = image.color.a;
        for (var t = 0.0f; t < 1.0f; t += Time.deltaTime / seconds)
        {
            //change color as you want
            var newColor = new Color(1.0f, 1.0f, 1.0f, Mathf.Lerp(alpha, target , t));
            image.color = newColor;
            yield return null;
        }
    }
}
