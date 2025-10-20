using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] GameObject shockwavePrefab;
    [SerializeField] GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }//check if we collide with the player
    private void OnTriggerEnter(Collider other)
    {// sets game over to true
        if (other.CompareTag("Player")) {
            gameManager.gameOver = true;
            // creates a shockwave
            Instantiate(shockwavePrefab, transform.position, Quaternion.identity);
            // destroy key
            Destroy(gameObject, 0.1f);
        }
    }
}
