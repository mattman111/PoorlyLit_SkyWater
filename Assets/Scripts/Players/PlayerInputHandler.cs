using UnityEngine;
using UnityEngine.InputSystem;

namespace ByteClub.MayorOffice.Players
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private GameInput _input;

        public Vector2 MoveInput { get; private set; }
        public bool InteractPressedThisFrame { get; private set; }

        private void Awake()
        {
            _input = new GameInput();
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Move.performed += OnMove;
            _input.Player.Move.canceled += OnMove;

            _input.Player.Interact.performed += OnInteract;
        }

        private void OnDisable()
        {
            _input.Player.Move.performed -= OnMove;
            _input.Player.Move.canceled -= OnMove;

            _input.Player.Interact.performed -= OnInteract;

            _input.Disable();
        }

        private void LateUpdate()
        {
            InteractPressedThisFrame = false;
        }

        private void OnMove(InputAction.CallbackContext context) => MoveInput = context.ReadValue<Vector2>();
        private void OnInteract(InputAction.CallbackContext context) => InteractPressedThisFrame = true;
    }
}
