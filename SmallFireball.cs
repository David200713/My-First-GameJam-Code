using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFireball : MonoBehaviour
{
    public float bulletSpeed = 20f;

    public Rigidbody2D rb;
    public GameObject boss;

    BossHealth bossHealthScript;
    SfxPlayer audioManager;
    //Boss_Run bossRun;
    Shake shake;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        bossHealthScript = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SfxPlayer>();
        //bossRun = GameObject.FindGameObjectWithTag("Boss").GetComponentInChildren<Boss_Run>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boss"))
        {
            //bossRun.bossSpeed = 1f;
            shake.CamShake2();
            bossHealthScript.TakeDamage(20);
            anim.SetTrigger("SMExplode");
            audioManager.PlaySFX(audioManager.hit);
        }

        if (collision.gameObject.CompareTag("Border"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Deactivate()
    {
        Destroy(this.gameObject);
    }
}
