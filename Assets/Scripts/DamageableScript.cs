using System;
using UnityEngine;

public class DamageableScript : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float hp;
    [SerializeField]
    private float maxHp = 100;

    public float MaxHp => maxHp;

    public event EventHandler<float> OnHpChange;

    void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        //objUI.SetHpSliderValue(hp / maxHp);

        OnHpChange?.Invoke(this, hp);

        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
