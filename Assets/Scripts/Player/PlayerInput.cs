using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _fireRate = 0.1f;

    private float _fireTimer = 0f;
    
    private void Update()
    {
        _fireTimer += Time.deltaTime;

        if (Input.GetMouseButton(0) && _fireTimer >= _fireRate)
        {
            _weapon.Shoot();
            _fireTimer = 0f;
        }
    }
}
