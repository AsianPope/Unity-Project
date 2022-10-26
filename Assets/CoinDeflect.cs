using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDeflect : MonoBehaviour
{
    [SerializeField] private GameObject mob;
    [SerializeField] private float invincibilityDurationSeconds;
    private bool isInvincible;

    // Start is called before the first frame update
    void Start()
    {
        isInvincible = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(delta.Time == invincibilityDurationSeconds)
            isInvincible = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isInvincible)
        {
            if (mob != null)
            {
                Vector3 direction = mob.position - rb.position;
                direction.Normalize();
                Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
                rb.angularVelocity = rotationAmount * rotationForce;
                rb.velocity = transform.forward * force;
            }
        }
    }
}
