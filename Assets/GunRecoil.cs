using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    Vector3 initGunPosition, currentGunPosition, targetGunPosition;
    [SerializeField] float kickbackZ;

    public float returnAmount, snappiness;
    // Start is called before the first frame update
    void Start()
    {
        initGunPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        back();
    }

    public void recoil()
    {
        targetGunPosition -= new Vector3(0, 0, kickbackZ);
    }

    public void back()
    {
        targetGunPosition = Vector3.Lerp(targetGunPosition, initGunPosition, Time.deltaTime * returnAmount);
        currentGunPosition = Vector3.Lerp(currentGunPosition, targetGunPosition, Time.fixedDeltaTime * snappiness);

        transform.localPosition = currentGunPosition;
    }
}
