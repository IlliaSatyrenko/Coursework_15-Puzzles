namespace Coursework
{
    internal class CustomTextBox: TextBox
    {
        private ToolTip errorToolTip = new ToolTip();
        public bool isError = false;
        public bool isRepeatable = false;

        public CustomTextBox()
        {
            BorderStyle = BorderStyle.FixedSingle;
            BackColor = Color.White;
            Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Size = new Size(26, 26);
            TextAlign = HorizontalAlignment.Center;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            CustomValidate();
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            errorToolTip.Hide(this);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (Text != "" && !isError)
            {
                CustomValidate();
            }
        }

        //Метод валідації текстового поля
        public void CustomValidate()
        {
            if (!int.TryParse(Text, out int value) || value < 0 || value > 15 && Text == Text.TrimStart('0') && Text == Text.Trim() && Text != "0")
            {
                isError = true;
                ShowError("Введіть число від 0 до 15");
            }
            else if (Text != Text.TrimStart('0') && Text != "0")
            {
                isError = true;
                ShowError("Введіть число без нулів на початку");
            }
            else if (Text != Text.Trim())
            {
                isError = true;
                ShowError("Введіть число без пробілів");
            }
            else if (!isError)
            {
                BackColor = Color.White;
                errorToolTip.Hide(this);
            }
        }
        
        //Метод, що показує помилку текстового поля
        public void ShowError(string ErrorMessage)
        {
            BackColor = Color.MistyRose;
            errorToolTip.Show(ErrorMessage, this, 0, -Height);
        }
    }
}
