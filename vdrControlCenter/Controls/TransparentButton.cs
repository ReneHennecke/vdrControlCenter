namespace vdrControlCenterUI.Controls;

public class TransparentButton : Button
{
    public TransparentButton()
    {
        SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
    }
}

