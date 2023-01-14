using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{

    #region Fields
    public TextMeshProUGUI InputText;
    private float result;
    private float input;
    private float input2;
    private string operation;
    private string currentInput;
    private bool equalIsPressed;
    #endregion Fields


    #region Methods
    public void ClickNumber(int val)
    {
        Debug.Log($" check val: {val}");
        if (!string.IsNullOrEmpty(currentInput))
        {
            if (currentInput.Length < 10)
            {
                currentInput += val;
            }
        }
        else
        {
            currentInput = val.ToString();
        }
        InputText.text = $"{currentInput}";
    }


    public void ClickOperation(string val)
    {
        Debug.Log($" ClickOperation val: {val}");
        if (input == 0)
        {
            SetCurrentInput();
            operation = val;
        }
        else
        {
            if (equalIsPressed)
            {
                equalIsPressed = false;
                operation = val;
                input2 = 0;
            }
            else
            {
                if (operation.Equals(val, StringComparison.OrdinalIgnoreCase))
                {
                    Calculate();
                }
                else
                {
                    operation = val;
                    input2 = 0;
                }
            }
        }
    }


    public void ClickEqual(string val)
    {
        Debug.Log($" ClickEqual val: {val}");
        Calculate();
        equalIsPressed = true;
    }


    private void Calculate()
    {
        if (input != 0 && !string.IsNullOrEmpty(operation))
        {
            SetCurrentInput();
            switch (operation)
            {
                case "+":
                    result = input + input2;
                    break;
                case "-":
                    result = input - input2;
                    break;
                case "*":
                    result = input * input2;
                    break;
                case "/":
                    result = input / input2;
                    break;
            }

            // show the result
            InputText.SetText(result.ToString());

            // save the last result for next calculation
            input = result;
        }
    }


    private void SetCurrentInput()
    {
        if (!string.IsNullOrEmpty(currentInput))
        {
            if (input == 0)
            {
                input = int.Parse(currentInput);
            }
            else
            {
                input2 = int.Parse(currentInput);
            }
            currentInput = "";
        }
    }

    // clear all the inputs
    public void ClearInput()
    {
        currentInput = "";
        input = 0;
        input2 = 0;
        result = 0;
        InputText.SetText("");
    }



    #endregion Methods
}
