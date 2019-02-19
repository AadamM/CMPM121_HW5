using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public int keyValue;

    private MasterController masterController;

    private void Start() {
        masterController = FindObjectOfType<MasterController>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            masterController.UpdateUI(keyValue);
            Destroy(gameObject);
        }
    }
}
