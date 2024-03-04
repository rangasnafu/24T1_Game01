using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettings : MonoBehaviour
{
    public GameObject settingsUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //DialogueText();
            settingsUI.SetActive(false);
            //Time.timeScale = 0f;
            //exclamationUI.SetActive(false);
        }
    }
}
