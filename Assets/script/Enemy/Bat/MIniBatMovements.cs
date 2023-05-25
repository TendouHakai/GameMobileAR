using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIniBatMovements : EnemyMovements
{
    public override void NormalMovement()
    {
        Vector3 vector3 = -transform.position + attackTarget.position;
        float deltaX = vector3.x;
        float deltaY = vector3.y;
        float deltaZ = vector3.z;

        float max = Mathf.Max(Mathf.Abs(deltaX), Mathf.Abs(deltaY), Mathf.Abs(deltaZ));
        velocity = new Vector3(deltaX / max, deltaY / max, deltaZ / max).normalized * movementSpeed;
    }

    public override void CombatMovement()
    {
        NormalMovement();
    }

    public void setAttackTarget(Transform AttackPosition)
    {
        attackTarget = AttackPosition;
    }
}
