using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    public Camera cam;
    public SteamVR_Input_Sources targSource;
    public SteamVR_Action_Boolean clcikAct;

    private GameObject curObj;
    private PointerEventData data;


    protected override void Awake()
    {
        base.Awake();
        data = new PointerEventData(eventSystem);
    }
    public override void Process()
    {
        data.Reset();
        data.position = new Vector2(cam.pixelWidth / 2, cam.pixelHeight / 2);

        eventSystem.RaycastAll(data, m_RaycastResultCache);
        data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        curObj = data.pointerCurrentRaycast.gameObject;

        m_RaycastResultCache.Clear();

        HandlePointerExitAndEnter(data, curObj);

        if (clcikAct.GetStateDown(targSource))
        {
            ProcessPress(data);
        }

        if (clcikAct.GetStateUp(targSource))
        {
            ProcessRelease(data);
        }

    }

    public PointerEventData GetData()
    {
        return data;
    }
    private void ProcessPress(PointerEventData data)
    {
        data.pointerPressRaycast = data.pointerCurrentRaycast;
        GameObject newPointerpress = ExecuteEvents.ExecuteHierarchy(curObj, data, ExecuteEvents.pointerDownHandler);
        if (newPointerpress == null)
        {
            newPointerpress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(curObj);

        }

        data.pressPosition = data.position;
        data.pointerPress = newPointerpress;
        data.rawPointerPress = curObj;
    }

    private void ProcessRelease(PointerEventData data)
    {
        ExecuteEvents.Execute(data.pointerEnter, data, ExecuteEvents.pointerUpHandler);
        GameObject poinnterUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(curObj);

        if (data.pointerPress == poinnterUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        eventSystem.SetSelectedGameObject(null);

        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;

    }
}