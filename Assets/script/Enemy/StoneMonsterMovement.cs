using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMonsterMovement : EnemyMovements
{
    [SerializeField] private float changeVelocityCount;
    Vector3 temp;
    public override void NormalMovement()
    {
        if (timeStart > changeVelocityCount)
        {
            temp = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * movementSpeed;

            timeStart = 0f;
        }
        else
        {
            timeStart += Time.deltaTime;
            velocity = Vector3.Lerp(velocity, temp, Time.deltaTime);
        }
    }

    public override void CombatMovement()
    {
        NormalMovement();
    }

}