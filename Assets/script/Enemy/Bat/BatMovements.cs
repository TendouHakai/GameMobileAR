using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovements : EnemyMovements
{
    public override void NormalMovement()
    {
        if (timeStart > 3.0f)
        {
            velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * movementSpeed;
            timeStart = 0f;
        }
        else timeStart += Time.deltaTime;
    }

    public override void CombatMovement()
    {
        NormalMovement();
    }

    public override void PerformMovement()
    {
        transform.LookAt(attackTarget.position);
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
