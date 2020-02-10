using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface used to ensure Playercontroller compatibility
/// By Nils
/// </summary>
public interface IPlayer
{
    void MoveLeft();
    void MoveRight();
    void MoveUp();
    void MoveDown();

    void PunchLeft();
    void PunchRight();
}
