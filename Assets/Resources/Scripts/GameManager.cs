using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE;
    public PlayerController player;
    public UIManager uiManager;
    public LevelManager levelManager;
    public ParticleManager particleManager;
    [SerializeField] private LevelBasePool levelBasePool;
    [SerializeField] private CollectablePool collectablePool;
    [SerializeField] private TrayPool trayPool;
    [SerializeField] private LevelEndPool levelEndPool;
    public List<GameObject> levelBaseList = new List<GameObject>();
    public List<WhiteSphere> whiteSpheres = new List<WhiteSphere>();
    public List<Tray> trayList = new List<Tray>();
    public List<GameObject> levelEndList = new List<GameObject>();
    public bool startBool,partEnd;
    private Vector3 startTouch, endTouch,directionTouch;

    private void Awake()
    {
        INSTANCE = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        levelBasePool.Create();
        collectablePool.Create();
        trayPool.Create();
        levelEndPool.Create();
        levelManager.level = PlayerPrefs.GetInt("LevelNumber", 0);
        levelManager.LoadLevel(levelManager.level);
    }

}
