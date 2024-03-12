using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettings : MonoBehaviour
{
    public GameObject settingsUI;
    public GameObject tabUI;
    public GameObject dialogueUI;
    public GameObject crosshairUI;

    //public GameObject transparentTabUI;

    public GameObject promptUI;
    public GameObject dropUI;
    public GameObject talkUI;
    public GameObject shakeUI;
    public GameObject gameOverUI;

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

        //if (crosshairUI.activeSelf)
        //{
        //    tabUI.SetActive(false);
        //    transparentTabUI.SetActive(true);
        //}
        //if (!crosshairUI.activeSelf)
        //{
        //    tabUI.SetActive(true);
        //    transparentTabUI.SetActive(false);
        //}

        if (dialogueUI.activeSelf)
        {
            tabUI.SetActive(false);
        }
        if (!dialogueUI.activeSelf)
        {
            tabUI.SetActive(true);
        }
        if (settingsUI.activeSelf)
        {
            tabUI.SetActive(false);
            crosshairUI.SetActive(false);
            //promptUI.SetActive(false);
            //dropUI.SetActive(false);
            //talkUI.SetActive(false);
            //shakeUI.SetActive(false);
            //gameOverUI.SetActive(false);
        }
        if (!settingsUI.activeSelf)
        {
            tabUI.SetActive(true);
            crosshairUI.SetActive(true);
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
