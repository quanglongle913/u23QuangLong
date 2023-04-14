using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
  
    [SerializeField] private Animator anim;

    private float hp;
    private string currentAnimName;
   
    public bool IsDeath => hp <= 0;

    private void Start()
    {
        OnInit();
       
    }
    public virtual void OnInit() {

        hp = 100;
    
    }


    //ham huy
    public virtual void OnDespawn()
    { 
    
    }

    protected virtual void OnDeath() {

        ChangeAnim("die");
        Invoke(nameof(OnDespawn),2f);
     }
    protected void ChangeAnim(string animName)
    {
        
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }

    public void OnHit(float damage) {

        if (!IsDeath) {
            hp -= damage;
            if (IsDeath) 
            {
                OnDeath();
            }
        
        }

    }
}