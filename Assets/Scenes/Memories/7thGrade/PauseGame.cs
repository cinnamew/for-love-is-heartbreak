using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class PauseGame : MonoBehaviour
{
    public void Pause() {
        Time.timeScale = 0;
    }

    public void Resume() {
        Time.timeScale = 1;
    }
}
