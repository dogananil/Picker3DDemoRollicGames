using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayPool : MonoBehaviour
{
    [SerializeField] private Tray trayPrefab;
    [SerializeField] private int size;

    public void Create()
    {
        for(int i=0;i<size;i++)
        {
            Tray newTray = Instantiate(trayPrefab, this.transform);
            GameManager.INSTANCE.trayList.Add(newTray);
            newTray.gameObject.SetActive(false);
        }
    }
}
