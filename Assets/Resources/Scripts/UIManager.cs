using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject nextLevelPanel;
    [SerializeField] private TextMeshProUGUI startLevel, endLevel;
    [SerializeField] private Image firstPart, secondPart;
    [SerializeField] private Color partColor;

    public void SetPartColor(int part)
    {
        if(part==1)
        {
            firstPart.color = Color.green;
        }
        else
        {
            secondPart.color = Color.green;
        }
    }
    public void ResetUI(int levelNumber)
    {
        firstPart.color = partColor;
        secondPart.color = partColor;
        startLevel.text = levelNumber.ToString();
        endLevel.text = (levelNumber + 1).ToString();
    }
}
