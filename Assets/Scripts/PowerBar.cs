using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    private Image fillImage;
    public Player player;
    [SerializeField]
    public float offsetX = 1;
    public float loopTime = 4;

    public float minThrowPower = 0f;
    public float currentThrowPower;
    public float maxTrowPower = 100f;
    public bool isAnimated => tween != null && tween.IsPlaying();

    public Ease ease;
    public Tween tween;


    private void Awake()
    {
        fillImage = slider.fillRect.GetComponent<Image>();
    }


    public void SetColor()
    {
        fillImage.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void PlayAnimation()
    {
        tween = slider.DOValue(1, loopTime)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(ease)
            .OnUpdate(SetColor);

    }

    public float GetPowerAndHide()
    {
        tween.Kill();
        StartCoroutine(Hide());
        return tween.ElapsedPercentage() * maxTrowPower;
    }

    public void Show()
    {
        this.gameObject.transform.position = new Vector3(player.transform.position.x + offsetX, player.transform.position.y, player.transform.position.z);
        this.gameObject.SetActive(true);
        PlayAnimation();

    }

    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(1);
        slider.value = 0;
        this.gameObject.SetActive(false);
    }
}
