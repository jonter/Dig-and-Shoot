using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    
    bool isOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void Win()
    {
        if (isOver == true) return;
        isOver = true;
        winPanel.SetActive(true);
        int coinsForRound = FindObjectOfType<MoneyManager>().GetCoins();
        winPanel.GetComponentInChildren<RoundMoney>().DisplayMoney(coinsForRound);
        winPanel.transform.localScale = new Vector3(0, 0, 0);
        winPanel.transform.DOScale(1, 0.4f).SetEase(Ease.OutBack).SetUpdate(true);

    }

    public void Lose()
    {
        if (isOver == true) return;
        isOver = true;
        losePanel.SetActive(true);
        int coinsForRound = FindObjectOfType<MoneyManager>().GetCoins();
        losePanel.GetComponentInChildren<RoundMoney>().DisplayMoney(coinsForRound);
        losePanel.transform.localScale = new Vector3(0, 0, 0);
        losePanel.transform.DOScale(1, 0.4f).SetEase(Ease.OutBack).SetUpdate(true);
    }

    public void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void GoNextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ShowAds()
    {
        int coinsForRound = FindObjectOfType<MoneyManager>().GetCoins();
        coinsForRound = coinsForRound * 2;
        GetComponentInChildren<RoundMoney>().DisplayMoney(coinsForRound);

    }


    
}
