using System.Drawing;
using System.Windows.Forms;

namespace calculatorCS
{
    public partial class Form1 : Form
    {   
        private FlowLayoutPanel flowLayoutPanel1;
        private Label? displayLabel;
        // Store the current number entered by the user
        private string currentNumber = "";
        // Store the previous number entered by the user
        private string previousNumber = "";
        // Store the operation currently selected by the user
        private char operation; 
        // Store whether a decimal point has been entered
        private bool isDecimalEntered = false;

        public Form1()
        {   
            // Create a new FlowLayoutPanel
            InitializeComponent();
            this.ClientSize = new Size(400, 400);
            FlowLayoutPanel flowLayoutPanel1 = new FlowLayoutPanel();
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Dock = DockStyle.Fill;

            

            // Create a new Label
            displayLabel = new Label();
            displayLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            displayLabel.Width = 300;
            displayLabel.Height = 70;
            displayLabel.TextAlign = ContentAlignment.MiddleCenter;
            displayLabel.Margin = new Padding(5, 10, 5, 5);
            flowLayoutPanel1.Controls.Add(displayLabel);

            
            //Add a TableLayout to the FlowLayoutPanel
            TableLayoutPanel tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.Height = 300;
            tableLayoutPanel1.Width = 300;
            tableLayoutPanel1.AutoSize = false;
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            tableLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Controls.Add(tableLayoutPanel1);
            // Add the FlowLayoutPanel to the form's Controls collection
            this.Controls.Add(flowLayoutPanel1);

            // Add buttons to The FlowLayoutPanel
            string[] buttonLabels = {"7" ,"8", "9", "*", "4", "5", "6", "-", "1", "2", "3", "+", "/", "0", ",", "="};
            for (int row = 0; row < 4; row++)
            {
                for(int col = 0; col < 4; col++)
                {
                    int index = row * 4 + col;
                    Button button = new Button();
                    button.Text = buttonLabels[index];
                    button.Font = new Font("Arial", 15, FontStyle.Bold);
                    button.AutoSize = false;
                    button.Width = 80;
                    button.Height = 80;
                    button.Margin = new Padding(0);
                    button.Padding = new Padding(0);
                    button.Click += Button_Click;
                    tableLayoutPanel1.Controls.Add(button, col, row);
                }
            }
            Button clearButton = new Button();
            clearButton.Text = "C";
            clearButton.Font = new Font("Arial", 15, FontStyle.Bold);
            clearButton.AutoSize = false;
            clearButton.Height = 80;
            clearButton.Width = 80;
            clearButton.Margin = new Padding(0);
            clearButton.Padding = new Padding(0);
            clearButton.Click += Button_Click;
            tableLayoutPanel1.Controls.Add(clearButton, 4, 3);


        }

        private void Button_Click(object? sender, EventArgs e)
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
                case ",":
                    //handle decimal
                    HandleDecInput(button.Text);
                    break;
                case "C":
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
                UpdateDisplay();
            }
        }

        private void HandleDigitInput(string ButtonText)
        {
            currentNumber += ButtonText;
            UpdateDisplay();
        }

        private void HandleDivInput(string ButtonText)
        {   
            previousNumber = currentNumber;
            currentNumber = "";
            //division operation 
            operation = '/';
        ;
        }

        private void HandleMultipInput(string ButtonText)
        {   
            previousNumber = currentNumber;
            currentNumber = "";
            operation = '*';
        
        }

        private void HandleAdditionInput(string ButtonText)
        {   
            previousNumber = currentNumber;
            currentNumber = "";
            operation = '+';
        }

        private void HandleSubstractInput(string ButtonText)
        {   
            previousNumber = currentNumber;
            currentNumber = "";
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
            previousNumber = "";
            operation = '\0';
            isDecimalEntered = false;
            
            UpdateDisplay();
        }

        private void HandleClearInput(string ButtonText)
        {
            previousNumber = "0";
            currentNumber = "0";
            operation = '\0';
            isDecimalEntered = false;

            UpdateDisplay();

        }

        private void UpdateDisplay()
        {   
            if (displayLabel != null)
            {
                displayLabel.Text = currentNumber;
            }

        }
    }         
}
