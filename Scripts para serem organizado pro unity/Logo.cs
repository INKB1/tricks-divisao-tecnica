using UnityEngine;
using System.Collections;

public class Logo : MonoBehaviour {

    private float time = 0.0f;


	// Use this for initialization
	void Start () {
        time = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            Application.LoadLevel("Scene0-Menu");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Application.LoadLevel("Scene0-Menu");
        }
	}
}
