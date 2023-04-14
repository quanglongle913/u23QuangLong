
using UnityEngine;

public class Bai11 : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
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
                if (hitInfo.collider.tag=="Player")
                {
                    rb.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
           
        }
    }
  
}
