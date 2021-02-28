using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Perk : MonoBehaviour
{
    public Button but;
    public Button but1;
    public Button but2;
    GameObject panel;
    GameObject playerPerks;
    GameObject progressBar;
    Animator anim_perks;
    Animator player_perks;
    bool is_active_panel = false;
    public float score = 3;
    int token = 0;
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("Panel");
        playerPerks = GameObject.FindGameObjectWithTag("playerPerks");
        progressBar = GameObject.FindGameObjectWithTag("progressBar");
        anim_perks = panel.GetComponent<Animator>();
        player_perks = playerPerks.GetComponent<Animator>();

    }
    void Update()
    {
        var value = progressBar.GetComponent<Slider>();
        value.value = ScoreCounter.enemies;
        if (ScoreCounter.enemies != 0 && ScoreCounter.enemies % score == 0)
        {
            score += 3;
            token += 1;
            anim_perks.Play("Perks_Left");
            is_active_panel = true;
        }
    }

    public void Is_Clicked()
    {
        if (is_active_panel == true)
        {
            Gun.reserch -= 0.1f;
            token -= 1;
            player_perks.Play("PlayerPerksASpeed");
            player_perks.SetBool("isActive", true);
            if (token == 0)
            {
                is_active_panel = false;
                anim_perks.Play("Perks_Right");
            }
        }
    }
    public void Is_Clicked1()
    {
        if (is_active_panel == true)
        {
            PlayerController.speed += 20;
            token -= 1;
            player_perks.Play("PlayerPerks");
            player_perks.SetBool("isActive", true);
            if (token == 0)
            {
                is_active_panel = false;
                anim_perks.Play("Perks_Right");
            }
        }
    }
    public void Is_Clicked2()
    {
        if (is_active_panel == true)
        {
            Bullet2D.damage += 1;
            token -= 1;
            player_perks.Play("PlayerPerksPower");
            player_perks.SetBool("isActive", true);
            if (token == 0)
            {
                is_active_panel = false;
                anim_perks.Play("Perks_Right");
            }
        }
    }
}

