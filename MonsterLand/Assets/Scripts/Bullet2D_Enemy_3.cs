using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2D_Enemy_3 : MonoBehaviour
{
    public float damage = 1;
    public GameObject Bullet_death;
    void Start()
    {
        Destroy(gameObject, 10);
    }

    [System.Obsolete]
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (!coll.isTrigger)
        {
            switch (coll.tag)
            {
                case "Player":
                    PlayerController player = coll.GetComponent<PlayerController>();
                    if (player != null)
                    {
                        player.ChangeColor();
                        player.TakeDamage(damage);
                        Destroy(gameObject);
                        Instantiate(Bullet_death, gameObject.transform.position + new Vector3(0,0,-1), gameObject.transform.rotation);
                    }
                    break;
                case "Enemy_2":

                    break;
            }
        }
    }
}
