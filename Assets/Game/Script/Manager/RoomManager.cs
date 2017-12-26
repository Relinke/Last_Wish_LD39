using System.Collections;
using System.Collections.Generic;
using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public World_1 World1;
    public World_2 World2;
    public World_3 World3;


    [SerializeField] private ProCamera2DRooms _camera2DRooms;
    private int _rommNum = -1;

    void Awake()
    {
        if (!_camera2DRooms)
        {
            _camera2DRooms = FindObjectOfType<ProCamera2DRooms>();
        }
        if (!World1)
        {
            World1 = GameObject.Find("World_1").GetComponent<World_1>();
        }
        if (!World2)
        {
            World2 = GameObject.Find("World_2").GetComponent<World_2>();
        }
        if (!World3)
        {
            World3 = GameObject.Find("World_3").GetComponent<World_3>();
        }
    }

    private void Update()
    {
        if (_rommNum != 2 && !_camera2DRooms.enabled)
        {
            _rommNum = 2;
            EnterRoom(_rommNum);
        }

        if (_camera2DRooms.CurrentRoomIndex != _rommNum)
        {
            _rommNum = _camera2DRooms.CurrentRoomIndex;
            EnterRoom(_rommNum);
        }
    }

    private void EnterRoom(int num)
    {
        if (num == 0)
        {
            World1.EnterRoom();
            World2.LeaveRoom();
            World3.LeaveRoom();
        }
        else if (num == 1)
        {
            World1.LeaveRoom();
            World2.EnterRoom();
            World3.LeaveRoom();
        }
        else if (num == 2)
        {
            World1.LeaveRoom();
            World2.LeaveRoom();
            World3.EnterRoom();
        }
    }
}