using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stomp : MonoBehaviour
{
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverUI.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
