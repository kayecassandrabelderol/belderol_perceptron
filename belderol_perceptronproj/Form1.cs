using System.Windows.Forms;

namespace belderol_perceptronproj
{
    public partial class Form1 : Form
    {
        double[] weights = { 0.0, 0.0 };
        double bias = 0.0;
        double learningRate = 1;
        
        public Form1()
        {
            InitializeComponent();
            Perception perception = new Perception(weights, bias, learningRate);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int epoch = Convert.ToInt32(textBox1.Text);
            Perception.TrainPerceptron(weights, bias, learningRate, epoch);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] input = new int[2];
            input[0] = Convert.ToInt32(textBox2.Text);
            input[1] = Convert.ToInt32(textBox3.Text);

            int output = Perception.PerceptronOutput(input, weights, bias);
            textBox4.Text = output.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
        }
    }
}