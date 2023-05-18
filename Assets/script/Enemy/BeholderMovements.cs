using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderMovements : EnemyMovements
{
    bool firstCombat = true;
    public override void NormalMovement()
    {
        if(!firstCombat)
            firstCombat = true;
        if (timeStart > 3.0f)
        {
            velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * movementSpeed;
            timeStart = 0f;
        }
        else timeStart += Time.deltaTime;
    }
    public override void CombatMovement()
    {
        if(firstCombat)
        {
            Vector3 vector3 = -transform.position + attackTarget.position;
            float deltaX = vector3.x;
            float deltaY = vector3.y;
            float deltaZ = vector3.z;

            float max = Mathf.Max(Mathf.Abs(deltaX), Mathf.Abs(deltaY), Mathf.Abs(deltaZ));
            velocity = new Vector3(deltaX / max, deltaY / max, deltaZ / max).normalized * movementSpeed;
            firstCombat = false;
        }
    }
}
