using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickableobject : MonoBehaviour
{
    public bool isPickable=true;
    private void OnTriggerEnter(Collider other){
        if(other.tag == "PlayerInteractionZoom"){
            other.GetComponentInParent<PickUpObject>().ObjectToPickup=this.gameObject;
        }

    }

    private void OnTriggerExit(Collider other){
        if(other.tag=="PlayerInteractionZoom"){
            other.GetComponentInParent<PickUpObject>().ObjectToPickup=null;
        }
    }
}
