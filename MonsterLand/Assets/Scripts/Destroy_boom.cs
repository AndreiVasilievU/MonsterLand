using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_boom : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 3f);
    }
}
