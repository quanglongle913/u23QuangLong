using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
 
    public Transform target;
    [SerializeField] private Vector3 offset; // vi tri tuong doi cuua target vs cam
    [SerializeField] private float speed=10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,target.position + offset,Time.fixedDeltaTime*speed);
    }
}
