using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float speed = 0;
	public static BackgroundScroller current;
	private Material material;

	float pos = 0;

	// Use this for initialization
	void Start () {
		current = this;
		material = GetComponent<Renderer> ().material;
	}

	public void Go () {
		pos += speed;
		if (pos> 1.0f)
			pos -= 1.0f;
	}
	// Update is called once per frame
	void Update () {
		material.mainTextureOffset = new Vector2 (pos, 0);
	}
}
