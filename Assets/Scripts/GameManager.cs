using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] DamageableScript player;

    private void Start()
    {
        player.OnHpChange += Player_OnHpChange;
    }

    private void OnDestroy()
    {
        player.OnHpChange -= Player_OnHpChange;
    }

    private void Player_OnHpChange(object sender, float e)
    {
        if (e <= 0)
        {
            Debug.Log("Game End");
        }
    }
}
