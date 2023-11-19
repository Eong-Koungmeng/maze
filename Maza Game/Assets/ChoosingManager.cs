using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UnityEngine;

public class ChoosingManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;
    public static string playerType;
    string[] characterTypeLabel = { "Runner", "Killer","Catcher" };
    [SerializeField] GameObject[] characterObjects;
    int i = 0;
    public void rightArrowButton()
    {
        characterObjects[i].SetActive(false);
        i = (i + 1) % 3;
        changePlayerType(characterTypeLabel[i]);
    }
    
    public void leftArrowButton()
    {
        characterObjects[i].SetActive(false);
        i--;
        if (i == -1)
            i = 2;
        changePlayerType(characterTypeLabel[i]);
    }

    void changePlayerType(string type)
    {
        playerType = type;
        label.text = type;
        characterObjects[i].SetActive(true);

    }
}
