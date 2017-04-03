using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    public int _Lives = 3;
    public int points;

    public Text lives_value;
    public Text points_value;

    public void Setlives(int newValue)
    {
        _Lives = newValue;
        Debug.Log(_Lives);
        lives_value.text = _Lives.ToString();
    }

    public int GetLives()
    {
        return _Lives;
    }
}