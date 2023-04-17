using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDemo : MonoBehaviour
{
    string username = "Name";
    // Start is called before the first frame update
    void Start()
    {
        
        PlayerPrefs.SetString(username, "Le");
        PlayerPrefs.Save();
        string value = PlayerPrefs.GetString(username);
        Debug.Log(":"+value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
