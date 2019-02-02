using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10, _lifetime = 3;
    [SerializeField] private int _damage = 1;
    public Vector2 Dir = new Vector3(1, 0); 

    private void Start()
    {
        Destroy(gameObject, _lifetime);      
    }

    public void Lunch(float num)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * _speed * num, ForceMode2D.Impulse);
    }

    private void Update()
    {
        //transform.position += transform.right * _speed * Time.deltaTime;
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

