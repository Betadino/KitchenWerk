
using UnityEngine;

public class OvenStatesHandler
{
    private IOvenState currentOvenState;

    public void SetState(IOvenState stateToSet, OvenController oc )
    {
        if(currentOvenState != null)
        {
            currentOvenState.OnExitState();
        }
        currentOvenState = stateToSet;

        if(currentOvenState != null)
        {
            currentOvenState.OnEnterState(oc);
        }

    }

     public void Update()
    {
        currentOvenState.OnUpdateState();
    }
}