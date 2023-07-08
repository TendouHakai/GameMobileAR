using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyMovements : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Collider GetCollider;
    [SerializeField] protected Animator ani;
    [SerializeField] public float movementSpeed;    
    [SerializeField] protected bool canMove;
    [SerializeField] protected bool noFlipping;
    [SerializeField] protected float yRange;

    public Transform attackTarget;
    public bool isAttack;
    protected Vector3 velocity;
    protected float timeStart;

    public float TimeToAttack;
    private float timeToAttackStart;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(Random.Range(-2f, 2f), 4f, Random.Range(-2f, 2f)).normalized * movementSpeed;
        isAttack = false;
        timeToAttackStart = 0f;
    }

    // Update is called once per frame
    void Update()
    {   
        if(timeToAttackStart > TimeToAttack && !isAttack)
        {
            changeToAttack();   
        }
        else
        {
            timeToAttackStart += Time.deltaTime;
        }

        if (canMove)
        {
            if (!isAttack)
            {
                if (Vector3.Distance(transform.position, attackTarget.position) > 12)
                {
                    MoveInside();
                }
                else {
                    NormalMovement();
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, attackTarget.position) > 12)
                {
                    MoveInside();
                }
                else
                {
                    CombatMovement();
                }
            }
            if (transform.position.y - attackTarget.position.y >= yRange)
                velocity.y = -Mathf.Abs(velocity.y);
            else if (transform.position.y - attackTarget.position.y <= -yRange)
                velocity.y = Mathf.Abs(velocity.y);
            PerformMovement();
        }
        
    }

    public abstract void NormalMovement();
    public abstract void CombatMovement();
    public virtual void MoveInside()
    {
        Vector3 vector3 = -transform.position + attackTarget.position;
        float deltaX = vector3.x;
        float deltaY = vector3.y;
        float deltaZ = vector3.z;

        float max = Mathf.Max(Mathf.Abs(deltaX), Mathf.Abs(deltaY), Mathf.Abs(deltaZ));
        velocity = new Vector3(deltaX / max, deltaY / max, deltaZ / max).normalized * movementSpeed;
    }

    public virtual void PerformMovement()
    {
        transform.LookAt(rb.position + velocity * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
       
    }

    public void StopMovementBehavior(float time)
    {
        canMove = false;
        StartCoroutine(StopCount(time));
    }

    private IEnumerator StopCount(float time)
    {
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    void changeToAttack()
    {
        isAttack = true;
        transform.Find("radarObject").GetChild(0).gameObject.SetActive(false);
        transform.Find("radarObject").GetChild(1).gameObject.SetActive(true);
    }
}
