using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtomStart : MonoBehaviour {

    public void OnClick()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("Scene1-Japan");
    }

}
