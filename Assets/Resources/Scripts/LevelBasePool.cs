using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBasePool : MonoBehaviour
{
    [SerializeField] private GameObject levelBase;
    [SerializeField] private int size;

    public void Create()
    {
        for(int i=0;i<size;i++)
        {
            GameObject newLevelBase = Instantiate(levelBase, this.transform);
            newLevelBase.SetActive(false);
            GameManager.INSTANCE.levelBaseList.Add(newLevelBase);
        }
    }
}
