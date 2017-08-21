using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager 
{

    GameObject mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
    //声明两个字典，用于存储Panel以及Panel下的控件
    private Dictionary<string, Dictionary<string, GameObject>> allMembers = null;

    private Dictionary<string, Dictionary<string, GameObject>> AllMembers
    {
        get
        {
            if (allMembers == null)
            {
                allMembers = new Dictionary<string, Dictionary<string, GameObject>>();
            }
            return allMembers;
        }
    }

    /// <summary>
    /// 注册Panel以及Panel下的所有控件，将其添加进字典
    /// </summary>
    /// <param name="panelName"></param>
    /// <param name="widgetName"></param>
    /// <param name="obj"></param>
    public void RegistGameObject(string panelName, string widgetName, GameObject obj)
    {
        if (AllMembers.ContainsKey(panelName))
        {
            if (AllMembers[panelName].ContainsKey(widgetName))
                return;
            AllMembers[panelName].Add(widgetName, obj);
        }
        else
        {
            Dictionary<string, GameObject> tmpNewDic = new Dictionary<string, GameObject>();
            tmpNewDic.Add(widgetName, obj);
            AllMembers.Add(panelName, tmpNewDic);
        }
    }


    /// <summary>
    /// 注销一个控件
    /// </summary>
    /// <param name="panelName"></param>
    /// <param name="widgetName"></param>
    public void UnRegistGameObject(string panelName, string widgetName)
    {
        if (AllMembers.ContainsKey(panelName))
        {
            if (AllMembers[panelName].ContainsKey(widgetName))
            {
                AllMembers[panelName].Remove(widgetName);
            }
        }
    }

    /// <summary>
    /// 注销一个Panel
    /// </summary>
    /// <param name="panelName"></param>
    public void UnRegistPanel(string panelName)
    {
        if (AllMembers.ContainsKey(panelName))
        {
            AllMembers.Remove(panelName);
        }
    }

    /// <summary>
    /// 获取控件
    /// </summary>
    /// <param name="panelName"></param>
    /// <param name="widgetName"></param>
    /// <returns></returns>
    public GameObject GetGameObject(string panelName, string widgetName)
    {
        if (AllMembers.ContainsKey(panelName))
        {
            if (AllMembers[panelName].ContainsKey(widgetName))
            {
                return AllMembers[panelName][widgetName];
            }
        }
        return null;
    }

    /// <summary>
    /// 显示界面
    /// </summary>
    /// <param name="panelName"></param>
    /// <returns></returns>
    //public GameObject ShowPanel(string senenName,string packageName,string panelName)
    //{
    //    Object tmpObj = null;
    //    GameObject targetObj = null;
    //    if (!AllMembers.ContainsKey(panelName))
    //    {
    //        tmpObj = ILoaderManager.Instance.GetSingleResources(senenName, packageName, panelName);
    //        targetObj = GameObject.Instantiate(tmpObj) as GameObject;
    //        targetObj.transform.SetParent(GameObject.FindGameObjectsWithTag("MainCanvas")[0].transform, false);
    //        RegistGameObject(panelName, panelName, targetObj);
    //    }
    //    else
    //    {
    //        targetObj = GetGameObject(panelName, panelName);
    //        targetObj.SetActive(true);
    //    }

    //    return targetObj;
    //}


    public GameObject ShowPanel(string panelName)
    {
        GameObject targetObj = null;
        if (!AllMembers.ContainsKey(panelName))
        {
            //AssetBundle加载随后在使用，先测Resource.load;
            targetObj = Resources.Load<GameObject>("Prefab/Panel/" + panelName);
            targetObj = GameObject.Instantiate<GameObject>(targetObj);
            targetObj.transform.SetParent(GameObject.FindGameObjectsWithTag("MainCanvas")[0].transform, false);
            RegistGameObject(panelName, panelName, targetObj);
        }
        else
        {
            targetObj = GetGameObject(panelName, panelName);
            targetObj.SetActive(true);
        }

        return targetObj;
    }


    /// <summary>
    /// 隐藏panel
    /// </summary>
    /// <param name="panelName"></param>
    public void HidePanel(string panelName)
    {
        if (!AllMembers.ContainsKey(panelName)) return;
        GameObject targetObj = GetGameObject(panelName, panelName);
        targetObj.SetActive(false);
    }

    /// <summary>
    /// 销毁panel
    /// </summary>
    /// <param name="panelName"></param>
    public void DestroyPanel(string panelName)
    {
        if (AllMembers.ContainsKey(panelName))
        {
            GameObject targetObj = GetGameObject(panelName, panelName);
            UnRegistPanel(panelName);
            GameObject.Destroy(targetObj);
        }
    }

    public GameObject ShowBG(string bgpanelName)
    {
        GameObject tmpGameObj = Resources.Load<GameObject>("Prefab/Panel/" + bgpanelName);
        tmpGameObj = GameObject.Instantiate(tmpGameObj);
        tmpGameObj.transform.SetParent(GameObject.FindGameObjectsWithTag("MainCanvas")[0].transform, false);
        tmpGameObj.transform.SetAsFirstSibling();
        return tmpGameObj;
    }


    public void MaskFull()
    {        
        GameObject tmpGameObj = Resources.Load<GameObject>("Prefab/UGUI/UI/MaskFull");
        tmpGameObj = GameObject.Instantiate(tmpGameObj);
        UIMask uimask = tmpGameObj.GetComponent<UIMask>();
        if (uimask == null)
        {
            tmpGameObj.AddComponent<UIMask>();
        }
        tmpGameObj.transform.SetParent(mainCanvas.transform, false);
        tmpGameObj.transform.SetAsLastSibling();
    }


    //public enum Moveby
    //{
    //    x,
    //    y,
    //    xy
    //}

    //public void PlayUIFlash(Transform transform, float movevalue, float time, EaseType easetype, Moveby Axis)
    //{
    //    switch (Axis)
    //    {
    //        case Moveby.x:
    //            transform.DoMoveX(movevalue, time, easetype);
    //            break;
    //        case Moveby.y:
    //            transform.DoMoveY(movevalue, time, easetype);
    //            break;
    //        case Moveby.xy:
    //            transform.DoMove(movevalue, time, easetype);
    //            break;

    //        default:
    //            break;
    //    }
    //}


}
