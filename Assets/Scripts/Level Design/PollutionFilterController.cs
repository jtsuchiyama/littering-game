using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionFilterController : MonoBehaviour
{
    public PlayerData playerData;

    // Reference for the filter Image component
    private Image _pollutionFilter;

    private void Start() {
        _pollutionFilter = GetComponent<Image>();
    }

    // Function that handles the updating of the filter object
    public void UpdateFilter(int coin_counter)
    {
        int increment = playerData.total_coins / 5;

        if (coin_counter == playerData.total_coins)
            UpdateAlpha(0);

        else if (coin_counter >= increment * 4)
            UpdateAlpha(0.1f);

        else if (coin_counter >= increment * 3)
            UpdateAlpha(0.2f);

        else if (coin_counter >= increment * 2)
            UpdateAlpha(0.3f);

        else if (coin_counter >= increment)
            UpdateAlpha(0.4f);

    }

    // Helper function for updating the filter's alpha value
    private void UpdateAlpha(float value) {
        var tempColor = _pollutionFilter.color;
        Debug.Log(tempColor.a);
        tempColor.a = value;
        Debug.Log(tempColor.a);
        _pollutionFilter.color = tempColor;
    }
}
