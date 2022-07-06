using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    [SerializeField] private Transform sirenLamps;
    [SerializeField] private int number = 0;
    Vector3 scale;
    private void Start()
    {
        StartCoroutine(PlaySiren());
        scale = sirenLamps.transform.localScale;
    }

    private IEnumerator PlaySiren()
    {
        while (true && number != 25)
        {
            number++;
            yield return new WaitForSeconds(0.3f);
            scale.x *= -1;
            sirenLamps.transform.localScale = scale;
            yield return new WaitForSeconds(0.3f);
            scale.x *= -1;
            sirenLamps.transform.localScale = scale;
        }
    }
}
