using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private bool _enable = true;
    [SerializeField, Range(0, 0.1f)] private float _Amplitude = 0.015f;
    [SerializeField, Range(0, 30)] private float _frequency = 10.0f;
    [SerializeField] private Transform _camera = null;
    [SerializeField] private Transform _cameraHolder = null;

    private float sinFrequency;
    private float cosFrequency;

    private float _toggleSpeed = 3.0f;
    private Vector3 _startPos;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        // Get the Rigidbody component attached to the same GameObject
        _rigidbody = GetComponent<Rigidbody>();
        _startPos = _camera.localPosition;
    }

    void Update()
    {
        if (!_enable) return;
        CheckMotion();
        ResetPosition();
        _camera.LookAt(FocusTarget());
    }

    private Vector3 FootStepMotion()
    {
        // Calculate head bobbing motion based on time and configured parameters
        Vector3 pos = Vector3.zero;
        pos.y += Mathf.Sin(Time.time * _frequency) * _Amplitude;
        pos.x += Mathf.Cos(Time.time * _frequency / 2) * _Amplitude * 2;
        return pos;
    }

    private void CheckMotion()
    {
        // Check the player's speed and trigger footstep motion if above a certain threshold
        float speed = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z).magnitude;
        if (speed < _toggleSpeed) return;

        PlayMotion(FootStepMotion());
    }

    private void PlayMotion(Vector3 motion)
    {
        // Apply the calculated motion to the camera's local position
        _camera.localPosition += motion;
    }

    private Vector3 FocusTarget()
    {
        // Calculate a target position for the camera to look at
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + _cameraHolder.localPosition.y, transform.position.z);
        pos += _cameraHolder.forward * 15.0f;
        return pos;
    }

    private void ResetPosition()
    {
        // Reset the camera's position to its initial position over time
        if (_camera.localPosition == _startPos) return;
        _camera.localPosition = Vector3.Lerp(_camera.localPosition, _startPos, 1 * Time.deltaTime);
    }
}
