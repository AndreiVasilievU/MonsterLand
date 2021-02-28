using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower : MonoBehaviour
{
    [SerializeField]
    GameObject buttonAgree;
    [SerializeField]
    Transform pointForAgree;
    [SerializeField]
    Transform parent;

    public virtual void OnSelected()
    {
        Instantiate(buttonAgree, pointForAgree.transform.position, pointForAgree.rotation, parent);
    }

    public virtual void Deselected()
    {
        GameObject GO = GameObject.FindGameObjectWithTag("Agree");
        Destroy(GO, 0.1f);
    }

    public virtual void Choice()
    {
        Debug.Log("AttackPower");
        Bullet2D.damage += 1f;
        GameObject GO = GameObject.FindGameObjectWithTag("Agree");
        Destroy(GO);
    }
}
