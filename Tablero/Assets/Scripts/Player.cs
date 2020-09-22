using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public float force;
    private Rigidbody rb;
    public GameObject camera; 
    private Vector3 offset;

    public Text txtScore;
    public  Button btnRestart;
    private int score; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
        offset = camera.transform.position;

        score = 0;
        btnRestart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 vector = new Vector3(h, 0.5f, v);
        rb.AddForce(vector*force*Time.deltaTime);

        camera.transform.position = this.transform.position + offset;
    }

    void OnTriggerEnter(Collider obj){
        Destroy(obj.gameObject);

        if (obj.gameObject.tag == "coin"){
            obj.gameObject.SetActive(false);

            score++;
            txtScore.text = "SCORE: " + score.ToString();
        }

        if(score == 6){
            txtScore.text = "YOU WIN!";
            //btnRestart.gameObject.SetActive(true);
        }
    }

    public void reloadGame(){
        Application.LoadLevel(Application.loadedLevel);
    }
}
