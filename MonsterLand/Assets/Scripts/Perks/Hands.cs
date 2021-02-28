using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField]
    GameObject buttonAgree;
    [SerializeField]
    Transform pointForAgree;
    [SerializeField]
    Transform parent;

    public Sprite newSprite;

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
        Debug.Log("2Hands");
        
        GameObject GO = GameObject.FindGameObjectWithTag("Agree");
        Destroy(GO);
    }
}
