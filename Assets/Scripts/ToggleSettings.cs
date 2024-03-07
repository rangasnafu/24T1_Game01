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
            settingsUI.SetActive(true);
            //Time.timeScale = 0f;
            //exclamationUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void ExitSettings()
    {
        //Time.timeScale = 1f;
        settingsUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
