﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BethanysPieShopMobile;
using BethanysPieShopMobile.Model;
using Xamarin.Forms;

namespace BethanysPieShopMobile
{
    public partial class MainPage : MasterDetailPage
    {

        public MainPage()
        {
            InitializeComponent();

            MasterView.NavigationListView.ItemSelected += NavigationListView_ItemSelected;
        }

        private void NavigationListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterNavigationItem item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.Target));
                MasterView.NavigationListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
