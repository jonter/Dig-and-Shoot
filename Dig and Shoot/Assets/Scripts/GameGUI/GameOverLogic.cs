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
    bool isAnim = false;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<BaseHealth>().OnDeath += Lose;
        FindObjectOfType<EnemySpawner>().OnWin += Win;
        TransitionPanel.HidePanel();
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
        StartCoroutine(SlowTime());
        SaveCoins(coinsForRound);
        SaveLevel();
    }

    void SaveCoins(int coins)
    {
        int allCoins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", allCoins + coins);

    }

    void SaveLevel()
    {
        int max = PlayerPrefs.GetInt("level");
        int index = SceneManager.GetActiveScene().buildIndex;
        if(index > max)
        {
            PlayerPrefs.SetInt("level", index);
        }

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
        StartCoroutine(SlowTime());
        SaveCoins(coinsForRound);
    }

    IEnumerator SlowTime()
    {
        yield return new WaitForSeconds(2);
        Time.timeScale = 0.3f;
    }

    public void Restart()
    {
        if (isAnim == true) return;
        isAnim = true;
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }

    public void GoNextLevel()
    {
        if (isAnim == true) return;
        isAnim = true;
        StartCoroutine(GoNextCoroutine());
    }
    IEnumerator GoNextCoroutine()
    {
        TransitionPanel.ShowPanel();
        yield return new WaitForSecondsRealtime(1);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    public void GoMenu()
    {
        if (isAnim == true) return;
        isAnim = true;
        StartCoroutine(GoMenuCoroutine());
    }

    IEnumerator GoMenuCoroutine()
    {
        TransitionPanel.ShowPanel();
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("Menu");
    }

    public void ShowAds()
    {
        if (isAnim == true) return;
        
        int coinsForRound = FindObjectOfType<MoneyManager>().GetCoins();
        coinsForRound = coinsForRound * 2;
        GetComponentInChildren<RoundMoney>().DisplayMoney(coinsForRound);

    }


    
}
