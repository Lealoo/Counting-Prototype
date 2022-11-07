using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallManager : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject blueBall;
    public GameObject greenBall;
    public GameObject orangeBall;
    public GameObject whiteBall;
    public GameObject violetBall;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
  
        

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if(other.gameObject.CompareTag("Ball_Blue"))
        {
            blueBall.SetActive(true);
            gameManager.ballInside++;
        }
        if (other.gameObject.CompareTag("Ball_Green"))
        {
            greenBall.SetActive(true);
            gameManager.ballInside++;
        }
        if (other.gameObject.CompareTag("Ball_Orange"))
        {
            orangeBall.SetActive(true);
            gameManager.ballInside++;
        }
        if (other.gameObject.CompareTag("Ball_Violet"))
        {
            violetBall.SetActive(true);
            gameManager.ballInside++;
        }
        if (other.gameObject.CompareTag("Ball_White"))
        {
            whiteBall.SetActive(true);
            gameManager.ballInside++;
        }
    }
  private void OnDisable()
    {
        blueBall.SetActive(false);
        greenBall.SetActive(false);
        orangeBall.SetActive(false);
        whiteBall.SetActive(false);
        violetBall.SetActive(false);
    }
}
