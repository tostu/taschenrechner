using System;
using Gtk;

public partial class MainWindow : Gtk.Window
{
    Taschenrechner.Calculation calculation = new Taschenrechner.Calculation();
    Boolean isResult = false;
    Boolean pendingOperation = false;


    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }

    //Helper
    private void clearText()
    {
        displayMain.DeleteText(0, displayMain.Text.Length);
    }

    private String getText()
    {
        return displayMain.Text.Replace(",", ".");
    }



    //Number Input + comma
    private void setText(String text)
    {
        text = text.Replace(".", ",");
        displayMain.InsertText(text);
    }

    protected void ClickNumber(object sender, EventArgs e)
    {
        Gtk.Button button = (Gtk.Button)sender;
        String buttonLabel = button.Label;

        if (isResult)
            {
                clearText();
                isResult = false;
            }
            if (buttonLabel == ",")
            {
                if (displayMain.Text.Length == 0)
                {
                    displayMain.Text = ("0,");
                }
                else if (!displayMain.Text.Contains(","))
                {
                displayMain.Text += (",");
                }
            }
            else
            {
                displayMain.Text += (buttonLabel);
            }
    }



    //deleting
    protected void clickButtonDel(object sender, EventArgs e)
    {
        //displayMain.DeleteText(displayMain.Text.Length - 1, displayMain.Text.Length);
        if (displayMain.Text.Length > 0)
        {
            displayMain.Text = displayMain.Text.Remove(displayMain.Text.Length - 1);
        }
    }

    protected void clickButtonReset(object sender, EventArgs e)
    {
        clearText();
        calculation.reset();
        pendingOperation = false;
        isResult = false;
    }

    //result
    protected void clickButtonEquals(object sender, EventArgs e)
    {
        if (pendingOperation)
        {
            resolution();
            pendingOperation = false;
        }
        else
        {
            if (calculation.method != Taschenrechner.Calculation.Method.NotSet)
            {
                resolution();
            }
        }
    }

    private void resolution() {

        if (pendingOperation)
        {
            calculation.setOperand2(getText());
        }

        calculation.calculate();
        clearText();

        setText(calculation.getVal());

        isResult = true;
    }

    //math functions
    private void manageFunction()
    {
        if (pendingOperation)
        {
            resolution();
        }
        else
        {
            calculation.setOperand1(getText());
            clearText();
            pendingOperation = true;
        }
    }

    protected void clickButtonAdd(object sender, EventArgs e)
    {
        manageFunction(); 
        calculation.method = Taschenrechner.Calculation.Method.Add;
    }

    protected void ClickButtonSubstract(object sender, EventArgs e)
    {
        manageFunction();
        calculation.method = Taschenrechner.Calculation.Method.Substract;
    }

    protected void ClickButtonMultiply(object sender, EventArgs e)
    {
        manageFunction(); 
        calculation.method = Taschenrechner.Calculation.Method.Multiply;
    }

    protected void ClickButtonDivide(object sender, EventArgs e)
    {
        manageFunction(); 
        calculation.method = Taschenrechner.Calculation.Method.Divide;
    }

    protected void ClearEntry(object sender, EventArgs e)
    {
        displayMain.DeleteText(0, displayMain.Text.Length);
    }

    protected void PrependMinus(object sender, EventArgs e)
    {
        if (!displayMain.Text.Contains("-"))
        {
            //displayMain.PrependText("-");
            displayMain.Text = displayMain.Text.Insert(0, "-");
        }
    }
}
