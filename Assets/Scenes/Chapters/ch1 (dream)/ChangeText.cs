using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeText : MonoBehaviour
{
    public TextMeshProUGUI text;
    private string artist;
    private string song;

    public void setText(string t) {
        text.text = t;
    }

    public void setArtist(string a) {
        artist = a;
    }
    public void setSong(string s) {
        song = s;
    }
    public void setMusicText() {
        text.text = "♫: " + artist + " - " + song;
    }

    public void whiteColor() {
        text.color = Color.white;
    }

    public void blackColor() {
        text.color = Color.black;
    }
    public void setColor(int r, int g, int b, int a) {
        text.color = new Color32((byte)r, (byte)g, (byte)b, (byte)a);
    }
}
