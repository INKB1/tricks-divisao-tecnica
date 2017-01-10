using UnityEngine;
using System.Collections;

public class TrocarCena : MonoBehaviour {

	public void CarregarCena (string cena)
    {
        Application.LoadLevel(cena);

    }
}
