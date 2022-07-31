using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float defaultSpeed;

    private Rigidbody playerRB;

    private float speed;

    private float zBound = 10.5f;
    private float xBound = 8.5f;

    private float boostTimer = 0;
    private bool boosting = false;


    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        speed = defaultSpeed;
    }

    void Update()
    {
        PlayerMovementControl();  // Move Player on horizontal and vertical axis, and set timer for Booster.
        ConstrainMovement();      // Keep Player within the frame of a camera.
        PlayerRotationControl();  // Rotate Player towards direction of mouse pointer.
        ShootingControl();        // Fire the projectiles.
    }

    void PlayerMovementControl()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.forward * speed * horizontalInput);
        playerRB.AddForce(Vector3.right * speed * -verticalInput);

        if(boosting)
        {
            boostTimer += Time.deltaTime;
            if (boostTimer >= 10f)
            {
                speed = defaultSpeed;
                boostTimer = 0;
                boosting = false;
                PlayerGun.Instance.firingSpeed = 0.1f;
            }
        }
    }

    void ConstrainMovement()
    {

        if(transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

        if (transform.position.x < -5f)
        {
            transform.position = new Vector3(-5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
    }

    void PlayerRotationControl()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && PauseMenu.GameIsPaused == false)
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    void ShootingControl()
    {
        if (Input.GetButton("Fire1"))
        {
            PlayerGun.Instance.Shoot();
        }
    }

    void OnTriggerEnter(Collider collider) // Booster handler.
    {
        if (collider.gameObject.CompareTag("Booster"))
        {
            boosting = true;
            speed = speed * 1.5f;
            PlayerGun.Instance.firingSpeed = PlayerGun.Instance.firingSpeed / 1.5f;
            Destroy(collider.gameObject);
        }
    }
}
