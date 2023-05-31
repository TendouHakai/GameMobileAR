using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BoomAttack : AttackSkill
{
    [SerializeField] private GameObject AttackProjectile;
    [SerializeField] private int numEnemy;
    public override void ExcuteAttack(Transform targetPosi)
    {
        for (int i = 0; i < numEnemy; i++)
        {
            Vector3 dir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            GameObject projectile = Instantiate(AttackProjectile, transform.position + dir * 5.0f, Quaternion.identity);
            projectile.GetComponent<EnemyMovements>().attackTarget = targetPosi;
            projectile.GetComponent<EnemyMovements>().TimeToAttack = Random.Range(0f, 30f);
            Destroy(projectile, 10);
        }
    }

}