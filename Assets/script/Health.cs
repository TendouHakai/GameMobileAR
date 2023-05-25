using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] SlashDamage effectgetDamage;
    [SerializeField] GameObject effectgetDead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void TakeDamge()
    {
        Debug.Log("take Damge");
        this.health--;
        if(effectgetDamage != null)
        {
            //effectgetDamage.SlashStart();   
            StartCoroutine(effectgetDamage.Slash());
        }

        if (health <= 0)
        {
            GameObject effect = Instantiate(effectgetDead, transform.position, Quaternion.identity);
            Destroy(effect ,1);
            Destroy(gameObject);
        }
    }
}