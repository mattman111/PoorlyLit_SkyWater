using UnityEngine;

namespace ByteClub.MayorOffice
{

    /// Will move interactionIcon logic to seperate script later - Matt
    public class EnvironmentInteractor : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private IconController _icon;
        private IInteractable _interactable;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                Debug.Log($"TRIGGER ENTERED: {other.name}");
                _interactable = interactable;
            }
            _icon.EnableIcon();
        }

        private void OnTriggerExit(Collider other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();

            if (interactable == _interactable)
            {
                _interactable = null;
            }
            _icon.DisableIcon();
        }

        public void Interact()
        {
            if (_interactable != null)
            {
                _interactable.Interact();
            }
            _icon.DisableIcon();
        }
    }
}
