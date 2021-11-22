using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject creditsPanel;
    private bool creditsPanelOpen = true;

    public void OnStartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCreditsClick()
    {
        if(creditsPanelOpen)
        {
            creditsPanel.SetActive(false);
            creditsPanelOpen = false;
        }
        else
        {
            creditsPanel.SetActive(true);
            creditsPanelOpen = true;    
        }
        
    }
}
