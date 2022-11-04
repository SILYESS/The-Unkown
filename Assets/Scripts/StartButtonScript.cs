using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour
{
    private Button button;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        //playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        playerController = GameObject.FindObjectOfType<PlayerController>();
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartGam()
    {
        playerController.StartGame();
    }
}
