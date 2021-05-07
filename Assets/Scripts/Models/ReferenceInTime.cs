using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceInTime
{
    public Vector3 Position;
    public Quaternion Rotation;
    
    public Vector3 Velocity;

    public Vector3 AngularVelocity;
    public ReferenceInTime(Vector3 pos, Quaternion rot, Vector3 vel, Vector3 angVel){

        Position = pos;
        Rotation = rot;
        Velocity = vel;
        AngularVelocity = angVel;
    }

}
