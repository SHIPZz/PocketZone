using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DependencyRegister
{
    private IHealth _playerHealth;
    private IHealth _enemyHealth;

    public DependencyRegister()
    {
        _playerHealth = new Health(Constant.PlayerHealth);
        _enemyHealth = new Health(Constant.EnemyHealth);
        DependencyContainer.Register(_enemyHealth);
        DependencyContainer.Register(_playerHealth);
    }

}
