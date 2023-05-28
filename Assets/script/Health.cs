using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] SlashDamage effectgetDamage;
    [SerializeField] GameObject effectgetDead;
    public Slider healthBar;
    public int deadScore;

    // Start is called before the first frame update
    void Start()
    {
        if(healthBar != null)
        {
            healthBar.maxValue = health;
            healthBar.value = health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealth(int health)
    {
        this.health = health;
        if (healthBar != null)
        {
            healthBar.value = health;
        }
    }

    public void TakeDamge()
    {
        Debug.Log("take Damge");
        this.health--;
        if (healthBar != null)
        {
            healthBar.value = health;
        }
        
        if (effectgetDamage != null)
        {
            //effectgetDamage.SlashStart();   
            StartCoroutine(effectgetDamage.Slash());
        }

        if (health <= 0)
        {
            GameObject effect = Instantiate(effectgetDead, transform.position, Quaternion.identity);
            Destroy(effect ,1);
            SpawnManager.instance.enemys.Remove(gameObject);
            if (deadScore != 0)
            {
                HubManager.instance.score += deadScore;
                Debug.Log(HubManager.instance.score);
            }
            AudioManager.instance.PlaySFX("Enemy dead");
            Destroy(gameObject);
        }
    }

    public void SetHealthBar(Slider healthBar)
    {
        this.healthBar = healthBar;
        healthBar.maxValue = health;
        healthBar.value = health;
    }
}
