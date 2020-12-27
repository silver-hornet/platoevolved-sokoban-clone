using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public LevelBuilder m_LevelBuilder;
    public GameObject m_NextButton;
    bool m_ReadyForInput;
    Player m_Player;

    void Start()
    {
        m_LevelBuilder.Build();
        m_Player = FindObjectOfType<Player>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize(); // To ensure input has a magnitude of 1
        if (moveInput.sqrMagnitude > 0.5) // Button pressed or held
        {
            if (m_ReadyForInput)
            {
                m_ReadyForInput = false;
                m_Player.Move(moveInput);
                //m_NextButton.SetActive(IsLevelComplete());
            }
        }
        else
        {
            m_ReadyForInput = true;
        }
    }

    public void NextLevel()
    {
        //m_NextButton.SetActive(false);
        m_LevelBuilder.NextLevel();
        //StartCoroutine(ResetSceneASync());
    }

    public void ResetScene()
    {
        //StartCoroutine(ResetSceneASync());
    }
}
