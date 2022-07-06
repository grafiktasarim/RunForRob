using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookToPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.LookAt(player);
    }
}
