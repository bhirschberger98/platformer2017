using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {
    public int _Lives = 3;
    private int points;

    public Text lives_value;
    public Text points_value;
    public GameObject Game_Over;
    public void Setlives(int newValue)
    {
        _Lives = newValue;
        Debug.Log(_Lives);
        lives_value.text = _Lives.ToString();

        if (_Lives == 0)
        {
            Game_Over.SetActive(true);
        }
    }

    public int GetLives()
    {
        return _Lives;
    }
    public void SetPoints(int newValue)
    {
        points = newValue;
        pointsValue.text = points.ToString;
    }
    public int GetPoints()
    {
        return points;
    }
}