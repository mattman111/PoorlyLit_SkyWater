using UnityEngine;

namespace ByteClub.MayorOffice
{
    public class Billboard : MonoBehaviour
    {
        [SerializeField] private BillboardType _billboardType;
        private void LateUpdate()
        {
            switch (_billboardType)
            {
                case BillboardType.LookAtCamera:
                    transform.LookAt(UnityEngine.Camera.main.transform, Vector3.up);
                    break;
                case BillboardType.CameraForward:
                    transform.forward = UnityEngine.Camera.main.transform.forward;
                    break;
            }
        }
    }


    public enum BillboardType { LookAtCamera, CameraForward };
}
