using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBorder : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        if(gameManager.isGameActive)
        {
            gameManager.score--;
        }
    }
}
