using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Vector3 playerInput;//Vector 3 elemento
    public float PlayerSpeed; // velocidad del persona
    public float Gravity; // velocidad del persona
    public Vector3 moverPlayer;
    public float horizontalMove; // variable que va a guardar la posicion en x cuando aprieten la tecla a - d 
    public float verticalMove; //variable que va a guardar la poscion en y cuando aprietan la tecla w-s
    public CharacterController player;// player de tipo charapter controler va a hacer una referencia a nuestro personaje principal
    // Start is called before the first frame update
    //Solo se ejecuta al iniciar el script


    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    
    void Start()
    {
        player=GetComponent<CharacterController>();//optener el Charapter Controller
    PlayerSpeed=8.0f;//se inicializa la velocidad
    Gravity=9.81f;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove=Input.GetAxis("Horizontal");
        verticalMove=Input.GetAxis("Vertical");


        playerInput = new Vector3(horizontalMove,0,verticalMove);
        playerInput=Vector3.ClampMagnitude(playerInput,1);


       camDirection();
        Check_Gravity();

        moverPlayer= playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + moverPlayer);

        player.Move(moverPlayer*PlayerSpeed*Time.deltaTime);



    }

    void Check_Gravity(){
        if(!player.isGrounded){
            player.Move(Vector3.down*Gravity*Time.deltaTime);
        }
    }

    void camDirection(){
        camForward=mainCamera.transform.forward;
        camRight=mainCamera.transform.right;
        camForward.y=0;
        camRight.y=0;
        camForward=camForward.normalized;
        camRight=camRight.normalized;
    }
 
 
}
