using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollidersPosition : MonoBehaviour
{
    private GameManager gameManager;

       

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
 
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball_Blue"))
        {
            gameManager.numberOfBallsBlue++;
        }
        if (other.gameObject.CompareTag("Ball_Green"))
        {
            gameManager.numberOfBallsGreen++;
        }
        if (other.gameObject.CompareTag("Ball_Orange"))
        {
            gameManager.numberOfBallsOrange++;
        }
        if (other.gameObject.CompareTag("Ball_White"))
        {
            gameManager.numberOfBallsWhite++;
        }
        if (other.gameObject.CompareTag("Ball_Violet"))
        {
            gameManager.numberOfBallsViolet++;
        }
    }
}

