using System.Collections;                  
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;                               
public class CollectCoin : MonoBehaviour
{
    public int score;                       
                                            
    public TextMeshProUGUI CoinText;       
    public PlayerController playerController;
    public int maxScore = 50;
    public Animator playerAnim;
    public GameObject player;
    public GameObject endPanel;


    private void Start()
    {
        playerAnim = player.GetComponentInChildren<Animator>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();   
            Destroy(other.gameObject); 
        }
        else if (other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;
            transform.Rotate(0, 180, 0, Space.Self);
            endPanel.SetActive(true);

            if (score >= maxScore)
            {
                playerAnim.SetBool("win", true);
            }
            else
            {
                playerAnim.SetBool("lose", true);
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void AddCoin() 
    {
        score++;
        CoinText.text = "Score: " + score.ToString();


    }

}
