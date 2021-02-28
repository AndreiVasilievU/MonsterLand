using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{
    public Transform player;
    private void LateUpdate()
    {
        Vector3 newPosition = player.position - new Vector3(0,0,10);
        newPosition.z = transform.position.z;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
