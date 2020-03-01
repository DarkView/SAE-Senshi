using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// basic damage calculation
/// by Zayarmoe Kyaw
/// </summary>
public class PlayerStats : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] public int health = 100;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int damage = 5;

    private bool damageCooldown = false;
    [SerializeField] public float attackCooldowntime = 1;

    public Vector3 DefaultPosition;

    private Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        DefaultPosition = this.transform.position;
    }

    private void Update()
    {
        ShowHealthBar();
    }

    public void SetDefaultPosition()
    {
        this.transform.position = DefaultPosition;
    }

    private void ShowHealthBar()
    {
        healthSlider.value = health;
    }

    private void DamageCalculation(int damageTaken)
    {
        this.health -= damageTaken;
    }

    private void OnCollisionEnter(Collision other)
    {
        Animator animEnemy = other.gameObject.GetComponentInChildren<Animator>();
        if (!damageCooldown && animEnemy.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            DamageCalculation(other.gameObject.GetComponentInChildren<PlayerStats>().damage);
            damageCooldown = true;
            anim.SetBool("hit", true);
        }
        else
        {
            StartCoroutine(DamageCooldown(attackCooldowntime));
        }
    }

    private IEnumerator DamageCooldown(float cooldownTime)
    {
        yield return new WaitForSecondsRealtime(cooldownTime);
        anim.SetBool("hit", false);
        damageCooldown = false;
    }
}
