using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float moveSpeed;
    public float jumpSpeed;
    public float lookSens;

    public float customGravity;

    public GameObject cannon;

    private CharacterController _charCon;
    private Vector3 _moveDir;
    private Camera _mainCam;

    private float _horDir;
    private float _forDir;
    private float _verDir;

    private float _horLook;
    private float _verLook;

    void Start() {
        _charCon = GetComponent<CharacterController>();
        _mainCam = GetComponentInChildren<Camera>();
    }


    void Update() {
        _horDir = Input.GetAxis("Horizontal");
        _forDir = Input.GetAxis("Vertical");

        if (!_charCon.isGrounded) {
            _verDir -= customGravity;
        } else {
            _verDir = 0f;

            if (Input.GetButton("Jump")) {
                _verDir += jumpSpeed;
            }
        }

        _horLook = Input.GetAxis("Mouse X");
        _verLook = Input.GetAxis("Mouse Y");

        /*
        if (_forDir > 0f) {
            cannon.GetComponent<Animation>().Play();
        } else {
            cannon.GetComponent<Animation>().Stop();
        }*/

        transform.Rotate(new Vector3(0f, _horLook * lookSens * Time.deltaTime, 0f));
        _mainCam.transform.Rotate(new Vector3(-(_verLook * lookSens * Time.deltaTime), 0f, 0f));

        _moveDir = transform.TransformDirection(_horDir, _verDir, _forDir);

        _charCon.Move(_moveDir * moveSpeed * Time.deltaTime);
    }
}
