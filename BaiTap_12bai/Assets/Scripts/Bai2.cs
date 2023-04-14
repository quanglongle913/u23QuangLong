using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai2 : MonoBehaviour
{
    //Bai 2 di chuyuen 1 ojb giua 2 diem 
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject point1, point2;
    private Vector3 target,start;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        start = rb.position;
        target = point1.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.transform.position = Vector3.MoveTowards(rb.transform.position, target, 2f * Time.fixedDeltaTime);
        checkTarget();
    }
    private void checkTarget() {
        if (Vector3.Distance(rb.position, point1.transform.position)<0.1f)
        {
            target = point2.transform.position;
        }
        if (Vector3.Distance(rb.position, point2.transform.position) < 0.1f)
        {
            target = start;
        }
        if (Vector3.Distance(rb.position, start) < 0.1f)
        {
            target = point1.transform.position;
        }


    }
}
