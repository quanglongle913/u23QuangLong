
using UnityEngine;

public class Bai12 : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject point1, point2, point3;



    // hoat dong voi 2D o Scene
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.tag == "Player")
                {
                    rb.GetComponent<MeshRenderer>().material.color = Color.red;
                    rb.position = Input.mousePosition;
                }
            }
           
        }
        if (Vector3.Distance(rb.position, point1.transform.position) < 0.1f)
        {
            Debug.Log("Complete 1");
        }
        if (Vector3.Distance(rb.position, point2.transform.position) < 0.1f)
        { 
            Debug.Log("Complete 2");
        }
        if (Vector3.Distance(rb.position, point3.transform.position) < 0.1f)
        { 
            //Z khac doi tuong ko hoat dong
            Debug.Log("Complete 3");  
        }
    }

}
