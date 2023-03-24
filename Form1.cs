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
        this.Constrols.Add(flowLayoutPanel1);

        // Add buttons to The FlowLayoutPanel
        for (int i = 0; i < 24; i++)
        {
            Button button = new Button();
            button.Text = "Button " + i;
            buttonPanel.Controls.Add(button);
        }
    }
}
