using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDemo : MonoBehaviour
{

    [SerializeField]private GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        RaycastHit[] hits;
        if (gameObject == null)
        {
            return;
        }
        else {
            hits = Physics.RaycastAll(gameObject.transform.position, gameObject.transform.right, 100.0F);

       
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                Renderer rend = hit.transform.GetComponent<Renderer>();

                if (rend)
                {
                    // Change the material of all hit colliders
                    // to use a transparent shader.
                    rend.material.shader = Shader.Find("Transparent/Diffuse");
                    Color tempColor = rend.material.color;
                    tempColor.a = 0.3F;
                    rend.material.color = tempColor;
                    Debug.Log("Did Hit" + hit.collider.name);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
