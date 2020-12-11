using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndPool : MonoBehaviour
{
    [SerializeField] private GameObject levelEnd;
    [SerializeField] private int size;

    public void Create()
    {
        for(int i=0;i<size;i++)
        {
            GameObject newLevelEnd = Instantiate(levelEnd, this.transform);
            newLevelEnd.gameObject.SetActive(false);
            GameManager.INSTANCE.levelEndList.Add(newLevelEnd);
        }
    }
}
