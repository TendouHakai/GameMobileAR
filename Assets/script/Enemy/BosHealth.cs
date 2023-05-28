using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BosHealth : Health
{
    public Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        if (healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }
    }

    // Update is called once per frame
    public override void setHealth(int health)
    {
        this.health = health;
        if (healthBar != null)
        {
            healthBar.value = health;
        }
    }

    public override void TakeDamge()
    {
        this.health--;
        if (healthBar != null)
        {
            this.healthBar.value = health;
        }

        if (effectgetDamage != null)
        {
            //effectgetDamage.SlashStart();   
            StartCoroutine(effectgetDamage.Slash());
        }

        if (health <= 0)
        {
            GameObject effect = Instantiate(effectgetDead, transform.position, Quaternion.identity);
            Destroy(effect, 1);
            if (deadScore != 0)
            {
                HubManager.instance.score += deadScore;
            }
            AudioManager.instance.PlaySFX("Enemy dead");
            SpawnManager.instance.enemys.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    public void SetHealthBar(Slider healthBar)
    {
        this.healthBar = healthBar;
        this.healthBar.maxValue = health;
        this.healthBar.value = health;
    }
}
