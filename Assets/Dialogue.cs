using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject promptUI;

    public bool squirrelTalk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && squirrelTalk)
        {
            DialogueText();
            promptUI.SetActive(false);
            //Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            squirrelTalk = true;
            promptUI.SetActive(true);
        }

    }

    private void DialogueText()
    {
        dialogueUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
