using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelProperties levelProperties;
    private int sphereIndex;
    public int level;
    private float lastEndPos=0;
    public bool nextLevel;

    public void LoadLevel(int levelNumber)
    {
        TextAsset jsonInfo = Resources.Load<TextAsset>("Level/level_" + levelNumber);
        levelProperties = JsonUtility.FromJson<LevelProperties>(jsonInfo.text);
        level = levelNumber;
        GameManager.INSTANCE.uiManager.ResetUI(level);
        CreateLevel(levelNumber);
    }
    private void CreateLevel(int levelNumber)
    {
        sphereIndex = 0;
        for(int i=0;i<levelProperties.levelParts.Length;i++)
        {
            Vector3 scaleLevelBase = GameManager.INSTANCE.levelBaseList[i].transform.localScale;
            GameManager.INSTANCE.levelBaseList[i].transform.localScale = new Vector3(scaleLevelBase.x, scaleLevelBase.y, levelProperties.levelParts[i].partLength);
            GameManager.INSTANCE.levelBaseList[i].transform.GetChild(2).GetComponent<BoxCollider>().enabled = true;
            if(lastEndPos<=0)
            {
                GameManager.INSTANCE.levelBaseList[i].transform.position = new Vector3(0, -0.46f, lastEndPos + ((i == 0) ? levelProperties.levelParts[i].partLength / 2 - 5f : GameManager.INSTANCE.levelBaseList[i - 1].transform.position.z + GameManager.INSTANCE.levelBaseList[i - 1].transform.localScale.z / 2 + GameManager.INSTANCE.levelBaseList[i].transform.localScale.z / 2 + 5f));
            }
            else
            {
                GameManager.INSTANCE.levelBaseList[i].transform.position = new Vector3(0, -0.46f,  ((i == 0) ? levelProperties.levelParts[i].partLength / 2+ lastEndPos: GameManager.INSTANCE.levelBaseList[i - 1].transform.position.z + GameManager.INSTANCE.levelBaseList[i - 1].transform.localScale.z / 2 + GameManager.INSTANCE.levelBaseList[i].transform.localScale.z / 2 + 5f));
            }
            GameManager.INSTANCE.levelBaseList[i].gameObject.SetActive(true);

            GameManager.INSTANCE.trayList[i].transform.position = new Vector3(0, -0.75f, GameManager.INSTANCE.levelBaseList[i].transform.position.z + GameManager.INSTANCE.levelBaseList[i].transform.localScale.z / 2 + 2.5f);
            GameManager.INSTANCE.trayList[i].SetText(levelProperties.levelParts[i].ballNumberOfTray,i);
            GameManager.INSTANCE.trayList[i].gameObject.SetActive(true);
            for (int j=0;j<levelProperties.levelParts[i].collectables.Length;j++)
            {
                GameManager.INSTANCE.whiteSpheres[sphereIndex].data = levelProperties.levelParts[i].collectables[j];
                GameManager.INSTANCE.whiteSpheres[sphereIndex].SetCollectable(lastEndPos);
                GameManager.INSTANCE.whiteSpheres[sphereIndex].gameObject.SetActive(true);
                sphereIndex++;
            }
        }
        GameManager.INSTANCE.levelEndList[levelNumber % 2 == 0 ? 0 : 1].transform.position = new Vector3(0, 0, GameManager.INSTANCE.trayList[levelProperties.levelParts.Length - 1].transform.position.z + 20f);
        lastEndPos = GameManager.INSTANCE.levelEndList[levelNumber % 2 == 0 ? 0 : 1].transform.position.z+25f;
        GameManager.INSTANCE.levelEndList[levelNumber % 2 == 0 ? 0 : 1].transform.GetChild(2).GetComponent<SphereCollider>().enabled = true;
        GameManager.INSTANCE.levelEndList[levelNumber % 2 == 0 ? 0 : 1].SetActive(true);
    }
    public void NextLevel()
    {
        level++;
        PlayerPrefs.SetInt("LevelNumber", level);
        LoadLevel(level);
        nextLevel = false;
    }
    public void GameOver()
    {
        lastEndPos = 0;
        GameManager.INSTANCE.player.ResetPlayer(lastEndPos);
        PlayerPrefs.SetInt("LevelNumber", level);
        LoadLevel(level);
        
    }
}
