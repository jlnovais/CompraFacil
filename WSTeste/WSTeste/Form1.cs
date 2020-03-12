using System;
using System.Windows.Forms;
using WSTeste.ClickSMS;
using WSTeste.WSCompraFacilPS;

namespace WSTeste
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBoxValor.SelectedIndex = 0;
            comboBoxValor1.SelectedIndex = 0;
            comboBoxValor2.SelectedIndex = 0;
            comboBoxValor3.SelectedIndex = 0;


            txtOrigemV5.Text = "test from program " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            try
            {
                var ws = new CompraFacilWS.CompraFacilWS();

                txtWSInfo.Text = "V5: " + ws.Url + txtWSInfo.Text;

                ws.Dispose();
            }
            catch
            {
                txtWSInfo.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "  Unable to access WebService (V5).";
            }


            txtOrigem.Text = "test from program " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            try
            {
                var ws = new clicksmsV4();

                txtWSInfo.Text += Environment.NewLine + "V4: " + ws.Url;

                ws.Dispose();
            }
            catch
            {
                txtWSInfo.Text += Environment.NewLine + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                  "   Unable to access WebService (V4).";
            }

            txtOrigem2.Text = "test from program " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            try
            {
                var ps = new CompraFacilPS();

                txtWSInfo.Text += Environment.NewLine + "V4: " + ps.Url;

                ps.Dispose();
            }
            catch
            {
                txtWSInfo.Text += Environment.NewLine + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                  "   Unable to access WebService (V4-PS).";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "" ||
                txtReferencia.Text.Trim() == "")
            {
                MessageBox.Show("You must insert user details and reference", "Get Info reference");
            }
            else
            {
                bool res;
                bool pago;
                var estado = "";
                var error = "";

                string dataUltimoPagamento;
                int totalPagamentos;

                if (radioV4.Checked)
                {
                    var ws = new clicksmsV4();

                    res = ws.getInfoCompra(txtReferencia.Text, txtUsername.Text, txtPassword.Text,
                        out pago, out estado, out dataUltimoPagamento, out totalPagamentos,
                        out error);
                }
                else
                {
                    var ws = new CompraFacilWS.CompraFacilWS();

                    res = ws.getInfoReference(txtReferencia.Text, txtUsername.Text, txtPassword.Text,
                        out pago, out estado, out dataUltimoPagamento, out totalPagamentos,
                        out error);
                }

                txtResultado.Text = "";

                if (res)
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") + "\r\n Call to webservice (" +
                                        (radioV4.Checked ? "getInfoCompra" : "getInfoReference") + ") executed OK.\n\n";
                    txtResultado.Text += "\r\npaid: " + pago;
                    txtResultado.Text += "\r\nstate: " + estado;
                    txtResultado.Text += "\r\nLast payment: " + dataUltimoPagamento;
                    txtResultado.Text += "\r\nTotal payments: " + totalPagamentos;

                    txtResultado.Text += "\r\nerror: " + error;

                    //if (dataUltimoPagamento.Trim() != "")
                    //{
                    //    IFormatProvider culture = new System.Globalization.CultureInfo("pt-PT", true);
                    //    DateTime d = Convert.ToDateTime(dataUltimoPagamento, culture);
                    //
                    //    txtResultado.Text += "\r\nData passando por dateTime:" + d.ToString("dd-MM-yyyy HH:mm:ss");
                    //}
                }
                else
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Call to webservice (getInfoCompra) executed NOT OK.\r\n";
                    txtResultado.Text += "\r\nerror: " + error;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("You must insert user details and value.", "Create reference");
            }
            else
            {
                decimal valor = -1;

                try
                {
                    if (comboBoxValor.SelectedItem.ToString() == "(other)")
                        valor = Convert.ToDecimal(txtValor.Text);
                    else
                        valor = Convert.ToDecimal(comboBoxValor.SelectedItem.ToString());
                }
                catch
                {
                    MessageBox.Show("The amount specified is invalid.", "Create reference");
                    return;
                }


                var ws = new clicksmsV4();

                string origem = txtOrigem.Text;
                string informacao = "test from program " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");


                var referencia = "";
                var entidade = "";
                decimal valorOut = 0;
                var error = "";
                var userBackoffice = -1;

                bool res = ws.SaveCompraToBDValor1(origem, txtUsername.Text, txtPassword.Text, valor,
                    informacao, userBackoffice,
                    out referencia, out entidade, out valorOut, out error);

                if (res)
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Call to webservice (SaveCompraToBDValor1) executed OK.\n\n";
                    txtResultado.Text += "\r\nreference: " + referencia;
                    txtResultado.Text += "\r\nentity: " + entidade;
                    txtResultado.Text += "\r\nvalueOut: " + valorOut;
                    txtResultado.Text += "\r\nerror: " + error;
                }
                else
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Call to webservice (SaveCompraToBDValor1) executed NOT OK.\r\n";
                    txtResultado.Text += "\r\nerror: " + error;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Deve especificar os dados de acesso e valor", "Geração de referência");
            }
            else
            {
                decimal valor = -1;

                try
                {
                    valor = Convert.ToDecimal(comboBoxValor1.SelectedItem.ToString() == "(other)" ? txtValor1.Text : comboBoxValor1.SelectedItem.ToString());
                }
                catch
                {
                    MessageBox.Show("The amount specified is invalid.", "Create reference");
                    return;
                }


                var ws = new clicksmsV4();

                string origem = txtOrigem1.Text;
                string informacao = "teste do programa [SaveCompraToBDValor2]" +
                                    DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");


                string referencia = "";
                string entidade = "";
                decimal valorOut = 0;
                string error = "";
                int userBackoffice = -1;

                bool res = ws.SaveCompraToBDValor2(origem, txtUsername.Text, txtPassword.Text,
                    valor,
                    informacao, "Nome do cliente de teste", "", "", "", "", "", "", "",
                    userBackoffice,
                    out referencia, out entidade, out valorOut, out error);

                if (res)
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Chamada ao WebService (SaveCompraToBDValor2) executada COM sucesso.\n\n";
                    txtResultado.Text += "\r\nreferencia: " + referencia;
                    txtResultado.Text += "\r\nentidade: " + entidade;
                    txtResultado.Text += "\r\nvalorOut: " + valorOut;
                    txtResultado.Text += "\r\nerror: " + error;
                }
                else
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Chamada ao WebService (SaveCompraToBDValor2) executada SEM sucesso.\r\n";
                    txtResultado.Text += "\r\nerror: " + error;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Deve especificar os dados de acesso e valor", "Geração de referência");
            }
            else
            {
                decimal valor = -1;

                try
                {
                    if (comboBoxValor2.SelectedItem.ToString() == "(other)")
                        valor = Convert.ToDecimal(txtValor2.Text);
                    else
                        valor = Convert.ToDecimal(comboBoxValor2.SelectedItem.ToString());
                }
                catch
                {
                    MessageBox.Show("The amount specified is invalid.", "Create reference");
                    return;
                }


                var ws = new CompraFacilPS();

                string origem = txtOrigem2.Text;
                string informacao = "teste do programa " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");


                string referencia = "";
                string dataLimitePagamento = "";
                decimal valorOut = 0;
                string error = "";
                int userBackoffice = -1;

                bool res = ws.SaveCompraToBDValor1(origem, txtUsername.Text, txtPassword.Text, valor,
                    informacao, userBackoffice,
                    out referencia, out dataLimitePagamento, out valorOut, out error);

                if (res)
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Chamada ao WebService (SaveCompraToBDValor1) [PS] executada COM sucesso.\n\n";
                    txtResultado.Text += "\r\nreferencia: " + referencia;
                    txtResultado.Text += "\r\ndataLimitePagamento: " + dataLimitePagamento;
                    txtResultado.Text += "\r\nvalorOut: " + valorOut;
                    txtResultado.Text += "\r\nerror: " + error;
                }
                else
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Chamada ao WebService (SaveCompraToBDValor1) [PS] executada SEM sucesso.\r\n";
                    txtResultado.Text += "\r\nerror: " + error;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Deve especificar os dados de acesso e valor", "Geração de referência");
            }
            else
            {
                decimal valor = -1;

                try
                {
                    if (comboBoxValor3.SelectedItem.ToString() == "(other)")
                        valor = Convert.ToDecimal(txtValor3.Text);
                    else
                        valor = Convert.ToDecimal(comboBoxValor3.SelectedItem.ToString());
                }
                catch
                {
                    MessageBox.Show("The amount specified is invalid.", "Create reference");
                    return;
                }


                var ws = new CompraFacilPS();

                string origem = txtOrigem3.Text;
                string informacao = "teste do programa [SaveCompraToBDValor2]" +
                                    DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");


                string referencia = "";
                string dataLimitePagamento = "";
                decimal valorOut = 0;
                string error = "";
                int userBackoffice = -1;

                bool res = ws.SaveCompraToBDValor2(origem, txtUsername.Text, txtPassword.Text,
                    valor,
                    informacao, "Nome do cliente de teste", "", "", "", "", "", "", "",
                    userBackoffice,
                    out referencia, out dataLimitePagamento, out valorOut, out error);

                if (res)
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Chamada ao WebService (SaveCompraToBDValor2) [PS] executada COM sucesso.\n\n";
                    txtResultado.Text += "\r\nreferencia: " + referencia;
                    txtResultado.Text += "\r\ndataLimitePagamento: " + dataLimitePagamento;
                    txtResultado.Text += "\r\nvalorOut: " + valorOut;
                    txtResultado.Text += "\r\nerror: " + error;
                }
                else
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Chamada ao WebService (SaveCompraToBDValor2) [PS] executada SEM sucesso.\r\n";
                    txtResultado.Text += "\r\nerror: " + error;
                }
            }
        }

        private void comboBoxValor_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValor.Enabled = ((ComboBox) sender).SelectedItem.ToString() == "(other)";
        }


        private void comboBoxValor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValor1.Enabled = ((ComboBox) sender).SelectedItem.ToString() == "(other)";
        }

        private void comboBoxValor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValor2.Enabled = ((ComboBox) sender).SelectedItem.ToString() == "(other)";
        }

        private void comboBoxValor3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValor3.Enabled = ((ComboBox) sender).SelectedItem.ToString() == "(other)";
        }

        private void comboBoxValorV5_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValorV5.Enabled = ((ComboBox) sender).SelectedItem.ToString() == "(other)";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            const int userBackoffice = -1;

            if (txtPassword.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("You must insert user details and value.", "Create reference");
            }
            else
            {
                decimal valor = -1;
                int validade = 0;

                try
                {
                    valor =
                        Convert.ToDecimal(comboBoxValorV5.SelectedItem.ToString() == "(other)"
                            ? txtValorV5.Text
                            : comboBoxValorV5.SelectedItem.ToString());
                }
                catch
                {
                    MessageBox.Show("The amount specified is invalid.", "Create reference");
                    return;
                }

                try
                {
                    validade = Convert.ToInt32(txtValidadeV5.Text);
                }
                catch
                {
                    MessageBox.Show("Time limit is invalid.", "Create reference");
                    return;
                }


                var ws = new CompraFacilWS.CompraFacilWS();

                string origin = txtOrigem.Text;
                string info = "test from program " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                string reference = "";
                decimal valorOut = 0;
                string error = "";

                bool sendEmailBuyer = (radioEmailYES.Checked);

                if (radioMB.Checked)
                {
                    string entity = "";
                    bool res = ws.getReferenceMB(origin, txtUsername.Text, txtPassword.Text, valor,
                        info, "name - test", "address - test", "postCode - test", "city - test",
                        "0000000", "", "123456789", txtEmail.Text, userBackoffice, validade, sendEmailBuyer,
                        out reference, out entity, out valorOut, out error);

                    if (res)
                    {
                        txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                            "\r\n Call to webservice (getReferenceMB - Multibanco) executed OK.\n\n";
                        txtResultado.Text += "\r\nreference: " + reference;
                        txtResultado.Text += "\r\nentity: " + entity;
                        txtResultado.Text += "\r\nvalueOut: " + valorOut;
                        txtResultado.Text += "\r\nerror: " + error;
                    }
                    else
                    {
                        txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                            "\r\n Call to webservice (getReferenceMB- Multibanco) executed NOT OK.\r\n";
                        txtResultado.Text += "\r\nerror: " + error;
                    }
                }
                else
                {
                    string limitePagamento = "";
                    bool res = ws.getReferencePS(origin, txtUsername.Text, txtPassword.Text, valor,
                        info, "name - test", "address - test", "postCode - test", "city - test",
                        "0000000", "", "123456789", txtEmail.Text, userBackoffice, sendEmailBuyer,
                        out reference, out limitePagamento, out valorOut, out error);

                    if (res)
                    {
                        txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                            "\r\n Call to webservice (getReferencePS - Payshop) executed OK.\n\n";
                        txtResultado.Text += "\r\nreference: " + reference;
                        txtResultado.Text += "\r\ndeadline for payment: " + limitePagamento;
                        txtResultado.Text += "\r\nvalueOut: " + valorOut;
                        txtResultado.Text += "\r\nerror: " + error;
                    }
                    else
                    {
                        txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                            "\r\n Call to webservice (getReferencePS - Payshop) executed NOT OK.\r\n";
                        txtResultado.Text += "\r\nerror: " + error;
                    }
                }
            }
        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "" ||
                txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("You must insert user details.", "Get Info reference");
            }
            else
            {
                bool res = false;
                string error = "";

                string ids = "";
                string refs = "";

                if (radioV4_1.Checked)
                {
                    var ws = new clicksmsV4();

                    res = ws.getInfo(txtUsername.Text, txtPassword.Text, txtStartDate.Text, txtEndDate.Text,
                        txtType.Text, out ids, out refs,
                        out error);
                }
                else
                {
                    var ws = new CompraFacilWS.CompraFacilWS();

                    res = ws.getInfo(txtUsername.Text, txtPassword.Text, txtStartDate.Text, txtEndDate.Text,
                        txtType.Text, out ids, out refs,
                        out error);
                }

                txtResultado.Text = "";

                if (res)
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Call to webservice (getInfo) executed OK.\n\n";
                    txtResultado.Text += "\r\nIDs: " + ids;
                    txtResultado.Text += "\r\nReferences: " + refs;

                    txtResultado.Text += "\r\nerror: " + error;

                    //if (dataUltimoPagamento.Trim() != "")
                    //{
                    //    IFormatProvider culture = new System.Globalization.CultureInfo("pt-PT", true);
                    //    DateTime d = Convert.ToDateTime(dataUltimoPagamento, culture);
                    //
                    //    txtResultado.Text += "\r\nData passando por dateTime:" + d.ToString("dd-MM-yyyy HH:mm:ss");
                    //}
                }
                else
                {
                    txtResultado.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss") +
                                        "\r\n Call to webservice (getInfo) executed NOT OK.\r\n";
                    txtResultado.Text += "\r\nerror: " + error;
                }
            }
        }
    }
}