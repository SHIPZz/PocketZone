using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicItem : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private GameObject _image;

    public GameObject Image =>
        _image;

    public int Index =>
        _index;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}
