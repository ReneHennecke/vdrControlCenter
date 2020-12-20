namespace vdrControlCenterUI.Controls
{
    using System;
    using System.Windows.Forms;

    public class ComboBoxRaX : ComboBox
    {
        private int _currentIndex = -1;
        public int CurrentIndex
        {
            get { return _currentIndex; }
        }

        private object _currentValue = null;
        public object CurrentValue
        {
            get { return _currentValue; }
        }

        private int _previousIndex = -1;
        public int PreviousIndex
        {
            get { return _previousIndex; }
        }

        private object _previousValue = null;
        public object PreviousValue
        {
            get { return _previousValue; }
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            _previousIndex = _currentIndex;
            _previousValue = _currentValue;
            _currentIndex = SelectedIndex;
            _currentValue = SelectedValue;
            base.OnSelectedIndexChanged(e);
        }
    }
}
