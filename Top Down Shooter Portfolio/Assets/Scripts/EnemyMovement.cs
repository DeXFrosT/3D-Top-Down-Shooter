using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _enemyRB;
    private GameObject _playerPos;

    void Start()
    {
        _enemyRB = GetComponent<Rigidbody>();
        _playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(PauseMenu.GameIsPaused == false)
        {
            _enemyRB.AddForce((_playerPos.transform.position - transform.position).normalized * _speed);

            transform.LookAt(_playerPos.transform.position);
        }        
    }

}
