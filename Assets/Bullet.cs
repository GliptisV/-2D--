using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10, _lifetime = 4;
    [SerializeField] private int _damage = 1;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
        transform.position += transform.right * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Health hp = collision.gameObject.GetComponent<Health>();                    
            hp.TakeDamage(_damage);
            Destroy(gameObject);
       }          
    }

}

