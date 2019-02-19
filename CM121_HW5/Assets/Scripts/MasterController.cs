using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterController : MonoBehaviour {

    public Text keysText;

    private int currentKeys;
    private int maxKeys;

    private void Start() {
        currentKeys = 0;
        maxKeys = GameObject.FindGameObjectsWithTag("Key").Length;
        UpdateUI(0);
    }

    public void UpdateUI(int changeValue) {
        currentKeys += changeValue;
        keysText.text = "Keys : " + currentKeys + " / " + maxKeys;
    }

}
