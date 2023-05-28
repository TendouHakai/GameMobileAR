using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public SlashDamage effectgetDamage;
    public GameObject effectgetDead;
    public int deadScore;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void setHealth(int health)
    {
        this.health = health;
    }

    public virtual void TakeDamge()
    {
        this.health--;
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
            }
            AudioManager.instance.PlaySFX("Enemy dead");
            Destroy(gameObject);
        }
    }
}
