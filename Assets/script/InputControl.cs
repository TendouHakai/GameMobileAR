using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputControl : MonoBehaviour
{
    private TouchControls touchControls;
    public InputAction Shoot;

    public GameObject GUN_LEFT;
    public GameObject GUN_RIGHT;

    public float TimeRate;
    bool left ;
    bool isShoot;

    private void Awake()
    {
        if (touchControls == null)
        {
            touchControls = new TouchControls();
        }

        Shoot = touchControls.Touch.Shoot;

        left = true;
        isShoot = true;
    }

    private void OnEnable()
    {
        if (touchControls != null)
        {
            Shoot.Enable();
            touchControls.Enable();
        }
    }

    private void OnDisable()
    {
        if (touchControls != null)
        {
            Shoot.Disable();
            touchControls.Disable();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Shoot.performed += ShootAction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShootAction(InputAction.CallbackContext context)
    {
        if(ARcursor.instance.isUseCursor)
        {
            ARcursor.instance.placeThePortal();
        }
        
        if (isShoot && SpawnManager.instance.isInFight)
        {
            Debug.Log("Shoot");
            if (left)
            {
                GUN_LEFT.GetComponent<GunRecoil>().recoil();
                GUN_LEFT.GetComponent<RaycastShoot>().Shoot();
                AudioManager.instance.PlaySFX("Shoot");
                StartCoroutine(ShootReLoad(true));
                left = false;
            }
            else
            {
                GUN_RIGHT.GetComponent<GunRecoil>().recoil();
                GUN_RIGHT.GetComponent<RaycastShoot>().Shoot();
                AudioManager.instance.PlaySFX("Shoot");
                StartCoroutine(ShootReLoad(false));
                left = true;
            }
        }
    }

    private IEnumerator ShootReLoad(bool isLeft)
    {
        isShoot = false;
        yield return TimeRate;
        isShoot = true;
    }
}
