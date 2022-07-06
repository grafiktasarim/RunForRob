using UnityEngine;

public class Police_Rope : MonoBehaviour
{
    [SerializeField] private Transform point;
    [SerializeField] private Transform police;

    [SerializeField] private bool now;

    private void Update()
    {
        if (now)
        {
            police.transform.localPosition = Vector3.Lerp(police.transform.localPosition, point.localPosition, 2 * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            now = true;
            GetComponent<AudioSource>().Play();
        }
    }
}
