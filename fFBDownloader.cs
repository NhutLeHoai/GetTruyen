using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using xNet;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace GetTruyen
{
    public partial class fFBDownloader : Form
    {
        public fFBDownloader()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        List<string> urlList = new List<string>();
        Dictionary<string, string> albumDict = new Dictionary<string, string>();
        List<string> albumIdToDownload = new List<string>();
        int downloadType = 0;
        class Web
        {
            static public WebClient downloader;
        }

        void ImageDownloader(string url, string _fileName)
        {
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49";
            try
            {
                using (Web.downloader = new WebClient())
                {
                    Web.downloader.Headers.Add("User-Agent", userAgent);
                    Web.downloader.DownloadFile(url,_fileName);
                    
                    while (Web.downloader.IsBusy) { }
                    Web.downloader.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        #region get download url from album url
        
        void GetNextPhoto(string nextUrl)
        {
            HttpRequest request = new HttpRequest();
            try
            {
                var jsonData = request.Get(nextUrl).ToString();
                var photo = JsonConvert.DeserializeObject<Photo>(jsonData);
                for (int i = 0; i < photo.data.Count(); i++)
                {
                    urlList.Add(photo.data[i].largest_image.source);
                }
                if (photo.paging.next != null || photo.paging.next != "")
                {
                    GetNextPhoto(photo.paging.next);
                }
            }

            catch (System.ArgumentNullException)
            {

            }
        }

        string GetNextAlbum(string nextUrl)
        {
            HttpRequest request = new HttpRequest();
            try
            {
                var jsonData = request.Get(nextUrl).ToString();
                var album = JsonConvert.DeserializeObject<Album>(jsonData);

                for (int i = 0; i < album.photos.data.Count(); i++)
                {
                    urlList.Add(album.photos.data[i].largest_image.source);

                }
                if (album.photos.paging.next != null || album.photos.paging.next != "")
                {
                    GetNextPhoto(album.photos.paging.next);
                }
                return album.name;
            }

            catch (System.ArgumentNullException)
            {
                return null;
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình download\nVui lòng kiểm tra lại Access Token và Link download");
                return null;
            }


        }

        void GetImgUrl(string savePath, string groupID = "")
        {
            if(groupID == "")
            {
                Regex groupIdFilter = new Regex("(?<=a\\.)(.*)(?=&)");
                Match matchFilter = groupIdFilter.Match(txbFBUrl.Text);
                groupID = matchFilter.Value;
            }
            string accessToken = txbAccessToken.Text;
            string fbGraphUrl = "https://graph.facebook.com/";
            string dataToGet = "?fields=name,photos.limit(1000){largest_image}";
            string fullGraphUrl = fbGraphUrl+groupID+dataToGet+"&access_token="+accessToken;
            string albumName = GetNextAlbum(fullGraphUrl);
            if(albumName != null)
            {
                Directory.CreateDirectory(savePath + "\\" + albumName);
                txbStatus.Text = "Đang tải Album " + albumName;
                int filename = 1;
                progressDownload.Value = 0;
                progressDownload.Maximum = urlList.Count;
                foreach (var link in urlList)
                {
                    string fileName = savePath + "\\" + albumName + @"\" + filename + ".jpg";
                    ImageDownloader(link, fileName);
                    txbDownloadStatus.Text = "Đang tải: "+filename+"/"+urlList.Count;
                    progressDownload.Value++;
                    filename++;
                }
                
                if(downloadType == 0)
                {
                    MessageBox.Show("Download hoàn tất!");
                }
                else if (downloadType == 1)
                {
                    string message = "Download album " + albumName + " hoàn tất!";
                    txbStatus.Text = message;
                    txbDownloadStatus.Text = "Finished!";
                    MessageBox.Show(message);
                    Web.downloader.Dispose();
                }
                urlList.Clear();
                filename = 1;
                albumName = "";
                savePath = "";
            }
            
        }
        #endregion

        void GetNextAlbumList(string nextUrl)
        {
            HttpRequest request = new HttpRequest();
            try
            {
                var jsonData = request.Get(nextUrl).ToString();
                var nextAlbum = JsonConvert.DeserializeObject<Photo>(jsonData);
                for (int i = 0; i < nextAlbum.data.Count(); i++)
                {
                    albumDict.Add(nextAlbum.data[i].id, nextAlbum.data[i].name);
                }
                if (nextAlbum.paging.next != null || nextAlbum.paging.next != "")
                {
                    GetNextAlbumList(nextAlbum.paging.next);
                }
            }

            catch (Exception)
            {

            }
        }



        void GetSelectedAlbum(string savePath)
        {
            for (int i = 0; i < ckbAlbumList.CheckedItems.Count; i++)
            {
                string albumID = ckbAlbumList.CheckedItems[i].ToString();
                string[] IDName = albumID.Replace("[","").Replace("]","").Split('\u002C');
                string ID = IDName[0];
                GetImgUrl(savePath, ID);
            }

        }

        void GetAlbumList(string nextUrl)
        {
            HttpRequest request = new HttpRequest();
            try
            {
                var jsonData = request.Get(nextUrl).ToString();
                var group = JsonConvert.DeserializeObject<Group>(jsonData);
                lbGroupName.Text = group.name;
                txbStatus.Text = "Đang tải trang...";
                for (int i = 0; i < group.albums.data.Count(); i++)
                {
                    albumDict.Add(group.albums.data[i].id, group.albums.data[i].name);
                }
                if (group.albums.paging.next != null || group.albums.paging.next != "")
                {
                    GetNextAlbumList(group.albums.paging.next);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Có lỗi trong quá trình lấy thông tin group\nVui lòng kiểm tra lại Access Token và Link download");
            }
        }
        void GetGroupAlbumList(string groupID)
        {
            string accessToken = txbAccessToken.Text;
            string fbGraphUrl = "https://graph.facebook.com/";
            string dataToGet = "?fields=name,albums.limit(100){name}";
            string fullGraphUrl = fbGraphUrl + groupID + dataToGet + "&access_token=" + accessToken;
            GetAlbumList(fullGraphUrl);

        }


        #region get fb IB from Group Url
        void GetFbGroupID()
        {
            txbStatus.Text = "Đang lấy thông tin...";
            
            HttpRequest getIdRequest = new HttpRequest();
            string groupUrl = txbFBUrl.Text;
            string groupUrlProcess = groupUrl.Replace("/", "%2F").Replace(":", "%3A");
            string contentType = "application/x-www-form-urlencoded";
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/103.0.5060.114 Safari/537.36 Edg/103.0.1264.49";
            
            getIdRequest.UserAgent = userAgent;
            string referer = "https://lookup-id.com/";
            getIdRequest.AddHeader("referer", referer);
            string data = "fburl="+groupUrlProcess+"&check=Lookup";
            string requestIdUrl = "https://lookup-id.com/";
            string html = getIdRequest.Post(requestIdUrl, data, contentType).ToString();
            string regFilterId = "(?<=<p id=\"code-wrap\"><span id=\"code\">)(.*)(?=</span><br/>)";
            Match matchregFilterId = Regex.Match(html, regFilterId);
            string groupID = matchregFilterId.Value; // lấy ID fb
            GetGroupAlbumList(groupID);
            BindingSource albumListSource = new BindingSource();
            albumListSource.DataSource = albumDict;
            ckbAlbumList.DataSource = albumListSource;
            ckbAlbumList.DisplayMember = "Value";
            ckbAlbumList.ValueMember = "Key";
            string searchResult = "Tải trang hoàn tất\nTìm thấy "+albumDict.Count+" album";
            txbStatus.Text = "Tìm kiếm hoàn tất";
            MessageBox.Show(searchResult);
            groupID = "";
            
        }
        #endregion



        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txbAccessToken.Text == "" || txbFBUrl.Text == "")
            {
                MessageBox.Show("Bạn chưa điền Access Token hoặc link!!!");
            }
            else
            {
                downloadType = 1;
                Thread getId = new Thread(() => { GetFbGroupID(); });
                getId.Start();
            }

        }

        private void btnToken1_Click(object sender, EventArgs e)
        {
            string urlTakeToken1 = "https://www.facebook.com/dialog/oauth?client_id=124024574287414&redirect_uri=fbconnect%3A%2F%2Fsuccess&scope=email%2Cpublish_actions%2Cpublish_pages%2Cuser_about_me%2Cuser_actions.books%2Cuser_actions.music%2Cuser_actions.news%2Cuser_actions.video%2Cuser_activities%2Cuser_birthday%2Cuser_education_history%2Cuser_events%2Cuser_games_activity%2Cuser_groups%2Cuser_hometown%2Cuser_interests%2Cuser_likes%2Cuser_location%2Cuser_notes%2Cuser_photos%2Cuser_questions%2Cuser_relationship_details%2Cuser_relationships%2Cuser_religion_politics%2Cuser_status%2Cuser_subscriptions%2Cuser_videos%2Cuser_website%2Cuser_work_history%2Cfriends_about_me%2Cfriends_actions.books%2Cfriends_actions.music%2Cfriends_actions.news%2Cfriends_actions.video%2Cfriends_activities%2Cfriends_birthday%2Cfriends_education_history%2Cfriends_events%2Cfriends_games_activity%2Cfriends_groups%2Cfriends_hometown%2Cfriends_interests%2Cfriends_likes%2Cfriends_location%2Cfriends_notes%2Cfriends_photos%2Cfriends_questions%2Cfriends_relationship_details%2Cfriends_relationships%2Cfriends_religion_politics%2Cfriends_status%2Cfriends_subscriptions%2Cfriends_videos%2Cfriends_website%2Cfriends_work_history%2Cads_management%2Ccreate_event%2Ccreate_note%2Cexport_stream%2Cfriends_online_presence%2Cmanage_friendlists%2Cmanage_notifications%2Cmanage_pages%2Cphoto_upload%2Cpublish_stream%2Cread_friendlists%2Cread_insights%2Cread_mailbox%2Cread_page_mailboxes%2Cread_requests%2Cread_stream%2Crsvp_event%2Cshare_item%2Csms%2Cstatus_update%2Cuser_online_presence%2Cvideo_upload%2Cxmpp_login&response_type=token";
            Process.Start(urlTakeToken1);
            System.Windows.Forms.Clipboard.SetText("view-source:https://www.facebook.com/dialog/oauth?client_id=124024574287414&redirect_uri=https://www.instagram.com/accounts/signup/&&scope=email&response_type=token");
            MessageBox.Show("Đã copy vào clipboard thành công.\nSau khi xác nhận đăng nhập vào Instagram vui lòng paste (Ctrl+v) \nvào thanh trình duyệt và copy Access token từ đó");
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (txbAccessToken.Text == "" || txbFBUrl.Text == "")
            {
                MessageBox.Show("Bạn chưa điền Access Token hoặc link!!!");
            }
            else if (getSavePlace.ShowDialog() == DialogResult.OK)
            {
                string savePath = getSavePlace.SelectedPath;
                if (downloadType == 0)
                {
                    Thread download = new Thread(() => { GetImgUrl(savePath); });
                    download.Start();
                }
                else if (downloadType == 1)
                {
                    Thread downloadByAlbum = new Thread(() => { GetSelectedAlbum(savePath); });
                    downloadByAlbum.Start();
                }
                

            }
        }

        private void fFBDownloader_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void saveAccessToken_Click(object sender, EventArgs e)
        {
            if (txbAccessToken.Text == "")
            {
                MessageBox.Show("Vui lòng nhập Access Token để lưu!");
            }
            else
            {
                File.WriteAllText("AccessToken.txt", txbAccessToken.Text);
                MessageBox.Show("Lưu Access Token thành công!");
            }
        }

        private void fFBDownloader_Load(object sender, EventArgs e)
        {
            if (File.Exists("AccessToken.txt"))
            {
                txbAccessToken.Text = File.ReadAllText("AccessToken.txt");
            }
            else
            {
                MessageBox.Show("Không tìm thấy file lưu Access Token, vui lòng điền Acess Token!");
            }
        }
    }
}
