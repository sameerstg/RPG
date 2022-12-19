using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    internal EnemyManager enemyManager;
    internal CharacterHolder characterHolder;
    private void Awake()
    {
        _instance = this;
        enemyManager = GetComponentInChildren<EnemyManager>();
        characterHolder = GetComponentInChildren<CharacterHolder>();
    }
}
