using System.Net.Mime;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Throwing : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    [Header("Settings")]

    public int totalThrows;
    public int totalThrowsMax = 300;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public KeyCode keyGun;
    public KeyCode keyMiniGun;
    public float throwForce;
    public float throwUpwardForce;

    [Header("Texter")]
    public Text textAmmo;
    public Text textGun;

    bool readyToThrow;

    public GameObject TargetObj;
    private HudController _actionTarget;
    public MovementState state;

    public enum MovementState
    {
        Gun,
        miniGun
    }

    private void Start()
    {
        readyToThrow = true;
        _actionTarget = TargetObj.GetComponent<HudController>();
    }

    private void Update()
    {
        limited();
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0 && !Pause.isPaused && !UpdatingPlayer.UpdatePause && state == MovementState.Gun && GrabSys.grabs)
        {
            Throw();
        }
        if(Input.GetKey(throwKey) && readyToThrow && totalThrows > 0 && !Pause.isPaused && !UpdatingPlayer.UpdatePause && state == MovementState.miniGun && GrabSys.grabs)
        {
            Throw();
        }
        if(Input.GetKey(keyGun))
            state = MovementState.Gun;

        if(Input.GetKey(keyMiniGun))
            state = MovementState.miniGun;

        textGun.text = state + " ";
        if(Input.GetKeyDown(throwKey) && totalThrows <= 0){
            _actionTarget.message(mission: "Недостаточно патронов");
        }

        textAmmo.text = totalThrows + " / " + totalThrowsMax;
        if(state == MovementState.Gun) ProjectileAddon.damage = 35;
        if(state == MovementState.miniGun) ProjectileAddon.damage = 15;
    }

    private void Throw()
    {
        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 5000f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }

    void limited(){
        if(totalThrows > 300){
            totalThrows = 300;
        }
    }
    void test(){
        totalThrows += 10;
    }
}