namespace calculatorCS;

public partial class Form1 : Form
{
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
        string[] buttonLabels = {"7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", ".", "=", "+" };
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
        
    }

}       

