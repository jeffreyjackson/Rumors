using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;


namespace CECS622_P1
{
    public partial class frmProject1 : Form
    {
        public frmProject1()
        {
            InitializeComponent();
        }

        public ArrayList RandomizeArrayList(ArrayList arrayList, Random random)
        {
            if (arrayList == null) { return arrayList; }
            int count = arrayList.Count;
            for (int i = 0; i < count; i++)
            {
                Object temp = arrayList[i];
                arrayList.RemoveAt(i);
                arrayList.Insert(random.Next(count), temp);
            }
            return arrayList;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            DataSet dsClear = new DataSet();
            dsClear.Clear();
            dgResults.DataSource = dsClear;
            Random r = new Random();
            if (Convert.ToInt16(txtNumStudents.Text) % 2 == 0)
            {
                ArrayList arlStudents = new ArrayList();
                //Initial student 0 has rumor 1
                arlStudents.Add("0.1");
                //All other students 1-n do not have rumor
                for (int i = 1; i < Convert.ToInt16(txtNumStudents.Text); i++)
                {
                    arlStudents.Add(i.ToString() + ".0");
                }
                bool blnFlag = false;
                bool bln10Shown = false;
                bool bln50Shown = false;
                int j = 2;
                double dblRandom;
                int intTime = 0;
                int intCount = 0;
                int intLiars = 0;
                while (blnFlag == false)
                {
                    for (int i = 0; i < Convert.ToInt16(arlStudents.Count); i++)
                    {
                        if (Convert.ToString(arlStudents[i].ToString()).Remove(0, arlStudents[i].ToString().Length - 1) == "1" || Convert.ToString(arlStudents[i+1].ToString()).Remove(0, arlStudents[i + 1].ToString().Length - 1) == "1")
                        {
                            if (Convert.ToString(arlStudents[i].ToString()).Remove(0, arlStudents[i].ToString().Length - 1) == "1" && Convert.ToString(arlStudents[i+1].ToString()).Remove(0, arlStudents[i + 1].ToString().Length - 1) == "1")
                            {
                                dblRandom = r.NextDouble();
                                if (dblRandom > .5)
                                {
                                    //if the first one with the rumor engages, then the second has heard twice.  
                                    arlStudents[i + 1] = Convert.ToString(arlStudents[i + 1].ToString()).Remove(arlStudents[i + 1].ToString().Length - 1, 1) + "2";
                                }
                                dblRandom = r.NextDouble();
                                if (dblRandom > .5)
                                {
                                    //if the second one with the rumor engages, then the first has heard twice.  
                                    arlStudents[i] = Convert.ToString(arlStudents[i].ToString()).Remove(arlStudents[i].ToString().Length - 1, 1) + "2";
                                }
                            }
                            else
                            {
                                if (Convert.ToString(arlStudents[i].ToString()).Remove(0, arlStudents[i].ToString().Length - 1) == "1")
                                {
                                    dblRandom = r.NextDouble();
                                    if (dblRandom > .5)
                                    {
                                        if (Convert.ToString(arlStudents[i+1].ToString()).Remove(0, arlStudents[i+1].ToString().Length - 1) != "2")
                                        {
                                            arlStudents[i + 1] = Convert.ToString(arlStudents[i + 1].ToString()).Remove(arlStudents[i + 1].ToString().Length - 1, 1) + "1";
                                        }
                                    }
                                }
                                else
                                {
                                    dblRandom = r.NextDouble();
                                    if (dblRandom > .5)
                                    {
                                        if (Convert.ToString(arlStudents[i].ToString()).Remove(0, arlStudents[i].ToString().Length - 1) != "2")
                                        {
                                            arlStudents[i] = Convert.ToString(arlStudents[i].ToString()).Remove(arlStudents[i].ToString().Length - 1, 1) + "1";
                                        }
                                    }
                                }
                            }
                        }
                        i = i + 1;
                    }
                    intTime = intTime + 1;
                    arlStudents = RandomizeArrayList(arlStudents, r);
                    intCount = 0;
                    intLiars = 0;
                    for (int k = 0; k < Convert.ToInt16(arlStudents.Count); k++)
                    {
                        if (Convert.ToString(arlStudents[k].ToString()).Remove(0, arlStudents[k].ToString().Length - 1) == "1")
                        {
                            intLiars = intLiars + 1;
                        }
                        if (Convert.ToString(arlStudents[k].ToString()).Remove(0, arlStudents[k].ToString().Length - 1) == "1" || Convert.ToString(arlStudents[k].ToString()).Remove(0, arlStudents[k].ToString().Length - 1) == "2")
                        {
                            //how many have heard the rumor
                            intCount = intCount + 1;
                        }
                    }
                    if (intLiars == 1 || intLiars == 0)
                    {
                        blnFlag = true;
                    }
                    if (intTime == 10)
                    {
                        MessageBox.Show(Convert.ToString(Convert.ToDouble(intCount) / Convert.ToDouble(arlStudents.Count) * 100) + "%", "After 10 minutes...");
                    }
                    if (intTime == 20)
                    {
                        MessageBox.Show(Convert.ToString(Convert.ToDouble(intCount) / Convert.ToDouble(arlStudents.Count) * 100) + "%", "After 20 minutes...");
                    }
                    if (intTime == 40)
                    {
                        MessageBox.Show(Convert.ToString(Convert.ToDouble(intCount) / Convert.ToDouble(arlStudents.Count) * 100) + "%", "After 40 minutes...");
                    }
                    if (bln10Shown == false)
                    {
                        if (Convert.ToDouble(intCount) / Convert.ToDouble(arlStudents.Count)> .1)
                        {
                            bln10Shown = true;
                            MessageBox.Show("10% of the students knew the rumor at time " + Convert.ToString(intTime), "10% Effected");
                        }
                    }
                    if (bln50Shown == false)
                    {
                        if (Convert.ToDouble(intCount) / Convert.ToDouble(arlStudents.Count) > .5)
                        {
                            bln50Shown = true;
                            MessageBox.Show("50% of the students knew the rumor at time " + Convert.ToString(intTime), "50% Effected");
                        }
                    }
                }
                MessageBox.Show("Done @ t = " + intTime);
            }
            else
            {
                MessageBox.Show("The number of students should be even", "Even Number");
            }
        }
    }
}