using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovJogador : MonoBehaviour
{

    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    [SerializeField] AudioSource jumpSound;

    public Joystick joystick;
    public FixedButton fixedButton;

    public GameObject scorePanel;

    //
    private bool win;



    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        fixedButton = FindObjectOfType<FixedButton>();

        rb = GetComponent<Rigidbody>();

        //
        win = false;
        //cameraPos = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        //rb.velocity = new Vector3(joystick.Horizontal * movementSpeed, rb.velocity.y, joystick.Vertical * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        if (fixedButton.pressed && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            jumpSound.Play();
        }

        //

        WinFinish();
    }


    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        jumpSound.Play();
    }

    //cabeca do inimigo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    //checar o chao
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

    //jogador encostou no win(final do nivel)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("win") == true)
        {
            win = true;
            var unlockedLevel = SceneManager.GetActiveScene().buildIndex + 1;
            if (unlockedLevel > PlayerPrefs.GetInt("unlockedLevel", 0))
            {
                PlayerPrefs.SetInt("unlockedLevel", unlockedLevel);
            }
            Debug.Log("Finish - WIN");
            scorePanel.SetActive(true);
        }
    }

    private void WinFinish()
    {
        if (win == true)
        {
            rb.velocity = new Vector3(0, rb.velocity.x, 0);

        }

        /*if(SceneManager.GetActiveScene().buildIndex>PlayerPrefs.GetInt("FaseCompletada"))
            {
                PlayerPrefs.SetInt("FaseCompletada", SceneManager.GetActiveScene().buildIndex);
                PlayerPrefs.Save();
            }*/
    }

    // GetWin retorna true se jogardor ganhou a partida
    public bool GetWin()
    {
        return win;
    }
}
