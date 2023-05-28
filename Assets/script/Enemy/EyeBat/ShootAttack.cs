using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAttack : AttackSkill
{
    [SerializeField] private GameObject AttackProjectile;
    public override void ExcuteAttack(Transform targetPosi)
    {
            Vector3 dir = (-transform.position + targetPosi.position).normalized;
            GameObject projectile = Instantiate(AttackProjectile, transform.position + dir * 3.0f, Quaternion.identity);
            projectile.GetComponent<ProjectileMovement>().SetDirection(dir);
            Destroy(projectile, 5);
    }

}
