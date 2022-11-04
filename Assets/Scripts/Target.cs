using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    [SerializeField] float targetSpeed;
    float torqRange = 200;
    public int score ;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTarget();
        DestroyTarget();
    }

    void MoveTarget()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -targetSpeed);
        transform.Rotate(Vector3.forward * RandomTorque() * Time.deltaTime);
    }

    void DestroyTarget()
    {
        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }
    float RandomTorque()
    {
        return Random.Range(0, torqRange);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        score += 1;
        //scoreText.SetText("Astreoids Destroyed: " + score);
        Debug.Log("Target destroyed");
    }
}
