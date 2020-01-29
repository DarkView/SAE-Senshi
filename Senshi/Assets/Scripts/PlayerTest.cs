using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private float horizontal;
    [SerializeField] private int speed;
    private Rigidbody playerRb;
    private Animator playerAnimator;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Attack();
    }

    void Move()
    {
        horizontal = Input.GetAxis("Horizontal") * Time.deltaTime;
        playerRb.MovePosition(playerRb.position += new Vector3(horizontal,0,0) * speed);
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            playerAnimator.SetBool("boxing",true);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            playerAnimator.SetBool("boxing", false);
        }
    }
}