using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletEnemy : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject sphere;
    public Transform Target;
    public float totalDamage = 10f;
    public float throwForce = 30f;
    public float Speed = 5f;
    [Tooltip("Как близко приближаться к Target")]
    public GameObject PlayerObj;
    private HealthManager healthManager;

    void Update()
    {
        if(rb.isKinematic){
            Speed = 0f;     
        } else {
            Speed = 5f;
        }
        var dir = Target.position - transform.position;
        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target.position, step);

        transform.LookAt(Target);
        
    }
    private void Start() {
        healthManager = PlayerObj.GetComponent<HealthManager>();
    }
    void OnCollisionEnter(Collision collision) {
        if (collision.rigidbody && collision.rigidbody.tag == "Player") {
            healthManager.HealthPlayer -= (Mathf.Round(Random.Range(10.0f, 20.0f)));
            Destroy(sphere);
        }
    }
}
