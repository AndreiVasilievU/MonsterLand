using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer sr;
    public float hit_point = 2;
    public float hit_point_cur = 2;
    public int coast = 1;
    public float speed;
    public Transform target;
    public RaycastHit2D hit;
    public Rigidbody2D rb;
    public GameObject Death;
    public float enemyDamage = 1;

    PlayerController player;

    public Image bar;
    public float fill;

    public Canvas can;
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        can = GetComponentInChildren<Canvas>();
        can.gameObject.SetActive(false);
        bar.fillAmount = fill;
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            player.ChangeColor();
            player.TakeDamage(enemyDamage);
        }
    }

    void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        float dist = Vector3.Distance(target.transform.position, this.transform.position);
        Vector3 dir = target.transform.position - transform.position;
        hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dir.x, dir.y), dist);
        Debug.DrawRay(transform.position, dir, Color.red);
        rb.transform.eulerAngles = new Vector3
            (0, 0, 90 + Mathf.Atan2((target.position.y - rb.transform.position.y), (target.position.x - rb.transform.position.x)) * Mathf.Rad2Deg);
        rb.transform.position = Vector2.MoveTowards(new Vector2(rb.transform.position.x, rb.transform.position.y),
            new Vector2(target.position.x, target.position.y), speed * Time.deltaTime);
        can.transform.position = rb.transform.position + new Vector3(0,1,0);
        can.transform.eulerAngles = new Vector3(0,0,0);
    
    }

    public virtual void ChangeColor()
    {
        sr.color = new Color32(204, 38, 36, 250);
        Invoke("ResetColor", 0.2f);
    }

    public virtual void ResetColor()
    {
        sr.color = new Color32(217, 197, 197, 228);
    }

    public void TakeDamage(float damage)
    {
        hit_point -= damage;
        if (hit_point < hit_point_cur)
        {
            can.gameObject.SetActive(true);
        }
        bar.fillAmount -= (damage / hit_point_cur);
        if(hit_point <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Instantiate(Death, transform.position, transform.rotation);
        Destroy(gameObject,0.1f);
        ScoreCounter.enemies += coast;
    }
    
}
