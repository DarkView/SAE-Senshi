using UnityEngine;

/// <summary>
/// Controls the players movement and attacks
/// By Nils
/// </summary>
public class PlayerController : MonoBehaviour, IPlayer
{

    /// <summary>
    /// Moves the player Left
    /// </summary>
    public void MoveLeft()
    {
        Debug.Log("Moving L");
    }
    
    /// <summary>
    /// Moves the player Right
    /// </summary>
    public void MoveRight()
    {
        Debug.Log("Moving R");
    }
    
    /// <summary>
    /// Moves the player Up
    /// </summary>
    public void MoveUp()
    {
        Debug.Log("Moving U");
    }
    
    /// <summary>
    /// Moves the player Down
    /// </summary>
    public void MoveDown()
    {
        Debug.Log("Moving D");
    }
    
    /// <summary>
    /// Makes the player punch with their left hand
    /// </summary>
    public void PunchLeft()
    {
        Debug.Log("Moving PL");
    }
    
    /// <summary>
    /// Makes the player punch with their right hand
    /// </summary>
    public void PunchRight()
    {
        Debug.Log("Moving PR");
    }
}
