using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    CharacterGameplayUi characterGameplayUi;
    private void Awake()
    {
        characterGameplayUi = GetComponentInChildren<CharacterGameplayUi>();
    }
}
