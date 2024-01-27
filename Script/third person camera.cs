using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamara : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;
    public float sensibilidad;
    [Range (0,1)] public float lerpValue;
    // Start is called before the first frame update
    void Start()
    {
        target=GameObject.Find("Player").transform;
        lerpValue=1.0f;
        sensibilidad=4f;
        offset=new Vector3(0,5,-10);
    }

    // Update is called once per frame
 void LateUpdate(){
    transform.position=Vector3.Lerp(transform.position,target.position+offset,lerpValue);
    offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X")*sensibilidad,Vector3.up) * offset;

    transform.LookAt(target);
 }
}
