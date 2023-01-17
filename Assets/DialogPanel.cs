using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogPanel : BaseManager<DialogPanel>
{
    public Text Name;
    public Text Content;
    public Text Tips;
    public Image Character;
    public UnityEvent overCallBack;
    DialogNode _dialogNode = null;
    int _index = 0;//当前对话的索引
    private void Start()
    {
        PanelActive(false);
    }
    public void ReadNodeIfNotNull(DialogNode dialogNode, int index)
    {


        if (dialogNode.Name.Length - 1 <= index)
        {
            Debug.Log("一段对话读完了" + index + "行");
            PanelActive(false);
            _index = 0;
            _dialogNode = null;
            GameManager.GetInstance().setState(GameState.normal);

            return;
        }
        _dialogNode = dialogNode;
        PanelActive(true);
        Name.text = dialogNode.Name[index];
        Content.text = dialogNode.Content[index];
        Character.sprite = dialogNode.character[index];
        _index++;

    }
    public void ReadNodeIfNotNull(DialogNode dialogNode, ref int index, bool isTips)
    {
        _dialogNode = dialogNode;

        if (dialogNode.Name.Length <= index)
        {
            Debug.Log("一段对话读完了" + index + "行");
            PanelActive(false);
            _index = 0;
            _dialogNode = null;
            GameManager.GetInstance().state = GameState.normal;
            overCallBack.Invoke();
            overCallBack.RemoveAllListeners();

            return;
        }

        Tips.gameObject.SetActive(isTips);
        PanelActive(true);
        Name.text = dialogNode.Name[index];
        Content.text = dialogNode.Content[index];
        Character.sprite = dialogNode.character[index];
        index++;
        _index = index;


    }
    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            if (Input.GetKeyUp(KeyCode.Space) && _dialogNode)
            {
                ReadNodeIfNotNull(_dialogNode, ref _index, true);
            }
        }
    }
    public void PanelActive(bool active)
    {
        gameObject.SetActive(active);
    }
}
