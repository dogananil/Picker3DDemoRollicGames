using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tray : MonoBehaviour
{
    public TextMeshPro text;
    private int size;
    private int ballNumber=0;
    [SerializeField] private Transform levelBase;
    private bool pass=false;
    private bool gameOver;
    private Coroutine tempCoroutine;
    private int partIndex;
    public void SetText(int need,int part)
    {
        text.text = "0/" + need.ToString();
        ballNumber = 0;
        partIndex = part+1;
        pass = false;
        levelBase.transform.localPosition = new Vector3(levelBase.localPosition.x, -0.46f, levelBase.localPosition.z);
        size = need;
    }
    public void IncreaseText(int ballNumber)
    {
        text.text = ballNumber.ToString() + "/" + size.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Sphere") && !collision.transform.GetComponent<WhiteSphere>().collected)
        {
            collision.transform.GetComponent<WhiteSphere>().collected = true;
            ballNumber++;
            IncreaseText(ballNumber);
            StartCoroutine(collision.transform.GetComponent<WhiteSphere>().StartCollectAnimation());
            if(ballNumber>=size && !pass)
            {
                pass = true;
                gameOver = false;
                StopCoroutine(tempCoroutine);
                StartCoroutine(LevelBaseUp());

            
            }
            else if(ballNumber<size && !pass)
            {
                gameOver = true;
                tempCoroutine = StartCoroutine(GameOver());

            }
        }
    }
    private IEnumerator LevelBaseUp()
    {
        float timeLapse = 0, totalTime=2.0f;
        Vector3 startPos = levelBase.transform.position;
        Vector3 endPos = new Vector3(startPos.x, -0.46f, startPos.z);
        yield return new WaitForSeconds(2.0f);
        GameManager.INSTANCE.particleManager.PlayParticle(transform, ParticleType.Smiley);
        while(timeLapse<=totalTime)
        {
            levelBase.transform.position = Vector3.Lerp(startPos, endPos, timeLapse);
            timeLapse += Time.deltaTime;
            yield return null;
        }
        GameManager.INSTANCE.partEnd = false;
        GameManager.INSTANCE.uiManager.SetPartColor(partIndex);
    }
    private IEnumerator GameOver()
    {
        float timeLapse = 0, totalTime = 3.0f;

        while(timeLapse<=totalTime)
        {
            timeLapse += Time.deltaTime;
            yield return null;
        }
        if(gameOver)
        {
            //Debug.Log();    
            GameManager.INSTANCE.uiManager.gameOverPanel.SetActive(true);
        }
        //GameManager.INSTANCE.levelManager.GameOver();
    }
}
