using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueuingSystem
{
    public partial class CashierWindowQueue : Form
    {
        // Timer declaration
        private Timer timer;

        public CashierWindowQueue()
        {
            InitializeComponent();

            // Setup ListView Columns
            listCashierQueue.Columns.Add("Queue Number", 180);

            // Setup Timer for Auto Refresh
            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += new EventHandler(timer1_tick); 
            timer.Start(); 
        }

        // Display Method for Queue items
        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        // Refresh Button Click
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        // Remove the served customer
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                CashierClass.CashierQueue.Dequeue(); // Removes front item
                DisplayCashierQueue(CashierClass.CashierQueue);
            }
            else
            {
                MessageBox.Show("Queue is currently empty!");
            }
        }

        // Timer
        private void timer1_tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }
    }
}
