using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIBase : MonoBehaviour {


    public void Awake()
    {
        Main.UiInstance.RegistGameObject(transform.name, transform.name, gameObject);
        AddBehaviours(transform);
        AddLongPress(transform);
    }

    /// <summary>
    /// 给Panel下的控件添加UIBehaviour脚本
    /// </summary>
    /// <param name="root"></param>
    private void AddBehaviours(Transform root)
    {
        for (int i = 0; i < root.childCount; i++)
        {
            Transform tmpChild = root.GetChild(i);
            UIBehaviour tmpBehav = tmpChild.GetComponent<UIBehaviour>();
            if (tmpBehav != null) continue;
            if (!transform.name.EndsWith("_n"))
            {
                tmpChild.gameObject.AddComponent<UIBehaviour>();
                if (transform.name.EndsWith("_m")) continue;
            }
            if (tmpChild.childCount > 0)
            {
                AddBehaviours(tmpChild);
            }
        }
    }


    /// <summary>
    /// 给控件添加长按脚本以满足特殊需求
    /// </summary>
    /// <param name="root"></param>
    private void AddLongPress(Transform root)
    {
        for (int i = 0; i < root.childCount; i++)
        {
            Transform tmpChild = root.GetChild(i);
            LongPress tmpBehav = tmpChild.GetComponent<LongPress>();
            if (tmpBehav != null) continue;
            if (!transform.name.EndsWith("_n"))
            {
                tmpChild.gameObject.AddComponent<LongPress>();
                if (transform.name.EndsWith("_m")) continue;
            }
            if (tmpChild.childCount > 0)
            {
                AddBehaviours(tmpChild);
            }
        }
    }

    /// <summary>
    /// 资源加载
    /// </summary>
    /// <param name="Path"></param>
    /// <returns></returns>
    public Object LoadResources(string Path)
    {
        Object tmpObj = Resources.Load(Path);
        return tmpObj;
    }

    public GameObject InitialRes(string path)
    {
        Object tmpObj = LoadResources(path);
        GameObject tmpGameObj = GameObject.Instantiate(tmpObj) as GameObject;
        tmpGameObj.transform.SetParent(GameObject.FindGameObjectsWithTag("MainCanvas")[0].transform);
        return tmpGameObj;
    }

    /// <summary>
    /// 获取Panel
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    public GameObject GetPanel(string panelName)
    {
        return Main.UiInstance.GetGameObject(panelName, panelName);
    }

    /// <summary>
    /// 获取控件
    /// </summary>
    /// <param name="panelName"></param>
    /// <param name="widgetName"></param>
    /// <returns></returns>
    public GameObject GetWidget(string panelName, string widgetName)
    {
        return Main.UiInstance.GetGameObject(panelName, widgetName);
    }

    /// <summary>
    /// 获取控件上挂载的UIBehaviour脚本
    /// </summary>
    /// <param name="panelName"></param>
    /// <param name="widgetName"></param>
    /// <returns></returns>
    public UIBehaviour GetUIBehaviour(string panelName, string widgetName)
    {
        GameObject tmpObj = GetWidget(panelName, widgetName);
        UIBehaviour tmpBehaviour = tmpObj.GetComponent<UIBehaviour>();
        if (tmpBehaviour != null)
        {
            return tmpBehaviour;
        }
        return null;
    }

    /// <summary>
    /// 关闭时清空
    /// </summary>
    void OnDestroy()
    {
        //Debug.Log("字典"+Main.UiInstance.AllMembers.Count);
        //Debug.Log("1111==" + Main.UiInstance.AllMembers[transform.name][transform.name].name);
        Main.UiInstance.UnRegistGameObject(transform.name, transform.name);
        Main.UiInstance.UnRegistPanel(transform.name);
    }

 
    public void AddButtonListener(string panelName, string widgetName, UnityAction action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName,widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddButtonListener(action);
        }
    }

    public void AddButtonListener(string panelName, string widgetName, UnityAction<GameObject> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName); 
        if (uiBehaviour != null)
        {
            uiBehaviour.AddButtonListener(action);
        }
    }

    public void AddToggleListener(string panelName, string widgetName, UnityAction<bool> action) 
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName); ;
        if (uiBehaviour != null)
        {
            uiBehaviour.AddToggleListener(action);
        }
    }


    public void AddInputFieledListener(string panelName, string widgetName, UnityAction<string> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddInputFieledListener(action);
        }
    }


    public void AddPointDownListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddPointDownListener(action);
        }
    }


    public void AddPointUpListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddPointUpListener(action);
        }
    }

    public void AddPointEnterListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddPointEnterListener(action);
        }
    }

    public void AddPointExitListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddPointExitListener(action);
        }
    }


    public void AddPointClickListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddPointClickListener(action);
        }
    }


    public void AddDragListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddDragListener(action);
        }
    }

    public void AddBeginDragListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddBeginDragListener(action);
        }
    }


    public void AddEndDragListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddEndDragListener(action);
        }
    }


    public void AddDropListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddDropListener(action);
        }
    }


    public void AddSelectListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddSelectListener(action);
        }
    }

    public void AddScrollListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddScrollListener(action);
        }
    }


    public void AddMoveListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddMoveListener(action);
        }
    }


    public void AddInitializePotentialDragListenListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddInitializePotentialDragListener(action);
        }
    }

    public void AddSubmitListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddSubmitListener(action);
        }
    }

    public void AddUpdateSelectedListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddUpdateSelectedListener(action);
        }
    }


    public void AddCancelListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddCancelListener(action);
        }
    }

    public void AddDeselectListener(string panelName, string widgetName, UnityAction<BaseEventData> action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddDeselectListener(action);
        }
    }


    public void AddBtnOnPressListener(string panelName, string widgetName, UnityAction action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddButtonLongPressListener(action);
        }
    }


    public void AddBtnOnClickListen(string panelName, string widgetName, UnityAction action)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.AddButtonOnClickListener(action);
        }
    }

    public void OnDestroy(string panelName, string widgetName)
    {
        UIBehaviour uiBehaviour = GetUIBehaviour(panelName, widgetName);
        if (uiBehaviour != null)
        {
            uiBehaviour.OnDestroy();
        }
    }
}
