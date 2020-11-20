using NaughtyAttributes;
using UnityEngine;

public class DogStates : MonoBehaviour
{
    [SerializeField, ReadOnly] private string currentStateName;
    public StateMachine stateMachine;

    #region States

    public IdleState idleState;
    public ChasingState chasingState;

    #endregion

    public void Initialize(Dog dog)
    {
        stateMachine = gameObject.AddComponent<StateMachine>();
        idleState.Initialize(dog, stateMachine);
        chasingState.Initialize(dog, stateMachine);

        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        currentStateName = stateMachine.CurrentState.ToString();
        stateMachine.CurrentState.HandleInput();

        stateMachine.CurrentState.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.CurrentState.FixedUpdate();
    }
}