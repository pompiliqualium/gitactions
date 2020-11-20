using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone : MonoBehaviour
{
    [SerializeField]
    public float aggroRadius = 0.5f;
    [SerializeField]
    public float weight = 1;
    public Rigidbody rigidBody;



    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

}
