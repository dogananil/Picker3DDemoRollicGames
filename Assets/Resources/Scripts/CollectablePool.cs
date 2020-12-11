using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePool : MonoBehaviour
{
    [SerializeField] private WhiteSphere whiteSpherePrefab;
    [SerializeField] private int size;

    public void Create()
    {
        for(int i=0;i<size;i++)
        {
            WhiteSphere newSphere = Instantiate(whiteSpherePrefab, this.transform);
            newSphere.gameObject.SetActive(false);
            GameManager.INSTANCE.whiteSpheres.Add(newSphere);

        }
    }
}
