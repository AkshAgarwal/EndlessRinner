using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : StateMachine
{
    #region Data Members
    //Singleton instance of the class.
    public static PlayerMovement instance;

    //Player Rigid Body and Player Animator.
    [Header("Player Animator and RigidBody reference")]

    [SerializeField] public Rigidbody playerRigidBody;
    [SerializeField] public Animator playerAnimator;

    //Player Movement data members.
    [HideInInspector] public const float _sideOffset = 1.7f;
    [HideInInspector] public const float _jumpForce = 5.8f;
    [HideInInspector] public float playerSpeed;
    [HideInInspector] public float pathCoordinate;
    [HideInInspector] public float sideSpeed;
    [HideInInspector] public int desiredLane=1;
    [HideInInspector] public bool isDead;
    private int randomPlayerDeath;
    private bool isForwardFacing;
    // Timer related data members.
    private float timer;
    private const float _maxPlayerSpeed = 100f;
    private const float _secondsBeforeBegining = 3f;

    // Timer reference.
    [Header("Timer Reference")]
    [SerializeField] TextMeshProUGUI Timer;

    //Score Reference
    private int Score;

    //GameManager Reference.
    [Header("Game Manager Reference")]
    [SerializeField] private GameObject gameManager;

    // Player Spawn boolean
    private bool isSpawned;

    #endregion

    #region Start Function
    void Start()
    {
        desiredLane = 1;
        Cursor.lockState = CursorLockMode.Locked;
        //Singleton Instance defined to this.
        instance = this;
        isDead = false;

        //Defining Maximum Player speed pathcoordinate and current Player speed.
        pathCoordinate = 0f;
        playerSpeed = 0f;

        //Definition of Timer related data members.
        timer = _secondsBeforeBegining;
        StartCoroutine(StartDelay());

        //Subscribing MoveLeft MoveRight and Jump of InputManager Events to player movement functions.
        PlayerInputManager.playerMove += Move;
        PlayerInputManager.playerJump += Jump;
     
    }
    #endregion

    #region Player Movement Member Functions
    //Player Moving Forward towards Z Axis or forward.
    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector3(playerRigidBody.velocity.x, playerRigidBody.velocity.y, 10 * playerSpeed * Time.deltaTime);
        if (playerSpeed <= 0 && !isDead)
        {
            playerAnimator.Play("Idle");
        }
        else if (playerSpeed >= 0 && !isDead)
        {
            playerAnimator.Play("Running");
        }
      
    }

    //Function to move Player Left or Right.
    private void Move(bool movingRight)
    {
       
        setState(new MoVe(this));
        desiredLane += (movingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
        StartCoroutine(State.Move(desiredLane,isDead,playerSpeed));
    }


    //Function to make player jump.
    private void Jump()
    {
        setState(new Jump(this));
        StartCoroutine(State.Jumping(isDead,playerSpeed));
    }
    #endregion

    #region Timer manipulation Functions
    void Update()
    {
        //Calling timer function

        TimerIncrement();

    }
  
    void TimerIncrement()
    {
        //To increment time and manage speed increment and score increment.

        while (timer >= 0)
        {
            timer -= Time.deltaTime;
            Timer.SetText("Timer: " + timer.ToString("0"));
            break;
        }
        if (timer <= 0)
        {
            timer = 0f;
            // When the timer reaches zero the gamemanager score Timer increment script will be enabled.//
            gameManager.GetComponent<TimerManager>().enabled = true;
        }
    }
    #endregion
    //Timer which sets speed to default(this case 0) waits for specified seconds and sets speed to 100 units.
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(_secondsBeforeBegining);
        playerSpeed = 100;
    }
    

    #region Speed manipultaion member function
    //Function to increment speed by 5 units
    public void SpeedIncrement()
    {
        if (playerSpeed <= _maxPlayerSpeed)
            playerSpeed += 5;
    }
    #endregion

    #region Collision detection
    //To detect collision between Player and other gameObjects
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Vector3 normal = collision.contacts[0].normal;
            if (normal == -transform.forward)
            {
                Debug.Log("WORKED FORWARD");
            }

            else if (normal == -(transform.forward))
            {
                Debug.Log("WORKED BACKWARD");
            }

            else if (normal == transform.right)
            {
                Debug.Log("WORKED RIGHT");
                
            }

            else if (normal == -(transform.right))
            {
                Debug.Log("WORKED LEFT");
            }
            playerSpeed = 0f;
            randomPlayerDeath = Random.Range(0, 3);
            isDead = true;
            setState(new PlayerDeath(this));
            StartCoroutine(State.Dead(gameObject, MenuManager.menuManager, randomPlayerDeath, isDead, playerSpeed, playerAnimator));
          
        }
    }
    #endregion

    #region Disable Function
    //When Player disables or dies the functions will be unsubscribed from the events.
    private void OnDisable()
    {
        PlayerInputManager.playerMove -= Move;
        PlayerInputManager.playerJump -= Jump;
    }
    #endregion 

}
