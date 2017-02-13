using UnityEngine;
using System.Collections;

public class MultiJumpTest : MonoBehaviour {

    public float timeDoubleClick = 0.0f, timeLongClick = 0.0f;
    public bool grounded;
    private float _buttonDownPhaseStart, _doubleClickPhaseStart;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            _buttonDownPhaseStart = Time.time;
        }

        if (_doubleClickPhaseStart > -1 && (Time.time - _doubleClickPhaseStart) > timeDoubleClick)
        {
            Debug.Log("Single Click");
            _doubleClickPhaseStart = -1;
        }

        if (Input.GetKeyUp(KeyCode.Space) && grounded)
        {
            if (Time.time - _buttonDownPhaseStart > timeLongClick)
            {
                Debug.Log("Long Click");
                _doubleClickPhaseStart = -1;
            }
            else
            {
                if (Time.time - _doubleClickPhaseStart < timeDoubleClick)
                {
                    Debug.Log("Double Click");
                    _doubleClickPhaseStart = -1;
                }else
                {
                    _doubleClickPhaseStart = Time.time;
                }
            }
        }
	
	}
}
