using Unity.Cinemachine;
using UnityEngine;
using ByteClub.MayorOffice.Players;

namespace ByteClub.MayorOffice.Camera
{
    public class CameraTriggerZones : MonoBehaviour
    {
        //Need to somehow get the current camera? Gonna hard code it.
        [SerializeField] private CinemachineCamera _otherCamera;
        [SerializeField] private CinemachineCamera _triggerCamera;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Player>(out _))
            {
                _triggerCamera.enabled = true;
                _otherCamera.enabled = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<Player>(out _))
            {
                _triggerCamera.enabled = false;
                _otherCamera.enabled = true;
            }
        }
    }
}

