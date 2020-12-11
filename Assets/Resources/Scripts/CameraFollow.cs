using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;
    Vector3 offSet,smoothedPos;
    [SerializeField] private float smoothSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        smoothedPos = Vector3.Slerp(transform.position, target.position + offSet, smoothSpeed*Time.deltaTime);
        smoothedPos.x = 0;
        transform.position = smoothedPos;
    }
}
