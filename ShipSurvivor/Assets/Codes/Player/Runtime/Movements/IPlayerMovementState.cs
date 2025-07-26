namespace Game.Player
{
    public interface IPlayerMovementState
    {
        void EnterState(PlayerMovement context);
        void ExitState(PlayerMovement context);
        void UpdateState(PlayerMovement context);
    }
}