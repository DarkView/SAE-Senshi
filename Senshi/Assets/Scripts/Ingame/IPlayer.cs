/// <summary>
/// Interface used to ensure Playercontroller compatibility
/// By Nils
/// </summary>
public interface IPlayer
{
    void MoveBackward();
    void MoveForward();
    void MoveUp();
    void MoveDown();

    void PunchLeft();
    void PunchRight();
}
