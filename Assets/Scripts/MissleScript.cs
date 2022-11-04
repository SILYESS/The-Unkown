using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MissleScript : MonoBehaviour
{
    [SerializeField] private float missleSpeed = 100;
    public int score = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.forward * Time.deltaTime * missleSpeed);
        if (transform.position.z > 200)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            score += 1;
            Debug.Log("missle destroy");
        }
        
    }


}
