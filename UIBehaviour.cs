using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour {

    private UIBase tmpBase;

    void Awake()
    {
        tmpBase = transform.GetComponentInParent<UIBase>();
        Main.UiInstance.RegistGameObject(tmpBase.name, transform.name, gameObject);
    }

    public void AddButtonListener(UnityAction action)
    {
        Button tmpButton = transform.GetComponent<Button>();
        if (tmpButton != null)
        {
            tmpButton.onClick.AddListener(action);
        }
    }

    //长按
    public void AddButtonLongPressListener(UnityAction action)
    {
        LongPress tmpLong = transform.GetComponent<LongPress>();
        if (tmpLong != null)
        {
            tmpLong.onLongPress.AddListener(action);
        }

    }

    //短按点击
    public void AddButtonOnClickListener(UnityAction action)
    {
        LongPress tmpLong = transform.GetComponent<LongPress>();
        if (tmpLong != null)
        {
            tmpLong.onClick.AddListener(action);           
        }

    }


    /// <summary>
    /// 把按钮以GameObject形式返回的方法
    /// </summary>
    /// <param name="action"></param>
    public void AddButtonListener(UnityAction<GameObject> action)
    {
        Button tmpButton = transform.GetComponent<Button>();
        if (tmpButton != null)
        {
            tmpButton.onClick.AddListener(delegate () {
                action(tmpButton.gameObject);
            });
        }
    }




    public void AddToggleListener(UnityAction<bool> action)
    {
        Toggle tmpToggle = transform.GetComponent<Toggle>();
        if (tmpToggle != null)
        {
            tmpToggle.onValueChanged.AddListener(action);
        }
    }


    public void AddInputFieledListener(UnityAction<string> action)
    {
        InputField tmpInput = transform.GetComponent<InputField>();
        if (tmpInput != null)
        {
            tmpInput.onEndEdit.AddListener(action);
        }
    }

    public void AddPointDownListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.PointerDown;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);

    }


    public void AddPointUpListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.PointerUp;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);

    }

    public void AddPointEnterListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.PointerEnter;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);

    }

    public void AddPointExitListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.PointerExit;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }


    public void AddPointClickListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.PointerClick;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }

    public void AddDragListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.Drag;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);

    }


    public void AddBeginDragListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.BeginDrag;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);

    }


    public void AddEndDragListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.EndDrag;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);

    }


    public void AddDropListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.Drop;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);

    }

    public void AddSelectListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.Select;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);

    }



    public void AddScrollListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.Scroll;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }


    public void AddMoveListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.Move;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }

    public void AddInitializePotentialDragListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.InitializePotentialDrag;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }



    public void AddSubmitListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.Submit;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }


    public void AddUpdateSelectedListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.UpdateSelected;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }

    public void AddCancelListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.Cancel;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }


    public void AddDeselectListener(UnityAction<BaseEventData> action)
    {
        EventTrigger tmpTrigger = transform.GetComponent<EventTrigger>();
        if (tmpTrigger == null)
            tmpTrigger = gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        UnityAction<BaseEventData> callBack = new UnityAction<BaseEventData>(action);
        entry.eventID = EventTriggerType.Deselect;

        entry.callback = new EventTrigger.TriggerEvent();
        entry.callback.AddListener(action);

        tmpTrigger.triggers.Add(entry);
    }


    public void OnDestroy()
    {        
        Main.UiInstance.UnRegistGameObject(tmpBase.name,transform.name);
    }

}
