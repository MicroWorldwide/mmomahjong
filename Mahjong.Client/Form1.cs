using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mahjong.Plugin;
using Mahjong.Core;

namespace Mahjong.Client
{
    public partial class Form1 : Form
    {
        IReferee refe;
        PlayerData p1;
        PlayerData p2;
        PlayerData p3;
        PlayerData p4;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Plugin p = new Plugin(Environment.CurrentDirectory);
            refe = p.GetReferees()[0];
            p1 = new PlayerData("Player 1");
            refe.AddPlayer(p1);
            p2 = new PlayerData("Player 2");
            refe.AddPlayer(p2);
            p3 = new PlayerData("Player 3");
            refe.AddPlayer(p3);
            p4 = new PlayerData("Player 4");
            refe.AddPlayer(p4);
            refe.NewGame();
            Draw();
        }

        void Draw()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            Group g1 = p1.GetHand();
            Group g2 = p2.GetHand();
            Group g3 = p3.GetHand();
            Group g4 = p4.GetHand();
            for (int i = 0; i < g1.Count; i++)
                listBox1.Items.Add(g1[i].GetNumber().ToString() + " " + g1[i].GetFamily().ToString());
            for (int i = 0; i < g2.Count; i++)
                listBox2.Items.Add(g2[i].GetNumber().ToString() + " " + g2[i].GetFamily().ToString());
            for (int i = 0; i < g3.Count; i++)
                listBox3.Items.Add(g3[i].GetNumber().ToString() + " " + g3[i].GetFamily().ToString());
            for (int i = 0; i < g4.Count; i++)
                listBox4.Items.Add(g4[i].GetNumber().ToString() + " " + g4[i].GetFamily().ToString());
            listBox1.Items.Add("");
            listBox2.Items.Add("");
            listBox3.Items.Add("");
            listBox4.Items.Add("");
            if (p1.GetRejected() != null)
                listBox1.Items.Add(p1.GetRejected().GetNumber().ToString() + " " + p1.GetRejected().GetFamily().ToString());
            if (p2.GetRejected() != null)
                listBox2.Items.Add(p2.GetRejected().GetNumber().ToString() + " " + p2.GetRejected().GetFamily().ToString());
            if (p3.GetRejected() != null)
                listBox3.Items.Add(p3.GetRejected().GetNumber().ToString() + " " + p3.GetRejected().GetFamily().ToString());
            if (p4.GetRejected() != null)
                listBox4.Items.Add(p4.GetRejected().GetNumber().ToString() + " " + p4.GetRejected().GetFamily().ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += refe.CurrentPlayer().GetName() + " Reject \r\n";
            if (refe.Rejected(refe.CurrentPlayer().GetHand()[listBox1.SelectedIndex]))
            {
                Draw();
                textBox1.Text += refe.CurrentPlayer().GetName() + " Play Free " + refe.GetNumberFreeTile().ToString() + "\r\n";
                List<Mahjong.Plugin.IReferee.m_rulepossibility> tmp = refe.GetRulesPossibilities(refe.CurrentPlayer());
                button2.Enabled = false;
                button5.Enabled = false;
                for (int i = 0; i < tmp.Count; i++)
                {
                    textBox1.Text += tmp[i].Rule.GetName() + " : " + tmp[i].Player.GetName();
                    if (tmp[i].Rule.GetName() == "Pong")
                        button2.Enabled = true;
                    if (tmp[i].Rule.GetName() == "Kong")
                        button5.Enabled = true;

                }
                   
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Mahjong.Plugin.IReferee.m_rulepossibility> tmp = refe.GetRulesPossibilities(refe.CurrentPlayer());
            refe.Call(tmp[0]);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            refe.Take();
            Draw();
        }
    }
}