using System;

public class StartScreen : Window
{
    public event Action PlayButtonClicked;

    public override void Close()
    {
        gameObject.SetActive(false);
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        gameObject.SetActive(true);
        WindowGroup.alpha = 1f;
        ActionButton.interactable = true;
    }

    protected override void OnClickButton()
    {
        PlayButtonClicked?.Invoke();
    }
}
