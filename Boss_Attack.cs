using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Attack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackArea = 3f;
    public LayerMask playerLayer;

    public Shake shake;

    PlayerHealth playerHealthScript;
    SfxPlayer audioManager;


    void Start()
    {
        playerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SfxPlayer>();
    }

    public void Attack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackArea, playerLayer);

        if(hitPlayer != null)
        {
            audioManager.PlaySFX(audioManager.attack);
            playerHealthScript.PlayerTakeDamage(20);
            shake.CamShake();
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackArea);
    }
}
