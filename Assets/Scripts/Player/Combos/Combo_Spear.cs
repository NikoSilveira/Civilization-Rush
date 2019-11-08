using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo_Spear : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerPhone player;
    private float attackSpecialCd = 10.02f;
    private float attackSpecialDuration;
    private bool spearAttacking = false;
    public Collider2D spearAttackTrigger;
    private Animator anim;
    private PlayerAttack playerAttackSpear;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhone>();
        playerAttackSpear = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        anim = gameObject.GetComponent<Animator>();
        spearAttackTrigger.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        SpecialAttackSpear();
    }

    public void SpecialAttackSpear()
    {
        if(player.myResistance == 5 && Input.GetKeyDown("o") && playerAttackSpear.weaponSelected == 2)
        {
            Debug.Log("pene");
            spearAttacking = true;
            attackSpecialDuration = attackSpecialCd;
            spearAttackTrigger.enabled = true;
            player.speedX += player.speedX + 4.2f;
            if (spearAttackTrigger.IsTouchingLayers(LayerMask.GetMask("Enemy")))
            {
                spearAttackTrigger.enabled = false;
                spearAttackTrigger.enabled = true;
            }
        }
        if (spearAttacking)
        {
            if(attackSpecialDuration > 0)
            {
                attackSpecialDuration -= Time.deltaTime;
            }
            else{
                player.myResistance = 0;
                spearAttackTrigger.enabled = false;
                spearAttacking = false;
                player.speedX -= player.speedX - 4.2F;
            }
        }
       // anim.SetBool("walking_left", spearAttacking);
    }
}
