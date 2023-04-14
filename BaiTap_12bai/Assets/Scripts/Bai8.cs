using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bai8 : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject point1, point2, point3;
    private Vector3 target;
 
    //chua xong ve duong cong
    void Start()
    {
  
        rb = GetComponent<Rigidbody>();
        rb.position = point1.transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {
        checkTarget();
        rb.position = Vector3.Slerp(rb.position, target, 2f * Time.deltaTime);
        
        
    }
    private void checkTarget()
    {
        if (Vector3.Distance(rb.position, point1.transform.position) < 0.1f)
        {

            target = point2.transform.position;
        }
        if (Vector3.Distance(rb.position, point2.transform.position) < 0.1f)
        {
            target = point3.transform.position;
        }
        if (Vector3.Distance(rb.position, point3.transform.position) < 0.1f)
        {
            target = point1.transform.position;
        }

    }
    
}
