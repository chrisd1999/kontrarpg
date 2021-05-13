using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMenu : MonoBehaviour
{
    [SerializeField] private GameObject map;
    private bool _mapEnabled = false;
    void Update()
    {
        if (Input.GetButtonDown("Map"))
        {
            _mapEnabled = !_mapEnabled;
        }
        ShowMap();
    }

    private void ShowMap()
    {
        if (_mapEnabled == true)
        {
            map.SetActive(true);
            return;
        }
        map.SetActive(false);
    }
}
