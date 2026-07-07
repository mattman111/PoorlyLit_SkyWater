using UnityEngine;

namespace ByteClub.MayorOffice.Environment
{
    [RequireComponent(typeof(AudioSource))]
    public class Chest : MonoBehaviour, IInteractable
    {
        private AudioSource _audioSource;
        [SerializeField] private float _openSpeed;
        //The pivot gameobject is a mess, but Idk how to force a custom pivot without moving the box collider???
        [SerializeField] private GameObject _pivot;
        [SerializeField] private Transform _lookToRotation;
        private bool _isOpen;
        private bool _isOpenning;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _isOpen = false;
            _isOpenning = false;
        }
        public void Interact()
        {
            if (!_isOpen && !_isOpenning)
            {
                Debug.Log("Player interacts with chest.");
                _audioSource.Play();
                _isOpenning = true;
            }
            else
            {
                Debug.Log("Chest is already open.");
            }


        }

        void Update()
        {
            if (_isOpenning)
            {
                float angleDiff = Quaternion.Angle(_pivot.transform.rotation, _lookToRotation.rotation);
                if (angleDiff > 0.1f)
                {
                    _pivot.transform.rotation = Quaternion.Lerp(_pivot.transform.rotation, _lookToRotation.rotation, _openSpeed * Time.deltaTime);
                }
                else
                {
                    _pivot.transform.rotation = _lookToRotation.rotation;
                    _isOpenning = false;
                    _isOpen = true;
                }
            }
        }
    }
}
