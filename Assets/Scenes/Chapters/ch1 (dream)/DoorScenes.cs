using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class DoorScenes : MonoBehaviour
{
    [SerializeField] List<Image> images = new List<Image>();
    int currImage = 0;

    public Flowchart flowchart;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextImage()
    {
        currImage++;
        if(currImage >= images.Count) {
            flowchart.ExecuteBlock("ur back ? omg");
            return;
        }
        if(currImage == 5) {
            flowchart.ExecuteBlock("huggies");
            return;
        }
        //images[currImage].SetActive(true);

    }
}
