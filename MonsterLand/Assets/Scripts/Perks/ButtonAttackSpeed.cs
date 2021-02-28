using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAttackSpeed : MonoBehaviour
{
    [SerializeField]
    GameObject buttonAgree;
    [SerializeField]
    Transform pointForAgree;
    [SerializeField]
    Transform parent;


    private void Start()
    {

    }

    public virtual void OnSelected()
    {
        Instantiate(buttonAgree,pointForAgree.transform.position,pointForAgree.rotation,parent);
    }

    public virtual void Deselected()
    {
        GameObject GO = GameObject.FindGameObjectWithTag("Agree");
        Destroy(GO, 0.1f);
    }

    public virtual void Choice()
    {
        Debug.Log("AttackSpeed");
        Gun.reserch -= 0.3f;
        GameObject GO = GameObject.FindGameObjectWithTag("Agree");
        Destroy(GO);
    }
}
