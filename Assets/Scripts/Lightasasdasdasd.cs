using UnityEngine;

public class ColorChangingLight : MonoBehaviour
{
    public Light targetLight;  // Ссылка на компонент Light
    public float changeSpeed = 1.0f;  // Скорость изменения цвета

    private Color startColor = Color.red;  // Начальный цвет (красный)
    private Color endColor = Color.white;  // Конечный цвет (белый)
    private float t = 0;  // Параметр для интерполяции

    void Start()
    {
        // Если свет не задан в инспекторе, берем компонент Light с этого объекта
        if (targetLight == null)
        {
            targetLight = GetComponent<Light>();
        }

        // Устанавливаем начальный цвет
        if (targetLight != null)
        {
            targetLight.color = startColor;
        }
    }

    void Update()
    {
        if (targetLight != null)
        {
            // Плавно меняем цвет от красного к белому
            t += Time.deltaTime * changeSpeed;
            targetLight.color = Color.Lerp(startColor, endColor, t);

            // Если дошли до белого, сбрасываем t, чтобы цвет снова начал меняться
            if (t >= 1.0f)
            {
                t = 0;
            }
        }
    }
}