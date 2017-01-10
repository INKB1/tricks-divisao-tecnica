using UnityEngine;
using System.Collections;

public class ObstaclesSpawn : MonoBehaviour {

    public float spawnWait;
    public Vector3 spawnValues; //Y será metade do tamanho da tela
    private GameObject[] hazards = new GameObject[3];
    public GameObject go1, go2, go3;

    // Use this for initialization
    void Start () {
        hazards[0] = go1;
        hazards[1] = go2;
        hazards[2] = go3;

        StartCoroutine(SpawnObstacles());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(spawnWait);
        while (true)
        {
            Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazards[CreateNumber()], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    int CreateNumber()
    {
        int escolha = Random.Range(0, 2);
        return escolha;

    }
}
