using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public CharacterData characterData;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Id:"+characterData.id+" Dame:"+characterData.stats.damage + " Defense:" + characterData.stats.defense);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
