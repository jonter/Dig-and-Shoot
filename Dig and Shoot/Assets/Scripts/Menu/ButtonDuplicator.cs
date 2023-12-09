using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDuplicator : MonoBehaviour
{
    [SerializeField] int buttonCount = 50;

    // Start is called before the first frame update
    void Start()
    {
        GameObject mainButton = transform.GetChild(0).gameObject;
        mainButton.GetComponent<LevelButton>().SetupButton(1, true);
        buttonCount--;

        int maxLevel = PlayerPrefs.GetInt("level");

        for (int i = 0; i < buttonCount; i++)
        {
            bool isEnable = false;
            int index = i + 2;
            if (index <= maxLevel + 1) isEnable = true;

            GameObject clone = Instantiate(mainButton, transform);
            clone.GetComponent<LevelButton>().SetupButton(index, isEnable);
        }
        float h = buttonCount * 250 / 3 + 300;
        RectTransform myrect = GetComponent<RectTransform>();
        myrect.sizeDelta = new Vector2(myrect.sizeDelta.x, h);
    }

   
}
