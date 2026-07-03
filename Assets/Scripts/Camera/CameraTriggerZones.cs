using Unity.Cinemachine;
using UnityEngine;

namespace ByteClub.MayorOffice.Camera
{
    public class CameraTriggerZones : MonoBehaviour
    {
        //Need to somehow get the current camera? Gonna hard code it.
        [SerializeField] private CinemachineCamera _otherCamera;
        [SerializeField] private CinemachineCamera _triggerCamera;
        [SerializeField] private GameObject _player;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == _player)
            {
                _triggerCamera.enabled = true;
                _otherCamera.enabled = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject == _player)
            {
                _triggerCamera.enabled = false;
                _otherCamera.enabled = true;
            }
        }
    }
}

