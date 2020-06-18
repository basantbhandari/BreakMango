using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    

    [Header("Target Properties")]
    [SerializeField] GameObject hitEffect;
    [SerializeField] float mangoBranchLinkingForce = 4f;
   

    // to access score variable
    private Bullet bulletObjInTarget = new Bullet();

  

    // when bullets hits the target
    void OnCollisionEnter2D(Collision2D colInfo)
    {
        // making mango to fall by gravity
        if (colInfo.relativeVelocity.magnitude > mangoBranchLinkingForce)
        {
            FallTheFruit();
        }
       
    }

    private void FallTheFruit()
    {
        // instantiate and destroy the effect
        var hiteff = Instantiate(hitEffect, transform.position, Quaternion.identity);
        hiteff.transform.parent = GameObject.Find("EffectsHolder").transform;
        Destroy(hiteff, 2f);
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      
    }



}
