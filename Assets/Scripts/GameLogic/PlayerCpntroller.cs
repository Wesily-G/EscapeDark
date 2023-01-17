using System.Collections;
using UnityEngine;


public class PlayerCpntroller : MonoBehaviour
{

    public Transform InteractiveItem; //交互的对象
    public Transform Reserve; //暂时存储交互对象
    private void Update()
    {
        Transform Item = OnGetTrigger();
        if (Item)
        {
            Reserve = Item;
        }
        if (Input.GetKeyDown(KeyCode.F) && Item)
        {
            Interactive(Item);

        }
    }
    //交互
    public void Interactive(Transform Item)
    {
        Debug.Log(123);
        if (Item)
        {
            Item.GetComponent<InterBase>().Execution();
        }

    }
    public Transform OnGetTrigger()
    {
        //正在搜索的半径
        int radius = 1;
        //一步一步扩大搜索半径,最大扩大到100
        while (radius < 5)
        {
            //球形射线检测,得到半径radius米范围内所有的物件
            Collider[] cols = Physics.OverlapSphere(transform.position, radius);
            //判断检测到的物件中有没有Enemy
            if (cols.Length > 0)
                for (int i = 0; i < cols.Length; i++)
                    if (cols[i].GetComponent<InterBase>())
                        return cols[i].transform;
            //没有检测到Enemy,将检测半径扩大2米
            radius += 2;
        }
        return null;
    }
}
