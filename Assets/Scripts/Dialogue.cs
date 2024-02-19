using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject promptUI;

    public bool squirrelTalk;

    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;
    public GameObject dialogue4;
    public GameObject dialogue5;
    public GameObject dialogue6;
    public GameObject dialogue7;
    public GameObject dialogue8;
    public GameObject dialogue9;
    public GameObject dialogue10;
    public GameObject dialogue11;
    public GameObject dialogue12;
    public GameObject dialogue13;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4; 
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;    
    public GameObject button8;
    public GameObject button9;
    public GameObject button10;
    public GameObject button11;
    public GameObject button12;
    public GameObject button13;

    public GameObject squirrelImage;
    public GameObject boyImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && squirrelTalk)
        {
            DialogueText();
            promptUI.SetActive(false);
            //Time.timeScale = 0f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            squirrelTalk = true;
            promptUI.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            squirrelTalk = false;
        }
    }

    public void DialogueText()
    {
        dialogueUI.SetActive(true);

        dialogue1.SetActive(true);
        button1.SetActive(true);

        squirrelImage.SetActive(true);

        if (dialogueUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (!dialogueUI.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void Next1()
    {
        dialogue1.SetActive(false);
        dialogue2.SetActive(true);

        button1.SetActive(false);
        button2.SetActive(true);

        squirrelImage.SetActive(false);
        boyImage.SetActive(true);
    }

    public void Next2()
    {
        dialogue2.SetActive(false);
        dialogue3.SetActive(true);

        button2.SetActive(false);
        button3.SetActive(true);

        boyImage.SetActive(false);
        squirrelImage.SetActive(true);
    }

    public void Next3()
    {
        dialogue3.SetActive(false);
        dialogue4.SetActive(true);

        button3.SetActive(false);
        button4.SetActive(true);

        squirrelImage.SetActive(false);
        boyImage.SetActive(true); 
    }

    public void Next4()
    {
        dialogue4.SetActive(false);
        dialogue5.SetActive(true);

        button4.SetActive(false);
        button5.SetActive(true);

        squirrelImage.SetActive(true);
        boyImage.SetActive(false);
    }

    public void Next5()
    {
        dialogue5.SetActive(false);
        dialogue6.SetActive(true);

        button5.SetActive(false);
        button6.SetActive(true);

        squirrelImage.SetActive(false);
        boyImage.SetActive(true);
    }

    public void Next6()
    {
        dialogue6.SetActive(false);
        dialogue7.SetActive(true);

        button6.SetActive(false);
        button7.SetActive(true);

        squirrelImage.SetActive(true);
        boyImage.SetActive(false);
    }

    public void Next7()
    {
        dialogue7.SetActive(false);
        dialogue8.SetActive(true);

        button7.SetActive(false);
        button8.SetActive(true);
    }

    public void Next8()
    {
        dialogue8.SetActive(false);
        dialogue9.SetActive(true);

        button8.SetActive(false);
        button9.SetActive(true);

        squirrelImage.SetActive(false);
        boyImage.SetActive(true);
    }

    public void Next9()
    {
        dialogue9.SetActive(false);
        dialogue10.SetActive(true);

        button9.SetActive(false);
        button10.SetActive(true);

        squirrelImage.SetActive(true);
        boyImage.SetActive(false);
    }

    public void Next10()
    {
        dialogue10.SetActive(false);
        dialogue11.SetActive(true);

        button10.SetActive(false);
        button11.SetActive(true);
    }

    public void Next11()
    {
        dialogue11.SetActive(false);
        dialogue12.SetActive(true);

        button11.SetActive(false);
        button12.SetActive(true);
    }

    public void Next12()
    {
        dialogue12.SetActive(false);
        dialogue13.SetActive(true);

        button12.SetActive(false);
        button13.SetActive(true);

        squirrelImage.SetActive(false);
        boyImage.SetActive(true);
    }

    public void Next13()
    {
        dialogue13.SetActive(false);
        button13.SetActive(false);

        boyImage.SetActive(false);

        dialogueUI.SetActive(false);
    }
}
