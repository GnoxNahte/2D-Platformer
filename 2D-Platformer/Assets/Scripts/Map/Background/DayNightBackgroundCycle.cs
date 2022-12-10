using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightBackgroundCycle : MonoBehaviour
{
    [SerializeField] SpriteRenderer daySprite;
    [SerializeField] SpriteRenderer nightSprite;

    private DayNightCycle dayNightCycle;

    private void Awake()
    {
        dayNightCycle = GameObject.FindObjectOfType<DayNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        float dayOpacity = (Mathf.Sin(dayNightCycle.timeOfDay) + 1f) * 0.5f;
        daySprite.color = new Color(1f, 1f, 1f, dayOpacity);
        nightSprite.color = new Color(1f, 1f, 1f, 1f - dayOpacity);
        print(1 - dayOpacity);
    }
}
