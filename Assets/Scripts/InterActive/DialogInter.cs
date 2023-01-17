
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.InterActive
{
    public class DialogInter : InterBase
    {
        public UnityEvent DialogCallBack;
        public DialogNode diaNode;

        public void Start()
        {
            addEvent(() =>
         {
             Debug.Log("与我反应" + gameObject.name);

             DialogPanel.GetInstance().ReadNodeIfNotNull(diaNode, 0);
             GameManager.GetInstance().setState(GameState.dialog);
             DialogPanel.GetInstance().overCallBack.AddListener(() =>
             {
                 DialogCallBack.Invoke();
             });
         });

        }


    }
}