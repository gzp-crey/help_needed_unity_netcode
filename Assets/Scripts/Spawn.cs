using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Spawn : NetworkBehaviour
{
    [SerializeField]
    Pickup Template;

    [SerializeField]
    int MaxCount;

    private float nextTeleport = 0.0f;
    private const float TeleportTimeout = 3.0f;

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (!IsServer)
            return;

        for (int i = 0; i < MaxCount; i++)
        {
            var pickup = Instantiate(Template, Vector3.zero, Quaternion.identity);
            var netObj = pickup.gameObject.GetComponent<NetworkObject>();
            netObj.Spawn();
            //netObj.TrySetParent(gameObject);
            pickup.Teleport();

            Debug.Log("Spawning pickup");
        }
        nextTeleport = Time.time + TeleportTimeout;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsServer)
            return;

        if (nextTeleport < Time.time)
        {
            // reactivate all the spawn point to pick
            foreach (var pickup in GameObject.FindObjectsOfType<Pickup>())
            //foreach (var pickup in gameObject.GetComponentsInChildren<Pickup>(true))
            {
                Debug.Log("Teleport pickup");
                pickup.Teleport();
            }

            nextTeleport = Time.time + TeleportTimeout;
        }
    }
}
