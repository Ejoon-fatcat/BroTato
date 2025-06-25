using System.Collections.Generic;
using Model;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelectPanel : MonoBehaviour
{
    public static RoleSelectPanel Instance;

    //角色数据信息
    public List<RoleData> RoleDatas = new List<RoleData>(); //角色数据信息

    //json文件
    public TextAsset roleTextAsset;

    //角色列表UI
    public Transform _roleList;

    //角色预制体
    public GameObject role_prefab;

    //角色名称
    public TextMeshProUGUI _roleName;

    //角色头像
    public Image _avatar;

    //角色描述
    public TextMeshProUGUI _roleDescribe;

    //通关记录
    public TextMeshProUGUI _text3;
    
    public CanvasGroup _canvasGroup;
    
    public CanvasGroup _contentCanvasGroup;

    public GameObject _roleDetails;

    private void Awake()
    {
        Instance = this;

        _roleList = GameObject.Find("RoleList").transform;
        role_prefab = Resources.Load<GameObject>("prefabs/Role");

        //读取json文件转换为对象
        roleTextAsset = Resources.Load<TextAsset>("Data/role");
        RoleDatas = JsonConvert.DeserializeObject<List<RoleData>>(roleTextAsset.text);

        //获取组件
        _roleName = GameObject.Find("RoleName").GetComponent<TextMeshProUGUI>();
        _avatar = GameObject.Find("Avatar_Role").GetComponent<Image>();
        _roleDescribe = GameObject.Find("RoleDescribe").GetComponent<TextMeshProUGUI>();
        _text3 = GameObject.Find("Text3").GetComponent<TextMeshProUGUI>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _roleDetails = GameObject.Find("RoleDetails");
    }

    void Start()
    {
        foreach (RoleData roleData in RoleDatas)
        {
            RoleUI r = GameObject.Instantiate(role_prefab, _roleList).GetComponent<RoleUI>();
            r.SetData(roleData);
        }
    }
}