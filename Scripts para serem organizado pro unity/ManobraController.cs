using UnityEngine;
using System.Collections;

public class ManobraController : MonoBehaviour {
    public Renderer carga1, carga2, carga3, carga4;
    Renderer beastJump, extremelyJump;
    public Sprite comp_beast, comp_extremely;

    void Start()
    {
        carga1 = GetComponent<Renderer>();
        carga2 = GetComponent<Renderer>();
        carga3 = GetComponent<Renderer>();
        carga4 = GetComponent<Renderer>();

        beastJump = GetComponent<Renderer>();
        extremelyJump = GetComponent<Renderer>();
    }

    void Update()
    {
        
    }
}