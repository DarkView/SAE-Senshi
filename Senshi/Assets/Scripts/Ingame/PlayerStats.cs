using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// basic damage calculation
/// by Zayarmoe Kyaw
/// </summary>
public class PlayerStats : MonoBehaviour
{
    [Range(0f,100f)]
    [SerializeField] private int health = 100;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int damage = 5;
    private bool damageCooldown = false;
    [SerializeField] private float attackCooldowntime = 1;

    private void Update()
    {
        ShowHealthbar();
    }

    private void ShowHealthbar()
    {
        healthSlider.value = health;
    }

    private void DamageCalculation(int damagetaken)
    {
        this.health -= damagetaken;
    }
     
    private void OnCollisionEnter(Collision other)
    {
        //other.gameObject.CompareTag("Attackcollider")
        if (true)
        {
            if (!damageCooldown)
            {
                DamageCalculation(other.gameObject.GetComponent<PlayerStats>().damage);
                damageCooldown = true;
            }
            else
            {
                StartCoroutine(DamageCooldown(attackCooldowntime));
            }
        }
    }

    private IEnumerator DamageCooldown(float cooldowntime)
    {
        yield return new WaitForSecondsRealtime(cooldowntime);
        damageCooldown = false;
    }
}
