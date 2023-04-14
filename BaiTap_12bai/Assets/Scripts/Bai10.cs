
using UnityEngine;

public class Bai10 : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject point1, point2, point3;
    private Vector3 target;

    float timer=2f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.position = point1.transform.position;
        target = point2.transform.position;
    }
    void FixedUpdate()
    {
        // cho 2s moi  thuc hien
        Invoke(nameof(runObj), 2f);
    }
    private void runObj()
    {
        if (Vector3.Distance(rb.position, point1.transform.position) < 0.1f)
        {
            //cho 1-2s moi doi target
            timer -= Time.fixedDeltaTime;
            if (timer < 0)
            {
                Debug.Log("" + timer);
                target = point2.transform.position;
                timer = Random.Range(1f, 2f);
            }
        }
        if (Vector3.Distance(rb.position, point2.transform.position) < 0.1f)
        {
            //cho 1-2s moi doi target
            timer -= Time.fixedDeltaTime;
            if (timer < 0)
            {
                Debug.Log("" + timer);
                target = point1.transform.position;
                timer = Random.Range(1f, 2f);
               
            }
        }
        rb.position = Vector3.Lerp(rb.position, target, 5f * Time.fixedDeltaTime);
    }
   
}
