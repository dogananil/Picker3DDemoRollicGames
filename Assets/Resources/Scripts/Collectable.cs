using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    [SerializeField]public CollectableData data;
    public bool collected;
    public ParticleSystem blastParticle;

    public void SetCollectable(float lastEndPos)
    {
        
        transform.position = new Vector3(data.pos[0], data.pos[1]-0.3f, data.pos[2]+lastEndPos);
        transform.GetComponent<SphereCollider>().enabled = true;
        collected = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
[System.Serializable]
public class CollectableData
{
    [SerializeField] public CollectableType type;
    [SerializeField] public float[] pos;
}
public enum CollectableType
{
    WhiteSphere
}
