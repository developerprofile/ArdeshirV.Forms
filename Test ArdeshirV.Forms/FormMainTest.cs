﻿#region Header

// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.IO;
using System.Drawing;
using ArdeshirV.Forms;
using ArdeshirV.Utilities;
using System.Windows.Forms;
using ArdeshirV.TestForms.Properties;
using AFP = ArdeshirV.Forms.Properties;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.TestForms
{
    public partial class FormMainTest : FormBase
    {
        private int intIncH = 100;
        private int intIncW = 150;
        private const string _stringEmail = "ArdeshirV@protonmail.com";
        private const string _stringWebsite = "https://ardeshirv.github.io/ArdeshirV.Forms";
        //-------------------------------------------------------------------------------
        public FormMainTest()
        {
            InitializeComponent();
            OnShrinkEnd += TestArdeshirV_Forms_OnShrinkEnd;
            StartPosition = FormStartPosition.CenterScreen;
            BackgoundEndGradientColor = Color.Lime;
            BackgoundStartGradientColor = Color.White;
            BackgoundInactiveEndGradientColor = Color.Yellow;
            BackgoundInactiveStartGradientColor = Color.White;
            UpdateMessageBar();
        }
        //-------------------------------------------------------------------------------
        private void TestArdeshirV_Forms_OnShrinkEnd(object sender, EventArgs e)
        {
            UpdateMessageBar();

            if(!buttonShrinkWidth.Enabled)
            {
                intIncW = -intIncW;
                buttonShrinkWidth.Enabled = true;
            }

            if (!buttonShrinkHeight.Enabled)
            {
                intIncH = -intIncH;
                buttonShrinkHeight.Enabled = true;
            }
        }
        //-------------------------------------------------------------------------------
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //-------------------------------------------------------------------------------
        private void buttonShrinkHeight_Click(object sender, EventArgs e)
        {
            buttonShrinkHeight.Enabled = false;
            this.ShrinkHeightByTime(Height - intIncH);
        }
        //-------------------------------------------------------------------------------
        private void buttonShrinkWidth_Click(object sender, EventArgs e)
        {
            buttonShrinkWidth.Enabled = false;
            this.ShrinkWidthByTime(Width - intIncW);
        }
        //-------------------------------------------------------------------------------
        private void buttonNewForm_Click(object sender, EventArgs e)
        {
            Form f = new FormMainTest();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(Location.X + 10, Location.Y + 10);
            f.Show(this);
        }
        //-------------------------------------------------------------------------------
        private void buttonErrorHandlerForm_Click(object sender, EventArgs e)
        {
            try {
        		// Create an error to test FormErrorHandler form
            	File.Open("some-file.ext", FileMode.Open);  // Throw an exception
            } catch (Exception exp) {
                FormErrorHandler.Show(exp, this, _stringWebsite);
            }
        }
        //-------------------------------------------------------------------------------
        private void buttonFormAbout_Click(object sender, EventArgs e)
        {
        	// AssemblyAttributeAccessors retrive all assembly data by reflection
        	AssemblyAttributeAccessors aaa = new AssemblyAttributeAccessors(this);
			string stringAssemblyTitle = aaa.AssemblyTitle;

			// TODO: You are allowed to add your donation addresses in your code like this:
			//Donations[] donations = new Donations[] {
			//	new Donations(      // Donations belong to this component and you can specify 
			//	stringAssemblyTitle,// several donation lists for several different component in your app
			//	new Donation[] {    // All below donations addresses are linked to
			//	              	    // the component with stringAssemblyTitle title
			//		new Donation("Bitcoin",                             // Donation name
			//		             "1MjwviitdNC7ndvjXL3dG7mE9Pir3ZBSBP",  // Donation address
			//		             ArdeshirV.Forms.Properties.Resources.Bitcoin), // Donation logo
			//		// if you use usual public cryptocurrency logos like bitcoin and etc...
			//		// then you can refer to ArdeshirV.Forms.Properties.Resources.Bitcoin image
			//		new Donation("Ethereum",  // Here another example about Ethereum
			//		             "0x1DBED0B76d1070a47613EdEE58D9eD8afD6A206D",
			//		             ArdeshirV.Forms.Properties.Resources.Ethereum)
			//	})};
			
			// Adding all my default donation addresses
			Donations[] donations = new Donations[] {
				new Donations(stringAssemblyTitle, DefaultDonationList.Items)
			};
			
			// You can add your copyright data about your different components like below code
			Copyright[] copyrights = new Copyright[] {
				new Copyright(this, Resources.Logo)  // the first parameter is
				// one of your components and the Copyright constructor can retrive all
				// assembly data about title, version, copyright and description automatically
				// but you are still able to specify title, version, copyright and description
				// yourself with another constructor like below:
				//, new Copyright(Text, "2.0.0", "Company", "Copyleft", "Test", ImageAppLogo)
				// but I prefer the first professional constructor and I think it's better
				// to specify details about your component in your AssemblyInfo.cs file not here
			};
			
			License[] licenses = new License[] {
				new License(stringAssemblyTitle,  // The component name
				            Resources.LICENSE,    // License Contents for specified component
				            Resources.GPLv3)      // License Logo
			};
			
        	FormAboutData data = new FormAboutData(this,
        	                                       copyrights,
        	                                       licenses,
        	                                       donations,
        	                                       _stringWebsite,
        	                                       _stringEmail);
        	FormAbout.Show(data);
        }
        //-------------------------------------------------------------------------------
        private void UpdateMessageBar()
        {
            m_lblMessage.Text = string.Format("W:{0}, H:{1}", Width, Height);
        }
        //-------------------------------------------------------------------------------
        private void buttonSplashForm_Click(object sender, EventArgs e)
        {
            FormSplash.Show(this, Resources.Logo);
        }
        //-------------------------------------------------------------------------------
        private void TestArdeshirV_Forms_Resize(object sender, EventArgs e)
        {
            UpdateMessageBar();
        }
        //-------------------------------------------------------------------------------
		void ButtonFormMessageClick(object sender, EventArgs e)
		{
			DialogResult drResult = FormMessage.Show(this).DialogResult;//this, "Message");
		}
        //-------------------------------------------------------------------------------
		void ButtonInputClick(object sender, EventArgs e)
		{
			//string stringResult;
			FormInput.Show();//this, "Message", out stringResult);
		}
    }
}
//---------------------------------------------------------------------------------------
