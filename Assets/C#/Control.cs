using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float _speed, _jumpForce =10;
    [SerializeField] private  GameObject _rocket;
    [SerializeField] private Transform _startBullet;
    
    private Vector3 dir;
    private Rigidbody2D myRg;

    private void Start()
    {
        myRg = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) Fire();
        if (Input.GetButtonDown("Jump")) Jump();

        dir.x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        transform.position += dir;
    }

    private void Fire()
    {
        Instantiate(_rocket, _startBullet.position, _startBullet.rotation);
    }

    private void Jump()
    {
        myRg.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }



}
