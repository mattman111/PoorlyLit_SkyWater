using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ByteClub.MayorOffice.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private GameInput _input;

        public event Action<Vector2> Move;

        private void Awake()
        {
            _input = new GameInput();
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Move.performed += OnMove;
            _input.Player.Move.canceled += OnMove;
        }

        private void OnDisable()
        {
            _input.Player.Move.performed -= OnMove;
            _input.Player.Move.canceled -= OnMove;

            _input.Disable();
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Move?.Invoke(context.ReadValue<Vector2>());
        }
    }
}
