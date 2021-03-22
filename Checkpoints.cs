using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//check if player enters the collider
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            levelManager.currentCP = gameObject;
            Debug.Log("Activated CP " + transform.position);
        }
    }

}
