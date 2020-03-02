using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// basic damage calculation
/// by Zayarmoe Kyaw
/// </summary>
public class PlayerStats : MonoBehaviour
{
    [Range(0f, 100f)] [SerializeField] public int health = 100;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int damage = 5;

    private bool damageCooldown = false;
    [SerializeField] public float attackCooldowntime = 1;

    public Vector3 DefaultPosition;

    private Animator anim;

    [SerializeField] private GameObject counterOne;
    [SerializeField] private GameObject counterTwo;
    [SerializeField] private GameObject counterThree;
    [SerializeField] private Sprite winCounterSprite;
    
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        DefaultPosition = transform.position;
    }

    private void Update()
    {
        ShowHealthBar();
    }

    public void SetDefaultPosition()
    {
        transform.position = DefaultPosition;
    }

    public void InitWinCount(int i)
    {
        switch (i)
        {
            case 1:
                counterTwo.SetActive(false);
                counterThree.SetActive(false);
                break;
            case 2:
                counterThree.SetActive(false);
                break;
            case 3:
                break;
        }
    }

    public void PrintWinCount(int wins)
    {
        switch (wins)
        {
            case 1:
                counterOne.GetComponent<Image>().sprite = winCounterSprite;
                break;
            case 2:
                counterTwo.GetComponent<Image>().sprite = winCounterSprite;
                break;
            case 3:
                counterThree.GetComponent<Image>().sprite = winCounterSprite;
                break;
        }
    }

    public void StatReset()
    {
        SetDefaultPosition();
        health = 100;
    }

    private void ShowHealthBar()
    {
        healthSlider.value = health;
    }

    private void DamageCalculation(int damageTaken)
    {
        health -= damageTaken;
    }

    private void OnCollisionEnter(Collision other)
    {
        var animEnemy = other.gameObject.GetComponentInChildren<Animator>();
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