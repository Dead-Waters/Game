using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles : MonoBehaviour
{
    public Vector2 position;
    public Vector2 size = new Vector2(1, 1);
    public bool onFirstLayer = true;
    public Sprite sprite;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        Init();
    }
                                                    
    public void Init()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.sprite = sprite;
        spriteRenderer.size = size;
        transform.localScale = new Vector3(size.x, size.y, 1);


        if (onFirstLayer)
        {
            BoxCollider2D boxCollider2D = gameObject.AddComponent<BoxCollider2D>();
            boxCollider2D.size = size;
        }

        if (position != Vector2.zero)
        {
            transform.position = position;
        }
        else {
            transform.position = new Vector2(transform.position.x, transform.position.y);
        }

        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), onFirstLayer? 0 : -1);
    }
}
