using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data", menuName = "Scriptable Object/Enemy Data", order = int.MaxValue)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private string enemyType;
    public string EnemyType { get { return enemyType; } }

    [SerializeField]
    private float hp;
    public float Hp { get { return hp; }}

    [SerializeField]
    private float searchRange;
    public float SearchRange { get { return searchRange; } }

    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }

    [SerializeField]
    private float height;
    public float Height { get { return height; } }
}