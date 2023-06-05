using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;
    private GameObject Katana;
    private GameObject Dagger;
    public GameObject DelayVisual;
    public bool attackBlocked;
    public bool changedBlocked;
    public bool startdelay;
    public int delay;
    public int scoredelay = 0;
    private Vector3 scaleChange;

    void Start()
    {
        Katana = GameObject.FindWithTag("katana");
        Dagger = GameObject.FindWithTag("dagger");
        //InvokeRepeating("StartDelay", 1, 1);
    }

    private void Update()
    {
        if(attackBlocked == false)
        {
            Attack();
        }

        //CircleZoneAttack();
        // if(startdelay == true)
        // {
        //     StartCoroutine(StartDelay());
        // }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    // private void CircleZoneAttack()
    // {
    //     scaleChange = new Vector3(attackRange - 5.3f, attackRange - 5.3f, 0);
    //     Circle.transform.localScale = scaleChange;
    // }

    public void Attack()
    {
        if(attackBlocked == false)
        {
            if(Input.GetMouseButton(0))
            {
                if(Dagger.activeSelf == true)
                {
                    anim.SetTrigger("attackdagger");
                }
                else
                {
                    anim.SetTrigger("attackkatana");
                }
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                }
                attackBlocked = true;
                changedBlocked = true;
                startdelay = true;
                DelayVisual.SetActive(false);
                StartCoroutine(DelayAttack());
                
            }
        }
    }

    public void StartDelay()
    {
        if(startdelay == true)
        {
            scoredelay += 1;
            if(scoredelay >= delay)
            {
                startdelay = false;
                scoredelay = 0;
            }
        }
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
        changedBlocked = false;
        DelayVisual.SetActive(true);
    }

    // private IEnumerator StartDelay()
    // {
    //     yield return new WaitForSeconds(1);
    //     scoredelay ++;
    //     if(scoredelay >= delay)
    //     {
    //         startdelay = false;
    //     }
    // }
}
