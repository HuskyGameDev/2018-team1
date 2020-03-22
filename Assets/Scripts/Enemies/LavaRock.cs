using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRock : MonoBehaviour
{
   // private Rigidbody2D rb;
    public Transform camTransform;

    // Start is called before the first frame update
    void Start()
    {
        //rb=this.GetComponent<Rigidbody2D>();
        camTransform=Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<camTransform.position.y-15){
            Destroy(this.gameObject);
        }
    }
}
