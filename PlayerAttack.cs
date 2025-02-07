using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float fireballSpeed;
    public GameObject fireballPrefab;
    public Transform spawnPoint;
    public Transform bossObject;
    public float bulletSpeed = 20f;

    public Transform firePoint;
    public GameObject smallFireballPrefab;

    PlayerMovement playerMovement;
    BossHealth bossHealthScript;

    private float cooldownTimer = Mathf.Infinity;
    private float smallAttackCooldownTimer = Mathf.Infinity;

    [SerializeField] private float attackCooldown;
    [SerializeField] private float smallFireballAttackCooldown;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        bossHealthScript = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && cooldownTimer > attackCooldown && (playerMovement.canAttack() || playerMovement.canAttack2()))
        {
            CastSpell();
        }

        if(Input.GetButtonDown("Fire2") && smallAttackCooldownTimer > smallFireballAttackCooldown && (playerMovement.canAttack() || playerMovement.canAttack2()))
        {
            Shoot();
        }

        cooldownTimer += Time.deltaTime;
        smallAttackCooldownTimer += Time.deltaTime;
    }

    public void CastSpell()
    {
        GameObject fireBall = Instantiate(fireballPrefab, spawnPoint.transform.position, Quaternion.Euler(0, 0, 270));
        Rigidbody2D rb = fireBall.GetComponent<Rigidbody2D>();

        Vector2 bossDir = bossObject.position - spawnPoint.position;
        rb.AddForce(bossDir * fireballSpeed, ForceMode2D.Impulse);

        anim.SetTrigger("Attack");

        cooldownTimer = 0;
    }

    void Shoot()
    {
        GameObject smallFireball = Instantiate(smallFireballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = smallFireball.GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * bulletSpeed;

        smallAttackCooldownTimer = 0;
    }
}
