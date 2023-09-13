using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour
{
    [SerializeField]
    private Roulette roulette;

    bool _isEnd = true;

    public void SpinStart()
    {
        if (_isEnd)
        {
            roulette.Spin(EndOfSpin);
            _isEnd = false;
        }
    }

    private void EndOfSpin(RoulettePieceData selectedData)
    {
        Debug.Log($"{selectedData.index}:{selectedData.description}");

        _isEnd = true;
    }
}

