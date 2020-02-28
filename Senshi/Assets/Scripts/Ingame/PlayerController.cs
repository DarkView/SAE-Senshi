using UnityEngine;

/// <summary>
/// Controls the players movement and attacks
/// By Nils
/// </summary>
public class PlayerController : MonoBehaviour, IPlayer
{
    private Animator anim;
    [SerializeField] private float speed;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Moves the player backward using rigidbody
    /// </summary>
    public void MoveBackward()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            var moveDirection = this.transform.rotation * Vector3.right * speed;
            this.transform.Translate(moveDirection * Time.deltaTime);
            anim.Play("Walking Backwards");
        }
    }

    /// <summary>
    /// Moves the player forward using rigidbody
    /// </summary>
    public void MoveForward()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            var moveDirection = this.transform.rotation * Vector3.left * speed;
            this.transform.Translate(moveDirection * Time.deltaTime);
            anim.Play("Walking");
        }
    }
    
    /// <summary>
    /// Moves the player Up
    /// </summary>
    public void MoveUp()
    {
    }
    
    /// <summary>
    /// Moves the player Down
    /// </summary>
    public void MoveDown()
    {
    }
    
    /// <summary>
    /// Makes the player punch with their left hand
    /// </summary>
    public void PunchLeft()
    {
        anim.Play("Punching");
    }
    
    /// <summary>
    /// Makes the player punch with their right hand
    /// </summary>
    public void PunchRight()
    {
        anim.Play("Punching");
    }

}
