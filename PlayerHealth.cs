using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour

{
    public Image healthBar;

    public YoudiedText YoudiedText;

    public AudioSource Sfxhurt;
    public AudioClip hurt, death;

    public float maxHealth = 100f;
    float currentHealth;

    public Animator animator;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / 100f;

        animator.SetTrigger("Hurt");
        Sfxhurt.clip = hurt;
        Sfxhurt.Play();
        if (currentHealth <= 0)
        {
            YoudiedText.Setup();
            Sfxhurt.clip = death;
            Sfxhurt.Play();
            gameObject.SetActive(false);
        }
    }
}
