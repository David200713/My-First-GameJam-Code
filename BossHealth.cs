using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;

    public HealthBar healthBar;

    Animator anim;
    SfxPlayer audioManager;


    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SfxPlayer>();
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            anim.SetBool("Death", true);
            audioManager.PlaySFX(audioManager.bossDeath);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void DestroyBossObject()
    {
        SceneManager.LoadScene("You Win");
        Destroy(this.gameObject);
    }
}
