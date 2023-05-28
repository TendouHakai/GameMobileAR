using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Player")
        {
            Debug.Log("Collision between Enemy and Player");
            SpawnManager.instance.enemys.Remove(gameObject);
            Destroy(gameObject);
            collisionInfo.collider.GetComponent<PlayerHealth>().TakeDamge();
        }

        if(collisionInfo.collider.tag == "Bullet")
        {
            Debug.Log("Collision between Enemy and Player Bullet");
            Destroy(collisionInfo.collider.gameObject);
            gameObject.GetComponent<Health>().TakeDamge();
        }
    }  
    
    public void OnCollisionStay(Collision collisionInfo)
    {

    }

    public void OnCollisionExit(Collision collisionInfo)
    {

    }
}
