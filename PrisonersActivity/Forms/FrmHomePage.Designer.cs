namespace PrisonersActivity.Forms
{
    partial class FrmHomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHomePage));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.skinPaletteDropDownButtonItem1 = new DevExpress.XtraBars.SkinPaletteDropDownButtonItem();
            this.barListItem2 = new DevExpress.XtraBars.BarListItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ZdocManager = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            this.ZTabView = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZdocManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTabView)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationCaption = "تطبيق إعاشات السجون";
            this.ribbon.ApplicationDocumentCaption = "تطبيق إعاشات السجون";
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Font = new System.Drawing.Font("Tajawal", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.skinRibbonGalleryBarItem1,
            this.skinPaletteDropDownButtonItem1,
            this.barListItem2,
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barDockingMenuItem1,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7,
            this.barButtonItem8});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 17;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsAnimation.PageCategoryShowAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.ribbon.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.ribbon.SearchItemShortcut = new DevExpress.XtraBars.BarShortcut((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F));
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.ShowOnMultiplePages;
            this.ribbon.ShowQatLocationSelector = false;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(760, 161);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "SKIN";
            this.skinRibbonGalleryBarItem1.Id = 1;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // skinPaletteDropDownButtonItem1
            // 
            this.skinPaletteDropDownButtonItem1.Id = 2;
            this.skinPaletteDropDownButtonItem1.Name = "skinPaletteDropDownButtonItem1";
            // 
            // barListItem2
            // 
            this.barListItem2.Caption = "نمط النافذة";
            this.barListItem2.Id = 4;
            this.barListItem2.ImageOptions.ImageUri.Uri = "spreadsheet/pivottableoptions;Size16x16";
            this.barListItem2.Name = "barListItem2";
            this.barListItem2.Strings.AddRange(new object[] {
            "Default",
            "Office2007",
            "Office2010",
            "Office2013",
            "Office2019",
            "MacOffice",
            "TabletOffice",
            "OfficeUniversal"});
            this.barListItem2.ListItemClick += new DevExpress.XtraBars.ListItemClickEventHandler(this.barListItem2_ListItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "السجناء";
            this.barButtonItem2.Id = 6;
            this.barButtonItem2.ImageOptions.ImageUri.Uri = "richedit/reviewers;Size16x16";
            this.barButtonItem2.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tajawal", 9F);
            this.barButtonItem2.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem2.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tajawal", 9F);
            this.barButtonItem2.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tajawal", 9F);
            this.barButtonItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem2.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tajawal", 9F);
            this.barButtonItem2.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "قائمة الجنسيات";
            this.barButtonItem3.Id = 7;
            this.barButtonItem3.ImageOptions.ImageUri.Uri = "spreadsheet/3flags;Size16x16";
            this.barButtonItem3.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem3.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem3.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem3.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem3.ItemAppearance.Normal.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem3.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem3.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tajawal", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem3.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "الإعدادات";
            this.barButtonItem4.Id = 9;
            this.barButtonItem4.ImageOptions.ImageUri.Uri = "icon%20builder/actions_settings;Size16x16";
            this.barButtonItem4.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem4.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem4.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem4.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem4.ItemAppearance.Normal.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem4.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem4.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem4.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Id = 10;
            this.barDockingMenuItem1.ImageOptions.ImageUri.Uri = "miscellaneous/windows;Size16x16";
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "استيراد";
            this.barButtonItem5.Id = 12;
            this.barButtonItem5.ImageOptions.ImageUri.Uri = "ExportToXLS;Size16x16";
            this.barButtonItem5.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem5.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem5.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem5.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem5.ItemAppearance.Normal.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem5.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem5.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem5.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "السجناء المنقولين";
            this.barButtonItem6.Id = 13;
            this.barButtonItem6.ImageOptions.ImageUri.Uri = "business%20objects/bo_transition;Size16x16";
            this.barButtonItem6.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tajawal", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem6.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem6.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem6.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem6.ItemAppearance.Normal.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem6.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem6.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem6.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "مركز التقارير";
            this.barButtonItem7.Id = 15;
            this.barButtonItem7.ImageOptions.ImageUri.Uri = "business%20objects/bo_report;Size16x16";
            this.barButtonItem7.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem7.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem7.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem7.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem7.ItemAppearance.Normal.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem7.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem7.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem7.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3});
            this.ribbonPage1.ImageOptions.ImageUri.Uri = "Home;Size16x16";
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "القوائم الرئيسية";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem3);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem6);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem7);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem5);
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem8);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2});
            this.ribbonPage2.ImageOptions.ImageUri.Uri = "business%20objects/bo_user;Size16x16";
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "تفضيلات المستخدم";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.skinPaletteDropDownButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.barListItem2);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barDockingMenuItem1);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 387);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(760, 24);
            // 
            // ZdocManager
            // 
            this.ZdocManager.MdiParent = this;
            this.ZdocManager.MenuManager = this.ribbon;
            this.ZdocManager.View = this.ZTabView;
            this.ZdocManager.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.ZTabView});
            // 
            // ZTabView
            // 
            this.ZTabView.AllowHotkeyNavigation = DevExpress.Utils.DefaultBoolean.True;
            this.ZTabView.Appearance.Font = new System.Drawing.Font("Tajawal", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZTabView.Appearance.Options.UseFont = true;
            this.ZTabView.AppearancePage.Header.Font = new System.Drawing.Font("Tajawal", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZTabView.AppearancePage.Header.Options.UseFont = true;
            this.ZTabView.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tajawal", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZTabView.AppearancePage.HeaderActive.Options.UseFont = true;
            this.ZTabView.AppearancePage.HeaderDisabled.Font = new System.Drawing.Font("Tajawal", 9.749999F, System.Drawing.FontStyle.Italic);
            this.ZTabView.AppearancePage.HeaderDisabled.Options.UseFont = true;
            this.ZTabView.AppearancePage.HeaderHotTracked.Font = new System.Drawing.Font("Tajawal", 9F);
            this.ZTabView.AppearancePage.HeaderHotTracked.Options.UseFont = true;
            this.ZTabView.AppearancePage.HeaderHotTracked.Options.UseTextOptions = true;
            this.ZTabView.AppearancePage.HeaderHotTracked.TextOptions.Trimming = DevExpress.Utils.Trimming.EllipsisCharacter;
            this.ZTabView.AppearancePage.HeaderSelected.Font = new System.Drawing.Font("Tajawal", 9F);
            this.ZTabView.AppearancePage.HeaderSelected.Options.UseFont = true;
            this.ZTabView.AppearancePage.PageClient.Font = new System.Drawing.Font("Tajawal", 9F);
            this.ZTabView.AppearancePage.PageClient.Options.UseFont = true;
            this.ZTabView.DocumentProperties.AllowFloat = false;
            this.ZTabView.DocumentProperties.AllowFloatOnDoubleClick = false;
            this.ZTabView.DocumentProperties.UseFormIconAsDocumentImage = true;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "استيراد قالب الإدارة";
            this.barButtonItem8.Id = 16;
            this.barButtonItem8.ImageOptions.ImageUri.Uri = "dashboards/drilldown;Size16x16";
            this.barButtonItem8.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem8.ItemAppearance.Disabled.Options.UseFont = true;
            this.barButtonItem8.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem8.ItemAppearance.Hovered.Options.UseFont = true;
            this.barButtonItem8.ItemAppearance.Normal.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem8.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem8.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tajawal", 9.749999F);
            this.barButtonItem8.ItemAppearance.Pressed.Options.UseFont = true;
            this.barButtonItem8.Name = "barButtonItem8";
            this.barButtonItem8.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem8_ItemClick);
            // 
            // FrmHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 411);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("FrmHomePage.IconOptions.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmHomePage";
            this.Ribbon = this.ribbon;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmHomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZdocManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZTabView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        public DevExpress.XtraBars.Docking2010.DocumentManager ZdocManager;
        public DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView ZTabView;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.SkinPaletteDropDownButtonItem skinPaletteDropDownButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarListItem barListItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
    }
}