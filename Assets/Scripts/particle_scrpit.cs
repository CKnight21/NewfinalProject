using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particle_scrpit : MonoBehaviour
{
    public GameObject triggerParticle;
    public GameObject collisionParticle;

    //Gets excuted when something enters this trigger, or when object enters a trigger.
    private void OnTriggerEnter(Collider other)
    {
        if (triggerParticle != null)
        {
            //The triggerParticle will be spawned at the loaction of this object
            //with the same rotation as this object
            Instantiate(triggerParticle, this.transform.position, this.transform.rotation);
        }
    }

    //Gets executed when something collides with this object
    private void OnCollisionEnter(Collision collision)
    {
        if (collisionParticle != null)
        {
            Instantiate(collisionParticle, collision.contacts[0].point, this.transform.rotation);

        }
    }
}