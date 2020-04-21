using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagMover : MonoBehaviour
{
    public Transform flagT;

    public FlagMover(Transform t){
        flagT=t;
    }

    public void move(){
        flagT.position=new Vector3(flagT.position.x,flagT.position.y+3,flagT.position.z);
    }
}
