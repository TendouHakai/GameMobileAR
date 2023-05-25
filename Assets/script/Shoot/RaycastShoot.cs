using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public int gunDamage = 1;                                                                                
    public float weaponRange = 20f;                                       
    public float hitForce = 100f;                                       
    public Transform shootPoint;
    public GameObject GunBullet; 

    private Camera fpsCam;
    // Start is called before the first frame update
    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
    }

    public void Shoot()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
        {
            GameObject bullet = GameObject.Instantiate(GunBullet, shootPoint.position, Quaternion.identity);
            //GameObject bullet = GameObject.Instantiate(GunBullet, hit.point, Quaternion.identity);

            bullet.GetComponent<BatbulletMovement>().setAttackTarget(hit.point);
        }
        else
        {
            // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
            GameObject bullet = GameObject.Instantiate(GunBullet, shootPoint.position, Quaternion.identity);
            //GameObject bullet = GameObject.Instantiate(GunBullet, fpsCam.transform.forward * weaponRange, Quaternion.identity);

            bullet.GetComponent<BatbulletMovement>().setAttackTarget(rayOrigin + (fpsCam.transform.forward * weaponRange));
        }
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}
