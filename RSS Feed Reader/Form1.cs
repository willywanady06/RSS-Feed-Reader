using System;
using System.ServiceModel.Syndication;
using System.Windows.Forms;
using System.Xml;
using System.Collections.Generic;
using System.Diagnostics;
namespace RSS_Feed_Reader
{


    public partial class Form1 : Form
    {

        String url;
        
        List<Feed> feeds = new List<Feed>();
 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            url = urlBox.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                
                getRssFeed(url);
            }
            else
            {
                MessageBox.Show("Please enter the feed URL", "URL Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void getRssFeed(String url)
        {
            try
            {
                XmlReader xmlReader = XmlReader.Create(url);
                SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
                xmlReader.Close();

                foreach (SyndicationItem item in feed.Items)
                {
                    feedList.Items.Add(String.Format(item.Title.Text));
                    Feed details = new Feed(item.Title.Text, item.Links[0].Uri.ToString(), item.PublishDate.ToString(), item.Summary.Text);
                    feeds.Add(details);
                }
            }
            
            catch (Exception e)
            {
                MessageBox.Show("Please Enter Valid URL", "Invalid URL", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }

            
        }

        private void linkClick(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabel.Text);
        }

        private void feedList_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.feedList.IndexFromPoint(e.Location);
            if(index != System.Windows.Forms.ListBox.NoMatches)
            {
                titleLabel.Text = feeds[index].Title;
                linkLabel.Text = feeds[index].Link;
                dateLabel.Text = feeds[index].PubDate;
                descBox.Text = feeds[index].Desc;
            }
        }
    }
}
