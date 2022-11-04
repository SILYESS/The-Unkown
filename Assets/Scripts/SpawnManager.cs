using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public List <GameObject> target;

    [SerializeField] float spawnRate = 2.0f;
    [SerializeField] float xSpawnRange = 9.5f;
    [SerializeField] float upSpawnPos = 4;
    [SerializeField] float downSpawnPos = -2.5f;
    [SerializeField] float zSpawnPos = 20;

    public GameObject player;
    private PlayerController playerControl;
    public TextMeshProUGUI scoreText;
    private Target targetScript;
    int scor;
    // Start is called before the first frame update
    void Start()
    {
        playerControl = GameObject.FindObjectOfType<PlayerController>();
        targetScript = GameObject.FindObjectOfType<Target>();
        StartCoroutine(SpawnTarget());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, target.Count);
            Instantiate(target[index], GenerateSpawnPos(), transform.rotation);
        }
    }


    private Vector3 GenerateSpawnPos()
    {
        float spawnPosX = Random.Range(xSpawnRange, -xSpawnRange);
        float spawnPosY = Random.Range(downSpawnPos, upSpawnPos);

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, zSpawnPos);

        return spawnPos;
    }    
}
