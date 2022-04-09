using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPSCONTROLLER : MonoBehaviour
{
    public List<Transform> wayPoint;
    public int curWayPoint;

    public Transform sitting;
    Animator anim;
    public float speed;

    NavMeshAgent agent;

    public bool sitdown;

    void Start() {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if(!sitdown){
            Patrol();
        } else Sitdown();
    }

    void Patrol(){
        anim.SetBool("sit", false);
        speed = Mathf.Clamp(speed, 0, 1);
        if(wayPoint.Count > 1){
            if(wayPoint.Count > curWayPoint){
                agent.SetDestination(wayPoint[curWayPoint].position);
                float dist = Vector3.Distance(transform.position, wayPoint[curWayPoint].position);

                if(dist > 2.5f){
                    anim.SetFloat("Speed", speed);
                    speed += Time.deltaTime * 3;
                } else if(dist <= 2.5f && dist >= 1f){
                    Vector3 direction = (wayPoint[curWayPoint].position = transform.position).normalized;
                    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
                } else {
                    curWayPoint++;
                }
            } else if (wayPoint.Count == curWayPoint){
                curWayPoint = 0;
            }
        } else if (wayPoint.Count == 1){
            agent.SetDestination(wayPoint[0].position);
            float dist = Vector3.Distance(transform.position, wayPoint[curWayPoint].position);
            if(dist > 1.5f){
                agent.isStopped = false;
                anim.SetFloat("Speed", speed);
                speed += Time.deltaTime * 3;
            } else {
                agent.isStopped = true;
                anim.SetFloat("Speed", speed);
                speed -= Time.deltaTime * 5;

                Vector3 direction = (wayPoint[0].position = transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
            }
        } else {
            agent.isStopped = true;
            anim.SetFloat("Speed", speed);
            speed -= Time.deltaTime * 5;
        }

    }

    void Sitdown(){
        agent.SetDestination(sitting.position);
        float dist = Vector3.Distance(transform.position, sitting.position);
        if(dist > 1.5f){
            agent.isStopped = false;
           anim.SetFloat("Speed", speed);
            speed += Time.deltaTime * 3;
        } else {
            agent.isStopped = true;
            anim.SetFloat("Speed", speed);
            speed -= Time.deltaTime * 5;

            Vector3 direction = (sitting.position = transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10);
            anim.SetBool("sit", true);
        }
        speed = Mathf.Clamp(speed, 0, 1);
    }
}
