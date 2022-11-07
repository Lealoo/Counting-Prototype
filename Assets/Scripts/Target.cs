using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private MeshRenderer targetMeshrenderer;
    private GameManager gameManager;
    private float rangePosX = 10.0f;
    private float spawnPosY = 15.0f;
    private float spawnPosZ = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
       targetMeshrenderer = GetComponent<MeshRenderer>();
       // gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        transform.position = RandomSpawnPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
       if(gameManager.roundNumber == 6)
        {
            targetMeshrenderer.enabled = false;
        }
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-rangePosX, rangePosX), spawnPosY, spawnPosZ);
    }
}
