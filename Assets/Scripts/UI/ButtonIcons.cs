using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonIcons : MonoBehaviour
{
    [SerializeField] private Button[] lvlButtons;
    [SerializeField] private Sprite unlockedIcon;
    [SerializeField] private Sprite lockedIcon;
    [SerializeField] private int firstLevelBuildIndex;

    private void Awake()
    {
        int unlockedLvl = PlayerPrefs.GetInt(EndGameManager.instance.lvlUnlock, firstLevelBuildIndex);
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + firstLevelBuildIndex <= unlockedLvl)
            {
                lvlButtons[i].interactable = true;
                lvlButtons[i].image.sprite = unlockedIcon;

                TextMeshProUGUI buttonText = lvlButtons[i].GetComponentInChildren<TextMeshProUGUI>();
                Debug.Log("buttonText" + buttonText);
                buttonText.text = (i + 1).ToString();
                buttonText.enabled = true;
            }
            else
            {
                lvlButtons[i].interactable = false;
                lvlButtons[i].image.sprite = lockedIcon;
                lvlButtons[i].GetComponentInChildren<TextMeshProUGUI>().enabled = false;
            }
        }
    }
}
