using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttacks01 : AttackSkill
{
    [SerializeField] private GameObject AttackProjectile;
    [SerializeField] private Transform shootPoint;

    public override void ExcuteAttack(Transform targetPosi)
    {
        GameObject projectile = Instantiate(AttackProjectile, shootPoint.position, Quaternion.identity);
        projectile.GetComponent<BatbulletMovement>().setAttackTarget(targetPosi.position);
        Destroy(projectile, 7);
    }
}
