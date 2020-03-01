using System.Collections;
using TMPro;
using UnityEngine;

/// <summary>
/// Controls the players movement and attacks
/// By Nils
/// </summary>
public class PlayerController : MonoBehaviour, IPlayer
{
    private Animator anim;
    [SerializeField] private float speed;
    private bool cdRightPunch;
    private bool cdLeftPunch;

    private void Start()
    {
        cdRightPunch = true;
        cdLeftPunch = true;
        anim = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Moves the player backward using rigidbody
    /// </summary>
    public void MoveBackward()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Punching") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
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
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Punching") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Walking Backwards"))
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
        if (cdLeftPunch)
        {
            cdLeftPunch = false;
            anim.Play("Punching");
            StartCoroutine(CooldownLeftPunch());
        }
    }
    
    /// <summary>
    /// Makes the player punch with their right hand
    /// </summary>
    public void PunchRight()
    {
        if (cdRightPunch)
        {
            cdRightPunch = false;
            anim.Play("Punching");
            StartCoroutine(CooldownRightPunch());
        }
    }

    private IEnumerator CooldownRightPunch()
    {
        yield return new WaitForSeconds(2);
        cdRightPunch = true;
    }

    private IEnumerator CooldownLeftPunch()
    {
        yield return new WaitForSeconds(2);
        cdLeftPunch = true;
    }

}
