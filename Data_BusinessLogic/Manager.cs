﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Data_BusinessLogic.DB;

namespace Data_BusinessLogic
{
    public class Manager
    {
        public static RepairDBContext _context = new RepairDBContext();
        public static Frame MainFrame { get; set; }
        public static void Navigate(Page page)
        {
            MainFrame.Navigate(page);
        }

        public static void GoBack()
        {
            if (MainFrame.CanGoBack)
            {
                MainFrame.GoBack();
            }
        }
    }
}
