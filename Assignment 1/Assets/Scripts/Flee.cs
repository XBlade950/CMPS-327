using UnityEngine;
using System.Collections;

public class Flee : MonoBehaviour {
    public GameObject player;
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 desired_velocity = Vector3.Normalize(player.transform.position - gameObject.transform.position) * (speed * Time.deltaTime);

        gameObject.transform.position -= desired_velocity;
        transform.LookAt(player.transform); 

    
	}
}
