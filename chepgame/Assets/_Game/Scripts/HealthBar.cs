using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image imageFill;
    [SerializeField] Vector3 offset;

    float hp;
    float maxHP;

    private Transform target;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Health Bar .....");
        //tut mau trong khoang thoi gian * speed
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp/maxHP , Time.deltaTime * 5f);
        transform.position = target.position + offset;
    }
    public void OnInit(float maxHp,Transform target)
    {
        this.target = target;
        this.maxHP = maxHp;
        hp = maxHP;
        imageFill.fillAmount = 1;
    }
    public void SetNewHp(float hp) 
    {
        this.hp = hp;
        //imageFill.fillAmount = hp / maxHP;
    }
}
