using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFall : MonoBehaviour
{
    [SerializeField] private Sprite[] rocks;
    [SerializeField] private float distance;
    [SerializeField] PhysicsMaterial2D physicMaterial;

    [SerializeField] private float interval = 0.7f;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);

            var obj = new GameObject();
            obj.transform.SetParent(transform);

            var renderer = obj.AddComponent<SpriteRenderer>();
            renderer.sprite = rocks[Random.Range(0, rocks.Length)];

            obj.transform.position = new Vector2(Random.Range(this.transform.position.x - distance, this.transform.position.x + distance), transform.position.y);

            var rigidbody = obj.AddComponent<Rigidbody2D>();
            rigidbody.sharedMaterial = physicMaterial;

            var collider = obj.AddComponent<CircleCollider2D>();
            collider.sharedMaterial = physicMaterial;

            obj.AddComponent<Rock>();
        }
    }

}
