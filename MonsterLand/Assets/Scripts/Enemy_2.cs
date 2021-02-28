using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2 : Enemy

{
    [SerializeField]
    float angry_distance;
    [SerializeField]
    float jumpSpeed = 5;
    bool isJump = false;
    bool isRemember = false;
    Vector3 pos;
    Vector3 targetJump;
    Animator anim;
    PlayerController player;

    public override void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        can = GetComponentInChildren<Canvas>();
        can.gameObject.SetActive(false);
        bar.fillAmount = fill;
    }
    public override void Move()
    {
        if (Vector2.Distance(transform.position, target.position) > angry_distance)
        {
            NoJumpMove();
            anim.SetBool("is_jump", false);
        }

        if (Vector2.Distance(transform.position, target.position) < angry_distance && isJump == false)
        {
            Jump();
            anim.SetBool("is_jump", true);
        }

        if (Vector2.Distance(transform.position, target.position) < angry_distance && isJump == true)
        {
            NoJumpMove();
            anim.SetBool("is_jump", false);
        }

        can.transform.position = rb.transform.position + new Vector3(0, 1, 0);
        can.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.ChangeColor();
            player.TakeDamage(enemyDamage);
            Die();
        }
    }
    void Jump()
    {
        StartCoroutine(Jump_cor());
    }
    IEnumerator Jump_cor()
    {
        if (isRemember == false)
        {
            RememberPos();
        }
        yield return new WaitForSeconds(1f);
        rb.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
            new Vector2(targetJump.x, targetJump.y), jumpSpeed * Time.deltaTime);
        rb.transform.eulerAngles = new Vector3
            (0, 0, 270 + Mathf.Atan2((targetJump.y - transform.position.y), (targetJump.x - transform.position.x)) * Mathf.Rad2Deg);
        if (rb.transform.position == targetJump)
        {
            rb.transform.eulerAngles = new Vector3
           (0, 0, 270 + Mathf.Atan2((target.position.y - transform.position.y), (target.position.x - transform.position.x)) * Mathf.Rad2Deg);
            isRemember = false;
            isJump = true;
        }
    }
    void NoJumpMove()
    {
        float dist = Vector3.Distance(target.transform.position, this.transform.position);
        Vector3 dir = target.transform.position - transform.position;
        hit = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(dir.x, dir.y), dist);
        Debug.DrawRay(transform.position, dir, Color.red);
        rb.transform.eulerAngles = new Vector3
            (0, 0, 270 + Mathf.Atan2((target.position.y - transform.position.y), (target.position.x - transform.position.x)) * Mathf.Rad2Deg);
        rb.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y),
            new Vector2(target.position.x, target.position.y), speed * Time.deltaTime);
    }
    void RememberPos()
    {
        pos = target.position;
        targetJump = pos;
        target.position = targetJump;
        isRemember = true;
    }
}
