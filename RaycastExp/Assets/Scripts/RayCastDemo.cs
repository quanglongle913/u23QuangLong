using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDemo : MonoBehaviour
{

    [SerializeField]private GameObject ball;

    
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit[] hits;
        if (ball == null)
        {
            return;
        }
        else {
            hits = Physics.RaycastAll(ball.transform.position, ball.transform.right, 100.0F);

       
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                Renderer rend = hit.transform.GetComponent<Renderer>();

                if (rend)
                {
                    Debug.Log("Did Hit" + hit.collider.name);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Ground")))
            {
                //khoảng cách từ gốc tòa độ đến điểm va chạm
                float distance = hit.distance; 
                //Tính tọa độ điểm va chạm: Gốc + Khoảng cách * Hướng của tia
                Vector3 ObjPosition = ray.origin + distance * ray.direction;
                ball.transform.position = new Vector3(ObjPosition.x, ObjPosition.y, ObjPosition.z);
            }
        }
       
    }
}
