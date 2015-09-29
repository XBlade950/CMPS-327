using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {
    public string nextLevel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyDown("tab")){
        Application.LoadLevel(nextLevel);
    }
	}
}
