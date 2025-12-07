using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public float waveTime;
    public float quantityOfEnemies;
    public List<GameObject> enemiesThisWave;
}
