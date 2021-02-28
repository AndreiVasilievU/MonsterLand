using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_3 : MonoBehaviour
{
    private List<Vector2> PathToTarget = new List<Vector2>();
    private PathFinder PathFinder;

    private bool isMoving;
    public GameObject Target;
    public float moveSpeed;
    [SerializeField]
    Rigidbody2D rb;

    public Image bar;
    public float fill;

    Animator anim;

    public Canvas can;

    public SpriteRenderer sr;
    public float hit_point = 2;
    public float hit_point_cur = 2;
    public int coast = 1;

    public GameObject Death;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Target = GameObject.FindGameObjectWithTag("Player");
        if (Target != null)
        {
            PathFinder = GetComponent<PathFinder>();
            PathToTarget = PathFinder.GetPath(Target.transform.position);
            isMoving = true;

            can = GetComponentInChildren<Canvas>();
            can.gameObject.SetActive(false);
            bar.fillAmount = fill;
        }
    }

    void Update()
    {
        Move();

        can.transform.position = transform.position + new Vector3(0, 1, 0);
        can.transform.eulerAngles = new Vector3(0, 0, 0);

        rb.transform.eulerAngles = new Vector3
            (0, 0, 90 + Mathf.Atan2((Target.transform.position.y - transform.position.y), (Target.transform.position.x - transform.position.x)) * Mathf.Rad2Deg);
    }
    public void ChangeColor()
    {
        sr.color = new Color32(204, 38, 36, 250);
        Invoke("ResetColor", 0.2f);
    }

    public void ResetColor()
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
        if (hit_point <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(Death, transform.position, transform.rotation);
        Destroy(gameObject, 0.1f);
        ScoreCounter.enemies += coast;
    }

    private void Move()
    {
        if (Target == null)
        {
            return;
        }
        if (PathToTarget.Count == 0 && Vector2.Distance(rb.transform.position, Target.transform.position) > 0.001f)
        {
            PathToTarget = PathFinder.GetPath(Target.transform.position);
            isMoving = true;
            anim.SetBool("is_Move", true);
        }
        if (PathToTarget.Count == 0)
        {
            return;
        }

        if (isMoving)
        {
            if (Vector2.Distance(rb.transform.position, PathToTarget[PathToTarget.Count - 1]) > 0.0005f)
            {
                rb.transform.position = Vector2.MoveTowards(rb.transform.position, PathToTarget[PathToTarget.Count - 1], moveSpeed * Time.deltaTime);
            }
            if (Vector2.Distance(rb.transform.position, PathToTarget[PathToTarget.Count - 1]) <= 0.0005f)
            {
                isMoving = false;
                anim.SetBool("is_Move", false);
            }
        }
        else
        {
            PathToTarget = PathFinder.GetPath(Target.transform.position);
            isMoving = true;
            anim.SetBool("is_Move", true);
        }
    }
}
