using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static float speed = 250f;
    private Rigidbody2D _rb;
    public Joystick joystick;
    public Joystick joystick2;
    float zAxis;
    Animator player;

    public SpriteRenderer sr;
    [SerializeField]
    public Image bar;

    [SerializeField]
    public float fill;

    [SerializeField]
    Canvas can;

    [SerializeField]
    float hit_point = 2;
    [SerializeField]
    float hit_point_cur = 2;

    UnityEvent _Rotate;

    float move_horizontal;
    float move_vertical;

    [SerializeField]
    static Sprite newSprite;

    void Start()
    {
        player = GetComponent<Animator>();
        can = GetComponentInChildren<Canvas>();
        can.gameObject.SetActive(false);
        bar.fillAmount = fill;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       Move();
       if(_Rotate != null)
       {
            Rotate();
       }

        can.transform.position = transform.position + new Vector3(0, 1, 0);
        can.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    public void ChangeSprite()
    {
        sr.sprite = newSprite;
    }
    public void TakeDamage(float damage)
    {
        hit_point -= damage;
        if (hit_point < hit_point_cur)
        {
            can.gameObject.SetActive(true);
        }
        bar.fillAmount -= (damage / hit_point_cur);
        if (hit_point <= 0)
        {
            Die();
        }
    }
    public void ChangeColor()
    {
        sr.color = new Color32(204, 38, 36, 250);
        Invoke("ResetColor", 0.2f);
    }
    public virtual void ResetColor()
    {
        sr.color = new Color32(217, 197, 197, 228);
    }

    void Die()
    {
        player.Play("PlayerDeath");
        speed = 0;
    }
    void Move()
    {
        if(joystick.Horizontal > 0.1f)
        {
            move_horizontal = 1;
        }
        if(joystick.Vertical > 0.1f)
        {
            move_vertical = 1;
        }
        if (joystick.Vertical == 0f)
        {
            move_vertical = 0;
        }
        if (joystick.Horizontal < -0.1f)
        {
            move_horizontal = -1;
        }
        if (joystick.Vertical < -0.1f)
        {
            move_vertical = -1;
        }
        if(joystick.Horizontal == 0f)
        {
            move_horizontal = 0;
        }
        if (joystick.Vertical == 0f)
        {
            move_vertical = 0;
        }
        Vector3 movement = new Vector3(move_horizontal, move_vertical, transform.position.z );
        Vector3 run = movement * speed * Time.deltaTime;
        _rb.AddForce(run );

        if(run != Vector3.zero)
        {
            player.SetBool("is_Run", true);
        }
        else
        {
            player.SetBool("is_Run", false);
        }
    }

    public void Rotate()
    {
        float hAxis = joystick2.Horizontal;
        float vAxis = joystick2.Vertical;
        zAxis = Mathf.Atan2(hAxis , -vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, zAxis);
    }
}
