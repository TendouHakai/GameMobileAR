using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAttack : AttackSkill
{
    [SerializeField] private float movSpeed;
    int AttackState = 0;
    public override void ExcuteAttack(Transform targetPosi)
    {
        switch (AttackState)
        {
            case 0:
                Debug.Log("State Attack 01");
                Attack01(targetPosi);
                break;
            case 1:
                Debug.Log("State Attack 02");
                Attack02();
                break;
        }
        
    }

    void Attack01(Transform targetPosi)
    {
        Vector3 vector3 = -transform.position + targetPosi.position;
        float deltaX = vector3.x;
        float deltaY = vector3.y;
        float deltaZ = vector3.z;

        float max = Mathf.Max(Mathf.Abs(deltaX), Mathf.Abs(deltaY), Mathf.Abs(deltaZ));
        Vector3 velocity = new Vector3(deltaX / max, deltaY / max, deltaZ / max);
        transform.parent.gameObject.GetComponentInParent<EnemyMovements>().SetVelocity(velocity.normalized * movSpeed);
        AttackState++;
    }

    void Attack02()
    {
        transform.parent.gameObject.GetComponentInParent<EnemyMovements>().isAttack = false;
        Vector3 velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * transform.parent.gameObject.GetComponentInParent<EnemyMovements>().movementSpeed;
        transform.parent.gameObject.GetComponentInParent<EnemyMovements>().SetVelocity(velocity);
        AttackState = 0;
    }
}
