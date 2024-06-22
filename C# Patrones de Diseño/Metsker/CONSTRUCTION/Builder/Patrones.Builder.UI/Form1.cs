using Patrones.Builder.Core;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Patrones.Builder.UI
{
    public partial class Form1 : Form
    {
        private readonly List<PizzaBuilder> _lineas;
        public Form1()
        {
            InitializeComponent();

            _lineas = new List<PizzaBuilder>
            {
                new PizzaItalianaBuilder(),
                new PizzaLightBuilder(),
                new PizzaMuzzaBuilder(),
                new PizzaDeCanchaBuilder()
            };

            this.cboLineas.DataSource = _lineas;
        
        }

        private void btnConstruír_Click(object sender, EventArgs e)
        {
            PizzaBuilder builder = (PizzaBuilder)cboLineas.SelectedItem;
            Pizza pizza = builder.BuildPizza();

            this.lstEntregas.Items.Add(pizza);
        }
    }
}
