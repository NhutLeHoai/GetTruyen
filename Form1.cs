using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using xNet;

namespace GetTruyen
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        #region define some public variable
        Dictionary<string, string> chapterList = new Dictionary<string, string>();
        string mangaName = "";
        string webKey = "";
        ArrayList defWeb = new ArrayList();
        #endregion

        class Request
        {
            internal static WebClient request;
        } //define new request

        #region Remove special character in manga name & chapter name
        string specialCharProcess(string mangaName)
        {
            string[] specialChar = new string[] { "\\", "/", ":", "*", "?", "\"", "<", ">", "|" };
            for (int i = 0; i < specialChar.Length; i++)
            {
                mangaName = mangaName.Replace(specialChar[i], "");
            }
            return mangaName;
        }
        #endregion

        #region Get chapter url
        void GetNettruyenChapterUrl()
        {
            webKey = "";
            chapterList.Clear();
            string url = txbUrl.Text;

            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(url);



                string xPath = "";
                string xPathTitle = "";
                defWeb.Clear();
                foreach (var subUrl in url.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries))
                {

                    defWeb.Add(subUrl);
                }
                if (url.Contains("nettruyen"))
                {
                    xPath = "//div[@class='list-chapter']//a[@href]";
                    xPathTitle = "//*[@id='item-detail']/h1";
                    webKey = "nettruyen";
                }
                else if (url.Contains("truyenqq"))
                {
                    xPath = "//div[@class='list_chapter']//a[@href]";
                    xPathTitle = "/html/body/div[1]/div[1]/div[3]/div/div[1]/div[2]/h1";
                    webKey = "truyenqq";
                }
                else
                {
                    MessageBox.Show("Hiện tại chỉ hỗ trợ Nettruyen và TruyenQQ", "Trang web không hỗ trợ");
                }
                try
                {
                    foreach (HtmlNode link in doc.DocumentNode.SelectNodes(xPath))
                    {
                        string chapterName = specialCharProcess(link.InnerHtml.Replace("Chương", "Chapter"));
                        HtmlAttribute chapterLink = link.Attributes["href"];
                        if ((chapterLink.Value != "#"))
                        {
                            chapterList.Add(chapterLink.Value, chapterName);
                        }

                    }
                    HtmlNode title = doc.DocumentNode.SelectSingleNode(xPathTitle);
                    mangaName = title.InnerText;
                    ckdChapterList.Items.Clear();

                    BindingSource chapterListSource = new BindingSource();
                    chapterListSource.DataSource = chapterList;
                    ckdChapterList.DataSource = chapterListSource;
                    ckdChapterList.DisplayMember = "Value";
                    ckdChapterList.ValueMember = "Key";
                    pnl1.Enabled = true;
                    ckdSelectAll.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Đường dẫn không hợp lệ, vui lòng copy url ở mục chọn chapter", "Lỗi đường dẫn");
                }
            }


            catch { MessageBox.Show("Đường dẫn phải bao gồm phần http://\nVí dụ: http://www.nettruyenco.com/truyen-tranh/naruto-cuu-vi-ho-ly-11996", "Đường dẫn url không hợp lệ!"); }


        }
        #endregion


        static protected void ImageDownloader(string url, string _fileName)
        {
            try
            {
                Request.request.DownloadFileAsync(
                    new System.Uri(url),
                    _fileName
                    );
                while (Request.request.IsBusy) { }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        #region Download images
        void ImagesDownloader(string url,string fileName)
        {
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49";
            string referer = "www" + defWeb[1];
            string _fileName = fileName + ".jpg";

            if (!url.Contains(@"https:") && (!url.Contains(@"http:")))
            {
                url = @"http:" + url;
            }

            using(Request.request = new WebClient())
            {
                Request.request.Headers.Add("User-Agent", userAgent);
                Request.request.Headers.Add("Referer", referer);
                ImageDownloader(url, _fileName);
                Request.request.Dispose();
            }
            


        }
        #endregion

        #region Get img Url
        void GetImgUrl(string chapterUrl,string chapterDirPath)
        {
            HtmlWeb chapterWeb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument chapterNode = chapterWeb.Load(chapterUrl);
            string imgXPath = "";
            if (webKey == "nettruyen")
            {
                imgXPath = "//div[@class='page-chapter']//img[@src]";
            }
            else
            {
                imgXPath = "//div[@class ='chapter_content']//img[@src]";
            }
            int i = 1;
            foreach (HtmlNode imgNode in chapterNode.DocumentNode.SelectNodes(imgXPath))
            {
                HtmlAttribute imgLink = imgNode.Attributes["src"];
                HtmlAttribute imgIndex = imgNode.Attributes["data-index"];
                string _chapterDirPath = chapterDirPath+"\\"+i.ToString();
                ImagesDownloader(imgLink.Value, _chapterDirPath);
                i++;
            }

        }
        
        void GetImgUrlAll (string request,string mangaDirPath)
        {
            
            
            Directory.CreateDirectory(mangaDirPath);
            if (request == "downall")
            {
                foreach (var chapter in chapterList.Keys)
                {
                    string chapterName = specialCharProcess(chapterList[chapter]);
                    txbStatus.Text = "Đang tải: " + chapterName;
                    string chapterDirPath = mangaDirPath +"\\"+ chapterName;
                    Directory.CreateDirectory(chapterDirPath);
                    GetImgUrl(chapter,chapterDirPath);
                       
                }
            }
            if (request == "downbychapter")
            {
                for (int i = 0; i < ckdChapterList.CheckedItems.Count; i++)
                {
                    string selectedChapter = ckdChapterList.CheckedItems[i].ToString();
                    string[] selectedChapterArray = selectedChapter.Replace("[", "").Replace("]", "").Split('\u002C');
                    string selectedChapterProcessed = specialCharProcess(selectedChapterArray[1].ToString());
                    txbStatus.Text = "Đang tải: " + selectedChapterProcessed;
                    string chapterDirPath = mangaDirPath + "\\" + selectedChapterProcessed;
                    Directory.CreateDirectory(chapterDirPath);
                    GetImgUrl(selectedChapterArray[0], chapterDirPath);
                        
                }
            }
            txbStatus.Text = "Tải hoàn tất!";
            MessageBox.Show("Quá trình tải truyện hoàn tất!");

            Request.request.Dispose();
            



        }
        #endregion

        private void btnGetList_Click(object sender, EventArgs e)
        {
            Thread getChapterUrl = new Thread(() => { GetNettruyenChapterUrl(); });
            getChapterUrl.Start();
            
        } //Click and get Get list URL

        private void btnDownAll_Click(object sender, EventArgs e)
        {
            
            if (fbdDirPath.ShowDialog() == DialogResult.OK)
            {
                mangaName = specialCharProcess(mangaName);
                string mangaDirPath = fbdDirPath.SelectedPath + "\\" + mangaName;
                Thread downAll = new Thread(() => { GetImgUrlAll("downall",mangaDirPath); });
                downAll.IsBackground = true;
                downAll.Start();
            }
        } // Download all 

        private void btnDownByChapter_Click(object sender, EventArgs e)
        {
            if (fbdDirPath.ShowDialog() == DialogResult.OK)
            {
                mangaName = specialCharProcess(mangaName);
                string mangaDirPath = fbdDirPath.SelectedPath + "\\" + mangaName;
                Thread downByChapter = new Thread(() => { GetImgUrlAll("downbychapter",mangaDirPath); });
                downByChapter.IsBackground = true;
                downByChapter.Start();
            }
        } //Click and download by chapter

        private void ckdSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (ckdSelectAll.Text == "Select all")
            {
                ckdSelectAll.Text = "Deselect all";
                for (int i = 0; i < chapterList.Count; i++)
                {
                    ckdChapterList.SetItemChecked(i, true);
                }
            }
            else
            {
                ckdSelectAll.Text = "Select all";
                for (int i = 0; i < chapterList.Count; i++)
                {
                    ckdChapterList.SetItemChecked(i, false);
                }
            }
            
        } //select - deselect all chapter list

        private void btnGetToFbForm_Click(object sender, EventArgs e)
        {
            fFBDownloader fFBDownloader = new fFBDownloader();
            fFBDownloader.ShowDialog();
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
















