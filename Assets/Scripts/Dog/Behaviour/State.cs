
public abstract class State 
{
    protected Dog dog;
    protected StateMachine stateMachine;

    public State Initialize(Dog dog,StateMachine stateMachine) {
        this.dog = dog;
        this.stateMachine = stateMachine;

        return this;
    }

    public virtual void Enter() {
       
    }

    public virtual void HandleInput() {

    }

    public virtual void Update() {

    }

    public virtual void FixedUpdate() {

    }

    public virtual void Exit() {

    }
}
