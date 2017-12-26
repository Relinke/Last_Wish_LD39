using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;

    public enum EventType
    {
        START_GAME,
        SHOW_FALL_BACKGROUND,
        HIDE_FALL_BACKGROUND
    }

    private void Awake()
    {
        instance = this;
    }

    public delegate void EventBase(GameObject sender, EventType eventInfo);

    public void OnNotify(GameObject sender, EventType eventInfo)
    {
        Debug.Log(eventInfo.ToString());
        switch (eventInfo)
        {
            case EventType.START_GAME:
                break;
            case EventType.SHOW_FALL_BACKGROUND:
                FallBGManager.instance.ShowBackground(true);
                break;
            case EventType.HIDE_FALL_BACKGROUND:
                FallBGManager.instance.ShowBackground(false);
                break;
        }
    }
}