using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float rotationSpeed = 300f;
    [SerializeField] float damage = 50f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);        
        transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
                
    }

}
