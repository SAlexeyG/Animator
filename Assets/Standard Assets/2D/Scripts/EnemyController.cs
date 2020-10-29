using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private Sprite[] rocks;
    [SerializeField] PhysicsMaterial2D physicMaterial;

    private UnityStandardAssets._2D.PlatformerCharacter2D platformerCharacter2D;
    private float direction = 1f;
    private float timer;

    private void Start()
    {
        platformerCharacter2D =
            GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();

        timer = Time.time;
    }

    private void Update()
    {
        direction *= Physics2D
            .Raycast(point.transform.position, Vector2.down, 0.3f) ? 1 : -1;
        platformerCharacter2D.Move(direction, false, false);

        var hit = Physics2D.Raycast(point.transform.position, Vector2.right, 5f);
        if (hit.collider != null)
        {
            GameObject player = hit.transform.gameObject;
            if (player.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>() && Time.time - timer > 1f)
            {
                DropRock();
                timer = Time.time;
            }
        }
    }

    private void DropRock()
    {
        var obj = new GameObject();
        obj.transform.position = transform.position;

        var renderer = obj.AddComponent<SpriteRenderer>();
        renderer.sprite = rocks[Random.Range(0, rocks.Length)];

        var rigidbody = obj.AddComponent<Rigidbody2D>();
        rigidbody.sharedMaterial = physicMaterial;

        var collider = obj.AddComponent<CircleCollider2D>();
        collider.sharedMaterial = physicMaterial;

        obj.AddComponent<Rock>();

        rigidbody.AddForce(new Vector2(1f, 1f), ForceMode2D.Impulse);
    }
}
