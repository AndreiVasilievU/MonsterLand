using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gun : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float speed = 20;
    public static float reserch = 1.5f;
    Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("Shot", 0f);
    }
    public void Shot() 
    {
        anim.Play("Idle");
        
            Rigidbody2D instantiatedProjectile = Instantiate(projectile,
                                                           transform.position,
                                                           transform.rotation)
                as Rigidbody2D;

            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, speed, 0));
        anim.Play("Gun_shot");
        
        Invoke("Shot", reserch);
    }
}

    

    
