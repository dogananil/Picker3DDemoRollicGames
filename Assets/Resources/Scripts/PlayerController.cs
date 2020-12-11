using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 startMousePos, endMousePos,direction;
    [SerializeField] private float sideSpeed,speed;
    private Rigidbody playerRB;
    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        StartDrag();
        MoveForward();

    }
    private void StartDrag()
    {
        if(!GameManager.INSTANCE.startBool)
        {
            if(Input.GetMouseButtonDown(0))
            {
                startMousePos = Input.mousePosition;
            }
            else if(Input.GetMouseButton(0))
            {
                endMousePos = Input.mousePosition;
                direction = endMousePos - startMousePos;
                GameManager.INSTANCE.startBool = true;
                GameManager.INSTANCE.uiManager.startPanel.gameObject.SetActive(false);
            }
        }
    }
    private void MoveForward()
    {
        if (!GameManager.INSTANCE.startBool || GameManager.INSTANCE.partEnd) return;
        playerRB.velocity = transform.forward * speed * Time.fixedDeltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;

        }
        else if (Input.GetMouseButton(0))
        {
            endMousePos = Input.mousePosition;
            direction = endMousePos - startMousePos;
            direction.y = 0;
            direction.z = 0;
            startMousePos = endMousePos;
            playerRB.velocity=transform.forward * speed * Time.fixedDeltaTime + direction * sideSpeed * Time.fixedDeltaTime;
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.5f,2.5f), transform.position.y, transform.position.z);
            Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, Camera.main.transform.position.z);

        }
        else if(Input.GetMouseButtonUp(0))
        {
            playerRB.velocity=transform.forward * speed * Time.fixedDeltaTime;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        /*if(collision.transform.CompareTag("Sphere"))
        {
            collision.transform.SetParent(transform);
        }*/
        if(collision.transform.CompareTag("PartEnd"))
        {
            collision.collider.enabled = false;
            
            GameManager.INSTANCE.partEnd = true;
            playerRB.velocity = Vector3.zero;
        }
        else if(collision.transform.CompareTag("TunnelEnd") && !GameManager.INSTANCE.levelManager.nextLevel)
        {
            collision.collider.enabled = false;
            GameManager.INSTANCE.levelManager.nextLevel = true;
            GameManager.INSTANCE.startBool = false;
            playerRB.isKinematic = true;
            playerRB.isKinematic = false;
            GameManager.INSTANCE.uiManager.nextLevelPanel.SetActive(true);
            //GameManager.INSTANCE.levelManager.NextLevel();
        }
    }
    public void ResetPlayer(float lastEndPoint)
    {
        GameManager.INSTANCE.partEnd = false;
        transform.position = new Vector3(0, -0.19f, lastEndPoint);
    }
}
