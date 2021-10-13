using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadsController : Singleton<GamePadsController>
{
    public bool isOnMobile;

    bool m_canMoveLeft;
    bool m_canMoveRight;

    public bool CanMoveLeft { get => m_canMoveLeft; set => m_canMoveLeft = value; }
    public bool CanMoveRight { get => m_canMoveRight; set => m_canMoveRight = value; }

    public override void Awake()
    {
        MakeSingleton(false);
    }

    private void Update()
    {
        if (!isOnMobile)
            PCHandle();
    }

    void PCHandle()
    {
        m_canMoveLeft = Input.GetAxisRaw("Horizontal") < 0; // get truc tren ban phim de dieu khien
        m_canMoveRight = Input.GetAxisRaw("Horizontal") > 0;
    }
}
