using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class FadeToBlack : MonoBehaviour
{
    
    public bool fading = false;
    public AudioMixer mainMixer;
    private float pastVol;
    private float fadeAmt = 1;
    private Image image;
    private float[] startColors = new float[4]; //5E5555
    private Color32 startColor;
    public bool antiFading = false;
    public bool fadeMusic = true;
    void Start() {
        image = GetComponent<Image>();
        startColor = image.color;
        for(int i = 0; i < 4; i++) {
            startColors[i] = startColor[i];
        }
        pastVol = GetMasterLevel();
        
    }
    void Update()
    {
        if(fading) {
            if(fadeAmt > 255) {
                return;
            }
            image.color = new Color32((byte)(startColors[0] - fadeAmt), (byte)(startColors[1] - fadeAmt), (byte)(startColors[2] - fadeAmt), 255);
            fadeAmt++;
            if(fadeMusic) mainMixer.SetFloat("musicvol", pastVol - Mathf.Log10(fadeAmt) * 20);
            //mainMixer.SetFloat("sfxvol", pastVol);
        }else if(antiFading) {
            //print(startColors[0] + " " + (startColors[0] - fadeAmt));
            byte red = (byte)(Math.Min(startColors[0], Math.Max(0, startColors[0] - fadeAmt)));
            byte green = (byte)(Math.Min(startColors[1], Math.Max(0, startColors[1] - fadeAmt)));
            byte blue = (byte)(Math.Min(startColors[2], Math.Max(0, startColors[2] - fadeAmt)));
            //print("red: " + red + ", b: " + blue + ", g: " + green);

            if(red == startColors[0] && blue == startColors[2] && green == startColors[1]) {
                antiFading = false;
                resetImage();
                return;
            }

            image.color = new Color32(red, green, blue, 255);
            fadeAmt--;
            if(fadeMusic) mainMixer.SetFloat("musicvol",  pastVol - fadeAmt);//Mathf.Log10(fadeAmt) * 20
            //print("past vol: " + pastVol + "; fade amt: " + fadeAmt);
        }
    }

    public void setFading(bool f) {
        fading = f;
        fadeAmt = 0;
        if(!f) {
            resetImage();
        }
    }
    public void resetImage() {
        image.color = startColor;
        mainMixer.SetFloat("musicvol", pastVol);
    }
    public void antiFade() {
        fading = false;
        antiFading = true;
        fadeAmt = 255;
        //image.color = Color.black;
        mainMixer.SetFloat("musicvol", -79);
    }

    public float GetMasterLevel(){
         float value;
         bool result =  mainMixer.GetFloat("musicvol", out value);
         if(result){
             return value;
         }else{
             return 0f;
         }
     }
}
