using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseLogic : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    bool isGameOver = false;

    bool isAnim = false;

    public static bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        FindObjectOfType<BaseHealth>().OnDeath += GameOver;
        FindObjectOfType<EnemySpawner>().OnWin += GameOver;
    }

    void GameOver()
    {
        isGameOver = true;
    }

    public void MakePause()
    {
        if (isAnim) return;
        if (isGameOver == true) return;
        if (pausePanel.activeSelf == true) return;
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        pausePanel.transform.localScale = new Vector3(0, 0, 0);
        pausePanel.transform.DOScale(1, 0.4f)
            .SetEase(Ease.OutBack).SetUpdate(true);
        StartCoroutine(SetAnimCoroutine(0.5f));
    }

    public void ContinueGame()
    {
        if (isAnim) return;
        isPaused = false;
        StartCoroutine(DisablePanel());
        Time.timeScale = 1;
        pausePanel.transform.DOScale(0, 0.4f)
            .SetEase(Ease.InBack).SetUpdate(true);
        StartCoroutine(SetAnimCoroutine(0.5f));
    }

    IEnumerator DisablePanel()
    {
        yield return new WaitForSeconds(0.4f);
        pausePanel.SetActive(false);
    }

    private void OnDisable()
    {
        pausePanel.transform.DOKill();
        isPaused = false;
    }

    IEnumerator SetAnimCoroutine(float duration)
    {
        isAnim = true;
        yield return new WaitForSecondsRealtime(duration);
        isAnim = false;
    }

}
