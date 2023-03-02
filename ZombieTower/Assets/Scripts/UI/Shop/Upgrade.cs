using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] protected string _label;
    [SerializeField] protected Sprite _icon;
    [SerializeField] protected Tower _tower;
}
