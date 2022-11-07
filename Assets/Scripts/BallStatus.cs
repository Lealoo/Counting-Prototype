using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStatus : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.endOfRound)
        {
            ball.SetActive(false);
        }
    }
}
