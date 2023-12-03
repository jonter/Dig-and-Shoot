using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    int levelIndex = 1;
    public void SetupButton(int index)
    {
        GetComponentInChildren<TMP_Text>().text = "" + index;
        levelIndex = index;
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(LoadLevel);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(levelIndex);
    }


}
