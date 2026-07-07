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
        }

        private void OnEnable()
        {
            if (_startDisabled)
            {
                DisableIcon();
            }
        }

        void Update()
        {

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
