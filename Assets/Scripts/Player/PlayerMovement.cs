using UnityEngine;

namespace ByteClub.MayorOffice.Player
{
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _playerMoveSpeed;

        private PlayerInputHandler _input;
        private Vector2 _moveInput;

        private void Awake()
        {
            _input = GetComponent<PlayerInputHandler>();
        }

        private void OnEnable()
        {
            _input.Move += OnMove;
        }

        private void OnDisable()
        {
            _input.Move -= OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            _moveInput = direction;
        }

        private void Update()
        {
            Vector3 move = new Vector3(_moveInput.x, 0f, _moveInput.y);
            transform.Translate(move * (_playerMoveSpeed * Time.deltaTime));
        }
    }
}
