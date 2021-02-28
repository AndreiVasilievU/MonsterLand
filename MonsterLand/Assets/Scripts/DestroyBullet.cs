using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 0.3f);
    }
}
