using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai7 : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject point1, point2, point3;
    private Vector3 target;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.transform.position = point1.transform.position;
        target = point1.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkTarget();
        rb.position = Vector3.MoveTowards(rb.position, target, 2f * Time.fixedDeltaTime);
        
    }
    private void checkTarget()
    {
        if (Vector3.Distance(rb.position, point1.transform.position) < 0.1f)
        {
            
            int tp = Random.Range(1,3);
            Debug.Log("" + tp);
            if (tp == 1) {
                target = point2.transform.position;
            }
            if (tp == 2)
            {
                target = point3.transform.position;
            }
        }
        if (Vector3.Distance(rb.position, point2.transform.position) < 0.1f)
        {
            int tp = Random.Range(1, 3);
            Debug.Log("" + tp);
            if (tp == 1)
            {
                target = point1.transform.position;
            }
            if (tp == 2)
            {
                target = point3.transform.position;
            }
        }
        if (Vector3.Distance(rb.position, point3.transform.position) < 0.1f)
        {
            int tp = Random.Range(1, 3);
            Debug.Log(""+tp);
            if (tp == 1)
            {
                target = point2.transform.position;
            }
            if (tp == 2)
            {
                target = point1.transform.position;
            }
        }
        

    }
}
