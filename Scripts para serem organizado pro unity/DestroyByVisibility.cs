using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DestroyByVisibility : MonoBehaviour {

    private GameController gameController;
    public int scoreValue;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnBecameInvisible(){
		if (gameObject.name != "Avião") {
			Destroy (this.gameObject);
            gameController.AddScore(scoreValue);
		}
        if (gameObject.tag == "Player")
        {
            SceneManager.LoadScene("SceneX-GameOver");
            Debug.Log(gameObject.tag);
        }
	}


}
