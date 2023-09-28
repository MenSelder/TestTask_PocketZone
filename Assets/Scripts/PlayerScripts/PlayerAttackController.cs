using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    [SerializeField] private AmmoItemSO ammoItemSO;

    private float cd = 1f;
    private float currentCd = 0;

    private float bulletSpeed = 10f;

    List<Transform> targetsList = new List<Transform>();

    private void Start()
    {
        PlayerController.Instance.OnAttackEvent += PlayerController_OnAttackEvent;
    }

    private void OnDestroy()
    {
        PlayerController.Instance.OnAttackEvent -= PlayerController_OnAttackEvent;
    }

    private void PlayerController_OnAttackEvent(object sender, EventArgs e) => OnAttack();

    private void OnAttack()
    {
        if (currentCd > 0)
            return;

        currentCd = cd;
        Attack();
    }

    private void Update()
    {
        if (currentCd > 0)
        {
            currentCd -= Time.deltaTime;
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyAI enemyAI;
        if (collision.TryGetComponent(out enemyAI))
        {
            targetsList.Add(enemyAI.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyAI enemyAI;
        if (collision.TryGetComponent(out enemyAI))
        {
            targetsList.Remove(enemyAI.transform);
        }
    }

    private void Attack()
    {
        if (targetsList.Count <= 0) return;

        if (!InventorySystem.Instance.ItemsDict.ContainsKey(ammoItemSO)) return;

        InventorySystem.Instance.Remove(ammoItemSO);

        int lastIndex = targetsList.Count - 1;
        Transform target = targetsList[lastIndex];

        var bullet = Instantiate(ammoItemSO.projectilePrefab, transform.position, Quaternion.identity);

        Vector2 direction = (target.position - transform.position).normalized;
        
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
