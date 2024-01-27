using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    public float pushPower=4.0f;
    // Start is called before the first frame update
    private void OnControllerColliderHit(ControllerColliderHit hit){
        Rigidbody body =hit.collider.attachedRigidbody;
        if(body==null || body.isKinematic){
            return;
        }
        if(hit.moveDirection.y < -0.3){
            return;
        }
        Vector3 pushDir=new Vector3(hit.moveDirection.x,0,hit.moveDirection.z);
        body.velocity=pushDir*pushPower;
    }
}
