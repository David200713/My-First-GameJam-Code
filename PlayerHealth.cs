using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth = 100;
    public int playerCurrentHealth;

    public HealthBar playerHealthBar;

    public Animator anim;
    SfxPlayer audioManager;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerCurrentHealth = playerMaxHealth;
        playerHealthBar.SetMaxHealth(playerMaxHealth);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SfxPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            audioManager.PlaySFX(audioManager.playerDeath);
            anim.SetBool("Death", true);
        }
    }

    public void PlayerTakeDamage(int damage)
    {
        playerCurrentHealth -= damage;
        playerHealthBar.SetHealth(playerCurrentHealth);
        //anim.SetBool("Hurt", true);
    }

    public void DestroyPlayer()
    {
        SceneManager.LoadScene("GAME OVER");
        Destroy(this.gameObject);
    }
}
