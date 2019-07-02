using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Newtonsoft.Json;
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

        

        public Form1()
        {
            InitializeComponent();

            presenceSensorBindingSource.Add(pre);
            temperatureSensorBindingSource.Add(temp);
            lightSensorBindingSource.Add(light);
            atmPressureSensorBindingSource.Add(atm);
            humiditySensorBindingSource.Add(hum);
            soundLevelSensorBindingSource.Add(sound);
            gpsSensorBindingSource.Add(gps);
            cO2SensorBindingSource.Add(co2);
            lEDBindingSource.Add(led);
            beeperBindingSource.Add(beep);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            beep.tick();
            led.tick();

            atm.tick();
            co2.tick();
            gps.tick();
            hum.tick();
            light.tick();
            pre.tick();
            sound.tick();
            temp.tick();
        }

        private void presenceSensorBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendTimer.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendTimer.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            atm.RegisterDevice();
            beep.RegisterDevice();
            co2.RegisterDevice();
            gps.RegisterDevice();
            hum.RegisterDevice();
            led.RegisterDevice();
            light.RegisterDevice();
            pre.RegisterDevice();
            sound.RegisterDevice();
            temp.RegisterDevice();
        }

        private void MetricsTimer_Tick(object sender, EventArgs e)
        {
            
            atm.generateMetric();
            co2.generateMetric();
            gps.generateGPSMetric();
            hum.generateMetric();
            light.generateMetric();
            pre.generateMetric();
            sound.generateMetric();
            temp.generateMetric();
        }
    }
}
