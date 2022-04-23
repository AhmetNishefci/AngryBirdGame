using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explosionParticlePrefab;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.collider.GetComponent<Bird>();
        if (bird != null)
        {
            Instantiate(_explosionParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }

        Enemy Enemy = collision.collider.GetComponent<Enemy>();
        if (Enemy != null)
        {
            return;
        }

        if(collision.contacts[0].normal.y < -0.5)
        {
            Instantiate(_explosionParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
    }
}
