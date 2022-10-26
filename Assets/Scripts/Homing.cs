using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float force;
    [SerializeField] private float rotationForce;
    [SerializeField] private float secondsBeforeHoming;
    [SerializeField] private float launchForce;
    private bool shouldFollow;
    private Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(WaitBeforeHoming());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (shouldFollow)
        {
            if(target != null)
            {
                Vector3 direction = target.position - rb.position;
                direction.Normalize();
                Vector3 rotationAmount = Vector3.Cross(transform.forward, direction);
                rb.angularVelocity = rotationAmount * rotationForce;
                rb.velocity = transform.forward * force;
            }
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }

    private IEnumerator WaitBeforeHoming()
    {
        rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
        yield return new WaitForSeconds(secondsBeforeHoming);
        shouldFollow = true;
    }
}
