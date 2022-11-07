using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI roundText;
    [SerializeField] TextMeshProUGUI scoreTextYour;
    [SerializeField] TextMeshProUGUI scoreTextPrev;
  

    [SerializeField] Button newGameButton;
    [SerializeField] Button restartGameButton;
    [SerializeField] Button scoreButton;
    [SerializeField] Button mainMenuButton;
    
    private float spawnRate = 1.5f;
    private float zPosition = 13.0f;

    
    public GameObject sphereOne;
    [SerializeField] GameObject sphereTwo;
    [SerializeField] GameObject sphereThree;
    [SerializeField] GameObject sphereFour;
    [SerializeField] GameObject sphereFive;
    [SerializeField] GameObject mainMenuScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject scoreScreen;
    [SerializeField] GameObject player;

    [SerializeField] Collider sphereOneCollider;
    [SerializeField] Collider sphereTwoCollider;
    [SerializeField] Collider sphereThreeCollider;
    [SerializeField] Collider sphereFourCollider;
    [SerializeField] Collider sphereFiveCollider;

    public int score = 0;
    public int ballInside = 0;
    public int numberOfBallsBlue = 0;
    public int numberOfBallsGreen = 0;
    public int numberOfBallsOrange = 0;  
    public int numberOfBallsWhite = 0;
    public int numberOfBallsViolet = 0;
    public int roundNumber = 1;

    public int oldScore = 0;

   

    public bool isGameActive = false;
    private bool paused = false;

    public bool endOfRound = false;

    private Vector3 position;
    

    private void Awake()
    {
        
    }
    void Start()
    {
        newGameButton.onClick.AddListener(StartGame);
        restartGameButton.onClick.AddListener(RestartGame);
        scoreButton.onClick.AddListener(ScorePanel);
        mainMenuButton.onClick.AddListener(RestartGame);


    }

    // Update is called once per frame
    void Update()
    { 
        PlayerPosition();
        BallCounter();
        ScoreCounter();
        RoundsNumber();
        RoundEnd();

        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeEscape();
        }
        if(!isGameActive)
        {
            restartGameButton.enabled = false;
        }
        else
        {
            restartGameButton.enabled = true;
        }
    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    private void BallCounter()
    {
        if (ballInside == 1)
        {
            sphereTwo.SetActive(true);
            sphereOneCollider.enabled = false;
        }
        if (ballInside == 2)
        {
            sphereThree.SetActive(true);
            sphereTwoCollider.enabled = false;
        }
        if (ballInside == 3)
        {
            sphereFour.SetActive(true);
            sphereThreeCollider.enabled = false;
        }
        if (ballInside == 4)
        {
            sphereFive.SetActive(true);
            sphereFourCollider.enabled = false;
        }
    }
    private void ScoreCounter()
    {
        if (ballInside == 5 && numberOfBallsBlue == 5)
        {
            score += 50;
        }
        if (ballInside == 5 && numberOfBallsGreen == 5)
        {
            score += 50;
        }
        if (ballInside == 5 && numberOfBallsOrange == 5)
        {
            score += 50;
        }
        if (ballInside == 5 && numberOfBallsViolet == 5)
        {
            score += 50;
        }
        if (ballInside == 5 && numberOfBallsWhite == 5)
        {
            score += 50;
        }

        if (ballInside == 5 && numberOfBallsBlue == 4)
        {
            score += 20;
        }
        if (ballInside == 5 && numberOfBallsGreen == 4)
        {
            score += 20;
        }
        if (ballInside == 5 && numberOfBallsOrange == 4)
        {
            score += 20;
        }
        if (ballInside == 5 && numberOfBallsViolet == 4)
        {
            score += 20;
        }
        if (ballInside == 5 && numberOfBallsWhite == 4)
        {
            score += 20;
        }

        if (ballInside == 5 && numberOfBallsBlue == 3)
        {
            score += 10;
        }
        if (ballInside == 5 && numberOfBallsGreen == 3)
        {
            score += 10;
        }
        if (ballInside == 5 && numberOfBallsOrange == 3)
        {
            score += 10;
        }
        if (ballInside == 5 && numberOfBallsViolet == 3)
        {
            score += 10;
        }
        if (ballInside == 5 && numberOfBallsWhite == 3)
        {
            score += 10;
        }

        if (ballInside == 5 && numberOfBallsBlue == 2)
        {
            score += 5;
        }
        if (ballInside == 5 && numberOfBallsGreen == 2)
        {
            score += 5;
        }
        if (ballInside == 5 && numberOfBallsOrange == 2)
        {
            score += 5;
        }
        if (ballInside == 5 && numberOfBallsViolet == 2)
        {
            score += 5;
        }
        if (ballInside == 5 && numberOfBallsWhite == 2)
        {
            score += 5;
        }

        if (ballInside == 5 && numberOfBallsBlue == 1)
        {
            score += 2;
        }
        if (ballInside == 5 && numberOfBallsGreen == 1)
        {
            score += 2;
        }
        if (ballInside == 5 && numberOfBallsOrange == 1)
        {
            score += 2;
        }
        if (ballInside == 5 && numberOfBallsViolet == 1)
        {
            score += 2;
        }
        if (ballInside == 5 && numberOfBallsWhite == 1)
        {
            score += 2;
        }

        scoreText.text = "Score: " + score;
    }
    private void RoundsNumber()
    {
        if (roundNumber <= 5)
        {
            roundText.text = "Round: " + roundNumber + "/5";
        }
        if (roundNumber > 5)
        {
            roundText.text = "Round: 5/5";
        }
    }
    private void RoundEnd()
    {
        if (ballInside == 5)
        {
            sphereOneCollider.enabled = true;
            sphereTwoCollider.enabled = true;
            sphereThreeCollider.enabled = true;
            sphereFourCollider.enabled = true;
            sphereFiveCollider.enabled = true;
            sphereOne.SetActive(false);
            sphereTwo.SetActive(false);
            sphereThree.SetActive(false);
            sphereFour.SetActive(false);
            sphereFive.SetActive(false);
            ballInside = 0;
            numberOfBallsBlue = 0;
            numberOfBallsGreen = 0;
            numberOfBallsOrange = 0;
            numberOfBallsWhite = 0;
            numberOfBallsViolet = 0;
            endOfRound = true;
            roundNumber++;
        }

        if (ballInside == 0 && endOfRound)
        {
            sphereOne.SetActive(true);
            endOfRound = false;

        }

        if (roundNumber == 6)
        {
            isGameActive = false;
            sphereOne.SetActive(false);
            sphereTwo.SetActive(false);
            sphereThree.SetActive(false);
            sphereFour.SetActive(false);
            sphereFive.SetActive(false);
            player.SetActive(false);
            MainManager.Instance.oldScore = score;
            scoreTextYour.text = MainManager.Instance.oldScore + " points";
            scoreTextPrev.text = MainManager.Instance.oldOldScore + " points";
            ScorePanel();
        }
    }
    void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    void ChangeEscape()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
    void PreStart()
    {
        sphereOne.SetActive(true);
        sphereTwo.SetActive(true);
        sphereThree.SetActive(true);
        sphereFour.SetActive(true);
        sphereFive.SetActive(true);
        sphereOneCollider = GameObject.Find("Sphere_1").GetComponent<Collider>();
        sphereTwoCollider = GameObject.Find("Sphere_2").GetComponent<Collider>();
        sphereThreeCollider = GameObject.Find("Sphere_3").GetComponent<Collider>();
        sphereFourCollider = GameObject.Find("Sphere_4").GetComponent<Collider>();
        sphereFiveCollider = GameObject.Find("Sphere_5").GetComponent<Collider>();
        sphereTwo.SetActive(false);
        sphereThree.SetActive(false);
        sphereFour.SetActive(false);
        sphereFive.SetActive(false);
    }
    public void StartGame()
    {
        PreStart();
        isGameActive = true;
        paused = false;
        Time.timeScale = 1;
        StartCoroutine(SpawnTarget());
        mainMenuScreen.SetActive(false);
        MainManager.Instance.oldOldScore = MainManager.Instance.oldScore;

    }
    void PlayerPosition()
    {
        position = Input.mousePosition;
        position.z = zPosition; // camera position = -10.0f, ball and player position = 3.0f (13.0f + -10.0f = 3.0f - needed position)
        position = Camera.main.ScreenToWorldPoint(position);
        player.transform.position = position; // setting player position to mouse position
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void ScorePanel()
    {
        isGameActive = false;
        mainMenuScreen.SetActive(false);
        scoreScreen.SetActive(true);
        scoreTextYour.text = MainManager.Instance.oldScore + " points";
        scoreTextPrev.text = MainManager.Instance.oldOldScore + " points";
    }
}
