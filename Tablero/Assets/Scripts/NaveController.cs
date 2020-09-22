using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveController : MonoBehaviour{

    public GameObject shot;
    public Transform shotContent;
    public float fireRate;
    public float nextFire;

    public GameObject asteroid;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float spawnWait;
    public float starWait;
    public float waveWait;


    public float xMin, xMax, zMin, zMax;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(createAsteroids()); 
    }

    void Update(){

        if(Input.GetButton("Fire1")&& Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotContent.position, shotContent.rotation);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); 
        float v = Input.GetAxis("Vertical"); 

        Vector3 vector = new Vector3(h,5f,v);
        rb.velocity = vector * 10;

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x,xMin,xMax),
            6.0f,
            Mathf.Clamp(rb.position.z,zMin,zMax)
        );  
        rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -2);
    }

    IEnumerator createAsteroids(){
        yield return new WaitForSeconds(starWait);
        while(true){
            for(int i=0; i< asteroidCount; i++){
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.Quaternion, spawnRotation)) = Quaternion.identity;
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
