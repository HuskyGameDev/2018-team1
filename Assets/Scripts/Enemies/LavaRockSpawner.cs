using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRockSpawner : MonoBehaviour
{
    public GameObject lavaRockPrefab;
    public float spawnDelay=.1f;
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
        lr.transform.position=new Vector2(Random.Range(camTransform.position.x-20,camTransform.position.x+20),camTransform.position.y+15);
        Vector2 sideForce=new Vector2(Random.Range(-50,50),0);
        float scale=Random.Range(1f,3f);
        lr.transform.localScale*=scale;
        lr.GetComponentInChildren<HitLavaRock>().damage=(int)(5*scale);
        lr.GetComponentInChildren<HitLavaRock>().knockback=1500*scale;
        rb.AddForce(sideForce,ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(-20,20),ForceMode2D.Impulse);

        // GameObject child = new GameObject();
		// child.transform.SetParent(lr.transform);
        // CircleCollider2D childHitBox = child.AddComponent<CircleCollider2D>();
		// childHitBox.isTrigger = true;
		// childHitBox.enabled = false;
    }

    IEnumerator spawnRoutine(){
        while(true){
            spawnLavaRock();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
