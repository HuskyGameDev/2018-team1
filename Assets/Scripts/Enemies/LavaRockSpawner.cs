using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRockSpawner : MonoBehaviour
{
    public GameObject lavaRockPrefab;
    public float spawnDelay=.4f;
    public Transform camTransform;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        camTransform=Camera.main.transform;
        StartCoroutine(spawnRoutine());
    }

    private void spawnLavaRock(){
        GameObject lr=Instantiate(lavaRockPrefab);
        rb=lr.GetComponent<Rigidbody2D>();
        lr.transform.position=new Vector2(Random.Range(camTransform.position.x-30,camTransform.position.x+30),camTransform.position.y+30);
        Vector2 sideForce=new Vector2(Random.Range(-100,100),0);
        float scale=Random.Range(1f,3f);
        lr.transform.localScale*=scale;
        lr.GetComponentInChildren<HitLavaRock>().damage=(int)(5*scale);
        lr.GetComponentInChildren<HitLavaRock>().knockback=1500*scale;
        rb.mass=3*scale;
        rb.AddForce(sideForce,ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-10,10),ForceMode2D.Impulse);
        rb.gravityScale=scale/5;
        rb.drag=scale;
    }

    IEnumerator spawnRoutine(){
        while(true){
            spawnLavaRock();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
