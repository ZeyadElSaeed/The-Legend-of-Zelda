using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicEffects : MonoBehaviour
{
    public GameObject MusicHandle;
    public GameObject EffectsHandle;
    public GameObject MusicFill;
    public GameObject EffectsFill;
    public static float MusicLevel = 0.745f;
    public static float EffectsLevel = 0.745f;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(MusicFill.GetComponent<RectTransform>().anchorMax);
        // MusicFill.GetComponent<RectTransform>().anchorMax = new Vector2(MusicLevel,1);
        // EffectsFill.GetComponent<RectTransform>().anchorMax = new Vector2(EffectsLevel,1);
        // Vector3 musicPosition = MusicHandle.GetComponent<RectTransform>().position;
        // Vector3 effectsPosition = EffectsHandle.GetComponent<RectTransform>().position;
        // MusicHandle.GetComponent<RectTransform>().position = new Vector3(MusicLevel*171.4f + 6.4f,musicPosition.y,musicPosition.z);
        // EffectsHandle.GetComponent<RectTransform>().position = new Vector3(EffectsLevel*171.4f + 6.4f,effectsPosition.y,effectsPosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        // 6.4 177.7
        MusicLevel = (MusicHandle.GetComponent<RectTransform>().position.x-6.4f)/171.4f;
        EffectsLevel = (EffectsHandle.GetComponent<RectTransform>().position.x-6.4f)/171.4f;
    }
}
