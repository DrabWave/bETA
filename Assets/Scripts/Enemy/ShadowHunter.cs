using System.Collections;
using UnityEngine;

public class ShadowHunter : MonoBehaviour
{
    // Появляется из затемнённых зон. Если игрок попадает в поле зрения, охотник мгновенно приближается. После атаки исчезает и появляется в другой части станции.

    public Transform[] RandomPointsShadowHunter = new Transform[3];
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

    //IEnumerator Attack()
    //{
    //    isAttack = true;
    //    transform.position = player.position + (player.forward * 4f);

    //    //yield return new WaitForSeconds(4f);

    //    //e.TeleportRand(transform, RandomPointsShadowHunter);
    //    isAttack = false;
    //    yield return null;
    //}
    private void AttackAndTeleport()
    {
        isAttack = true;
        transform.position = player.position + (player.forward * 4f);
        time += Time.deltaTime;
        e.Damage(0.01f);
        
        if (time >= 1.5f)
        {
            e.TeleportRand(transform, RandomPointsShadowHunter);
        }
        isAttack = false;
    }




}
