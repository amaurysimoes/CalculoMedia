using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//Utilizado para realizar o calculo
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

//Local do exemplo: https://www.devmedia.com.br/programa-em-windows-forms-com-csharp-de-calculo-de-media/16962

namespace CalculoMediaCsv
{
    public partial class ProgramaCalculosEstatisticosAruco : Form
    {
        public ProgramaCalculosEstatisticosAruco()
        {
            InitializeComponent();
        }

        public void Calcular()
        {
            try
            {
                //Declaro as variáveis, as converto para decimal e as jogo nos labels
                decimal Valor1, Valor2, Valor3, Valor4, maiorvalor, menorvalor, mediaCoordenadas;

                Valor1 = Convert.ToDecimal(tbCoordenada1.Text);
                Valor2 = Convert.ToDecimal(tbCoordenada2.Text);
                Valor3 = Convert.ToDecimal(tbCoordenada3.Text);
                Valor4 = Convert.ToDecimal(tbCoordenada4.Text);


                maiorvalor = Convert.ToDecimal(IsTextValidated(lblValorResult1.Text));
                menorvalor = Convert.ToDecimal(IsTextValidated(lblValorResult2.Text));
                mediaCoordenadas = Convert.ToDecimal(IsTextValidated(lblValorResult3.Text));

                //Teste condicional para descobrir qual é a maior nota
                if (Valor1 > Valor2 && Valor1 > Valor3 && Valor1 > Valor4)
                {
                    maiorvalor = Valor1;
                }
                else if (Valor2 > Valor1 && Valor2 > Valor3 && Valor2 > Valor4)
                {
                    maiorvalor = Valor2;
                }
                else if (Valor3 > Valor1 && Valor3 > Valor2 && Valor3 > Valor4)
                {
                    maiorvalor = Valor3;
                }
                else
                {
                    maiorvalor = Valor4;
                }

                //Teste condicional para descobrir qual é a menor nota
                if (Valor1 < Valor2 && Valor1 < Valor3 && Valor1 < Valor4)
                {
                    menorvalor = Valor1;
                }
                else if (Valor2 < Valor1 && Valor2 < Valor3 && Valor2 < Valor4)
                {
                    menorvalor = Valor2;
                }
                else if (Valor3 < Valor1 && Valor3 < Valor2 && Valor3 < Valor4)
                {
                    menorvalor = Valor3;
                }
                else
                {
                    menorvalor = Valor4;
                }

                //Faço a conversão dos valores das labels para string
                lblValorResult1.Text = maiorvalor.ToString();
                lblValorResult2.Text = menorvalor.ToString();

                //Calculo a média das notas e as armazeno na label
                mediaCoordenadas = (Valor1 + Valor2 + Valor3 + Valor4) / 4;
                lblValorResult3.Text = mediaCoordenadas.ToString();
            }

            catch (FormatException)
            {
                //Caso ocorra algum erro, apresento uma mensagem ao usuário
                MessageBox.Show("Digite números de 0 a 10, com ou sem vírgulas",
                "Mensagem do Sistema");
            }
        }

        private bool IsTextValidated(string strTextEntry)
        {
            //Método para não deixar o label vazio, senão dá erro de InvalidCast
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strTextEntry);
        }

        public void Limpar()
        {
            //Limpo as variáveis
            tbCoordenada1.Text = "";
            tbCoordenada2.Text = "";
            tbCoordenada3.Text = "";
            tbCoordenada4.Text = "";
            lblValorResult1.Text = "";
            lblValorResult1.Text = "";
            lblValorResult1.Text = "";
            lblValorResult1.Text = "";
        }

        public void Sair()
        {
            //Crio o método para o botão Sair
            DialogResult result;

            result = MessageBox.Show("Tem certeza que deseja sair?",
            "Mensagem do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void tbCoordenada1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Teste condicional para aceitar números no textbox
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }

            //Teste condicional para aceitar a tecla Backspace e vírgula
            if (e.KeyChar == 8 || e.KeyChar == 44)
            {
                e.Handled = false;
            }
        }

        private void tbCoordenada2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 8 || e.KeyChar == 44)
            {
                e.Handled = false;
            }
        }

        private void tbCoordenada3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 8 || e.KeyChar == 44)
            {
                e.Handled = false;
            }
        }

        private void tbCoordenada4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)))
            {
                e.Handled = true;
            }

            if (e.KeyChar == 8 || e.KeyChar == 44)
            {
                e.Handled = false;
            }
        }

        private void btnCalcular_Click_1(object sender, EventArgs e)
        {
            Calcular();
        }

        private void btnLimpar_Click_1(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            Sair();
        }
    }
}