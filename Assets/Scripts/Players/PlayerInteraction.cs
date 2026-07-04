using UnityEngine;

namespace ByteClub.MayorOffice.Players
{
    [RequireComponent(typeof(PlayerInputHandler))]
    [RequireComponent(typeof(EnvironmentInteractor))]
    public class PlayerInteraction : MonoBehaviour
    {
        private PlayerInputHandler _input;
        private EnvironmentInteractor _interactor;

        private void Awake()
        {
            _input = GetComponent<PlayerInputHandler>();
            _interactor = GetComponent<EnvironmentInteractor>();
        }

        private void Update()
        {
            if (_input.InteractPressedThisFrame)
            {
                _interactor.Interact();
            }
        }
    }
}
