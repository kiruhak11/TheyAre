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
    public static int totalThrows;
    public int totalThrowsMax = 300;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    [Header("Texter")]
    public Text textAmmo;
    public Text textGun;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        limited();
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
        textAmmo.text = totalThrows + " / " + totalThrowsMax;
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
}