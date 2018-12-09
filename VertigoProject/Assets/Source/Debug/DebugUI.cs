using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DebugUI : MonoBehaviour
{
    [SerializeField]
    private Text _textInventoryItems;

    [SerializeField]
    private Text _textEquippedItems;

    [SerializeField]
    private Text _textStates;

    [SerializeField]
    private Text _textActiveState;

    [SerializeField]
    private Button _buttonReset;

    private Player _player;

    private void Awake()
    {
        _player = Game.Instance.Player;

        _player.EquipmentManager.OnInventoryChanged += UpdateInventoryItems;
        _player.EquipmentManager.OnEquipmentChanged += (context) => { UpdateEquippedItems(); };
        _player.StateMachine.OnStateChanged += UpdateActiveState;

        _buttonReset.onClick.AddListener(() => { SceneManager.LoadScene(0); });

        UpdateInventoryItems();
        UpdateActiveState(_player.StateMachine.ActiveStateId);
        UpdateStates();
        UpdateEquippedItems();
    }

    private void Update()
    {
        _textActiveState.text = _player.StateMachine.ActiveStateId.ToString();
    }

    private void UpdateInventoryItems()
    {
        UpdateEquippedItems();
        _textInventoryItems.text = string.Empty;
        foreach (InventoryItem inventoryItem in _player.EquipmentManager.Inventory)
        {
            _textInventoryItems.text += string.Format("- {0}{1}", inventoryItem.context.name, Environment.NewLine);
        }
    }

    private void UpdateEquippedItems()
    {
        _textEquippedItems.text = string.Empty;
        foreach(KeyValuePair<AttachmentSlotId, Item> kvp in _player.EquipmentManager.EquippedItems)
        {
            if (kvp.Value != null)
            {
                _textEquippedItems.text += string.Format("{0}{1}", kvp.Value.GetContext().name, Environment.NewLine);
            }
        }
    }

    private void UpdateStates()
    {
        _textStates.text = string.Empty;
        foreach(KeyValuePair<StateId, State> kvp in _player.StateMachine.RegisteredStates)
        {
            _textStates.text += string.Format("- {0}{1}", kvp.Key.ToString(), Environment.NewLine);
        }
    }

    private void UpdateActiveState(StateId stateId)
    {
        
    }
}
