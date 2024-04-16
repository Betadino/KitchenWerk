public interface IObjectStates
{
    void OnEnterState(ObjectController obj);
    void OnUpdateState(ObjectController obj);
    void OnExitState(ObjectController obj);
}