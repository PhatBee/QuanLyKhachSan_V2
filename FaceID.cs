﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FaceID : Form
    {
        string id;
        FaceRec faceRec = new FaceRec();

        public FaceID(string id)
        {

            InitializeComponent();
            faceRec.openCamera(pictureBox1);
            this.id = id;
        }
       /* public FaceID()
        {
            InitializeComponent();
            faceRec.openCamera(pictureBox1);
            this.id = id;
        }*/



        private void FaceID_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE(id);
        }

        private void FaceID_FormClosed(object sender, FormClosedEventArgs e)
        {
            faceRec.closeCamera();
        }

        private void FaceID_FormClosing(object sender, FormClosingEventArgs e)
        {
            faceRec.closeCamera();
        }
    }
}