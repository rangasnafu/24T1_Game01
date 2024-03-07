using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettings : MonoBehaviour
{
    public GameObject settingsUI;
    public GameObject tabUI;
    public GameObject dialogueUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !dialogueUI.activeSelf)
        {
            //DialogueText();
            settingsUI.SetActive(true);
            tabUI.SetActive(false);
            //Time.timeScale = 0f;
            //exclamationUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }

        if (dialogueUI.activeSelf)
        {
            tabUI.SetActive(false);
        }
        if (!dialogueUI.activeSelf)
        {
            tabUI.SetActive(true);
        }
    }

    public void ExitSettings()
    {
        //Time.timeScale = 1f;
        settingsUI.SetActive(false);
        tabUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
