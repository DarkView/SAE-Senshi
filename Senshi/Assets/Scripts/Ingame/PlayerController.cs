using System.Collections;
using UnityEngine;

/// <summary>
/// Controls and Animation
/// by Zayarmoe
/// </summary>
public class PlayerController : MonoBehaviour, IPlayer
{
    private Animator anim;
    [SerializeField] private float speed;
    [SerializeField] private bool punchCooldown;
    [SerializeField] private int playerID;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Moves the player forward 
    /// </summary>
    public void MoveForward()
    {
        if (!anim.GetBool("hit"))
        {
            var moveDirection = transform.rotation * Vector3.left * speed;
            transform.Translate(moveDirection * Time.deltaTime);
            switch (playerID)
            {
                case 1:
                    anim.SetBool("walkForward", true);
                    break;
                case 2:
                    anim.SetBool("walkBackward", true);
                    break;
            }
        }
    }

    /// <summary>
    /// Moves the player backward
    /// </summary>
    public void MoveBackward()
    {
        if (!anim.GetBool("hit"))
        {
            var moveDirection = transform.rotation * Vector3.right * speed;
            transform.Translate(moveDirection * Time.deltaTime);
            switch (playerID)
            {
                case 1:
                    anim.SetBool("walkBackward", true);
                    break;
                case 2:
                    anim.SetBool("walkForward", true);
                    break;
            }
        }
    }

    /// <summary>
    /// Makes the player punch with their left hand
    /// </summary>
    public void PunchLeft()
    {
        if (!punchCooldown)
        {
            anim.SetBool("punching", true);
            StartCoroutine(PunchCooldown());
        }
    }

    /// <summary>
    /// Makes the player punch with their right hand
    /// </summary>
    public void PunchRight()
    {
        if (!punchCooldown)
        {
            anim.SetBool("punching",true);
            StartCoroutine(PunchCooldown());
        }
    }

    private IEnumerator PunchCooldown()
    {
        yield return new WaitForSeconds(1f);
        punchCooldown = false;
    }

    public void AnimationReset()
    {
        anim.SetBool("hit", false);
        anim.SetBool("punching", false);
        anim.SetBool("walkForward", false);
        anim.SetBool("walkBackward", false);
    }

    /// <summary>
    /// Moves the player Down
    /// </summary>
    public void MoveDown()
    {
    }

    /// <summary>
    /// Moves the player Up
    /// </summary>
    public void MoveUp()
    {
    }
    
}