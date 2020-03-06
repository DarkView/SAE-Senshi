using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// basic damage calculation
/// by Zayarmoe, Leon
/// </summary>
public class PlayerStats : MonoBehaviour
{
    /// <summary>
    /// vector3 representing the spawn point of the player ; public
    /// </summary>
    public Vector3 DefaultPosition;
    /// <summary>
    /// animator object to control the animation parameters and animations ; private
    /// </summary>
    private Animator anim;

    /// <summary>
    /// int value representing the health of the player ; clamped between 0 and 100 ; serialized public 
    /// </summary>
    [Range(0f, 100f)] [SerializeField] public int health;
    /// <summary>
    /// slider object to display the health of the player ; serialized private
    /// </summary>
    [SerializeField] private Slider healthSlider;

    /// <summary>
    /// float value representing the cooldown time of the player attacks ; serialized private 
    /// </summary>
    [SerializeField] private float attackCooldownTime = 1;
    /// <summary>
    /// bool value representing whether you can take damage or not ; private
    /// </summary>
    private bool damageCooldown = false;
    /// <summary>
    /// int value representing the amount of damage the player deals ; serialized private
    /// </summary>
    [SerializeField] private int damage = 5;
    
    /// <summary>
    /// gameObject containing the first win counter icon ; serialized private
    /// </summary>
    [SerializeField] private GameObject counterOne;
    /// <summary>
    /// gameObject containing the second win counter icon ; serialized private
    /// </summary>
    [SerializeField] private GameObject counterTwo;
    /// <summary>
    /// gameObject containing the third win counter icon ; serialized private
    /// </summary>
    [SerializeField] private GameObject counterThree;
    /// <summary>
    /// sprite to change counter into for each win the player has ; serialized private 
    /// </summary>
    [SerializeField] private Sprite winCounterSprite;
    
    /// <summary>
    /// start function called every frame ; get animator component and DefaultPosition ; private
    /// </summary>
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        DefaultPosition = transform.position;
    }

    /// <summary>
    /// update function called every frame ; calls ShowHealthBar() ; private
    /// </summary>
    private void Update()
    {
        ShowHealthBar();
    }

    /// <summary>
    /// method to set the player position to the default spawn position ; private 
    /// </summary>
    private void SetDefaultPosition()
    {
        transform.position = DefaultPosition;
    }

    /// <summary>
    /// method to set how many counters are needed for the fight ; public 
    /// </summary>
    /// <param name="i">needed counters</param>
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

    /// <summary>
    /// method to change the counter into the sprite for win counters ; public 
    /// </summary>
    /// <param name="wins">current wins</param>
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

    /// <summary>
    /// method to reset the players stats ; public 
    /// </summary>
    public void StatReset()
    {
        SetDefaultPosition();
        health = 100;
    }

    /// <summary>
    /// method to display the current health on the slider healthSlider ; private
    /// </summary>
    private void ShowHealthBar()
    {
        healthSlider.value = health;
    }

    /// <summary>
    /// method to reduce the health by the damage taken ; private
    /// </summary>
    /// <param name="damageTaken">amount of taken damage</param>
    private void DamageCalculation(int damageTaken)
    {
        health -= damageTaken;
    }

    /// <summary>
    /// OnCollisionEnter function called when this collider collides with another collider ; hit detection for player ; private
    /// </summary>
    /// <param name="other">the collider that is collided with</param>
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
            StartCoroutine(DamageCooldown(attackCooldownTime));
        }
    }

    /// <summary>
    /// method to set being able to get damaged on cooldown ; private
    /// </summary>
    /// <param name="cooldownTime">duration of the damage cooldown</param>
    /// <returns></returns>
    private IEnumerator DamageCooldown(float cooldownTime)
    {
        yield return new WaitForSecondsRealtime(cooldownTime);
        anim.SetBool("hit", false);
        damageCooldown = false;
    }
}