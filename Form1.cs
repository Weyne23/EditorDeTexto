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
            if(MessageBox.Show("Desejá salvar o arquivo?", "Mensagem", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                salvar();
                limpar();
            }
            else if(MessageBox.Show("Desejá descartar o arquivo?", "Mensagem", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);//filestream cria um novo arquivo//primeiro paranmetro é o nome do arquivo
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
            catch(Exception ex)
            {
                MessageBox.Show("Erro na gravação: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
