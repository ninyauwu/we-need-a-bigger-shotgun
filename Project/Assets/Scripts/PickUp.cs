using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField]
    private GameObject _item;
    [SerializeField]
    private Transform _visual;

    private void Start()
    {
        StartCoroutine(PickUpFloatingAnimation());
    }

    private IEnumerator PickUpFloatingAnimation()
    {
        while (true)
        {
            _visual.Rotate(Vector3.up, 60 * Time.deltaTime, Space.World);
            _visual.localPosition = new Vector3(0, 5 + Mathf.Sin(Time.time) * 0.5f, 0);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerController player))
        {
            // Assign item to player
            Debug.Log($"picked up {_item}");

            // Can also create an absract item class Item and
            // make seperate pickups with their own effect when you pick them up
        }
    }
}
