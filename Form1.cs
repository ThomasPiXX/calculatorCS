namespace calculatorCS;

public partial class Form1 : Form
{   
    // Store the current number entered by the user
    private string currentNumber = "0";
    // Store the previous number entered by the user
    private string previousNumber = "0";
    // Store the operation currently selected by the user
    private char operation; 
     // Store whether a decimal point has been entered
     private bool isDecimalEntered = false;

    public Form1()
    {   
        // Create a new FlowLayoutPanel
        InitializeComponent();
        FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
        flowLayoutPanel1.Dock = DockStyle.Fill;

        // Add the FlowLayoutPanel to the form's Controls collection
        this.Controls.Add(flowLayoutPanel1);

        // Add buttons to The FlowLayoutPanel
        string[] buttonLabels = {"c" ,"7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", ".", "=", "+" };
        foreach( string label in buttonLabels)
        {
            Button button = new Button();
            button.Text = label;
            button.Font = new Font("Arial", 18, FontStyle.Bold);
            button.Width = 70;
            button.Height = 70;
            button.Margin = new Padding(5);
            button.Click += Button_Click;
            flowLayoutPanel1.Controls.Add(button);
        }
    }

    private void Button_Click(object sender, EventArgs e)
    {
        Button button = (Button)sender;
        string buttonText = button.Text;

        switch (buttonText)
        {
            case "0":
            case "1":
            case "2":
            case "3":
            case "4":
            case "5": 
            case "6":
            case "7":  
            case "8": 
            case "9":
                // handle digit input
                HandleDigitInput(button.Text);
                break;       
            case "+":
                //handle addition
                HandleAdditionInput(button.Text);
                break;      
            case "-":
                //handle substraction
                HandleSubstractInput(button.Text);
                break;        
            case "*":
                //Handle multiplication
                HandleMultipInput(button.Text);
                break;
            case "/":
                //Handle division
                HandleDivInput(button.Text);
                break;                     
            case "=":
                //handle equal sign
                HandleEqualInput(button.Text);
                break;         
            case ".":
                //handle decimal
                HandleDecInput(button.Text);
                break;
            case "c":
                HandleClearInput(button.Text);
                break;
        }
        
        // Update the display
        UpdateDisplay();

    }
    private void HandleDecInput(string ButtonText)
    {
        if (!isDecimalEntered)
        {   
            currentNumber += ".";
            isDecimalEntered = true;
            UpdateDisplay(currentNumber);
        }
    }

    private void HandleDigitInput(string ButtonText)
    {
        currentNumber += ButtonText;
        UpdateDisplay(currentNumber);
    }

    private void HandleDivInput(string ButtonText)
    {   
        previousNumber = currentNumber;
        currentNumber = "0";
        //division operation 
        operation = '/';
       ;
    }

    private void HandleMultipInput(string ButtonText)
    {   
        previousNumber = currentNumber;
        currentNumber = "0";
        operation = '*';
       
    }

    private void HandleAdditionInput(string ButtonText)
    {   
        previousNumber = currentNumber;
        currentNumber = "0";
        operation = '+';
    }

    private void HandleSubstractInput(string ButtonText)
    {   
        previousNumber = currentNumber;
        currentNumber = "0";
        operation = '-';
    }

    private void HandleEqualInput(string ButtonText)
    {
        //default value
        double result = 0.0;
        switch (operation)
        {
            case '+':
                result = double.Parse(previousNumber) + double.Parse(currentNumber);
                break;
            case '-':
                result = double.Parse(previousNumber) - double.Parse(currentNumber);
                break;
            case '*':
                result = double.Parse(previousNumber) * double.Parse(currentNumber);
                break;
            case '/':
                result = double.Parse(previousNumber) / double.Parse(currentNumber);
                break;   
        }
        
        currentNumber = result.ToString();
        previousNumber = "0";
        operation = '\0';
        isDecimalEntered = false;
        
        UpdateDisplay(result);
    }

    private void HandleClearInput(string ButtonText)
    {
        previousNumber = "0";
        currentNumber = "0";
        operation = '\0';
        isDecimalEntered = false;

        UpdateDisplay(currentNumber);

    }


}      

