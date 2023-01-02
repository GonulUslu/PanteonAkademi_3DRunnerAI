using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckCollisions : MonoBehaviour
{

    public PlayerController playerController;
    Vector3 playerStartPos;
    public GameObject speedBoosterIcon;
    private InGameRanking inGameRanking;
    public GameObject inGameRankingPanel;
   
    private void Start()
    {
        inGameRankingPanel.SetActive(true);
        
        playerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
        inGameRanking = FindObjectOfType<InGameRanking>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
           
            if (inGameRanking.namesText[6].text =="Character")
            {
               
                PlayerFinished();
                SceneManager.LoadScene(2);
                //inGameRankingPanel.SetActive(false);
                //gameOverWinnerPanel.SetActive(true);
            }
            else
            {
                PlayerFinished();
                SceneManager.LoadScene(3);
                //inGameRankingPanel.SetActive(false);
                //gameOverLoserPanel.SetActive(true);
            }
           
        }
        if (other.CompareTag("SpeedBoost"))
        {
            speedBoosterIcon.SetActive(true);
            playerController.runningSpeed = playerController.runningSpeed + 3f;
            StartCoroutine(SlowAfterAWhile());
        }
    }

   
    void PlayerFinished()
    {
        playerController.runningSpeed = 0.0f;
        playerController.xSpeed = 0.0f;
        transform.Rotate(0, 180, 0, Space.Self);
        GameManager.instance.isGameOver = true;
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            transform.position = playerStartPos;
        }
    }

    private IEnumerator SlowAfterAWhile()
    {
        yield return new WaitForSeconds(3);
        playerController.runningSpeed = playerController.runningSpeed - 3f;
        speedBoosterIcon.SetActive(false);
    }
}
