﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EliteTeam.BaseLib;

namespace EliteTeam.PresentationLayer
{
    public partial class frmMatchSimulation : Form, IMatchView
    {
        public frmMatchSimulation()
        {
            InitializeComponent();
        }

        public void CloseView()
        {
            throw new NotImplementedException();
        }

        public void ShowModaless(IMatchController matchController)
        {
            throw new NotImplementedException();
        }
    }
}
