namespace ByteClub.MayorOffice.Players
{
    public class PlayerData
    {
        public PlayerState PlayerState { get; private set; } = PlayerState.Idle;
        public bool IsInteracting { get; private set; }

        public void ChangeState(PlayerState state) => PlayerState = state;
        public void SetInteracting(bool value) => IsInteracting = value;
    }
}
