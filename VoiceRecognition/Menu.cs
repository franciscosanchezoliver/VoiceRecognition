using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace VoiceRecognition
{
    public partial class Menu : Form
    {
        ReconocimientoDeVoz reconocimientoDeVoz;

        public Menu()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            reconocimientoDeVoz = new ReconocimientoDeVoz(this);
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            reconocimientoDeVoz.ParaReconocimientoDeVoz();
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            reconocimientoDeVoz.ArrancarConocimientoDeVoz();
        }

    }
}
