using UnityEngine;

public interface IOvenState
{
    void OnEnterState(OvenController oc);
    void OnUpdateState();
    void OnExitState();
}