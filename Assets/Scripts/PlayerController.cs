using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizantalInput;
    [SerializeField] private float vSpeed = 10;
    [SerializeField] private float hSpeed = 10;
    private Rigidbody playerRb;
    public bool isGameActive;

    
    public GameObject missilePrefab;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public TextMeshProUGUI gameTitle;
    public Button startButton;
    public TextMeshProUGUI scoreText;
    private MissleScript missleScript;
    

    private SpawnManager spawnManager;
    private float xBound = 6.2f;
    float upBound = 4;
    float downBound = -2.5f;
    int remainingLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();
        //missleScript = gameObject.GetComponent<MissleScript>();
        playerRb = GetComponent<Rigidbody>();
        isGameActive = false;
        remainingLives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        StartGame();
    }
    //Player Controll
    void MovePlayer()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizantalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.up * verticalInput * vSpeed * Time.deltaTime);
        transform.Translate(Vector3.right * horizantalInput * hSpeed * Time.deltaTime);
        Boundries();
    }
    void Boundries()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }

        if (transform.position.y > upBound)
        {
            transform.position = new Vector3(transform.position.x, upBound, transform.position.z);
        }
        else if (transform.position.y < downBound)
        {
            transform.position = new Vector3(transform.position.x, downBound, transform.position.z);
        }
    }

    /**************************************************************************************/
    //Missile Controll
    void FireMissile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnMissile();
        }
    }
    void SpawnMissile()
    {
        if (isGameActive)
        {
            Instantiate(missilePrefab, SpawnPos(), missilePrefab.transform.rotation);
        }
    }

    Vector3 SpawnPos()
    {
        return new Vector3(transform.position.x, transform.position.y, 7.5f);
    }
    /**********************************************************************************/


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            remainingLives -= 1;
            if(remainingLives == 0)
            {
                gameObject.SetActive(false);
                GameOver();
            }
            
        }
    }

    void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        isGameActive = true;
        
        startButton.gameObject.SetActive(false);
        gameTitle.gameObject.SetActive(false);
        gameObject.SetActive(true);
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Lives: " + remainingLives;
        MovePlayer();
        FireMissile();
    }

    public void RestartGame()
    {
        if(remainingLives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
