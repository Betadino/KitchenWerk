using UnityEngine;

public interface IPlayerInteractionStates
{
    void OnEnterState(PlayerController player)
    {

    }

    void OnUpdateState(PlayerController player, Collider2D collider)
    {

    }

    void OnExitState(PlayerController player)
    {

    }
}