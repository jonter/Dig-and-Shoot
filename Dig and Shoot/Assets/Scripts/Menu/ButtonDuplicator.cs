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
        buttonCount--;

        for (int i = 0; i < buttonCount; i++)
        {
            GameObject clone = Instantiate(mainButton, transform);
            clone.GetComponent<LevelButton>().SetupButton(i+2);
        }
        float h = buttonCount * 250 / 3 + 300;
        RectTransform myrect = GetComponent<RectTransform>();
        myrect.sizeDelta = new Vector2(myrect.sizeDelta.x, h);
    }

   
}
