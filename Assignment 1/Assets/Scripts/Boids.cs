using UnityEngine;
using System.Collections;


public class Boids : MonoBehaviour {

    private GameObject[] boids;
    private int n;
    public float offset;
    public GameObject place;
    public Vector3 wind;
    public float Xmin, Xmax, Ymin, Ymax, Zmin, Zmax;
    public float speed;
    public float cohesion;
    public float alignment;
    public float tendency;
    private GameObject player;
    private GameObject point;
    private Vector3 movement, v1, v2, v3, v4, v5, v6;


	// Use this for initialization
	void Start () {
        
        
        
 
	}
	
	// Update is called once per frame
	void Update (){ 
        
        boids = GameObject.FindGameObjectsWithTag("boid");
        n = boids.Length;
        foreach (GameObject b in boids)
        {

            v1 = Cohesion(b) * cohesion;
            v2 = Seperation(b);
            v3 = Alignment(b)  * alignment;
            v4 = TendTo(b) * tendency;
            //v5 = Bound(b);
            movement = v1 + v2 + v3 + (wind / 100) + v4;
            b.GetComponent<Rigidbody>().velocity += movement * Time.deltaTime * speed; 
            
        }
	
	}

    Vector3 Cohesion(GameObject b)
    {
        Vector3 pc = new Vector3();

        foreach (GameObject boid in boids)
        {
            if (boid != b)
            {
                pc = pc + boid.transform.position;
            }
        }
       
        pc = pc / (n - 1);
        return (pc - b.transform.position) / (50);
    }

    Vector3 Seperation(GameObject b)
    {
        Vector3 c = new Vector3();
        foreach (GameObject boid in boids)
        {
            if (boid != b)
            {
                
                if (Mathf.Abs(Vector3.Distance(b.transform.position, boid.transform.position)) < offset)
                {
                    c = c - (boid.transform.position - b.transform.position);
                }
            }
        }
        return c;
    }

    Vector3 Alignment(GameObject b)
    {
        Vector3 pv = new Vector3();

        foreach (GameObject boid in boids)
        {
            if (boid != b)
            {
                pv = pv + boid.GetComponent<Rigidbody>().velocity;
            }
        }

        pv = pv / (n - 1);
       

        return (pv - b.GetComponent<Rigidbody>().velocity) / 8;
    }

    Vector3 TendTo(GameObject b)
    {
        Vector3 empty = new Vector3();
        for (int i =0; i < boids.Length; i++){
            if (boids[i].GetComponent<PlayerController>().enabled){
                return empty;
            }
        }

        

        return (place.transform.position - b.transform.position) / (200);
    }

    Vector3 Bound(GameObject b)
    {
        Vector3 v = new Vector3();

        if (b.transform.position.x < Xmin){
            v.x = 1;
        }
        else if (b.transform.position.x > Xmax){
            v.x = -1;
        }
        if (b.transform.position.y < Ymin){
            v.y = 1;
        }
        else if (b.transform.position.y > Ymax){
            v.x = -1;
        }
        if (b.transform.position.z < Zmin){
            v.z = 1;
        }
        else if (b.transform.position.z < Zmax){
            v.z = -1;
        }

        return v;
    }

    
}
