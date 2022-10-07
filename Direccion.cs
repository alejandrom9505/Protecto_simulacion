using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direccion : MonoBehaviour{
    public Rueda[] wheels;

    [Header("car specs")]
    public float wheelBase;
    public float rearTrack;
    public float turnRadius;

    [Header("Inputs")]
    public float steerInput;

    public float acKermannAngleLeft;
    public float acKermannAngleRight;  
   

 
    void Update(){
        steerInput = Input.GetAxis("horizontal");

        if (steerInput > 0){
            acKermannAngleLeft  = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
            acKermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
        } else if (steerInput < 0){
            acKermannAngleLeft = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius - (rearTrack / 2))) * steerInput;
            acKermannAngleRight = Mathf.Rad2Deg * Mathf.Atan(wheelBase / (turnRadius + (rearTrack / 2))) * steerInput;
        }else{
            acKermannAngleLeft =  0;
            acKermannAngleRight = 0; 
        }
        foreach(Rueda w in wheels)
        {
            if (w.wheelFrontLeft)
                w.steerAngle = acKermannAngleLeft;
            if (w.wheelFrontRight)
                w.steerAngle = acKermannAngleRight;
        }
        
    }
}
