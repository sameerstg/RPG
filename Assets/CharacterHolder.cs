using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHolder : MonoBehaviour
{
    internal List<GameObject> charactersGameobjects = new List<GameObject>();
    internal List<Player> players = new List<Player>();
    public static GameObject activeCharacterGO;
    public static int activeCharacterIndex;
    public static Player activePlayerCs;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    PlayerInput playerInput;
    public CoolDown characterChangeCooldown;
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            charactersGameobjects.Add(transform.GetChild(i).gameObject);
            players.Add(charactersGameobjects[i].GetComponent<Player>());
            charactersGameobjects[i].SetActive(false);
        }
        playerInput = GetComponent<PlayerInput>();
        characterChangeCooldown.EndCoolDown();
        SelectCharacter(0);


    }
    private void Update()
    {
        characterChangeCooldown.RunCooldownTime();
    }
    private void OnEnable()
    {
        playerInput.PlayerActions.SelectCharacter1.started +=ctx => SelectCharacter(0);
        playerInput.PlayerActions.SelectCharacter2.started +=ctx => SelectCharacter(1);
        playerInput.PlayerActions.SelectCharacter3.started +=ctx => SelectCharacter(2);
        playerInput.PlayerActions.SelectCharacter4.started +=ctx => SelectCharacter(3);
    }
    public void SelectCharacter(int index)
    {
        if (activeCharacterGO)
        {
            if (index == activeCharacterIndex || characterChangeCooldown.IsCooldown())
            {
                return;
            }
        }
        
        if (activeCharacterGO)
        {
            charactersGameobjects[index].transform.position = activeCharacterGO.transform.position;
        }
        foreach (var item in charactersGameobjects)
        {
            item.SetActive(false);
        }
        charactersGameobjects[index].SetActive(true);
        activeCharacterGO = charactersGameobjects[index];
        activeCharacterIndex = index;
        activePlayerCs = players[index];
        cinemachineVirtualCamera.LookAt = players[index].cameraLookPoint.transform;
        cinemachineVirtualCamera.Follow = players[index].cameraLookPoint.transform;


    }
}
