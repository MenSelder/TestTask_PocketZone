using UnityEngine;
using UnityEngine.UI;

public class HPBarUI : MonoBehaviour
{    
    [SerializeField] private DamageableScript damageableScript;

    private Slider hpBarSlider;

    private void Awake()
    {
        hpBarSlider = GetComponent<Slider>();
    }

    private void Start()
    {
        damageableScript.OnHpChange += DamageableScript_OnHpChange;
    }

    private void DamageableScript_OnHpChange(object sender, float e)
    {
        hpBarSlider.value = e / damageableScript.MaxHp;
    }
}
