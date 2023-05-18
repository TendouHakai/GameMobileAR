using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    private List<AttackSkill> attacks;

    private Animator animator;
    private EnemyMovements movbeh;

    [SerializeField] private Transform attackTarget;
    private AttackSkill currentAttack;

    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if (!animator)
        {
            animator = transform.GetChild(0).GetComponent<Animator>();
        }
        movbeh = GetComponent<EnemyMovements>();
        isAttacking = false;
        GetListAttacks();
    }

    public void GetListAttacks()
    {
        AttackSkill[] listAttacks = gameObject.GetComponentsInChildren<AttackSkill>();
        attacks = new List<AttackSkill>();
        attacks.Clear();
        for (int i = 0; i < listAttacks.Length; i++)
            attacks.Add(listAttacks[i]);
    }

    private AttackSkill AttackToUse()
    {
        List<AttackSkill> availableAttacks = new List<AttackSkill>();

        foreach (AttackSkill items in attacks)
        {
            if (items.CanExcuteAttack(attackTarget.position))
                availableAttacks.Add(items);
        }

        if (availableAttacks.Count > 0)
        {
            int i = UnityEngine.Random.Range(0, availableAttacks.Count);
            return availableAttacks[i];
        }
        else
            return null;
    }

    void Attack()
    {
        AttackSkill attack = AttackToUse();
        if (!attack)
            return;
        currentAttack = attack;
        StartCoroutine(WaitForAttack(currentAttack.attackDuration));

        if (attack.stopMoving)
            movbeh.StopMovementBehavior(currentAttack.attackDuration);

        if (!currentAttack.hasAni)
            currentAttack.ExcuteAttack(attackTarget);

        animator.SetTrigger(currentAttack.aniTrigger);
        StartCoroutine(currentAttack.AttackCD());
        Debug.Log(currentAttack.aniTrigger);
    }

    public void AniTriggerAttack()
    {
        currentAttack.ExcuteAttack(attackTarget);
    }

    private IEnumerator WaitForAttack(float delay)
    {
        isAttacking = true;
        yield return new WaitForSeconds(delay);
        if (currentAttack.isHasEventFinishAttack)
        {
            currentAttack.ExcuteAttack(attackTarget);
        }
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!movbeh.isAttack)
            return;
        if (isAttacking)
            return;

        Attack();
    }
}
