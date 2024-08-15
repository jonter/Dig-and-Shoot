using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class SplashScreenTransition : MonoBehaviour
{
    [SerializeField] float transitionTime = 1.5f;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(transitionTime);
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }

    
}
