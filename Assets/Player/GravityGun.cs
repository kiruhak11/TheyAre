using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float maxGrabDist = 10f, thorwForce = 20f, lerpSpeed = 10f;
    [SerializeField] Transform objectHolder;
    Rigidbody grabbedRB;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
            if(grabbedRB){
                grabbedRB.MovePosition(Vector3.Lerp(grabbedRB.position, objectHolder.transform.position, Time.deltaTime * lerpSpeed));
                if(Input.GetMouseButtonDown(0)){
                    grabbedRB.isKinematic = false;
                    grabbedRB.AddForce(cam.transform.forward * thorwForce, ForceMode.VelocityChange);
                    grabbedRB = null;
                }
            }

            if(Input.GetKeyDown(KeyCode.E)){
                if(grabbedRB){
                    if(grabbedRB.tag != "obj") {
                        grabbedRB.isKinematic = false;
                        grabbedRB = null;
                    }
                }else{
                    RaycastHit hit;
                    Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                    if(Physics.Raycast(ray, out hit, maxGrabDist)){
                        grabbedRB = hit.collider.gameObject.GetComponent<Rigidbody>();
                        if(grabbedRB){
                            grabbedRB.isKinematic = true;
                        }
                    }
                }
            }
    }
}
