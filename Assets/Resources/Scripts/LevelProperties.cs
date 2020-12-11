using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelProperties 
{
    [SerializeField] public LevelPart[] levelParts;
}
[System.Serializable]
public class LevelPart
{
    [SerializeField] public float partLength;
    [SerializeField] public int ballNumberOfTray;
    [SerializeField] public CollectableData[] collectables;
}
