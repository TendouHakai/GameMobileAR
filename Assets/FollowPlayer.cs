using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform targetObject;
    // Start is called before the first frame update
    private float rotateSpeed = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(targetObject.position.x, transform.position.y, targetObject.position.z);

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetObject.rotation, rotateSpeed);
        Vector3 temp = transform.rotation.eulerAngles;
        temp.y = targetObject.eulerAngles.y;
        transform.rotation = Quaternion.Euler(temp);
    }
}
