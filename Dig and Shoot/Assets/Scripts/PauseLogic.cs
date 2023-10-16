using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    public void MakePause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    
}
