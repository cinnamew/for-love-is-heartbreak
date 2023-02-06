using UnityEngine;  
 using System.Collections;  
 using UnityEngine.EventSystems;  
 using UnityEngine.UI;
 using TMPro;
 
 public class ChangeTextColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
 
     public TMP_Text t; // = GetComponentInChildren(Text)
     public Color startColor;
     public Color endColor = new Color32(120, 100, 135, 255);
     private bool isChanging = false;   //changing from color 1 to color 2
     private float count = 0f;
     public float speed = 1;
 
    void Start() {
        t = GetComponent<TMP_Text>();
        //print(t);
        startColor = t.color;
    }

    void Update() {
        if(count < 0f) count = 0.1f;
        else if(count > 1) count = 1;
        //print(count);
        Color32 tempColor;
        if(isChanging) {
            tempColor = Color32.Lerp(t.color, endColor, count*speed);
            t.color = tempColor;
            count += 0.1f;
        }else {
            tempColor = Color32.Lerp(t.color, startColor, count*speed);
            t.color = tempColor;
            count -= 0.1f;
        }
        

    }

     public void OnPointerEnter(PointerEventData eventData)
     {
         isChanging = true;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         isChanging = false;
         //t.color = startColor;
     }
 }