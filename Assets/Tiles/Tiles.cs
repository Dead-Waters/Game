using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (!boxCollider2D)
            {
                boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
                boxCollider2D.size = size;
            }
            if (backgroundLayerPosition != 0)
            {
                boxCollider2D.isTrigger = true;
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

        // onMouseDown is only work with left click
        private void OnMouseDown()
        {
            OnBreak();
        }

        public void OnBreak()
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            float distance = Vector2.Distance(player.transform.position, transform.position);
            if (distance < TilesConfig.getInstance().breakDistance)
            {
                Destroy(gameObject);
                NotifyRefreshArround(1);
            }
        }

        public void NotifyRefreshArround(int Distance)
        {
            Tiles[] tiles;
            // search arround tiles with raycast
            tiles = Physics2D.OverlapCircleAll(transform.position, Distance)
                .Select(x => x.GetComponent<Tiles>())
                .Where(x => x != null && x != this)
                .ToArray();
            // debug the overlap circle

            Debug.DrawLine(transform.position, transform.position + new Vector3(Distance, 0, 0), Color.red, 1);
            Debug.DrawLine(transform.position, transform.position + new Vector3(-Distance, 0, 0), Color.red, 1);
            Debug.DrawLine(transform.position, transform.position + new Vector3(0, Distance, 0), Color.red, 1);
            Debug.DrawLine(transform.position, transform.position + new Vector3(0, -Distance, 0), Color.red, 1);

            foreach (Tiles tile in tiles)
                tile.onRefresh();
        }

        public void onRefresh()
        {
            Debug.Log("onRefresh : " + gameObject.name);
        }
    }
}
