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

    public Transform attackTarget;
    public bool isAttack;
    protected Vector3 velocity;
    protected float timeStart;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 1f).normalized * movementSpeed;
        isAttack = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (canMove)
        {
            if (!isAttack)
            {
                if (Vector3.Distance(transform.position, attackTarget.position) > 17.5)
                {
                    Debug.Log("Move inside");
                    MoveInside();
                }
                else {
                    Debug.Log("Normal Movement");
                    NormalMovement();
                }
            }
            else
            {
                Debug.Log("Combat Movement");
                CombatMovement();
            }
        }
        PerformMovement();
    }

    public abstract void NormalMovement();
    public abstract void CombatMovement();
    void MoveInside()
    {
        Vector3 vector3 = -transform.position + attackTarget.position;
        float deltaX = vector3.x;
        float deltaY = vector3.y;
        float deltaZ = vector3.z;

        float max = Mathf.Max(Mathf.Abs(deltaX), Mathf.Abs(deltaY), Mathf.Abs(deltaZ));
        velocity = new Vector3(deltaX / max, deltaY / max, deltaZ / max).normalized * movementSpeed;
    }

    public void PerformMovement()
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

}
