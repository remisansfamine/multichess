using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

using UnityEngine;
using UnityEngine.Events;


public class Spectator : Client
{
    protected override void InterpretPacket(Packet toInterpret)
    {
        switch (toInterpret.header.type)
        {
            case EPacketType.MOVE_VALIDITY:
                break;

            case EPacketType.TEAM_SWITCH:
                ChessGameMgr.Instance.team = ChessGameMgr.EChessTeam.None;
                break;
            case EPacketType.SPECTATORS_MOVEMENTS:
                ExecuteMovement(toInterpret);
                break;
            default:
                base.InterpretPacket(toInterpret);
                break;
        }
    }
}
