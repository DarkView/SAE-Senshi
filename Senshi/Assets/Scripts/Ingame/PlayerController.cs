using System.Collections;
using UnityEngine;

/// <summary>
/// Controls and Animations for players 
/// by Zayarmoe, Leon
/// </summary>
public class PlayerController : MonoBehaviour, IPlayer
{
    /// <summary>
    /// animator object to control the players animations ; private 
    /// </summary>
    private Animator anim;
    /// <summary>
    /// float value representing the speed of the player ; serialized private
    /// </summary>
    [SerializeField] private float speed;
    /// <summary>
    /// bool value representing whether punching is on cooldown or not ; serialized private 
    /// </summary>
    [SerializeField] private bool punchCooldown;
    /// <summary>
    /// int value representing which player for movement and animations ; serialized private 
    /// </summary>
    [SerializeField] private int playerID;

    /// <summary>
    /// start function called every frame ; get the animator component ; private 
    /// </summary>
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Moves the player forward dependent on rotation ; players animation depending on playerID ; public 
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
    /// Moves the player backward dependent on rotation ; players animation depending on playerID ; public 
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
    /// Makes the player punch with their left hand ; plays the punch animation ; sets punch on cooldown ; public 
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
    /// Makes the player punch with their right hand ; plays the punch animation ; sets punch on cooldown ; public 
    /// </summary>
    public void PunchRight()
    {
        if (!punchCooldown)
        {
            anim.SetBool("punching",true);
            StartCoroutine(PunchCooldown());
        }
    }

    /// <summary>
    /// coroutine to set punch on cooldown ; private 
    /// </summary>
    /// <returns>waits one second</returns>
    private IEnumerator PunchCooldown()
    {
        yield return new WaitForSeconds(1f);
        punchCooldown = false;
    }

    /// <summary>
    /// resets all animator parameters for player animator ; public 
    /// </summary>
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