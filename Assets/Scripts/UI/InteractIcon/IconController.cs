using UnityEngine;


namespace ByteClub.MayorOffice
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class IconController : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private bool _startDisabled;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_startDisabled)
            {
                DisableIcon();
            }
        }

        public void DisableIcon()
        {
           _spriteRenderer.enabled = false;
        }

        public void EnableIcon()
        {
            _spriteRenderer.enabled = true;
        }
    }
}
