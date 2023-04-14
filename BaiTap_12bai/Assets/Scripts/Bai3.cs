using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai3 : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject point1, point2, point3;
    private Vector3 target,startPoint;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPoint = rb.position;
        target = point1.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.position = Vector3.MoveTowards(rb.position, target, 2f * Time.fixedDeltaTime);
        checkTarget();
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
            target = startPoint;
        }
        if (Vector3.Distance(rb.position, startPoint) < 0.1f)
        {
            target = point1.transform.position;
        }

    }
}
