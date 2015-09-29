using UnityEngine;
using System.Collections;

public class OffsetPursuit : MonoBehaviour {

    public GameObject player;
    public float speed;
    public float offset;
    // Use this for initialization
    void Start()
    {
        player.GetComponent<Transform>();
        gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        

        Vector3 desired_velocity = Vector3.Normalize(player.transform.position - gameObject.transform.position) * (speed * Time.deltaTime);
        

        

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) > offset)
        {
            gameObject.transform.position += desired_velocity;
        }

        if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= offset)
        {
            gameObject.transform.position -= desired_velocity;
        }

        transform.LookAt(player.transform);
    }
}
