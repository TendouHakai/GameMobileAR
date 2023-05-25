using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeholderMovements : EnemyMovements
{
    [SerializeField] private GameObject ChildObject;
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
            Vector3 vector3 = -transform.position + attackTarget.position;
            float deltaX = vector3.x;
            float deltaY = vector3.y-1.0f;
            float deltaZ = vector3.z;

            float max = Mathf.Max(Mathf.Abs(deltaX), Mathf.Abs(deltaY), Mathf.Abs(deltaZ));
            velocity = new Vector3(deltaX / max, deltaY / max, deltaZ / max).normalized * movementSpeed;
    }
}
