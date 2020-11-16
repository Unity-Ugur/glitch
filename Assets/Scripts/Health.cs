using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]  int health;
    [SerializeField] GameObject explosionSparkles;
    [SerializeField] float durationOfExplosion = 1f;

    // Start is called before the first frame update

    public int getHealth()
    {
        return health;
    }
    
    public void DamageDeal(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        Debug.Log(health);
        if (health <= 0)
        {
            GameObject explosion = Instantiate(explosionSparkles, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            Destroy(gameObject);
        }
    }
}
