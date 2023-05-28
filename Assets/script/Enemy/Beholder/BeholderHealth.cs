using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderHealth : Health
{
    [SerializeField] private GameObject childFrefabs;
    public override void TakeDamge()
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
            Destroy(effect, 1);
            if (deadScore != 0)
            {
                HubManager.instance.score += deadScore;
            }
            AudioManager.instance.PlaySFX("Enemy dead");

            // Spawn child enemies
            SpawnManager.instance.addEnemy(childFrefabs, 3, transform.position, 0f, 30f);

            SpawnManager.instance.enemys.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
