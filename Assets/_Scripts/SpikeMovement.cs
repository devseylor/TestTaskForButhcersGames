using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpikeMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f; 
    [SerializeField] private float _startY = -25f;
    [SerializeField] private float _endY = 0f;

    private void Start()
    {
        StartCoroutine(MoveSpike());
    }

    private IEnumerator MoveSpike()
    {
        while (true)
        {
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * _moveSpeed;
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(_startY, _endY, t), transform.position.z);
                yield return null;
            }
            yield return new WaitForSeconds(0.5f); // Add a delay at the top position (optional)
            t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime * _moveSpeed;
                transform.position = new Vector3(transform.position.x, Mathf.Lerp(_endY, _startY, t), transform.position.z);
                yield return null;
            }
            yield return new WaitForSeconds(0.5f); // Add a delay at the bottom position (optional)
        }
    }
}
