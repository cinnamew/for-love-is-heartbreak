using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    

    public void fadeOut(float duration) {
        StartCoroutine(StartFade(duration));
    }

    public IEnumerator StartFade(float duration)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0, currentTime / duration);
            //print("fading");
            yield return null;
        }
        //print("done fading");
        yield return null;
    }

    public void fadeIn(float duration) {
        StartCoroutine(StartFadeIn(duration));
    }

    public IEnumerator StartFadeIn(float duration)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        audioSource.volume = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0, start, currentTime / duration);
            //print("fading");
            yield return null;
        }
        //print("done fading in");
        yield return null;
    }
}
