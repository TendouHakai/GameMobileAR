using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Player")
        {
            collisionInfo.collider.GetComponent<PlayerHealth>().TakeDamge();
            Destroy(this.gameObject);
        }
        else if (collisionInfo.collider.tag == "Bullet")
        {
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
