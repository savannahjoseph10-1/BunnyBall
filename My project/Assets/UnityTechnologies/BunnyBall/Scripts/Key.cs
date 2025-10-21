using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // This is a variable for the shockwave Prefab
    [SerializeField] GameObject shockwavePrefab;
    // This is a variable for the game manager 
    [SerializeField] GameManager gameManager;

    // This functions runs once at the beggining of the game
    private void Start()
    {
        // Finds the game manager 
        gameManager = FindObjectOfType<GameManager>();
    }
    // This function runs when we collide with thw trigger 
    private void OnTriggerEnter(Collider other)
    {
        // checks if we collide with something tagged as "player"
        if (other.CompareTag("Player")) {
            // if we do collide with something tagged as "player"

            //gameover is true
            gameManager.gameOver = true;
            // creates a shockwave
            Instantiate(shockwavePrefab, transform.position, Quaternion.identity);
            // destroys this game object 
            Destroy(gameObject, 0.1f);
        }
    }
}
