using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            internal static HttpRequest request;
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
            chapterList.Clear();
            string url = txbUrl.Text;
            HtmlWeb web = new HtmlWeb();
            try {
                HtmlAgilityPack.HtmlDocument doc = web.Load(url);

                string xPath = "";
                string xPathTitle = "";

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
                        if((chapterLink.Value != "#"))
                        {
                            chapterList.Add(chapterName, chapterLink.Value);
                        }
                            
                    }
                    HtmlNode title = doc.DocumentNode.SelectSingleNode(xPathTitle);
                    mangaName = title.InnerText;
                    ckdChapterList.Items.Clear();
                    foreach (string chapterName in chapterList.Keys)
                    {
                        ckdChapterList.Items.Add(chapterName);
                    }
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

        #region Download images
        void ImagesDownloader(string url,string fileName)
        {
            
            Request.request = new HttpRequest();
            Request.request.Cookies = new CookieDictionary();
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49";
            string referer = "www" + defWeb[1];
            Request.request.ConnectTimeout = 5000;
            Request.request.AddHeader("User-Agent", userAgent);
            Request.request.AddHeader("Referer",referer);
            if (!url.Contains(@"https:") && (!url.Contains(@"http:")))
            {
                url = @"http:" + url;
            }
            var img = Request.request.Get(url).ToMemoryStream().ToArray();
            File.WriteAllBytes(fileName+".jpg", img);
            Request.request.Close();
            
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
                    string chapterName = specialCharProcess(chapter);
                    txbStatus.Text = "Đang tải: " + chapterName;
                    string chapterDirPath = mangaDirPath +"\\"+ chapterName;
                    Directory.CreateDirectory(chapterDirPath);
                    GetImgUrl(chapterList[chapter],chapterDirPath);
                       
                }
            }
            if (request == "downbychapter")
            {
                for (int i = 0; i < chapterList.Count; i++)
                {
                    if (ckdChapterList.GetItemChecked(i))
                    {
                        string selectedChapter = specialCharProcess(ckdChapterList.Items[i].ToString());
                        txbStatus.Text = "Đang tải: " + selectedChapter;
                        string chapterDirPath = mangaDirPath + "\\" + selectedChapter;
                        Directory.CreateDirectory(chapterDirPath);
                        GetImgUrl(chapterList[selectedChapter], chapterDirPath);
                        
                    }
                }
            }
            txbStatus.Text = "Tải hoàn tất!";
            MessageBox.Show("Quá trình tải truyện hoàn tất!");

            
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
    }
}
















