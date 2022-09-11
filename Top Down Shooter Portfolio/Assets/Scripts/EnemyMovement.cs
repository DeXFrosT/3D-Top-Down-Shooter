using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody enemyRB;
    private GameObject playerPos;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(PauseMenu.GameIsPaused == false)
        {
            enemyRB.AddForce((playerPos.transform.position - transform.position).normalized * speed);

            transform.LookAt(playerPos.transform.position);
        }        
    }

}
