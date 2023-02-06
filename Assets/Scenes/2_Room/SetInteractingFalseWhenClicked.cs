using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class SetInteractingFalseWhenClicked : MonoBehaviour
{
    
    private Button button;
    [SerializeField] Flowchart flowchart;

    // Start is called before the first frame update
    void Start()
    {
        button = this.gameObject.GetComponent<Button>();
        button.onClick.AddListener(whenClicked);
    }

    private void whenClicked() {
        flowchart.ExecuteBlock("setInteractingFalse");
    }
}
