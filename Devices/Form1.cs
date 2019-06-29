using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            AtmPressureSensor atm = new AtmPressureSensor();
            Beeper beep = new Beeper();
            CO2Sensor co2 = new CO2Sensor();
            GpsSensor gps = new GpsSensor();
            HumiditySensor hum = new HumiditySensor();
            LED led = new LED();
            LightSensor light = new LightSensor();
            PresenceSensor pre = new PresenceSensor();
            SoundLevelSensor sound = new SoundLevelSensor();
            TemperatureSensor temp = new TemperatureSensor();


            
            InitializeComponent();
            label3.DataBindings.Add("Text", pre, "id");
            label5.DataBindings.Add("Text", pre, "Name");
            label7.DataBindings.Add("Text", pre, "Type");
            label9.DataBindings.Add("Text", pre, "Metric");
            label11.DataBindings.Add("Text", pre, "Mac");

            label14.DataBindings.Add("Text", temp, "id");
            label16.DataBindings.Add("Text", temp, "Name");
            label18.DataBindings.Add("Text", temp, "Type");
            label20.DataBindings.Add("Text", temp, "Metric");
            label22.DataBindings.Add("Text", temp, "Mac");

            label25.DataBindings.Add("Text", light, "id");
            label27.DataBindings.Add("Text", light, "Name");
            label29.DataBindings.Add("Text", light, "Type");
            label31.DataBindings.Add("Text", light, "Metric");
            label33.DataBindings.Add("Text", light, "Mac");

            label36.DataBindings.Add("Text", atm, "id");
            label38.DataBindings.Add("Text", atm, "Name");
            label40.DataBindings.Add("Text", atm, "Type");
            label42.DataBindings.Add("Text", atm, "Metric");
            label44.DataBindings.Add("Text", atm, "Mac");

            label47.DataBindings.Add("Text", hum, "id");
            label49.DataBindings.Add("Text", hum, "Name");
            label51.DataBindings.Add("Text", hum, "Type");
            label53.DataBindings.Add("Text", hum, "Metric");
            label55.DataBindings.Add("Text", hum, "Mac");

            label58.DataBindings.Add("Text", sound, "id");
            label60.DataBindings.Add("Text", sound, "Name");
            label62.DataBindings.Add("Text", sound, "Type");
            label64.DataBindings.Add("Text", sound, "Metric");
            label66.DataBindings.Add("Text", sound, "Mac");

            label69.DataBindings.Add("Text", gps, "id");
            label71.DataBindings.Add("Text", gps, "Name");
            label73.DataBindings.Add("Text", gps, "Type");
            label75.DataBindings.Add("Text", gps, "Metric");
            label77.DataBindings.Add("Text", gps, "Mac");

            label80.DataBindings.Add("Text", co2, "id");
            label82.DataBindings.Add("Text", co2, "Name");
            label84.DataBindings.Add("Text", co2, "Type");
            label86.DataBindings.Add("Text", co2, "Metric");
            label88.DataBindings.Add("Text", co2, "Mac");

            label91.DataBindings.Add("Text", led, "id");
            label93.DataBindings.Add("Text", led, "Name");
            label95.DataBindings.Add("Text", led, "Type");
            label97.DataBindings.Add("Text", led, "Metric");
            label99.DataBindings.Add("Text", led, "Mac");

            label102.DataBindings.Add("Text", beep, "id");
            label104.DataBindings.Add("Text", beep, "Name");
            label106.DataBindings.Add("Text", beep, "Type");
            label108.DataBindings.Add("Text", beep, "Metric");
            label110.DataBindings.Add("Text", beep, "Mac");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
