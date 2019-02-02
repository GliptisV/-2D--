using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float _speed, _jumpForce =10;
    [SerializeField] private Bullet _rocket;
    [SerializeField] private Transform _startBullet;
   
    public bool IsForward; 
    private Vector3 _dir;
    private Rigidbody2D _myRg;
    private bool _isGroubded = false;
    [SerializeField] private float _groundDis;
    [SerializeField] private LayerMask _mask;

    private void Start()
    {
        _myRg = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) Fire();
        if (Input.GetButtonDown("Jump")) Jump();

        _dir.x = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;

        if (_dir.x < 0 && !IsForward)
            Flip();

        if (_dir.x > 0 && IsForward)
            Flip();

        transform.position += _dir;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _groundDis, _mask);

        if (hit != false) _isGroubded = true;
        else _isGroubded = false;

        Debug.DrawRay(transform.position, Vector2.down * _groundDis, Color.red);
    }


    private void Fire()
    {

      Bullet bull = Instantiate(_rocket, _startBullet.position, _startBullet.rotation);
      bull.Lunch(1f * Mathf.Sign(transform.localScale.x));
    }

    private void Jump()
    {
        if(_isGroubded)
        _myRg.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
    }

    void Flip()
    {
        IsForward = !IsForward;
 
        Vector3 V = transform.localScale;
        V.x *= -1;
        transform.localScale = V;
    }
}
