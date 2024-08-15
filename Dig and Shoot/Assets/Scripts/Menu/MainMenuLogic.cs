using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField] int levelCount = 10;
    [SerializeField] Button infiniteButton;
    [SerializeField] Button startButton;
    [SerializeField] Button levelsButton;
    [SerializeField] Button upgradesButton;
    [SerializeField] Button backButtonUpgrades;
    [SerializeField] Button backButtonLevels;


    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject levelPanel;
    [SerializeField] GameObject upgradesPanel;

    [SerializeField] TMP_Text startButtonText;

    bool isAnim = false;

    [SerializeField] Transform cavePoint;
    [SerializeField] Transform mainPoint;

    // Start is called before the first frame update
    void Start()
    {
        TransitionPanel.HidePanel();
        upgradesButton.onClick.AddListener(GoUpgrades);
        levelsButton.onClick.AddListener(GoLevels);
        backButtonLevels.onClick.AddListener(BackToMain);
        backButtonUpgrades.onClick.AddListener(BackToMain);

        int maxLevel = PlayerPrefs.GetInt("level");
        if (maxLevel > 0) startButtonText.text = "Продолжить";

        infiniteButton.onClick.AddListener(StartGame);
        if(maxLevel < levelCount) infiniteButton.gameObject.SetActive(false);
        startButton.onClick.AddListener(StartGame);
    }

    

    void StartGame()
    {
        if (isAnim == true) return;
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        isAnim = true;
        mainPanel.transform.DOLocalMoveY(2200, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        mainPanel.SetActive(false);
        Camera.main.transform.DOMove(cavePoint.position, 1);
        Camera.main.transform.DORotate(cavePoint.eulerAngles, 1);
        TransitionPanel.ShowPanel();
        MainMusic.SetBattleMusic();
        yield return new WaitForSeconds(1);
        int index = PlayerPrefs.GetInt("level");
        if (index == 0) index = 1;
        SceneManager.LoadScene(index + 1);
        
    }

    public IEnumerator LoadLevelCoroutine(int level)
    {
        if (isAnim == true) yield break;
        isAnim = true;
        mainPanel.transform.DOLocalMoveY(2200, 0.5f).SetEase(Ease.InBack);
        levelPanel.transform.DOLocalMoveY(2200, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        mainPanel.SetActive(false);
        
        Camera.main.transform.DOMove(cavePoint.position, 1);
        Camera.main.transform.DORotate(cavePoint.eulerAngles, 1);
        TransitionPanel.ShowPanel();
        MainMusic.SetBattleMusic();
        yield return new WaitForSeconds(1);
        
        SceneManager.LoadScene(level);
        
    }

    void GoUpgrades()
    {
        if (isAnim == true) return;
        StartCoroutine(ShowUpgrades());
    }

    IEnumerator ShowUpgrades()
    {
        isAnim = true;
        mainPanel.transform.DOLocalMoveY(2200, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        upgradesPanel.SetActive(true);
        upgradesPanel.transform.localPosition = new Vector3(0, 2200, 0);
        upgradesPanel.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        mainPanel.SetActive(false);
        isAnim = false;
    }

    void GoLevels()
    {
        if (isAnim == true) return;
        StartCoroutine(ShowLevels());
    }

    IEnumerator ShowLevels()
    {
        isAnim = true;
        mainPanel.transform.DOLocalMoveY(2200, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        levelPanel.SetActive(true);
        levelPanel.transform.localPosition = new Vector3(0, 2200, 0);
        levelPanel.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        mainPanel.SetActive(false);
        isAnim = false;
    }

    void BackToMain()
    {
        if (isAnim == true) return;
        StartCoroutine(BackMainCoroutine());
    }

    IEnumerator BackMainCoroutine()
    {
        isAnim = true;
        levelPanel.transform.DOLocalMoveY(2200, 0.5f).SetEase(Ease.InBack);
        upgradesPanel.transform.DOLocalMoveY(2200, 0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        mainPanel.SetActive(true);
        mainPanel.transform.localPosition = new Vector3(0, 2200, 0);
        mainPanel.transform.DOLocalMoveY(0, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        levelPanel.SetActive(false);
        upgradesPanel.SetActive(false);
        isAnim = false;
    }





}
