using UnityEngine;

namespace ByteClub.MayorOffice
{
    public class EnvironmentInteractor : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        private IInteractable _interactable;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IInteractable interactable))
            {
                Debug.Log($"TRIGGER ENTERED: {other.name}");
                _interactable = interactable;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            IInteractable interactable = other.GetComponent<IInteractable>();

            if (interactable == _interactable)
            {
                _interactable = null;
            }
        }

        public void Interact()
        {
            if (_interactable != null)
            {
                _interactable.Interact();
            }
        }
    }
}
