using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositions : MonoBehaviour
{
    public static bool gameStarted = false;
    public bool lightoff = false;

    [SerializeField] private AudioSource heli;
    [SerializeField] private GameObject lights;
    [SerializeField] private GameObject _light;

    private void Update()
    {
        if (!gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Invoke("Alarm", 1);
                Invoke("Heli", 2);
                Invoke("StartTheGame", 3);
                Invoke("LightOff", 15);
            }
        }

        if (gameStarted)
        {
            transform.Translate(Vector3.forward * 5 * Time.deltaTime);
        }

        if (lightoff)
        {
            _light.transform.Translate(-_light.transform.forward * 7 * Time.deltaTime);
        }
    }


    private void Alarm()
    {
        lights.SetActive(true);
        _light.SetActive(true);
        GetComponent<AudioSource>().Play();
    }

    private void Heli()
    {
        heli.Play();
    }


    private void StartTheGame()
    {
        gameStarted = true;
    }


    private void LightOff()
    {
        lightoff = true;
    }
}
