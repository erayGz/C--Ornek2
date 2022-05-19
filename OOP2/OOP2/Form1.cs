namespace OOP2
{
    public partial class Form1 : Form
    {
        VadesizHesap h1 = new VadesizHesap();
        public Form1()
        {
            h1.Bakiye = 250m;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sonuc = h1.ParaCek(numericUpDown1.Value);
            MessageBox.Show(sonuc);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sonuc = h1.ParaYatirma(numericUpDown1.Value);
            MessageBox.Show(sonuc);
        }
    }
}