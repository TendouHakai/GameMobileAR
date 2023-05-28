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

    float TimeRate = 0.15f;
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
        Debug.Log("Shooting");
        if (isShoot && SpawnManager.instance.isInFight)
        {
            if (left)
            {
                GUN_LEFT.GetComponentInChildren<Animator>().SetTrigger("Shoot");
                GUN_LEFT.GetComponent<RaycastShoot>().Shoot();
                AudioManager.instance.PlaySFX("Shoot");
                StartCoroutine(ShootReLoad());
                left = false;
            }
            else
            {
                GUN_RIGHT.GetComponentInChildren<Animator>().SetTrigger("Shoot");
                GUN_RIGHT.GetComponent<RaycastShoot>().Shoot();
                AudioManager.instance.PlaySFX("Shoot");
                StartCoroutine(ShootReLoad());
                left = true;
            }
        }
    }

    private IEnumerator ShootReLoad()
    {
        isShoot = false;
        yield return TimeRate;
        isShoot = true;
    }
}
