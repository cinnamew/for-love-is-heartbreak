using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalIcon : MonoBehaviour
{
    private Button button;
    [SerializeField] GameObject journal;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OpenJournal);
    }

    void OpenJournal() {
        
        journal.SetActive(true);
    }
}
