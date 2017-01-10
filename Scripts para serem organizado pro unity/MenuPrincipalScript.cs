using UnityEngine;
using System.Collections;

public class MenuPrincipalScript : MonoBehaviour {

    public Canvas CanvasStart;
    public Canvas CanvasMenu;

    

    private float time = 0.0f;

	// Use this for initialization
	void Start () {
        time = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {
        
            if (Input.anyKey)
            {
                time = 30.0f;
            }
            else
            {
                if (time > 0)
                {
                    time -= Time.deltaTime;
                }
                else
                {
                    CanvasMenu.gameObject.SetActive(false);
                    Debug.Log("CanvasMenu desabilitado");
                    CanvasStart.gameObject.SetActive(true);
                    Debug.Log("CanvasStart habilitado");
                }

            }
        
	}
}
