using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Opponent : MonoBehaviour
{
    public NavMeshAgent opponentAgent;
    public GameObject target;
    Vector3 opponentStartPos;
    public GameObject speedBoosterIcon;

    // Start is called before the first frame update
    void Start()
    {
        opponentStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        opponentAgent = GetComponent<NavMeshAgent>();
        speedBoosterIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        opponentAgent.SetDestination(target.transform.position);

        if (GameManager.instance.isGameOver)
        {
            opponentAgent.speed = 0f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            transform.position = opponentStartPos; ;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("End"))
        {
            opponentAgent.speed = 0;
            transform.Rotate(transform.position.x, 180, transform.position.z, Space.Self);
        }
        if (other.CompareTag("SpeedBoost"))
        {
            speedBoosterIcon.SetActive(true);
            opponentAgent.speed = opponentAgent.speed + 3f;
            StartCoroutine(SlowAfterAWhile());
        }
    }

    private IEnumerator SlowAfterAWhile()
    {
        yield return new WaitForSeconds(3);
        opponentAgent.speed = opponentAgent.speed  - 3f;
        speedBoosterIcon.SetActive(false);
    }
}
