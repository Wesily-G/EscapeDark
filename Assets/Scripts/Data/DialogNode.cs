using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Option
{
    _Null,
    FindParent,
    badBoy
}
[CreateAssetMenu(fileName = "DialogNode", menuName = "ScriptableObjects/DialogNode", order = 1)]
public class DialogNode : ScriptableObject
{
    public string[] Name;
    public string[] Content;
    public Sprite[] character;
}
