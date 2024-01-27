using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickup;
    public GameObject PickedObject;
    public Transform interactionZone;


    // Update is called once per frame
    void Update()
    {
        if(ObjectToPickup !=null && ObjectToPickup.GetComponent<Pickableobject>().isPickable == true && PickedObject==null)
        {
            if(Input.GetKeyDown(KeyCode.F)){
                PickedObject=ObjectToPickup;
                PickedObject.GetComponent<Pickableobject>().isPickable=false;
                PickedObject.transform.SetParent(interactionZone);
                PickedObject.transform.position=interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity=false;
                PickedObject.GetComponent<Rigidbody>().isKinematic=true;

            }
        }else if(PickedObject!=null){
            if(Input.GetKeyDown(KeyCode.F)){
                 PickedObject.GetComponent<Pickableobject>().isPickable=true;
                PickedObject.transform.SetParent(null);
                PickedObject.GetComponent<Rigidbody>().useGravity=true;
                PickedObject.GetComponent<Rigidbody>().isKinematic=false;
                PickedObject=null;
            }
        }
        
    }
}
