using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorDeTexto
{
    public partial class Form1 : Form
    {
        StringReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void novo()
        {
            if (MessageBox.Show("Desejá salvar o arquivo?", "Mensagem", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                salvar();
                limpar();
            }
            else if (MessageBox.Show("Desejá descartar o arquivo?", "Mensagem", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                limpar();
            }
        }

        private void limpar()
        {
            rtb_texto.Clear();
            rtb_texto.Focus();
        }

        private void salvar()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);//filestream cria ou abre um arquivo//primeiro parametro é o nome do arquivo
                    //segundo parametro é o modo de abrir(OpenOrCreate quando o arquivo ja existe ele abre e faz a alteração se não existir ele cria um novo)
                    //Terceiro parametro é o de acesso, que no caso é de escrita
                    StreamWriter cfb_streamWriter = new StreamWriter(arquivo);//Serve para escrever o arquivo na maquina
                    cfb_streamWriter.Flush();//Zerou o buffer
                    cfb_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);//de Onde  ele vai começar no arquivo
                    cfb_streamWriter.Write(this.rtb_texto.Text);//Salvou o arquivo
                    cfb_streamWriter.Flush();//Zerou o buffer novamente
                    cfb_streamWriter.Close();//Fechou o streamWriter (importante fazer isso)
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro na gravação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void abrir()
        {
            //this.openFileDialog1.Multiselect = false;//Para não poder selecionar mais de um arquivo
            this.openFileDialog1.Title = "Abrir arquivo";//titulo
            this.openFileDialog1.InitialDirectory = @"C:\Users\augus\OneDrive\Documentos\C#\Editor de texto arquivos salvos";//Onde vai abrir inicialmente para pegar os arquivos
            this.openFileDialog1.Filter = "(*.TXT)|*.TXT";//Aqui é pra edfinir os tipos de arquivos que ele vai abrir//Para todos os arquivos usa "(*.*)|*.*"

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.ReadWrite);
                    StreamReader cfb_streamReader = new StreamReader(arquivo);
                    cfb_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.rtb_texto.Clear();
                    string linha = cfb_streamReader.ReadLine();
                    while (linha != null)
                    {
                        rtb_texto.Text += linha + "\n";
                        linha = cfb_streamReader.ReadLine();
                    }
                    cfb_streamReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de leitura: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void copiar()
        {
            if (rtb_texto.SelectionLength > 0)//Verifica o conteudo selecionado
            {
                rtb_texto.Copy();
            }
        }

        private void cortar()
        {
            if (rtb_texto.SelectionLength > 0)//Verifica o conteudo selecionado
            {
                rtb_texto.Cut();
            }
        }

        private void colar()
        {
            rtb_texto.Paste();
        }

        private void negrito()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = rtb_texto.Font.Name;
            tamanho_da_fonte = rtb_texto.Font.Size;
            n = rtb_texto.SelectionFont.Bold;
            i = rtb_texto.SelectionFont.Italic;
            s = rtb_texto.SelectionFont.Underline;
            rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);

            if (n == false)
            {
                if (i == true && s == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false && s == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (i == true && s == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (i == false && s == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
            }
            else
            {
                if (i == true && s == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false && s == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
                else if (i == true && s == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
            }
        }

        private void italico()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = rtb_texto.Font.Name;
            tamanho_da_fonte = rtb_texto.Font.Size;
            n = rtb_texto.SelectionFont.Bold;
            i = rtb_texto.SelectionFont.Italic;
            s = rtb_texto.SelectionFont.Underline;
            rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);

            if (i == false)
            {
                if (n == true && s == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == false && s == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == true && s == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (n == false && s == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
            }
            else
            {
                if (n == true && s == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false && s == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
                else if (n == true && s == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
            }
        }

        private void sublinhado()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = rtb_texto.Font.Name;
            tamanho_da_fonte = rtb_texto.Font.Size;
            n = rtb_texto.SelectionFont.Bold;
            i = rtb_texto.SelectionFont.Italic;
            s = rtb_texto.SelectionFont.Underline;
            rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);

            if (s == false)
            {
                if (i == true && n == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false && n == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (i == true && n == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline | FontStyle.Italic);
                }
                else if (i == false && n == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }
            }
            else
            {
                if (i == true && n == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Bold);
                }
                else if (i == false && n == true)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
                else if (i == true && n == false)
                {
                    rtb_texto.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }
            }
        }

        private void alinharEsquerda()
        {
            rtb_texto.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alinharDireita()
        {
            rtb_texto.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void alinharCentro()
        {
            rtb_texto.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void alinharJustificado()
        {
            MessageBox.Show("Não implementado ainda.");
            rtb_texto.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void imprimir()
        {
            printDialog1.Document = printDocument1;
            leitura = new StringReader(this.rtb_texto.Text);
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();//Aqui chama o metodo de PrintPage
            }
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvar();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            salvar();
        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrir();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            copiar();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colar();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cortar();
        }

        private void btn_cortar_Click(object sender, EventArgs e)
        {
            cortar();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            negrito();
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            negrito();
        }

        private void itálicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            italico();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sublinhado();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            sublinhado();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void btn_justificado_Click(object sender, EventArgs e)
        {
            alinharJustificado();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhaPagina = 0;
            float posY = 0;
            int cont = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;//Pegand o margem da pagina e diminuindo em 50
            float margemSuperior = e.MarginBounds.Top - 50;

            if (margemEsquerda < 5)
            {
                margemEsquerda = 20;
            }

            if (margemSuperior < 5)
            {
                margemSuperior = 20;
            }

            string linha = null;
            Font fonte = rtb_texto.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);//Qual a cor que vai ser usada na impressão
            linhaPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);//para pegar o numero de linhas por pagina
            linha = leitura.ReadLine();
            while (cont < linhaPagina)
            {
                posY = (margemSuperior + (cont * fonte.GetHeight(e.Graphics)));//para determinar a minha procisão Y da linha, pq dependendo da fonte pode ficar mis encima ou mais embaixo para encaixar direito, ele praticamente pega o tamanho da minha fonte
                e.Graphics.DrawString(linha, fonte, pincel, margemEsquerda, posY, new StringFormat());//para desenhar a string na hora de imprimir
                cont++;
                linha = leitura.ReadLine();
            }
            if (linha != null)
            {
                e.HasMorePages = true;//Caso haja ainda mais linhas ele imprime em outra pagina
            }
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();
        }
    }
}
