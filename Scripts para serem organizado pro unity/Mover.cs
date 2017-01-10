using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float hitbox; //se for entre 1 e 0.8 ele acerta o personagem em cheio, entre 0.7 e 0.6 ele passa muito perto
	private Transform target;
	private float movex;
	private float movey;
	private Rigidbody2D rb2d;

	void CheckOriginal(){
		if (this.gameObject.name == "Avião") {
			movey = 0.0f;
			hitbox = 0.0f;
		}
	}

	void Start(){
        target = GameObject.FindWithTag("Player").transform;
		rb2d = GetComponent<Rigidbody2D> ();
		movex = target.position.x - transform.position.x;
		movey = target.position.y - transform.position.y;
		//CheckOriginal ();
	}
		

	void Update(){
		rb2d.velocity = new Vector2 (movex * hitbox, movey);
	}
}
