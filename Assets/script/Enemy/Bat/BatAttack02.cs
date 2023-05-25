using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttack02 : AttackSkill
{
    [SerializeField] private GameObject Child;
    [SerializeField] private Transform shootPoint;

    public override void ExcuteAttack(Transform targetPosi)
    {
        GameObject child1 = Instantiate(Child, shootPoint.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f)), Quaternion.identity);
        child1.GetComponent<MIniBatMovements>().setAttackTarget(targetPosi);

        GameObject child2 = Instantiate(Child, shootPoint.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f)), Quaternion.identity);
        child2.GetComponent<MIniBatMovements>().setAttackTarget(targetPosi);

        GameObject child3 = Instantiate(Child, shootPoint.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f)), Quaternion.identity);
        child3.GetComponent<MIniBatMovements>().setAttackTarget(targetPosi);

        GameObject child4 = Instantiate(Child, shootPoint.position + new Vector3(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f)), Quaternion.identity);
        child4.GetComponent<MIniBatMovements>().setAttackTarget(targetPosi);
    }
}
