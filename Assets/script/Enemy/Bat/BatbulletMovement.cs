using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatbulletMovement : MonoBehaviour
{
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected Collider GetCollider;
    [SerializeField] public float movementSpeed;
    [SerializeField] public float Range;
    Vector3 PosiBegin;
    public Vector3 attackTarget;
    protected Vector3 velocity;

    void Update()
    {
        if (Vector3.Distance(transform.position, PosiBegin) > Range)
        {
            Destroy(this.gameObject);
        }
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    public void setAttackTarget(Vector3 position)
    {
        attackTarget = position;
        PosiBegin = transform.position;
        Vector3 vector3 = -transform.position + attackTarget;
        float deltaX = vector3.x;
        float deltaY = vector3.y;
        float deltaZ = vector3.z;

        float max = Mathf.Max(Mathf.Abs(deltaX), Mathf.Abs(deltaY), Mathf.Abs(deltaZ));
        velocity = new Vector3(deltaX / max, deltaY / max, deltaZ / max).normalized * movementSpeed;
    }
}
