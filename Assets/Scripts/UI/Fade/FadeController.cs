using UnityEngine;

namespace ByteClub.MayorOffice
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FadeController : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _fadeDuration = 1f;
        [SerializeField] private bool _fadeInOnStart;
        [SerializeField] private bool _destroyOnFadeOutComplete;

        private bool _isFadingOut;
        private bool _isFadingIn;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            if (_fadeInOnStart)
            {
                Color color = _spriteRenderer.color;
                color.a = 0f;
                _spriteRenderer.color = color;
                _isFadingIn = true;
            }
            else
            {
                _isFadingOut = true;
            }
        }

        private void Update()
        {
            if (_fadeDuration <= 0f) return;

            float delta = Time.deltaTime / _fadeDuration;
            Color color = _spriteRenderer.color;

            if (_isFadingIn)
            {
                color.a += delta;
                if (color.a >= 1f)
                {
                    color.a = 1f;
                    _isFadingIn = false;
                }
                _spriteRenderer.color = color;
            }
            else if (_isFadingOut)
            {
                color.a -= delta;
                if (color.a <= 0f)
                {
                    color.a = 0f;
                    _isFadingOut = false;
                    _spriteRenderer.color = color;

                    if (_destroyOnFadeOutComplete)
                        Destroy(gameObject);

                    return;
                }
                _spriteRenderer.color = color;
            }
        }

        public void FadeIn()
        {
            _isFadingIn = true;
            _isFadingOut = false;
        }

        public void FadeOut()
        {
            _isFadingOut = true;
            _isFadingIn = false;
        }
    }
}
