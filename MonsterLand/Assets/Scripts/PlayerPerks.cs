using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPerks : MonoBehaviour
{
    public Transform pos;

    private void Update()
    {
        gameObject.transform.position = pos.transform.position - new Vector3(0.85f,-0.5f,0);
    }
}
