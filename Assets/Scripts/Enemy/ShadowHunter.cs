using System.Collections;
using UnityEngine;

public class ShadowHunter : MonoBehaviour
{
    // Появляется из затемнённых зон. Если игрок попадает в поле зрения, охотник мгновенно приближается. После атаки исчезает и появляется в другой части станции.

    public Transform[] RandomPointsShadowHunter = new Transform[13];
    public Transform player;
    public float distanceForAttack = 10;
    public bool isAttack;
    public Enemies e;
    public float distanceToPlayer;
    public float time;


    void Start()
    {
        isAttack = false;
    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < distanceForAttack)
        {
            AttackAndTeleport();
        }
    }

    private void AttackAndTeleport()
    {

        Vector3 attackPos = player.position + (player.forward * 4f);
        attackPos.y = transform.position.y;
        transform.position = attackPos;
        time += Time.deltaTime;
        if (!isAttack)
        {
            StartCoroutine(Attack());
        }
        
        if (time >= 1f)
        {
            e.TeleportRand(transform, RandomPointsShadowHunter);
            time = 0;
        }
    }


    private IEnumerator Attack()
    {
        isAttack = true;
        e.Damage(0.5f);
        yield return new WaitForSeconds(2f);
        isAttack = false;
    }

}
