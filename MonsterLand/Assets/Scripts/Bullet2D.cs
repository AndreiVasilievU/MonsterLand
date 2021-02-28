using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet2D : MonoBehaviour
{
    public static float damage = 1;
    public GameObject Bullet_death;
    void Start()
    {
        Destroy(gameObject, 5);
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.isTrigger)
        {
            switch (coll.tag)
            {
                case "Enemy_1":
                    Enemy enemy = coll.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.ChangeColor();
                        enemy.TakeDamage(damage);
                        Destroy(gameObject);
                        Instantiate(Bullet_death, gameObject.transform.position, gameObject.transform.rotation);
                    }
                    break;
                case "Enemy_3":
                    Enemy_3 enemy_3 = coll.GetComponent<Enemy_3>();
                    if (enemy_3 != null)
                    {
                        enemy_3.ChangeColor();
                        enemy_3.TakeDamage(damage);
                        Destroy(gameObject);
                        Instantiate(Bullet_death, gameObject.transform.position, gameObject.transform.rotation);
                    }
                    break;
            }
            
        }
        
    }

}
