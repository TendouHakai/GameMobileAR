using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Vector3 movDirection;

    [SerializeField] private float moveSpeed;

   public void SetDirection(Vector3 direc)
    {
        movDirection = direc .normalized;
    }
    private void FixedUpdate()
    {
        transform.position += movDirection * Time.fixedDeltaTime * moveSpeed;
    }
}
