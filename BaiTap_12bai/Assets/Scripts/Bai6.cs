using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai6 : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed=2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        { 
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + speed * Time.deltaTime, rb.transform.position.z);
           
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y - speed * Time.deltaTime, rb.transform.position.z);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("Right Arrow +  "+ rb.transform.position.x + speed * Time.deltaTime);
            rb.transform.position = new Vector3(rb.transform.position.x + speed * Time.deltaTime, rb.transform.position.y, rb.transform.position.z);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.transform.position = new Vector2(rb.transform.position.x - speed * Time.deltaTime, rb.transform.position.y);
        }
    }
}
