using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]Shake shake;
    public Transform bossObj;
    public float rotationModifier;

    SfxPlayer audioManager;
    BossHealth bossHealthScript;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SfxPlayer>();
        bossHealthScript = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 faceDir = bossObj.position - transform.position;
        float angle = Mathf.Atan2(faceDir.y, faceDir.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Boss"))
        {
            //take damage from boss and destroy the game object
            shake.CamShake2();
            bossHealthScript.TakeDamage(50);
            anim.SetTrigger("Explode");
            transform.position = bossObj.position;
            audioManager.PlaySFX(audioManager.explosion);
        }

        //destroy game object if it hits the border
        if(collision.gameObject.CompareTag("Border"))
        {
            anim.SetTrigger("Explode");
            Destroy(this.gameObject);
        }
    }

    private void Deactivate()
    {
        Destroy(this.gameObject);
    }
}
