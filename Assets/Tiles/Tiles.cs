using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tiles
{
    public class Tiles : MonoBehaviour
    {
        public Vector2 position;
        public Vector2 size = new Vector2(1, 1);
        public float backgroundLayerPosition;
        public Sprite sprite;

        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (!spriteRenderer)
                spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            spriteRenderer.drawMode = SpriteDrawMode.Sliced;
            spriteRenderer.sprite = sprite;
            spriteRenderer.size = size;
            transform.localScale = new Vector3(size.x, size.y, 1);

            BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();
            if (backgroundLayerPosition == 0 && !boxCollider2D)
            {
                boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
                boxCollider2D.size = size;
            }
            else if (backgroundLayerPosition != 0 && boxCollider2D)
            {
                Destroy(boxCollider2D);
            }

            if (position != Vector2.zero)
            {
                transform.position = position;
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }

            transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), backgroundLayerPosition);
        }
    }
}
