using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField] private float horizontal;
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
        playerRb.MovePosition(this.transform.position += new Vector3(horizontal,0,0));
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