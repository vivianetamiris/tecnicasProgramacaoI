namespace Aula14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double peso = double.Parse(txtPeso.Text);
            double altura = double.Parse(txtAltura.Text);
            double imc = peso / (altura * altura);
            string indice;
            if (imc < 18.5)
                indice = "Abaixo do peso";
            else if (imc < 24.9)
                indice = "Peso normal";
            else if (imc < 29.9)
                indice = "Sobrepeso";
            else if (imc < 34.9)
                indice = "Obesidade Grau I";
            else if (imc < 39.9)
                indice = "Obesidade Grau II";
            else
                indice = "Obesidade Grau III";

            lblResultado.Text = $"IMC: {imc:F2} - {indice}";
        }
     
        }
    }

