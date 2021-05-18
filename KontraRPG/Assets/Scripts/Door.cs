using System;
using Inventory.Items;
using TMPro;
using UnityEngine;
using static Inventory.Inventory;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject _ui;
    
    private Animator _anim;
    private Inventory.Inventory _inventory;
    private bool _closedDoor = true;

    private void Start()
    {
        _inventory = Instance;
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        _ui.SetActive(_closedDoor);
        if (!Input.GetKeyDown(KeyCode.F)) return;
        OpenDoor();
    }
    
    private void OnTriggerExit(Collider other)
    {
        _ui.SetActive(false);
    }

    private void OpenDoor()
    {
        if (_inventory.CheckItemInInventory(new WitchKey()))
        {
            _anim.SetBool("Opened", true);
            _inventory.RemoveItemFromInventory(new WitchKey());
            _closedDoor = false;
        }
    }
}
