using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangureSphere : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject sphere;
    public GameObject throwObj;
    public Transform attackPoint;
    public Transform Target;
    bool attack;
    public float totalDamage = 10f;
    public float throwUpwardForce;
    public float throwForce = 30f;
    public float Speed = 5f;
    [Tooltip("Как близко приближаться к Target")]
    public float RelaxDistance;
    public GameObject PlayerObj;
    public float timeThrow;
    private HealthManager healthManager;

    void Update()
    {
        Throw();
        if(rb.isKinematic){
            Speed = 0f;     
        } else {
            Speed = 5f;
        }
        var dir = Target.position - transform.position;
        if (dir.sqrMagnitude > RelaxDistance*RelaxDistance)
        {
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

            transform.LookAt(Target);
            attack = true;
        } else attack = false;
    }
    private void Start() {
        healthManager = PlayerObj.GetComponent<HealthManager>();
        attack = false;
        timeThrow = 1f;
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.rigidbody && collision.rigidbody.tag == "Player") {
            healthManager.HealthPlayer -= Mathf.Round(Random.Range(10.0f, 20.0f));
            Destroy(sphere);
        }
        if (collision.rigidbody && collision.rigidbody.tag == "bullet") {
            healthManager.HealthPlayer += Mathf.Round(Random.Range(1.0f, 5.0f));
            if(healthManager.HealthPlayer >=100){
                healthManager.HealthPlayer = 100;
            }
            Destroy(sphere);
        }

    }

    private void Throw(){
        if(attack){
            timeThrow -= 1 * Time.deltaTime;
            if(timeThrow <= 0){
                Instantiate(throwObj, attackPoint.transform.position, attackPoint.transform.rotation);
                timeThrow = 1f;
            }
        }
    }
}
