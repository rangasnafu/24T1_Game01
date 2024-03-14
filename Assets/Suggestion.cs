using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suggestion : MonoBehaviour
{
    public GameObject suggestionUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke(nameof(PromptSuggestion), 1f);
            //suggestionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke(nameof(DeletePromptSuggestion), 1f);
            //suggestionUI.SetActive(false);
        }
    }

    private void PromptSuggestion()
    {
        suggestionUI.SetActive(true);
    }

    private void DeletePromptSuggestion()
    {
        suggestionUI.SetActive(false);
    }
}
