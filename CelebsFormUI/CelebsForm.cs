using System;
using CelebsWebApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Windows.Forms;
using System.Text;

namespace CelebsFormUI
{
    public partial class CelebsForm : Form
    {
        protected const string webApiPrefix = "http://localhost:58490";
        private static readonly HttpClient client = new HttpClient();

        public CelebsForm()
        {
            InitializeComponent();
            listViewCelebs.FullRowSelect = true;
            listViewCelebs.CheckBoxes = true;
           
        }

        protected void InitCelebsDataListView()
        {
            ResetCelebsDataListView();
        }

        protected void ResetCelebsDataListView()
        {

            listViewCelebs.Items.Clear();
            // Get to Web Api to reset Celebs list
            string responseJson = client.GetStringAsync($"{webApiPrefix}/api/celebs/InitCelebsList").Result;
            List<Celeb> celebsList = JsonConvert.DeserializeObject<List<Celeb>>(responseJson);

            ImageList imageListSmall = new ImageList();
            imageListSmall.ImageSize = new Size(100, 100);
            // Add images to ImageList Collection
            foreach (Celeb celeb in celebsList)
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    using (Stream stream = webClient.OpenRead(celeb.Picture))
                    {
                        imageListSmall.Images.Add(Image.FromStream(stream));
                    }
                }
            }
            listViewCelebs.SmallImageList = imageListSmall;
            // Add celebs Data to ListView
            int imageIndex = 0;
            foreach (Celeb celeb in celebsList)
            {
                ListViewItem item = new ListViewItem(celeb.FullName);
                item.SubItems.Add(celeb.BirthDate);
                item.SubItems.Add(celeb.Gender);
                item.SubItems.Add(celeb.Title);
                item.ImageIndex = imageIndex++;
                listViewCelebs.Items.Add(item);
            }
            lblCelebCount.Text = listViewCelebs.Items.Count.ToString();
        }

        protected void RemoveCelebs(object sender, EventArgs e)
        {

            if (listViewCelebs.CheckedIndices.Count == 0)
            {
                return;
            }

            StringBuilder removeIndicesStr = new StringBuilder();
            List<int> removeIndices = new List<int>();

            for (int i = 0; i < listViewCelebs.CheckedIndices.Count; i++)
            {
                removeIndicesStr.Append(listViewCelebs.CheckedIndices[i]);
                if (i < listViewCelebs.CheckedIndices.Count - 1)
                {
                    removeIndicesStr.Append(",");
                }
                removeIndices.Add(listViewCelebs.CheckedIndices[i]);
            }

            // string responseJson = client.GetStringAsync($"{webApiPrefix}/api/celebs/DeleteCeleb/{selectedRow.ToString()}").Result;
            string responseJson = client.GetStringAsync($"{webApiPrefix}/api/celebs/DeleteCelebs/{removeIndicesStr.ToString()}").Result;

            buttonRemoveItem.Text = "Deleting...";
            EnableDisableButtons(false);

            removeIndices.Reverse();
            foreach (int index in removeIndices)
            {
                listViewCelebs.Items.RemoveAt(index);
            }

            buttonRemoveItem.Text = "Remove Item";
            lblCelebCount.Text = listViewCelebs.Items.Count.ToString();
            EnableDisableButtons(true);
        }

        protected void ResetCelebsList(object sender, EventArgs e)
        {
            buttonResetList.Text = "Loading...";
            EnableDisableButtons(false);
            ResetCelebsDataListView();
            buttonResetList.Text = "Reset List";
            EnableDisableButtons(true);
        }

        protected void EnableDisableButtons(bool state)
        {
            buttonResetList.Enabled = state;
            buttonRemoveItem.Enabled = state;
        }

        private void CelebsForm_Load(object sender, EventArgs e)
        {
            InitCelebsDataListView();
        }
    }
}
