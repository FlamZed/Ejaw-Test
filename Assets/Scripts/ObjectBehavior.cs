using System.Collections;
using UniRx;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour
{
    [SerializeField] private string objectType;

    private Renderer renderer;
    private GeometryObjectModel model;
    private ClickColorData colorData;
    private int localCountIndex = 0;

    private CompositeDisposable disposables;

    private void OnEnable()
    { // создаем disposable
        Initialize();

        model.ClickCount = 0;

        EndlessTimer(colorData.ObservableTime);
    }

    private void OnDisable()
    { // уничтожаем подписки
        if (disposables != null)
        {
            disposables.Dispose();
        }
    }

    private void Initialize()
    {
        disposables = new CompositeDisposable();

        renderer = GetComponent<Renderer>();
        colorData = GeometryObjectData.GetData(objectType);
        model = new GeometryObjectModel();
    }
    
    private void EndlessTimer(int time)
    {
        Observable.Timer(System.TimeSpan.FromSeconds(time))
             .Repeat()// создаем timer Observable
        .Subscribe(_ => { // подписываемся
            Observable.WhenAll(Observable.FromCoroutine(() => SmoothColor(renderer, RandomColor(), 3f))).Subscribe().AddTo(this);
        }).AddTo(disposables); // привязываем подписку к disposable
    }

    public void ChangeColor()
    {
        model.ClickCount++;

        if(model.ClickCount >= colorData.MinClicksCount && model.ClickCount <= colorData.MaxClicksCount)
        {
            Observable.WhenAll(Observable.FromCoroutine(() => SmoothColor(renderer, colorData.Color[localCountIndex], 2f))).Subscribe();
            localCountIndex++;
        }
    }

    private static IEnumerator SmoothColor(Renderer rend, Color endColor, float time)
    {
        float currTime = 0f;
        do
        {
            rend.material.color = Color.Lerp(rend.material.color, endColor, currTime / time);
            currTime += Time.deltaTime;
            yield return null;
        } while (currTime <= time);
    }

    private static Color RandomColor()
    {
        return new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
    }
}