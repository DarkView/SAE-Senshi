using System;
using UnityEngine;

/// <summary>
/// Controls the players movement and attacks
/// By Nils
/// </summary>
public class PlayerController : MonoBehaviour, IPlayer
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Moves the player Forward
    /// </summary>
    public void MoveBackward()
    {
        transform.Translate(0, 0, (-15f * Time.deltaTime));
    }
    
    /// <summary>
    /// Moves the player Backward
    /// </summary>
    public void MoveForward()
    {
        transform.Translate(0, 0, (15f * Time.deltaTime));
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
