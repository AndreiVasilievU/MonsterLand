using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Enemy_3 : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rocket;
    [SerializeField]
    float rocketSpeed;
    [SerializeField]
    float rocketReserch;
    [SerializeField]
    GameObject shot;
    private void Start()
    {
        Invoke("Shot", 0f);
    }
    public void Shot()
    {
        Rigidbody2D instantiatedProjectile = Instantiate(rocket,
                                                       transform.position,
                                                       transform.rotation)
            as Rigidbody2D;

        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, -rocketSpeed, 0));
        Instantiate(shot, gameObject.transform.position + new Vector3(0, 0, -1), gameObject.transform.rotation);

        Invoke("Shot", rocketReserch);
    }
}
