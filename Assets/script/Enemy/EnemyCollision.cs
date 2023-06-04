using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            SpawnManager.instance.enemys.Remove(gameObject);
            if (transform.tag == "Enemy")
            {
                Destroy(gameObject);
            }
            collisionInfo.collider.GetComponent<PlayerHealth>().TakeDamge();
        }
        else if (collisionInfo.collider.tag == "Bullet")
        {
            Destroy(collisionInfo.collider.gameObject);
            gameObject.GetComponent<Health>().TakeDamge();
        }
    }

    public void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bullet")
        {
            Destroy(collisionInfo.collider.gameObject);
            gameObject.GetComponent<Health>().TakeDamge();
        }
    }

    public void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Bullet")
        {
            Destroy(collisionInfo.collider.gameObject);
            gameObject.GetComponent<Health>().TakeDamge();
        }
    }
}
