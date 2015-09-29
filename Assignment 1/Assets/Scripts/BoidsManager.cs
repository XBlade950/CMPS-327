using UnityEngine;
using System.Collections;

public class BoidsManager : MonoBehaviour {
    private GameObject[] boids;
    public float offset;
    public float cohesion;
    public float alignment;
    public float tendency;
    public GameObject place;
    public Vector3 wind;
    public float Xmin, Xmax, Ymin, Ymax, Zmin, Zmax;
    public float speed;
    public GameObject boid;
    public int boidLimit;
	// Use this for initialization
	void Start () {
       // boids = GameObject.FindGameObjectsWithTag("boid");
	}
	
	// Update is called once per frame
	void Update () {
        boids = GameObject.FindGameObjectsWithTag("boid");
        foreach (GameObject b in boids)
        {
            b.GetComponent<Boids>().offset = offset;
            b.GetComponent<Boids>().place = place;
            b.GetComponent<Boids>().wind = wind;
            b.GetComponent<Boids>().Xmin = Xmin;
            b.GetComponent<Boids>().Xmax = Xmax;
            b.GetComponent<Boids>().Ymin = Ymin;
            b.GetComponent<Boids>().Ymax = Ymax;
            b.GetComponent<Boids>().Zmin = Zmin;
            b.GetComponent<Boids>().Zmax = Zmax;
            b.GetComponent<Boids>().speed = speed;
            b.GetComponent<Boids>().cohesion = cohesion;
            b.GetComponent<Boids>().alignment = alignment;
            b.GetComponent<Boids>().tendency = tendency;

        }

        if (Input.GetKeyDown("space") && boids.Length < boidLimit)
        {
            Vector3 spawn = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
            Instantiate(boid, spawn, Quaternion.identity);
        }

        if (Input.GetKeyDown("backspace") && boids.Length > 1)
        {
            GameObject toDelete = boids[Random.Range(0, boids.Length)];
            if (toDelete.name == "Player")
            {
                while (toDelete.name == "Player") { 
                    toDelete = boids[Random.Range(0, boids.Length)];
                }
                
            }
            if (toDelete.name != "Player")
            {
                Destroy(toDelete);
            }
            
           
        }

        if (Input.GetKeyDown("q"))
        {
            for (int i = 0; i < boids.Length; i++)
            {
                if (boids[i].name == "Player")
                {
                    boids[i].GetComponent<PlayerController>().enabled = !boids[i].GetComponent<PlayerController>().enabled;
                }
            }
            place.GetComponent<PlayerController>().enabled = !place.GetComponent<PlayerController>().enabled;
        }

	}
}
