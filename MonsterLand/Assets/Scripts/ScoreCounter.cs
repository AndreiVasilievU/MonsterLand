using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    Text text;
    public static int enemies;
    private void Start()
    {
        text = GetComponent<Text>();
    }
    private void Update()
    {
        text.text = "Score: " + enemies.ToString();
    }

}
