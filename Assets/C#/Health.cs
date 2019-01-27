using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health = 2;

    public void TakeDamage(int dmg)
    {
        _health -= dmg;

        if (_health <= 0)
            Destroy(gameObject);
    }
}
