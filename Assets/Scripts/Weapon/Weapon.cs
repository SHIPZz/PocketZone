using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private int _bulletsCount;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _bulletSpeed = 10f;

    private ObjectPool<GameObject> _objectPool;

    private void Start()
    {
        _objectPool = new ObjectPool<GameObject>(() => Instantiate(_bulletPrefab), _bulletsCount);
    }

    public void Shoot()
    {
        GameObject bullet = _objectPool.Get();
        
        if (bullet == null)
        {
            Debug.LogWarning("Пуля не доступна. Увеличьте размер пула.");
            return;
        }

        bullet.transform.position = _shootPoint.position;
        bullet.transform.rotation = _shootPoint.rotation;

        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = (_shootPoint.right * _bulletSpeed);
        
        
    }
}
