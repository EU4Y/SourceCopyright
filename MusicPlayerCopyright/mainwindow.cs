using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Net;   
using System.Threading;
using WMPLib;
using System.Data.OleDb;
using System.Drawing.Imaging;
using NetFwTypeLib;
namespace MusicPlayerCopyright
{

    
    public partial class mainwindow : Form
    {
        int eX = 0;
        int eY = 0;
        string DropTitleSong = "";
        string UpcomingSongPlayerOne = "";
        string UpcomingSongPlayerTwo = "";
        clsSongCrypt amcrypt = new clsSongCrypt();
        gblClass ObjMainClass = new gblClass();
        string FitnessRecordShowType = "";
        string downloadSongName = "";
        Point p1 = new Point();
        string SearchText = "";
        Point p2 = new Point();
        bool drawLine;
        Pen p;
        PaintEventArgs EventSpl;
        int TotShuffle = 0;
        Int16 ShuffleCount = 0;
        string pAction = "New";
        Int32 ModifyPlaylistId;
        string IsbtnClick = "N";
        string fileName = "";
        string temp_songid = "";
        Boolean Add_Playlist = false;
        Boolean Show_Record = false;
        Boolean Drop_Song = false;
        string SubmitValidate;
        Int32 CurrentRow;
        Boolean Is_Drop = false;
        Int32 CurrentPlaylistRow = 0;
        Boolean Song_Mute = false;
        Boolean Stop_Insert = false;
        Boolean Grid_Clear = false;
        Boolean IsDrop_Song = false;
        Boolean FirstTimeSong = false;
        Boolean FirstPlaySong = true;
        string exit = "No";
        string BestOffRecordShowType = "";
        DataGridViewButtonColumn SongDownload = new DataGridViewButtonColumn();
        DataGridViewImageColumn Column_Img_Stream = new DataGridViewImageColumn();
        public WindowsMediaPlayer player;
        public mainwindow()
        {
            InitializeComponent();
        }
        private void InitilizeGrid()
        {
            if (dgPlaylist.Rows.Count > 0)
            {
                dgPlaylist.Rows.Clear();
            }
            if (dgPlaylist.Columns.Count > 0)
            {
                dgPlaylist.Columns.Clear();
            }

            dgPlaylist.Columns.Add("songid", "song Id");
            dgPlaylist.Columns["songid"].Width = 0;
            dgPlaylist.Columns["songid"].Visible = false;
            dgPlaylist.Columns["songid"].ReadOnly = true;

            dgPlaylist.Columns.Add("songname", "Title");
            dgPlaylist.Columns["songname"].Width = 450;
            dgPlaylist.Columns["songname"].Visible = true;
            dgPlaylist.Columns["songname"].ReadOnly = true;

            dgPlaylist.Columns.Add("Length", "Length");
            dgPlaylist.Columns["Length"].Width = 80;
            dgPlaylist.Columns["Length"].Visible = true;
            dgPlaylist.Columns["Length"].ReadOnly = true;

            dgPlaylist.Columns.Add("Album", "Album");
            dgPlaylist.Columns["Album"].Width = 0;
            dgPlaylist.Columns["Album"].Visible = false;
            dgPlaylist.Columns["Album"].ReadOnly = true;

            dgPlaylist.Columns.Add("Year", "Year");
            dgPlaylist.Columns["Year"].Width = 0;
            dgPlaylist.Columns["Year"].Visible = false;
            dgPlaylist.Columns["Year"].ReadOnly = true;

            dgPlaylist.Columns.Add("Artist", "Artist");
            dgPlaylist.Columns["Artist"].Width = 150;
            dgPlaylist.Columns["Artist"].Visible = true;
            dgPlaylist.Columns["Artist"].ReadOnly = true;
           
        }
        private void InitilizeHideGrid()
        {
            if (dgHideSongs.Rows.Count > 0)
            {
                dgHideSongs.Rows.Clear();
            }
            if (dgHideSongs.Columns.Count > 0)
            {
                dgHideSongs.Columns.Clear();
            }

            dgHideSongs.Columns.Add("songid", "song Id");
            dgHideSongs.Columns["songid"].Width = 100;
            dgHideSongs.Columns["songid"].Visible = true;
            dgHideSongs.Columns["songid"].ReadOnly = true;

            dgHideSongs.Columns.Add("Status", "Status");
            dgHideSongs.Columns["Status"].Width = 100;
            dgHideSongs.Columns["Status"].Visible = true;
            dgHideSongs.Columns["Status"].ReadOnly = true;

        }

        private void InitilizeLocalGrid()
        {
            if (dgLocalPlaylist.Rows.Count > 0)
            {
                dgLocalPlaylist.Rows.Clear();
            }
            if (dgLocalPlaylist.Columns.Count > 0)
            {
                dgLocalPlaylist.Columns.Clear();
            }

            dgLocalPlaylist.Columns.Add("playlistId", "playlist Id");
            dgLocalPlaylist.Columns["playlistId"].Width = 0;
            dgLocalPlaylist.Columns["playlistId"].Visible = false;
            dgLocalPlaylist.Columns["playlistId"].ReadOnly = true;

            dgLocalPlaylist.Columns.Add("playlistname", "Playlist Name");
            //dgLocalPlaylist.Columns["playlistname"].Width = 210;
            dgLocalPlaylist.Columns["playlistname"].Visible = true;
            dgLocalPlaylist.Columns["playlistname"].ReadOnly = true;

            dgLocalPlaylist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewLinkColumn EditPlaylist = new DataGridViewLinkColumn();
            EditPlaylist.HeaderText = "Edit";
            EditPlaylist.Text = "Edit";
            EditPlaylist.DataPropertyName = "Edit";
            dgLocalPlaylist.Columns.Add(EditPlaylist);
            EditPlaylist.UseColumnTextForLinkValue = true;
            EditPlaylist.Width = 0;
            EditPlaylist.Visible = false;
            

        }

        private void InitilizeCommanGrid()
        {
             
                if (dgCommanGrid.Rows.Count > 0)
                {
                    dgCommanGrid.Rows.Clear();
                }
                if (dgCommanGrid.Columns.Count > 0)
                {
                    dgCommanGrid.Columns.Clear();
                }

                dgCommanGrid.Columns.Add("songid", "song Id");
                dgCommanGrid.Columns["songid"].Width = 0;
                dgCommanGrid.Columns["songid"].Visible = false;
                dgCommanGrid.Columns["songid"].ReadOnly = true;

                dgCommanGrid.Columns.Add("songname", "Title");
                dgCommanGrid.Columns["songname"].Width = 435;
                dgCommanGrid.Columns["songname"].Visible = true;
                dgCommanGrid.Columns["songname"].ReadOnly = true;

                dgCommanGrid.Columns.Add("Length", "Length");
                dgCommanGrid.Columns["Length"].Width = 80;
                dgCommanGrid.Columns["Length"].Visible = true;
                dgCommanGrid.Columns["Length"].ReadOnly = true;

                dgCommanGrid.Columns.Add("aritstname", "Aritst");
                dgCommanGrid.Columns["aritstname"].Width = 130;
                dgCommanGrid.Columns["aritstname"].Visible = true;
                dgCommanGrid.Columns["aritstname"].ReadOnly = true;

                dgCommanGrid.Columns.Add("albumname", "Album");
                dgCommanGrid.Columns["albumname"].Width = 0;
                dgCommanGrid.Columns["albumname"].Visible = false;
                dgCommanGrid.Columns["albumname"].ReadOnly = true;


                SongDownload.HeaderText = "";
                SongDownload.Text = "";
                SongDownload.DataPropertyName = "SongDownload";
                dgCommanGrid.Columns.Add(SongDownload);
                SongDownload.UseColumnTextForButtonValue = true;
                SongDownload.Width = 30;
           

        }
        private void InitilizeCommanOptionGrid(DataGridView Grid_Name)
        {
            if (Grid_Name.Rows.Count > 0)
            {
                Grid_Name.Rows.Clear();
            }
            if (Grid_Name.Columns.Count > 0)
            {
                Grid_Name.Columns.Clear();
            }

            Grid_Name.Columns.Add("playlistId", "playlist Id");
            Grid_Name.Columns["playlistId"].Width = 0;
            Grid_Name.Columns["playlistId"].Visible = false;
            Grid_Name.Columns["playlistId"].ReadOnly = true;
            
            Grid_Name.Columns.Add("CommanName", "Comman Name");
//            Grid_Name.Columns["CommanName"].Width = 265;
            Grid_Name.Columns["CommanName"].Visible = true;
            Grid_Name.Columns["CommanName"].ReadOnly = true;
            Grid_Name.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void InitilizeNewestGrid()
        {
            if (dgNewest.Rows.Count > 0)
            {
                dgNewest.Rows.Clear();
            }
            if (dgNewest.Columns.Count > 0)
            {
                dgNewest.Columns.Clear();
            }

            dgNewest.Columns.Add("playlistId", "playlist Id");
            dgNewest.Columns["playlistId"].Width = 0;
            dgNewest.Columns["playlistId"].Visible = false;
            dgNewest.Columns["playlistId"].ReadOnly = true;

            dgNewest.Columns.Add("Title", "Title");
            dgNewest.Columns["Title"].Width = 190;
            dgNewest.Columns["Title"].Visible = true;
            dgNewest.Columns["Title"].ReadOnly = true;

            dgNewest.Columns.Add("Artist", "Artist");
            dgNewest.Columns["Artist"].Width = 80;
            dgNewest.Columns["Artist"].Visible = true;
            dgNewest.Columns["Artist"].ReadOnly = true;


        }

        

        private void PopulateInputFileTypeDetail(Int32 currentPlayRow)
        {
            string mlsSql="";
            string GetLocalPath = "";
            string TitleYear = "";
            string TitleTime = "";
           var Special_Name = "";
           string Special_Change = "";
            Int32 iCtr=0;
            Int32 srNo = 0;
            DataTable dtDetail= new DataTable();
            //mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(currentPlayRow);

            mlsSql = "SELECT  Titles.TitleID, ltrim(Titles.Title) as Title, Titles.Time,Albums.Name AS AlbumName ,";
            mlsSql = mlsSql + " Titles.TitleYear ,  ltrim(Artists.Name) as ArtistName  FROM ((( TitlesInPlaylists  ";
            mlsSql = mlsSql + " INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID )  ";
            mlsSql = mlsSql + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID ) ";
            mlsSql = mlsSql + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID ) ";
            mlsSql = mlsSql + " where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(currentPlayRow);

           
            dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
            InitilizeGrid();
            if ((dtDetail.Rows.Count > 0))
            {
                for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                {
                    GetLocalPath = dtDetail.Rows[iCtr]["TitleID"] + ".ogg";
                    srNo = iCtr ;
                    dgPlaylist.Rows.Add();
                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["TitleID"];

                    Special_Name = "";
                    Special_Change = "";
                    Special_Name = dtDetail.Rows[iCtr]["Title"].ToString();
                    Special_Change = Special_Name.Replace("??$$$??", "'"); 
                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[1].Value = Special_Change;

                    string str = dtDetail.Rows[iCtr]["Time"].ToString();
                    string[] arr = str.Split(':');
                    TitleTime = arr[1] + ":" + arr[2];

                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[2].Value = TitleTime;

                    Special_Name = "";
                    Special_Change = "";

                    Special_Name = dtDetail.Rows[iCtr]["AlbumName"].ToString();
                    Special_Change = Special_Name.Replace("??$$$??", "'"); 
                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[3].Value = Special_Change;

                    TitleYear = dtDetail.Rows[iCtr]["TitleYear"].ToString();
                    if (TitleYear == "0")
                    {
                        dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[4].Value = "- - -";
                    }
                    else
                    {
                        dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[4].Value = dtDetail.Rows[iCtr]["TitleYear"];
                    }

                    Special_Name = "";
                    Special_Change = "";

                    Special_Name = dtDetail.Rows[iCtr]["ArtistName"].ToString();
                    Special_Change = Special_Name.Replace("??$$$??", "'"); 
                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[5].Value = Special_Change;

                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[1].Style.Font = new Font("Segoe UI", 12,System.Drawing.FontStyle.Regular);
                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[2].Style.Font = new Font("Segoe UI", 10);
                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[3].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Italic);
                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[4].Style.Font = new Font("Segoe UI", 10);
                    dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[5].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Italic);

                    

                }
            }
            foreach (DataGridViewRow row in dgPlaylist.Rows)
            {
                row.Height = 30;
            }
            RowHide();
        }


        private void FillLocalPlaylist()
        {
            string str;
            int iCtr;
            DataTable dtDetail;
            str = "select playlistId,name from Playlists where UserID=" + StaticClass.UserId + " and tokenid= " + StaticClass.TokenId ;
            dtDetail = ObjMainClass.fnFillDataTable_Local(str);
            InitilizeLocalGrid();
            if ((dtDetail.Rows.Count > 0))
            {
                for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                {
                    dgLocalPlaylist.Rows.Add();
                    dgLocalPlaylist.Rows[dgLocalPlaylist.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["playlistId"];
                    dgLocalPlaylist.Rows[dgLocalPlaylist.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["name"];

                    if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = "update Playlists set tokenid=" + StaticClass.TokenId + " where playlistid=" + dtDetail.Rows[iCtr]["playlistId"];
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();
                }
                foreach (DataGridViewRow row in dgLocalPlaylist.Rows)
                {
                    row.Height = 30;
                }
                dgLocalPlaylist.Rows[0].Selected = true;
            }

        }
        private void mainwindow_Load(object sender, EventArgs e)
        {
            string str = "";
            this.Text = StaticClass.MainwindowMessage;
            //////////////////////////////////////////
            //////////////////////////////////////////
            delete_temp_table();
            DeleteHideSongs();
            //////////////////////////////////////////
            //////////////////////////////////////////
            musicPlayer1.enableContextMenu = false;
            musicPlayer2.enableContextMenu = false;
            StreamMusicPlayer.enableContextMenu = false;
            dgPlaylist.AllowDrop = true;
            musicPlayer1.uiMode = "none";
            musicPlayer2.uiMode = "none";

            InitilizeGrid();
            InitilizeHideGrid();
            InitilizeCommanGrid();

            if (StaticClass.IsCopyright == true)
            {
                lblCopyrightLicence1.Visible = false;
                lblCopyrightLicence2.Visible = false;
                lblExpiryPlayer.Text = StaticClass.PlayerExpiryMessage;

                InitilizeNewestGrid();
                str = "SELECT TOP (100) Titles.TitleID as IdName, ltrim(Titles.Title) as textname, Artists.Name as ArtistName, Albums.Name AS AlbumName FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID where titlecategoryid=4 order by Titles.TitleID desc";
                FillNewestGrid(str);

                InitilizeCommanOptionGrid(dgBestOf);
                str = "select PlaylistId as IdName, ltrim(Name) as textName from Playlists where isPredefined=1 order by Name";
                FillCommanOptionGrid(str, dgBestOf);

                str = "SELECT TOP (200) Titles.TitleID, ltrim(Titles.Title) as Title,Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID where titlecategoryid=4 order by Titles.TitleID desc";
                FillGrid(str);
            }
            else
            {
                lblCopyrightLicence1.Visible = true;
                lblCopyrightLicence1.Text = StaticClass.PlayerExpiryMessage;
                lblCopyrightLicence2.Visible = true;
                lblCopyrightLicence2.Text = StaticClass.PlayerExpiryMessage;
            }

            if (StaticClass.IsFitness == true)
            {
                lblFitnessExpiry.Text = StaticClass.FitnessExpiryMessage;
                lblFitnessLicence.Visible = false;
                //FillFitnessGenre();
            }
            else
            {
                lblFitnessLicence.Visible = true;
                lblFitnessLicence.Text = StaticClass.FitnessExpiryMessage;
            }


            if (StaticClass.IsCopyright == false && StaticClass.IsFitness == true)
            {
                //FillFitnessGenreTitles(Convert.ToInt32(dgFitness.Rows[0].Cells[0].Value));
            }


            FillLocalPlaylist();
            delete_temp_table();
            InitilizeMusicGrid(dgMusicPlayer1);
            InitilizeMusicGrid(dgMusicPlayer2);




            str = "select * from tblmusic_player_settings where DFClientId=" + StaticClass.UserId + " and localUserId=" + StaticClass.LocalUserId + " and tokenno= " + StaticClass.TokenId ;
            DataSet ds = new DataSet();
            ds = ObjMainClass.fnFillDataSet(str);
            if (dgLocalPlaylist.Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                    dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Selected = true;
                    PlaySongDefault();
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                    dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Selected = true;
                    Get_Last_Settings();
                }
            }
            else
            {
                panPlayerButton.Enabled = true;
            }
            musicPlayer1.settings.volume = 100;
            musicPlayer2.settings.volume = 100;
            
            RowHide();

            GetFirstSong();
            DownloadSong();
            
           // LoadGif();
            SearchText = "";
            FillStreamData();
            FillStar(dgSongRatingPlayerOne);

            if (FirstTimeSong == true)
            {
                SetRating(dgSongRatingPlayerOne);
                SetDisableRating(dgSongRatingPlayerTwo);
            }
            else
            {
                GetSavedRating(musicPlayer1.currentMedia.name, dgSongRatingPlayerOne);
                SetDisableRating(dgSongRatingPlayerTwo);
            }
        }
        

       

        //private void LoadGif()
        //{
        //    Image img = ((System.Drawing.Image)(Properties.Resources.Loading));
        //    MemoryStream mstr = new MemoryStream();
        //    img.Save(mstr, ImageFormat.Gif);
        //    picLoading.Image = Image.FromStream(mstr);
        //}
        private void GetFirstSong()
        {
            string file = "";
            string LocalFileName = "";
            if (dgCommanGrid.Rows.Count == 0) return;
            if (dgLocalPlaylist.Rows.Count == 0 && dgPlaylist.Rows.Count == 0)
            {
                SaveDefaultPlaylist(file);
                for (int iCtr = 0; (iCtr <= 24); iCtr++)
                {
                    file = dgCommanGrid.Rows[iCtr].Cells[0].Value.ToString();
                    LocalFileName = Application.StartupPath + "\\" + file + ".sec";
                    if (System.IO.File.Exists(LocalFileName))
                    {
                        insert_Playlist_song(file, "Yes");
                        PlaySongDefault();
                        FirstPlaySong = false;
                    }
                    else
                    {
                        FirstTimeSong = true;
                        FirstPlaySong = true;
                        Add_Playlist = true;
                        insert_temp_data(file);
                        multi_song_download();
                    }
                }
                return;

            }
            else if (dgLocalPlaylist.Rows.Count != 0 && dgPlaylist.Rows.Count == 0)
            {
                for (int iCtr = 0; (iCtr <= 24); iCtr++)
                {
                    file = dgCommanGrid.Rows[iCtr].Cells[0].Value.ToString();
                    LocalFileName = Application.StartupPath + "\\" + file + ".sec";
                    if (System.IO.File.Exists(LocalFileName))
                    {
                        insert_Playlist_song(file, "Yes");
                        PlaySongDefault();
                        FirstPlaySong = false;
                    }
                    else
                    {
                        FirstTimeSong = true;
                        FirstPlaySong = true;
                        Add_Playlist = true;
                        insert_temp_data(file);
                        multi_song_download();
                    }
                }
                return;
            } 
        }
        private void InitilizeMusicGrid(DataGridView dgGrid)
        {
            if (dgGrid.Rows.Count > 0)
            {
                dgGrid.Rows.Clear();
            }
            if (dgGrid.Columns.Count > 0)
            {
                dgGrid.Columns.Clear();
            }
            dgGrid.Columns.Add("songid", "Song Id");
            dgGrid.Columns["songid"].Width = 200;
            dgGrid.Columns["songid"].Visible = true;
            dgGrid.Columns["songid"].ReadOnly = true;
        }
        void delete_temp_table()
        {
            try
            {
                if (StaticClass.constr.State == ConnectionState.Open)
                {
                    StaticClass.constr.Close();
                }

                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = StaticClass.constr;
                cmd.CommandText = "delete from temp_song where tokenid=" + StaticClass.TokenId;
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();
            }
            catch
            {
                 
            }
        }

        void delete_temp_data(string songid)
        {
            if (StaticClass.constr.State == ConnectionState.Open)
            {
                StaticClass.constr.Close();
            }

            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = StaticClass.constr;
            cmd.CommandText = "delete from temp_song where tempid=" + Convert.ToInt32(songid);
            cmd.ExecuteNonQuery();
            StaticClass.constr.Close();
        }
        void insert_temp_data(string songid)
        {
            string filePath = "";
            try
            {
                filePath = Application.StartupPath + "\\" + songid + ".ogg";
                if (StaticClass.constr.State == ConnectionState.Open)
                {
                    StaticClass.constr.Close();
                }

                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = StaticClass.constr;
                cmd.CommandText = "INSERT INTO temp_song(tempid, tempSongid,tokenid)   VALUES(@param1,@param2, @param3)";

                cmd.Parameters.AddWithValue("@param1", songid);
                cmd.Parameters.AddWithValue("@param2", songid);
                cmd.Parameters.AddWithValue("@param3", StaticClass.TokenId);
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();
                
            }
            catch 
            {
                if (System.IO.File.Exists(filePath))
                {
                    delete_temp_data(songid);
                }
            }
        }
        private void InsertDownloadSong(string songid)
        {
            try
            {
                if (StaticClass.constr.State == ConnectionState.Open)
                {
                    StaticClass.constr.Close();
                }

                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = StaticClass.constr;
                cmd.CommandText = "INSERT INTO userDownloadTitle(DfClientId, titleId,tokenid)   VALUES(@param1,@param2,@param3)";

                cmd.Parameters.AddWithValue("@param1", StaticClass.UserId);
                cmd.Parameters.AddWithValue("@param2", songid);
                cmd.Parameters.AddWithValue("@param3", StaticClass.TokenId);
                cmd.ExecuteNonQuery();
                StaticClass.constr.Close();
            }
            catch
            {
            }

        }
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the object used to communicate with the server.
            downloadSongName = "";
            string localPath = Application.StartupPath + "\\";
            string file_song_path = Application.StartupPath + "\\" + fileName;
            try
            {

                //FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create("ftp://81.83.13.236:2112/AMMusicFiles/ripper/oggfiles/" + fileName);
                //requestFileDownload.Credentials = new NetworkCredential("paras", "paras2014");

                FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create("ftp://85.195.82.94:21/AMMusicFiles/ripper/oggfiles/" + fileName);
                requestFileDownload.Credentials = new NetworkCredential("harish", "Mohali123");
               // requestFileDownload.KeepAlive = true;
                requestFileDownload.UsePassive = false;
               // requestFileDownload.UseBinary = true;

                requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;

                FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();

                Stream responseStream = responseFileDownload.GetResponseStream();
                FileStream writeStream = new FileStream(localPath + fileName, FileMode.Create);

                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);

                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);


                    // calculate the progress out of a base "100"

                    double dIndex = (double)(bytesRead);

                    double dTotal = (double)Length;

                    double dProgressPercentage = (dIndex / dTotal);

                    int iProgressPercentage = (int)(dProgressPercentage * 100);

                    // update the progress bar
                    bgWorker.ReportProgress(iProgressPercentage);

                }
                downloadSongName = file_song_path;
                Stop_Insert = false;
//                Add_Playlist = true;
                responseStream.Close();
                writeStream.Close();

                requestFileDownload = null;
                responseFileDownload = null;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.Message);

                MessageBox.Show("Song is not available for now", "Eu4y Music Player");
              //  delete_temp_data(fileName);
                Add_Playlist = false;
                FirstTimeSong = false;
                Drop_Song = false;
                Stop_Insert = true;
                return;
            }

        }
        private void AddSongGrid(string TempSongName, string file, int X, int Y)
        {
            int Index=0;
            drawLine = false;
            dgPlaylist.Invalidate();
            if (System.IO.File.Exists(TempSongName))
            {
                insert_Playlist_song(file, "No");
                Point clientPoint = dgPlaylist.PointToClient(new Point(X, Y));
                
                Index = dgPlaylist.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
                if (dgPlaylist.Rows.Count == 0 || dgPlaylist.Rows.Count == 1)
                {
                    dgPlaylist.Rows.Add();
                    Index = 0;
                    ResetPlaylist(Index, file);
                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                    }
                    DownloadSong();
                    return;

                }
                else if (Index == -1)
                {
                    Index = 1;
                    ResetPlaylist(Index, file);
                    DownloadSong();
                    return;
                }
                else if (Index != -1)
                {
                    ResetPlaylist(Index, file);

                }
                DownloadSong();
            }
                        
        }
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
         
  
        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string sName = "";
            string TempName = "";
            string GetDownloadLocalPath = "";
            GC.Collect();
            GetDownloadLocalPath = downloadSongName;
            if (System.IO.File.Exists(GetDownloadLocalPath))
            {
                clsSongCrypt.encrfile(new Uri(downloadSongName, UriKind.Relative));
            }
            
            sName = temp_songid;
            TempName = Application.StartupPath + "\\" + sName + ".sec";
            delete_temp_data(temp_songid);
            if (Stop_Insert == false)
            {
               InsertDownloadSong(temp_songid);
            }
            

           // insert_Playlist_song(sName);
            if (Add_Playlist == true)
            {
                if (dgPlaylist.Rows.Count == 300)
                {
                    MessageBox.Show("Playlist is full. Create new playlist", "Eu4y Music Player");
                    return;
                }
                else if (DropTitleSong == "Yes")
                {
                    DropTitleSong = "No";
                    AddSongGrid(TempName, sName, eX, eY);
                    return;
                }
                else
                {
                    DeleteHideSong(sName);
                    insert_Playlist_song(sName, "Yes");

                }
            }
            if (IsDrop_Song == true)
            {
                if (musicPlayer1.URL != "")
                {
                    Set_foucs_PayerOne();
                }
                else if (musicPlayer2.URL != "")
                {
                    Set_foucs_PayerTwo();
                }
            }
            if (FirstTimeSong == true)
            {
                if (dgPlaylist.Rows.Count > 1)
                {
                    NextSongDisplay(dgPlaylist.Rows[1].Cells[0].Value.ToString());
                    //SetDisableRating(dgSongRatingPlayerTwo);
                }

                   // insert_Playlist_song(sName, "Yes");
                
                if (FirstPlaySong == true)
                {


                    PlaySongDefault();
                    FirstPlaySong = false;
                }
            }
            if (Drop_Song == true)
            {
                if (musicPlayer2.URL == "")
                {
                    Drop_Song = false;

                    DeleteHideSongs();
                    InsertHideSong(sName);
                    RowHide();

                    NextSongDisplay(sName);
                    Song_Set_foucs3(sName);
                    GetDropSongRow(sName);
                    DownloadSong();
                    return;

                }
                else if (musicPlayer1.URL == "")
                {
                    Drop_Song = false;

                    DeleteHideSongs();
                    InsertHideSong(sName);
                    RowHide();
                    NextSongDisplay2(sName);
                    Song_Set_foucs3(sName);
                    GetDropSongRow(sName);
                    DownloadSong();
                    return;

                }
            }
            if (musicPlayer1.URL != "")
            {
                ObjMainClass.DeleteAllOgg(musicPlayer1.currentMedia.name.ToString() + ".ogg");
            }
            else if (musicPlayer2.URL != "")
            {
                ObjMainClass.DeleteAllOgg(musicPlayer2.currentMedia.name.ToString() + ".ogg");
            }
            DownloadSong();
            multi_song_download();
           
        }
        private void Set_foucs_PayerOne()
        {
            try
            {
                for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                {
                    if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == musicPlayer1.currentMedia.name.ToString())
                    {

                        if (dgPlaylist.Rows[i].Visible == false)
                        {
                            DeleteParticularHideSong();
                            UpdateHideSong(musicPlayer1.currentMedia.name.ToString());
                        }
                        else
                        {
                            dgPlaylist.CurrentCell = dgPlaylist.Rows[i].Cells[1];
                            dgPlaylist.Rows[i].Selected = true;

                            dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[1].Style.SelectionBackColor = Color.FromArgb(20, 162, 175);
                            dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[1].Style.SelectionForeColor = Color.White;
                        }
                        lblSongName.ForeColor = Color.Yellow;
                        lblArtistName.ForeColor = Color.Yellow;
                        lblMusicTimeOne.ForeColor = Color.Yellow;
                        lblSongDurationOne.ForeColor = Color.Yellow;
                        pbarMusic1.ForeColor = Color.Yellow;
                        panMusicOne.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.CurrentPlayer));
                        pbarMusic1.BackColor = Color.FromArgb(9, 130, 154);

                        lblSongName2.ForeColor = Color.Gray;
                        lblArtistName2.ForeColor = Color.Gray;
                        lblMusicTimeTwo.ForeColor = Color.Gray;
                        lblSongDurationTwo.ForeColor = Color.Gray;
                        pbarMusic2.ForeColor = Color.Gray;
                        pbarMusic2.BackColor = Color.FromArgb(175, 175, 175);
                        panMusicTwo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.DisablePlayer));

                    }
                }
            }
            catch
            {
            }
        }
        private void Set_foucs_PayerTwo()
        {
            try
            {
                for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                {
                    if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == musicPlayer2.currentMedia.name.ToString())
                    {
                        if (dgPlaylist.Rows[i].Visible == false)
                        {
                            DeleteParticularHideSong();
                            UpdateHideSong(musicPlayer2.currentMedia.name.ToString());
                        }
                        else
                        {
                            dgPlaylist.CurrentCell = dgPlaylist.Rows[i].Cells[1];
                            dgPlaylist.Rows[i].Selected = true;
                            dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[1].Style.SelectionBackColor = Color.FromArgb(20, 162, 175);
                            dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[1].Style.SelectionForeColor = Color.White;
                        }

                        lblSongName2.ForeColor = Color.Yellow;
                        lblArtistName2.ForeColor = Color.Yellow;
                        lblMusicTimeTwo.ForeColor = Color.Yellow;
                        lblSongDurationTwo.ForeColor = Color.Yellow;
                        pbarMusic2.ForeColor = Color.Yellow;
                        pbarMusic2.BackColor = Color.FromArgb(9, 130, 154);
                        panMusicTwo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.CurrentPlayer));

                        lblSongName.ForeColor = Color.Gray;
                        lblArtistName.ForeColor = Color.Gray;
                        lblMusicTimeOne.ForeColor = Color.Gray;
                        lblSongDurationOne.ForeColor = Color.Gray;
                        pbarMusic1.ForeColor = Color.Gray;
                        pbarMusic1.BackColor = Color.FromArgb(175, 175, 175);
                        panMusicOne.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.DisablePlayer));

                        return;
                    }
                }
            }
            catch { }
        }
        private void GetDropSongRow(string DropSongId)
        {
            for (int i = 0; i < dgPlaylist.Rows.Count; i++)
            {
                if (dgPlaylist.Rows.Count > 0)
                {
                    if (DropSongId == dgPlaylist.Rows[i].Cells[0].Value.ToString())
                    {
                        CurrentRow = i - 1;
                    }
                }
            }
        }
        private void DownloadSong()
        {
            string GetLocalPath;
            string SongFind = "";
            for (int i = 0; i < dgCommanGrid.Rows.Count; i++)
            {
                GetLocalPath = Application.StartupPath + "\\" + dgCommanGrid.Rows[i].Cells[0].Value + ".sec";
                SongFind = "";
                if (System.IO.File.Exists(GetLocalPath))
                {
                    if (dgPlaylist.Rows.Count > 0)
                    {
                        for (int a = 0; a < dgPlaylist.Rows.Count; a++)
                        {
                            if (dgCommanGrid.Rows[i].Cells[0].Value.ToString() == dgPlaylist.Rows[a].Cells[0].Value.ToString())
                            {
                                dgCommanGrid.Rows[i].Cells[5].Style.ForeColor = Color.LightGreen;
                                dgCommanGrid.Rows[i].Cells[5].Style.BackColor = Color.LightGreen;
                                SongDownload.FlatStyle = FlatStyle.Popup;
                                SongFind = "Y";
                            }
                            else
                            {
                                if (SongFind != "Y")
                                {
                                    dgCommanGrid.Rows[i].Cells[5].Style.ForeColor = Color.Plum;
                                    dgCommanGrid.Rows[i].Cells[5].Style.BackColor = Color.Plum;
                                    SongDownload.FlatStyle = FlatStyle.Popup;
                                }
                            }
                        }
                    }
                    else
                    {
                        dgCommanGrid.Rows[i].Cells[5].Style.ForeColor = Color.Plum;
                        dgCommanGrid.Rows[i].Cells[5].Style.BackColor = Color.Plum;
                        SongDownload.FlatStyle = FlatStyle.Popup;
                    }

                }
                else
                {
                    dgCommanGrid.Rows[i].Cells[5].Style.ForeColor = Color.White;
                    dgCommanGrid.Rows[i].Cells[5].Style.BackColor = Color.Gainsboro;
                    SongDownload.FlatStyle = FlatStyle.Popup;
                }
            }
        }

        private void RecordAdd(DataGridView dgGrid, string songTitle)
        {
            string IsExist = "No";

            for (int i = 0; i < dgGrid.Rows.Count; i++)
            {
                if (Convert.ToString(dgGrid.Rows[i].Cells[0].Value) == songTitle)
                {
                    IsExist = "Yes";
                }

            }
            if (IsExist == "No")
            {
                dgGrid.Rows.Add();
                dgGrid.Rows[dgGrid.Rows.Count - 1].Cells[0].Value = songTitle;
            }
        }

        void multi_song_download()
        {

            string mlsSql = "";
            string songId = "";
            int i;

            mlsSql = "select * from temp_song where tokenid=" + StaticClass.TokenId;
            DataSet ds = new DataSet();
            ds = ObjMainClass.fnFillDataSet(mlsSql);
            if (bgWorker.IsBusy == false)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    songId = ds.Tables[0].Rows[i]["tempSongid"].ToString();
                    temp_songid = songId;
                    fileName = songId + ".ogg";
                    //lblSongDown.Text = "Song is downloading";
                    string filePath = Application.StartupPath + "\\" + fileName;

                    if (System.IO.File.Exists(filePath))
                    {
                       

                    }
                    else
                    {
                        
                        if (bgWorker.IsBusy == false)
                        {
                            bgWorker.RunWorkerAsync();
                            break;
                            return;
                        }
                    }

                }
            }

        }
        private void musicPlayer1_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            try
            {
                string mlsSql="";
                string currentFileName;
                var Special_Name = "";
                string Special_Change = "";

                currentFileName = musicPlayer1.currentMedia.name;
                mlsSql = "SELECT  Titles.Title as songname, Albums.Name as AlbumsName, Artists.Name AS ArtistsName FROM ( Albums INNER JOIN Titles ON Albums.AlbumID = Titles.AlbumID ) INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID where Titles.titleid=" + Convert.ToInt32(currentFileName);
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet_Local(mlsSql);

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["songname"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                lblSongName.Text = Special_Change;

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["ArtistsName"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                lblArtistName.Text = Special_Change;

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["AlbumsName"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                //lblalbumName.Text = Special_Change;

                TimerEventProcessorPlayerTwo();
                Song_Set_foucs();


                if (Song_Mute == true)
                {
                    musicPlayer1.settings.mute = true;
                }
                else
                {
                    musicPlayer1.settings.mute = false;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            musicPlayer1.Ctlcontrols.play();
            timer1.Enabled = false;
        }
        private void PlaylistSave()
        {
            string msQl = "";
            Int32 Playlist_Id = 0;
            if (StaticClass.constr.State == ConnectionState.Open)
            {
                StaticClass.constr.Close();
            }

            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("InsertPlayListsNew", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.BigInt));
            cmd.Parameters["@UserID"].Value = StaticClass.UserId;

            cmd.Parameters.Add(new SqlParameter("@IsPredefined", SqlDbType.Bit));
            cmd.Parameters["@IsPredefined"].Value = 0;

            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
            cmd.Parameters["@Name"].Value = txtPlaylistName.Text;

            cmd.Parameters.Add(new SqlParameter("@Summary", SqlDbType.VarChar, 50));
            cmd.Parameters["@Summary"].Value = " ";

            cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 50));
            cmd.Parameters["@Description"].Value = " ";

            cmd.Parameters.Add(new SqlParameter("@TokenId", SqlDbType.BigInt));
            cmd.Parameters["@TokenId"].Value = StaticClass.TokenId;

            try
            {
                Playlist_Id = Convert.ToInt32(cmd.ExecuteScalar());

                string sQr = "";

                if (StaticClass.LocalCon.State == ConnectionState.Open) StaticClass.LocalCon.Close();
                sQr = "insert into PlayLists values(" + Convert.ToInt32(Playlist_Id) + ", ";
                sQr = sQr + StaticClass.UserId + " , '" + txtPlaylistName.Text + "', " + StaticClass.TokenId + " )";
                StaticClass.LocalCon.Open();
                OleDbCommand cmdSaveLocal = new OleDbCommand();
                cmdSaveLocal.Connection = StaticClass.LocalCon;
                cmdSaveLocal.CommandText = sQr;
                cmdSaveLocal.ExecuteNonQuery();
                StaticClass.LocalCon.Close();



                // MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                // throw new ApplicationException ("Data error.");
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                StaticClass.constr.Close();
            }
        }

        private void PlaylistModify()
        {
            if (StaticClass.constr.State == ConnectionState.Open)
            {
                StaticClass.constr.Close();
            }

            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("UpdateUserPlayLists", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@PlayListID", SqlDbType.BigInt));
            cmd.Parameters["@PlayListID"].Value = ModifyPlaylistId;

            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
            cmd.Parameters["@Name"].Value = txtPlaylistName.Text;
            try
                {
                    cmd.ExecuteNonQuery();
                    string sQr = "";
                    if (StaticClass.LocalCon.State == ConnectionState.Open)
                    {
                        StaticClass.LocalCon.Close();
                    }
                    sQr = "update PlayLists set Name= '" + txtPlaylistName.Text + "' ";
                    sQr = sQr + " where PlayListID= " + Convert.ToInt16(ModifyPlaylistId);
                    StaticClass.LocalCon.Open();
                    OleDbCommand cmdSaveLocal = new OleDbCommand();
                    cmdSaveLocal.Connection = StaticClass.LocalCon;
                    cmdSaveLocal.CommandText = sQr;
                    cmdSaveLocal.ExecuteNonQuery();
                    StaticClass.LocalCon.Close();
                }
            catch (Exception ex)
                {
                   // MessageBox.Show(ex.Message);
                }
            finally
                {
                    StaticClass.constr.Close();
                }
        }

        private void FillCommanOptionGrid(string str, DataGridView Grid_Name)
        {
            int iCtr;
            try
            {
                InitilizeCommanOptionGrid(Grid_Name);
                DataTable dtDetail;
                dtDetail = ObjMainClass.fnFillDataTable(str);
                if ((dtDetail.Rows.Count > 0))
                {
                    BestOffRecordShowType = "MainAlbum";
                    for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                    {

                        Grid_Name.Rows.Add();
                        Grid_Name.Rows[Grid_Name.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["IdName"];
                        Grid_Name.Rows[Grid_Name.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["textname"];
                    }
                    foreach (DataGridViewRow row in Grid_Name.Rows)
                    {
                        row.Height = 30;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        private void FillNewestGrid(string str)
        {
            int iCtr;
            try
            {
                InitilizeNewestGrid();
                DataTable dtDetail;
                dtDetail = ObjMainClass.fnFillDataTable(str);
                if ((dtDetail.Rows.Count > 0))
                {
                    for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                    {

                        dgNewest.Rows.Add();
                        dgNewest.Rows[dgNewest.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["IdName"];
                        dgNewest.Rows[dgNewest.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["textname"];
                        dgNewest.Rows[dgNewest.Rows.Count - 1].Cells[2].Value = dtDetail.Rows[iCtr]["ArtistName"];

                        dgNewest.Rows[dgNewest.Rows.Count - 1].Cells[1].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
                        dgNewest.Rows[dgNewest.Rows.Count - 1].Cells[2].Style.Font = new Font("Segoe UI", 8, System.Drawing.FontStyle.Italic);

                    }
                    foreach (DataGridViewRow row in dgNewest.Rows)
                    {
                        row.Height = 30;
                    }

                    dgNewest.Sort(dgNewest.Columns[1], ListSortDirection.Ascending);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void FillGrid(string str)
        {
            int iCtr;
            
            string TitleTime = "";
            try
            {
                InitilizeCommanGrid();
                DataTable dtDetail;
                string GetLocalPath;
                dtDetail = ObjMainClass.fnFillDataTable(str);
                if ((dtDetail.Rows.Count > 0))
                {
                    
                    for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                    {
                       
                        dgCommanGrid.Rows.Add();
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["TitleID"];
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["Title"];
                        
                        string strTime = dtDetail.Rows[iCtr]["Time"].ToString();
                        string[] arr = strTime.Split(':');
                        TitleTime = arr[1] + ":" + arr[2];

                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[2].Value = TitleTime;
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[3].Value = dtDetail.Rows[iCtr]["ArtistName"];

                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[4].Value = dtDetail.Rows[iCtr]["AlbumName"];

                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[1].Style.Font = new Font("Segoe UI", 12,System.Drawing.FontStyle.Regular);
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[2].Style.Font = new Font("Segoe UI", 10);
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[3].Style.Font = new Font("Segoe UI", 8,System.Drawing.FontStyle.Italic);
                        dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[4].Style.Font = new Font("Segoe UI", 8, System.Drawing.FontStyle.Italic);

                        GetLocalPath = Application.StartupPath + "\\" + dtDetail.Rows[iCtr]["TitleID"] + ".sec";
                        if (System.IO.File.Exists(GetLocalPath))
                        {
                            dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[5].Style.ForeColor = Color.LightGreen;
                            dgCommanGrid.Rows[dgCommanGrid.Rows.Count - 1].Cells[5].Style.BackColor = Color.LightGreen;
                            SongDownload.FlatStyle = FlatStyle.Popup;
                        }
                    }
                    foreach (DataGridViewRow row in dgCommanGrid.Rows)
                    {
                        row.Height = 30;
                    }
                    dgCommanGrid.Sort(dgCommanGrid.Columns[1], ListSortDirection.Ascending);
                }
                 
            }
                
            catch 
            {
                
                return;
            }
        }
        void insert_Playlist_song_LocalDatabase(string song_id)
        {
            string sWr = "";
            var Special_Name ="";
            string Special_Change = "";
            int Playlist_Id = Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value);
            Int32 AlbumID = 0;
            Int32 ArtistID = 0;
            string sQr = "";
            DataSet dsAlbum = new DataSet();
            try
            {
                sQr = "select * from Titles where TitleID=" + song_id;
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet_Local(sQr);
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    
                    sQr = "select TitleID,AlbumID,ArtistID,Title,Gain,isnull(TitleYear,0) as TitleYear,Time from Titles where TitleID=" + song_id;
                    DataSet dsTitle = new DataSet();
                    dsTitle = ObjMainClass.fnFillDataSet(sQr);
                    AlbumID = Convert.ToInt32(dsTitle.Tables[0].Rows[0]["AlbumID"]);
                    ArtistID = Convert.ToInt32(dsTitle.Tables[0].Rows[0]["ArtistID"]);
                    Special_Name = dsTitle.Tables[0].Rows[0]["Title"].ToString();
                    Special_Change = Special_Name.Replace("'", "??$$$??");
                    if (StaticClass.LocalCon.State == ConnectionState.Open) StaticClass.LocalCon.Close();
                    sWr = "insert into Titles values (" + Convert.ToInt32(dsTitle.Tables[0].Rows[0]["TitleID"]) + " , " + Convert.ToInt32(dsTitle.Tables[0].Rows[0]["AlbumID"]) + " , ";
                    sWr = sWr + Convert.ToInt32(dsTitle.Tables[0].Rows[0]["ArtistID"]) + ", '" + Special_Change + "' , ";
                    sWr = sWr + "'" + dsTitle.Tables[0].Rows[0]["Gain"] + "' , '" + dsTitle.Tables[0].Rows[0]["Time"] + "' ,";
                    sWr = sWr + Convert.ToInt32(dsTitle.Tables[0].Rows[0]["TitleYear"]) + ")";
                    StaticClass.LocalCon.Open();
                    OleDbCommand cmdTitle = new OleDbCommand();
                    cmdTitle.Connection = StaticClass.LocalCon;
                    cmdTitle.CommandText = sWr;
                    cmdTitle.ExecuteNonQuery();
                    StaticClass.LocalCon.Close();
                }
                else
                {
                    sQr = "select TitleID,AlbumID,ArtistID,Title,Gain,isnull(TitleYear,0) as TitleYear,Time from Titles where TitleID=" + song_id;
                    DataSet dsTitle = new DataSet();
                    dsTitle = ObjMainClass.fnFillDataSet(sQr);
                    AlbumID = Convert.ToInt32(dsTitle.Tables[0].Rows[0]["AlbumID"]);
                    ArtistID = Convert.ToInt32(dsTitle.Tables[0].Rows[0]["ArtistID"]);

                }
                Special_Name = "";
                Special_Change = "";
                sQr = "select * from Albums where albumid=" + Convert.ToInt32(AlbumID);
                    DataSet dsAlbumLocal = new DataSet();
                    dsAlbumLocal = ObjMainClass.fnFillDataSet_Local(sQr);
                    if (dsAlbumLocal.Tables[0].Rows.Count <= 0)
                    {
                        sQr = "select * from Albums where albumid=" + Convert.ToInt32(AlbumID);
                        dsAlbum = ObjMainClass.fnFillDataSet(sQr);

                        Special_Name = dsAlbum.Tables[0].Rows[0]["Name"].ToString();
                        Special_Change = Special_Name.Replace("'", "??$$$??");

                        if (StaticClass.LocalCon.State == ConnectionState.Open) StaticClass.LocalCon.Close();
                        sWr = "insert into Albums values (" + Convert.ToInt32(dsAlbum.Tables[0].Rows[0]["AlbumID"]) + " , ";
                        sWr = sWr + Convert.ToInt32(dsAlbum.Tables[0].Rows[0]["ArtistID"]) + ", '" + Special_Change + "' ) ";
                        StaticClass.LocalCon.Open();
                        OleDbCommand cmdAlbum = new OleDbCommand();
                        cmdAlbum.Connection = StaticClass.LocalCon;
                        cmdAlbum.CommandText = sWr;
                        cmdAlbum.ExecuteNonQuery();
                        StaticClass.LocalCon.Close();
                    }
                    Special_Name = "";
                    Special_Change = "";

                    sQr = "select * from Artists where ArtistID=" + Convert.ToInt32(ArtistID);
                    DataSet dsArtistLocal = new DataSet();
                    dsArtistLocal = ObjMainClass.fnFillDataSet_Local(sQr);
                    if (dsArtistLocal.Tables[0].Rows.Count <= 0)
                    {
                        sQr = "select * from Artists where ArtistID=" + Convert.ToInt32(ArtistID);
                        DataSet dsArtist = new DataSet();
                        dsArtist = ObjMainClass.fnFillDataSet(sQr);
                        Special_Name = dsArtist.Tables[0].Rows[0]["Name"].ToString();
                        Special_Change = Special_Name.Replace("'", "??$$$??");
                        if (StaticClass.LocalCon.State == ConnectionState.Open) StaticClass.LocalCon.Close();
                        sWr = "insert into Artists values (" + Convert.ToInt32(dsArtist.Tables[0].Rows[0]["ArtistID"]) + ", '" + Special_Change + "' ) ";
                        StaticClass.LocalCon.Open();
                        OleDbCommand cmdAlbum = new OleDbCommand();
                        cmdAlbum.Connection = StaticClass.LocalCon;
                        cmdAlbum.CommandText = sWr;
                        cmdAlbum.ExecuteNonQuery();
                        StaticClass.LocalCon.Close();
                    }

               


                //(Convert.ToInt32(ds.Tables[0].Rows[0]["lastPlaylistId"]));



                if (StaticClass.LocalCon.State == ConnectionState.Open)
                {
                    StaticClass.LocalCon.Close();
                }
                sWr = "insert into TitlesInPlaylists values (" + Playlist_Id + " , " + Convert.ToInt32(song_id) + ")";
                StaticClass.LocalCon.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = StaticClass.LocalCon;
                cmd.CommandText = sWr;
                cmd.ExecuteNonQuery();
                StaticClass.LocalCon.Close();
               // DownloadSong();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }               

        void insert_Playlist_song(string songid, string GridReset)
        {
            try
            {

            if (StaticClass.constr.State == ConnectionState.Open)
            {
                StaticClass.constr.Close();
            }
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("InsertTitlesInPlayLists", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@PlayListID", SqlDbType.BigInt));
            cmd.Parameters["@PlayListID"].Value = Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value);

            cmd.Parameters.Add(new SqlParameter("@TitleID", SqlDbType.BigInt));
            cmd.Parameters["@TitleID"].Value = songid;

           
                cmd.ExecuteNonQuery();
                insert_Playlist_song_LocalDatabase(songid);
                if (GridReset == "Yes")
                {
                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                    }
                }
            }
            catch (Exception ex)
            {
               
               // throw new ApplicationException("Data error.");
            }
            finally
            {
                StaticClass.constr.Close();
            }
            
             
        }               
        private void PlaySongDefault()
        {
            string MusicFileName = "";
            string TempMusicFileName = "";
            for (int i = 0; i < dgPlaylist.Rows.Count; i++)
            {
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[i].Cells[0].Value));
                    musicPlayer1.URL = MusicFileName;
                    musicPlayer1.settings.volume = 100;
                    CurrentRow = i;
                    CurrentPlaylistRow = dgLocalPlaylist.CurrentCell.RowIndex;
                    if (CurrentRow == dgPlaylist.Rows.Count - 1)
                    {
                        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                    }
                    else
                    {
                        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                    }
                    return;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text= musicPlayer1.settings.volume.ToString();
            //Form1 objform1 = new Form1();
            //objform1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            musicPlayer1.settings.volume = 40;
            musicPlayer1.Ctlcontrols.currentPosition = 15;
            //Form2 objform2 = new Form2();
            //objform2.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitValidation();
            if (SubmitValidate == "True")
            {
                panPlaylist.Enabled = true;
                panComman.Enabled = true;
                
                panLock.Visible = false;
                
            }
        }
        private void SubmitValidation()
        {
            string str = "";
            str = "select * from tbluser_client_rights where userid=" + StaticClass.UserId + " and clientname='" + txtloginUserName.Text + "' and clientpassword='" + txtLoginPassword.Text + "'";
            DataSet ds = new DataSet();
            ds = ObjMainClass.fnFillDataSet(str);
            if (txtloginUserName.Text == "")
            {
                lblError.Text="Login user name cannot be blank";
                SubmitValidate = "False";
            }
            else if (txtLoginPassword.Text == "")
            {
                lblError.Text="Login password cannot be blank";
                SubmitValidate = "False";
            }
            else if (ds.Tables[0].Rows.Count <= 0)
            {
                lblError.Text="Login user/password is wrong";
                SubmitValidate = "False";
            }
            else if (ds.Tables[0].Rows.Count > 0)
            {
                lblError.Text = "";
                SubmitValidate = "True";
            }
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            musicPlayer2.Ctlcontrols.play();
            timer2.Enabled = false;
        }
        private void TimerEventProcessorPlayerTwo()
        {
            if (IsbtnClick == "N")
            {
                timer4.Enabled = false;
                timer5.Enabled = false;
            }
            else
            {
                timer4.Enabled = true;
                timer5.Enabled = true;
            }
            timAutoFadePlayerOne.Enabled = true;
            timAutoFadePlayerTwo.Enabled = true;
            //            timer3.Interval = 1000;
 //           timer3.Enabled = true;
            timMusicTimeOne.Enabled = true;
            timMusicTimeTwo.Enabled = true;

        }

        private void TimerEventProcessorPlayerOne()
        {

            if (IsbtnClick == "N")
            {
                timer4.Enabled = false;
                timer5.Enabled = false;
            }
            else
            {
                timer4.Enabled = true;
                timer5.Enabled = true;
            }
            timAutoFadePlayerOne.Enabled = true;
            timAutoFadePlayerTwo.Enabled = true;
            //            timer3.Interval = 1000;
            //           timer3.Enabled = true;
            timMusicTimeOne.Enabled = true;
            timMusicTimeTwo.Enabled = true;

        }

        private void timer3_Tick(object sender, EventArgs e)

        {

            double t = Math.Floor(musicPlayer1.currentMedia.duration - musicPlayer1.Ctlcontrols.currentPosition);
            double a = Math.Floor(musicPlayer1.Ctlcontrols.currentPosition);
            timeRemaining.Text = (t.ToString());
//            lblCurrentTiming.Text =  a.ToString();
            
        }


        private void PlaylistFadeSong()
        {
            string MusicFileName = "";
            string TempMusicFileName = "";
            string mlsSql = "";
            string FindSong = "";
            DataTable dtDetail;
            if (dgPlaylist.Rows.Count  == 0)
                {
                    if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                    {
                        CurrentPlaylistRow = 0;

                    }
                    else
                    {
                        CurrentPlaylistRow = CurrentPlaylistRow + 1;
                    }
                GHTE:
                    for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                    {
                        mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                        dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                        if ((dtDetail.Rows.Count > 0))
                        {
                            CurrentPlaylistRow = i;
                            FindSong = "True";
                            break;
                        }
                        else
                        {
                            FindSong = "false";
                            if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                            {
                                CurrentPlaylistRow = 0;
                            }
                            else
                            {
                                CurrentPlaylistRow = i;
                            }
                        }
                    }
                if (FindSong == "false")
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count == 0))
                    {
                        CurrentPlaylistRow = 0;
                        goto GHTE;
                    }
                }
                    dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                    //dgPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                    dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;
                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                    }
                    CurrentRow = 0;
                    TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                    MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                    if (System.IO.File.Exists(TempMusicFileName))
                    {
                        DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                        musicPlayer2.URL = MusicFileName;
                        musicPlayer2.settings.volume = 0;
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                        timer2.Enabled = true;
                        return;
                    }
                }

            if (dgPlaylist.Rows.Count-1 == 0)
            {
                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                {
                    CurrentPlaylistRow = 0;

                }
                else
                {
                    CurrentPlaylistRow = CurrentPlaylistRow + 1;
                }
            GHT:
                for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count > 0))
                    {
                        CurrentPlaylistRow = i;
                        FindSong = "True";
                        break;
                    }
                    else
                    {
                        FindSong = "false";
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;
                        }
                        else
                        {
                            CurrentPlaylistRow = i;
                        }
                    }
                }
            if (FindSong == "false")
            {
                mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                if ((dtDetail.Rows.Count == 0))
                {
                    CurrentPlaylistRow = 0;
                    goto GHT;
                }
            }
                dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                //dgPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;
                if (chkShuffleSong.Checked == true)
                {
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }
                CurrentRow = 0;
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer2.URL = MusicFileName;
                    musicPlayer2.settings.volume = 0;
                    if (CurrentRow == dgPlaylist.Rows.Count - 1)
                    {
                        NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                    }
                    else
                    {
                        NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                    }
                    timer2.Enabled = true;
                    return;
                }
            }




            gg:
               if (CurrentRow == dgPlaylist.Rows.Count - 1)
                {
                    if (IsDrop_Song == false)
                    {
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;

                        }
                        else
                        {
                            CurrentPlaylistRow = CurrentPlaylistRow + 1;
                        }

                        for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                        {
                            mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                            dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                            if ((dtDetail.Rows.Count > 0))
                            {
                                CurrentPlaylistRow = i;
                                break;
                            }
                            else
                            {
                                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                                {
                                    CurrentPlaylistRow = 0;
                                }
                                else
                                {
                                    CurrentPlaylistRow = i;
                                }
                            }
                        }

                        dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                        //dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                        dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;
                        if (chkShuffleSong.Checked == true)
                        {
                            PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                        }
                        else
                        {
                            PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                        }

                        CurrentRow = 0;
                    }
                    else
                    {
                        IsDrop_Song = false;
                    }
                    TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                    MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                    if (System.IO.File.Exists(TempMusicFileName))
                    {
                        DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                        musicPlayer2.URL = MusicFileName;
                        musicPlayer2.settings.volume = 0;
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                        timer2.Enabled = true;
                        return;
                    }


                }
                //if (chkShuffleSong.Checked == true)
                //{
                //    CurrentRow = CurrentRow + 3;
                //}
                //else
                //{
            if (CurrentRow >= dgPlaylist.Rows.Count)
            {
                CurrentRow = 0;
            }
            else
            {
                CurrentRow = CurrentRow + 1;
            }
               //}


                if (CurrentRow == dgPlaylist.Rows.Count)
                {
                    CurrentRow = dgPlaylist.Rows.Count - 1;
                    goto gg;
                }

                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer2.URL = MusicFileName;
                    musicPlayer2.settings.volume = 0;
                    if (CurrentRow == dgPlaylist.Rows.Count - 1)
                    {
                        NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                    }
                    else
                    {
                        NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                    }
                    timer2.Enabled = true;
                    return;
                }
                for (int i = Convert.ToInt16(CurrentRow); i < dgPlaylist.Rows.Count; i++)
                {
                    TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".sec";
                    MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".ogg";
                    if (System.IO.File.Exists(TempMusicFileName))
                    {
                        DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[i].Cells[0].Value));
                        musicPlayer2.URL = MusicFileName;
                        musicPlayer2.settings.volume = 0;
                        if (i == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay2(dgPlaylist.Rows[0].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay2(dgPlaylist.Rows[i + 1].Cells[0].Value.ToString());
                        }
                        timer2.Enabled = true;

                        //if (chkShuffleSong.Checked == true)
                        //{
                        //    if (CurrentRow == 0)
                        //    {
                        //        CurrentRow = i + 2;
                        //    }
                        //    else if (CurrentRow == 1)
                        //    {
                        //        CurrentRow = i + 4;
                        //    }
                        //    else
                        //    {
                        //        CurrentRow = i - 1;
                        //    }
                        //}
                        //else
                        //{
                            CurrentRow = i;
                       // }

                        timer2.Enabled = true;
                        return;
                    }
                
            }
        }
        private void dgLocalPlaylist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex >= 0)
                {
                    //CurrentPlaylistRow = dgLocalPlaylist.CurrentCell.RowIndex;
                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value));
                    }
                    //Song_Set_foucs();
                    DownloadSong();
                }
            }
            //if (e.ColumnIndex == 2)
            //{
            //    txtPlaylistName.Text = dgLocalPlaylist.Rows[e.RowIndex].Cells[1].Value.ToString();
            //    ModifyPlaylistId = Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value);
            //    pAction = "Modify";
            //    txtPlaylistName.Focus();
            //}
        }
        

        private void dgPlaylist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex == -1)
            {
                return;
            }
            //int rowindex = dgPlaylist.CurrentCell.RowIndex;
            //int columnindex = dgPlaylist.CurrentCell.ColumnIndex;
            //string localfilename;
            //try
            //{
            //    localfilename = dgPlaylist.Rows[rowindex].Cells[0].Value.ToString() + ".ogg";
            //    string localfilePath = Application.StartupPath + "\\" + localfilename;

            //    if (columnindex == 2)
            //    {
                    
            //        if (System.IO.File.Exists(localfilePath))
            //        {
            //            musicPlayer1.URL = localfilePath;
            //            musicPlayer1.settings.volume = 70;
            //            musicPlayer2.URL = "";
            //            musicPlayer2.Ctlcontrols.stop();
            //            CurrentRow = rowindex;

            //            if (CurrentRow == dgPlaylist.Rows.Count - 1)
            //            {
            //                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
            //            }
            //            else
            //            {
            //                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
            //            }
            //            return;
            //        }
            //    }

            //    if (columnindex == 3)
            //    {
                   
            //        if (StaticClass.isDownload != "1" || StaticClass.isRemove != "1")
            //        {
            //            MessageBox.Show(ObjMainClass.MainMessage, "Eu4y Music Player");
            //            return;
            //        }
            //        if (musicPlayer1.URL != "")
            //        {
            //            if (dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString() == musicPlayer1.currentMedia.name.ToString())
            //            {
            //                MessageBox.Show("You cannot delete current song", "Eu4y Music Player");
            //                return;
            //            }
            //        }
            //        if (musicPlayer2.URL != "")
            //        {
            //            if (dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString() == musicPlayer2.currentMedia.name.ToString())
            //            {
            //                MessageBox.Show("You cannot delete current song", "Eu4y Music Player");
            //                return;
            //            }
            //        }

            //        if (Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) != 0)
            //        {
            //            StaticClass.constr.Open();
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.Connection = StaticClass.constr;
            //            cmd.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgPlaylist.Rows[rowindex].Cells[0].Value;
            //            cmd.ExecuteNonQuery();
            //            StaticClass.constr.Close();

            //            delete_temp_data(dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString());

            //           // System.IO.File.Delete(localfilePath);
            //            if (chkShuffleSong.Checked == true)
            //            {
            //                PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
            //            }
            //            else
            //            {
            //                PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
            //            }
            //           // DownloadSong();

            //            //if (musicPlayer1.URL != "")
            //            //{
            //            //    Song_Set_foucs();
            //            //}
            //            //if (musicPlayer2.URL != "")
            //            //{
            //            //    Song_Set_foucs2();
            //            //}

            //            if (CurrentRow == dgPlaylist.Rows.Count - 1)
            //            {
            //                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
            //            }
            //            else
            //            {
            //                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
            //            }
                        
            //        }

            //        else
            //        {
            //            MessageBox.Show("Select a playlist", "Eu4y Music Player");
            //        }
            //    }
            //}
            //catch {}
        }
        private void Music_Player_Settings()
        {
            string str = "";
            string Song_Name="";
            string GetName = "";
            DataTable dtDetail;
            string mlsSql = "";
            if (dgLocalPlaylist.Rows.Count  == 0) return;
            if (dgPlaylist.Rows.Count  == 0) return;
            double LastSongDuration = Math.Floor(musicPlayer1.Ctlcontrols.currentPosition);
            if (StaticClass.constr.State == ConnectionState.Open)
            {
                StaticClass.constr.Close();
            }
            str = "delete from tblmusic_player_settings where DFClientId=" + StaticClass.UserId + " and localUserId= " + StaticClass.LocalUserId + " and tokenNo=" + StaticClass.TokenId;
                StaticClass.constr.Open();
                SqlCommand cmdDel = new SqlCommand();
                cmdDel.Connection = StaticClass.constr;
                cmdDel.CommandText = str;
                cmdDel.ExecuteNonQuery();
                StaticClass.constr.Close();

            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("Insert_music_player_settings", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@DFClientId", SqlDbType.BigInt));
            cmd.Parameters["@DFClientId"].Value = Convert.ToInt32(StaticClass.UserId);

            cmd.Parameters.Add(new SqlParameter("@localUserId", SqlDbType.BigInt));
            cmd.Parameters["@localUserId"].Value = Convert.ToInt32(StaticClass.LocalUserId); ;

            cmd.Parameters.Add(new SqlParameter("@lastPlaylistId", SqlDbType.BigInt));

            if (musicPlayer1.URL != "")
            {
                cmd.Parameters.Add(new SqlParameter("@lastTileId", SqlDbType.BigInt));
                cmd.Parameters["@lastTileId"].Value = Convert.ToInt32(musicPlayer1.currentMedia.name);
                Song_Name = musicPlayer1.currentMedia.name.ToString();
            }
            else if (musicPlayer2.URL != "")
            {
                cmd.Parameters.Add(new SqlParameter("@lastTileId", SqlDbType.BigInt));
                cmd.Parameters["@lastTileId"].Value = Convert.ToInt32(musicPlayer2.currentMedia.name);
                Song_Name = musicPlayer2.currentMedia.name.ToString();
            }


            for ( int i = 0; i < dgLocalPlaylist.Rows.Count; i++)
            {
                mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                dtDetail = ObjMainClass.fnFillDataTable(mlsSql);
                if ((dtDetail.Rows.Count > 0))
                {
                    for (int iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                    {
                        if (dtDetail.Rows[iCtr]["TitleID"].ToString() == Song_Name)
                        {
                            cmd.Parameters["@lastPlaylistId"].Value = Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                            GetName = "Yes";
                            break;
                        }
                    }
                }
                if (GetName == "Yes")
                {
                    break;
                }
            }
            
            

            cmd.Parameters.Add(new SqlParameter("@lastVolume", SqlDbType.Int));
            cmd.Parameters["@lastVolume"].Value = Convert.ToInt16(musicPlayer1.settings.volume);

            cmd.Parameters.Add(new SqlParameter("@lastSongDuration", SqlDbType.Int));
            cmd.Parameters["@lastSongDuration"].Value = Convert.ToInt16(LastSongDuration);

            cmd.Parameters.Add(new SqlParameter("@IsFade", SqlDbType.Int));
            cmd.Parameters["@IsFade"].Value = 0;

            cmd.Parameters.Add(new SqlParameter("@IsShuffle", SqlDbType.Int));
            if (chkShuffleSong.Checked == true)
            {
                cmd.Parameters["@IsShuffle"].Value = 1;
            }
            else
            {
                cmd.Parameters["@IsShuffle"].Value = 0;
            }

            cmd.Parameters.Add(new SqlParameter("@TokenNo", SqlDbType.BigInt));
            cmd.Parameters["@TokenNo"].Value = StaticClass.TokenId;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Application.Exit();
                return;
            }
            finally
            {
                StaticClass.constr.Close();
            }
        }
        private void Get_Last_Settings()
        {
            string tempSongName = "";
            try
            {
                string str = "";
                string SongName = "";
                str = "select * from tblmusic_player_settings where DFClientId=" + StaticClass.UserId + " and localUserId=" + StaticClass.LocalUserId + " and tokenNo=" + StaticClass.TokenId ;
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet(str);

                PopulateInputFileTypeDetail(Convert.ToInt32(ds.Tables[0].Rows[0]["lastPlaylistId"]));
                for (int i = 0; i < dgLocalPlaylist.Rows.Count; i++)
                {
                    if (dgLocalPlaylist.Rows[i].Cells[0].Value.ToString() == ds.Tables[0].Rows[0]["lastPlaylistId"].ToString())
                    {
                        dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[i].Cells[1];
                        CurrentPlaylistRow = i;
                    }
                }


               
                //tempSongName = Application.StartupPath + "\\" + ds.Tables[0].Rows[0]["lastTileId"] + ".sec";
                int tempRow = 0;
                for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                {
                    if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == ds.Tables[0].Rows[0]["lastTileId"].ToString())
                    {
                        tempRow = i + 1;
                        if (tempRow >= dgPlaylist.Rows.Count)
                        {
                            tempRow = 1;
                        }
                        tempSongName = Application.StartupPath + "\\" + dgPlaylist.Rows[tempRow].Cells[0].Value.ToString() + ".sec";
                        if (System.IO.File.Exists(tempSongName))
                        {
                            SongName = Application.StartupPath + "\\" + dgPlaylist.Rows[tempRow].Cells[0].Value.ToString() + ".ogg";
                            DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[tempRow].Cells[0].Value));
                            musicPlayer1.URL = SongName;
                            musicPlayer1.Ctlcontrols.currentPosition = 5;
                            CurrentRow = tempRow;


                            dgPlaylist.CurrentCell = dgPlaylist.Rows[i].Cells[1];
                            if (CurrentRow == dgPlaylist.Rows.Count - 1)
                            {
                                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                            }
                            else
                            {
                                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                            }

                        }
                    }
                }

                //            musicPlayer1.settings.volume = Convert.ToInt16(ds.Tables[0].Rows[0]["lastVolume"]);
                musicPlayer1.settings.volume = 100;

                if (Convert.ToInt16(ds.Tables[0].Rows[0]["IsShuffle"]) == 1)
                {
                    chkShuffleSong.Checked = true;
                    PopulateShuffleSong(Convert.ToInt32(ds.Tables[0].Rows[0]["lastPlaylistId"]), ShuffleCount);
                }
                else
                {
                    chkShuffleSong.Checked = false;
                    PopulateInputFileTypeDetail(Convert.ToInt32(ds.Tables[0].Rows[0]["lastPlaylistId"]));
                }
                //            musicPlayer1.Ctlcontrols.currentPosition = Convert.ToInt16(ds.Tables[0].Rows[0]["lastSongDuration"]);
                //          timer1.Enabled = true;

            }
            catch { }
        }
        private void Song_Set_foucs()
        {
            try
            {
                drawLine = false;
                dgPlaylist.Invalidate();
                for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                {
                    if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == musicPlayer1.currentMedia.name.ToString())
                    {
                        CurrentRow = i;
                        if (dgPlaylist.Rows[i].Visible == false)
                        {
                            DeleteParticularHideSong();
                            UpdateHideSong(musicPlayer1.currentMedia.name.ToString());
                        }
                        else
                        {
                            dgPlaylist.CurrentCell = dgPlaylist.Rows[i].Cells[1];
                            dgPlaylist.Rows[i].Selected = true;

                            dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[1].Style.SelectionBackColor = Color.FromArgb(20, 162, 175);
                            dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[1].Style.SelectionForeColor = Color.White;
                        }
                        lblSongName.ForeColor = Color.Yellow;
                        lblArtistName.ForeColor = Color.Yellow;
                        lblMusicTimeOne.ForeColor = Color.Yellow;
                        lblSongDurationOne.ForeColor = Color.Yellow;
                        pbarMusic1.ForeColor = Color.Yellow;
                        panMusicOne.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.CurrentPlayer));
                        pbarMusic1.BackColor = Color.FromArgb(9, 130, 154);

                        lblSongName2.ForeColor = Color.Gray;
                        lblArtistName2.ForeColor = Color.Gray;
                        lblMusicTimeTwo.ForeColor = Color.Gray;
                        lblSongDurationTwo.ForeColor = Color.Gray;
                        pbarMusic2.ForeColor = Color.Gray;
                        pbarMusic2.BackColor = Color.FromArgb(175, 175, 175);
                        panMusicTwo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.DisablePlayer));

                    }
                }
                
            }
            catch
            {
            }
        }

        private void Song_Set_foucs2()
        {
            try
            {
                drawLine = false;
                dgPlaylist.Invalidate();
                for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                {
                    if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == musicPlayer2.currentMedia.name.ToString())
                    {
                        CurrentRow = i;
                        if (dgPlaylist.Rows[i].Visible == false)
                        {
                            DeleteParticularHideSong();
                            UpdateHideSong(musicPlayer2.currentMedia.name.ToString());
                        }
                        else
                        {
                            dgPlaylist.CurrentCell = dgPlaylist.Rows[i].Cells[1];
                            dgPlaylist.Rows[i].Selected = true;
                            dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[1].Style.SelectionBackColor = Color.FromArgb(20, 162, 175);
                            dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[1].Style.SelectionForeColor = Color.White;
                        }

                        lblSongName2.ForeColor = Color.Yellow;
                        lblArtistName2.ForeColor = Color.Yellow;
                        lblMusicTimeTwo.ForeColor = Color.Yellow;
                        lblSongDurationTwo.ForeColor = Color.Yellow;
                        pbarMusic2.ForeColor = Color.Yellow;
                        pbarMusic2.BackColor = Color.FromArgb(9, 130, 154);
                        panMusicTwo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.CurrentPlayer));

                        lblSongName.ForeColor = Color.Gray;
                        lblArtistName.ForeColor = Color.Gray;
                        lblMusicTimeOne.ForeColor = Color.Gray;
                        lblSongDurationOne.ForeColor = Color.Gray;
                        pbarMusic1.ForeColor = Color.Gray;
                        pbarMusic1.BackColor = Color.FromArgb(175, 175, 175);
                        panMusicOne.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.DisablePlayer));
                       
                        return;
                    }
                }
            }
            catch { }
        }








        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string str = "";
            
            if (e.KeyCode==Keys.Return)
            {
                if (ObjMainClass.CheckForInternetConnection() == false)
                {
                    MessageBox.Show("Check your internet connection", "Eu4y music player");
                    return;
                }
                if (txtSearch.Text == "")
                {
                    str = "SELECT TOP (200) Titles.TitleID, Titles.Title, Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID where titlecategoryid=4 order by TitleID desc";
                    FillGrid(str);
                    DownloadSong();
                    return;

                }
                if (txtSearch.Text.Length < 2)
                {
                    MessageBox.Show("Atleast enter two character for search", "Eu4y Music Player");
                    return;
                }
                SearchText = txtSearch.Text;

                
                CommanSearch();
                //stSearch = "spOverallSearch'" + txtSearch.Text + "',300";
                //FillGrid(stSearch);
                txtSearch.TextAlign = HorizontalAlignment.Left;
                txtSearch.ForeColor = Color.White;
                txtSearch.Text = "";
                DownloadSong();
               // picLoading.Visible = false;
                
            }

        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.TextAlign = HorizontalAlignment.Left;
            txtSearch.ForeColor = Color.White;
            txtSearch.Text = "";
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = "Search";
            txtSearch.TextAlign = HorizontalAlignment.Center;
            txtSearch.ForeColor = Color.White;

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 39 || Convert.ToInt32(e.KeyChar) == 37)
            {
                e.Handled = true;
                return;
            }
           // MessageBox.Show(Convert.ToInt32(e.KeyChar).ToString());
            
        }
              
        
            
        private void btnFade_Click(object sender, EventArgs e)
        {
            try
            {
                if (musicPlayer1.URL == "" && musicPlayer2.URL == "" && dgPlaylist.Rows.Count == 0)
                {
                    MessageBox.Show("Drop the song on player", "Eu4y Music Player");
                    return;
                }
                drawLine = false;
                dgPlaylist.Invalidate();
                if (musicPlayer1.URL == "")
                {
                    IsbtnClick = "Y";
                    panPlayerButton.Enabled = false;
                    panComman.Enabled = false;
                    panPlaylist.Enabled = false;
                    PlaylistFadeSongPlayerOne();

                    timAutoFadePlayerOne.Enabled = false;
                    timAutoFadePlayerTwo.Enabled = false;
                    timer5.Enabled = true;
                    return;
                }
                if (musicPlayer2.URL == "")
                {
                    IsbtnClick = "Y";
                    panPlayerButton.Enabled = false;
                    panComman.Enabled = false;
                    panPlaylist.Enabled = false;
                    PlaylistFadeSong();

                    timAutoFadePlayerOne.Enabled = false;
                    timAutoFadePlayerTwo.Enabled = false;
                    timer4.Enabled = true;
                    return;

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
            }
        }
        private void PlaylistFadeSongPlayerOne()
        {
            string MusicFileName = "";
            string TempMusicFileName = "";
            string mlsSql = "";
            string FindSong = "";
            DataTable dtDetail;
            if (dgPlaylist.Rows.Count  == 0)
            {
                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                {
                    CurrentPlaylistRow = 0;
                }
                else
                {
                    CurrentPlaylistRow = CurrentPlaylistRow + 1;
                }
            GHTE:
                for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count > 0))
                    {
                        CurrentPlaylistRow = i;
                        FindSong = "True";
                        break;
                    }
                    else
                    {
                        FindSong = "false";
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;
                        }
                        else
                        {
                            CurrentPlaylistRow = i;
                        }
                    }
                }
            if (FindSong == "false")
            {
                mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                if ((dtDetail.Rows.Count == 0))
                {
                    CurrentPlaylistRow = 0;
                    goto GHTE;
                }
            }
                dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                //dgPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;
                if (chkShuffleSong.Checked == true)
                {
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }

                CurrentRow = 0;
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer1.URL = MusicFileName;
                    musicPlayer1.settings.volume = 0;
                    if (CurrentRow == dgPlaylist.Rows.Count - 1)
                    {
                        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                    }
                    else
                    {
                        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                    }
                    timer1.Enabled = true;
                    return;
                }
            }



            if (dgPlaylist.Rows.Count-1 == 0)
            {
                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                {
                    CurrentPlaylistRow = 0;

                }
                else
                {
                    CurrentPlaylistRow = CurrentPlaylistRow + 1;
                }
            GHT:
                for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count > 0))
                    {
                        CurrentPlaylistRow = i;
                        FindSong = "True";
                        break;
                    }
                    else
                    {
                        FindSong = "false";
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;
                        }
                        else
                        {
                            CurrentPlaylistRow = i;
                        }
                    }
                }
            if (FindSong == "false")
            {
                mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                if ((dtDetail.Rows.Count == 0))
                {
                    CurrentPlaylistRow = 0;
                    goto GHT;
                }
            }

                dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                //dgPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;
                if (chkShuffleSong.Checked == true)
                {
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }

                CurrentRow = 0;
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer1.URL = MusicFileName;
                    musicPlayer1.settings.volume = 0;
                    if (CurrentRow == dgPlaylist.Rows.Count - 1)
                    {
                        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                    }
                    else
                    {
                        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                    }
                    timer1.Enabled = true;
                    return;
                }
            }


        gg:
            if (CurrentRow == dgPlaylist.Rows.Count - 1)
            {
                if (IsDrop_Song == false)
                {
                    if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                    {
                        CurrentPlaylistRow = 0;

                    }
                    else
                    {
                        CurrentPlaylistRow = CurrentPlaylistRow + 1;
                    }

                    for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                    {
                        mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                        dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                        if ((dtDetail.Rows.Count > 0))
                        {
                            CurrentPlaylistRow = i;
                            break;
                        }
                        else
                        {
                            if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                            {
                                CurrentPlaylistRow = 0;
                            }
                            else
                            {
                                CurrentPlaylistRow = i;
                            }
                        }
                    }

                    dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                    //dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                    dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;

                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                    }
                    CurrentRow = 0;
                }
                else
                {
                    IsDrop_Song = false;
                }
                    TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                    MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                    if (System.IO.File.Exists(TempMusicFileName))
                    {
                        DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                        musicPlayer1.URL = MusicFileName;
                        musicPlayer1.settings.volume = 0;
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                        timer1.Enabled = true;
                        return;
                    }


                }
            //if (chkShuffleSong.Checked == true)
            //{
            //    if (CurrentRow == 0)
            //    {
            //        CurrentRow = CurrentRow + 1;
            //    }
            //    else
            //    {
            //        CurrentRow = CurrentRow - 2;
            //    }
            //}
            //else
            //{
        if (CurrentRow >= dgPlaylist.Rows.Count)
        {
            CurrentRow = 0;
        }
        else
        {
            CurrentRow = CurrentRow + 1;
        }
           // }
            if (CurrentRow == dgPlaylist.Rows.Count)
            {
                CurrentRow = dgPlaylist.Rows.Count - 1;
                goto gg;
            }

            TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
            MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
            if (System.IO.File.Exists(TempMusicFileName))
            {
                DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                musicPlayer1.URL = MusicFileName;
                musicPlayer1.settings.volume = 0;
                if (CurrentRow == dgPlaylist.Rows.Count - 1)
                {
                    NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                }
                else
                {
                    NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                }
                timer1.Enabled = true;
                return;
            }
            for (int i = Convert.ToInt16(CurrentRow); i < dgPlaylist.Rows.Count; i++)
            {
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[i].Cells[0].Value));
                    musicPlayer1.URL = MusicFileName;
                    musicPlayer1.settings.volume = 0;
                    if (i == dgPlaylist.Rows.Count - 1)
                    {
                        NextSongDisplay(dgPlaylist.Rows[0].Cells[0].Value.ToString());
                    }
                    else
                    {
                        NextSongDisplay(dgPlaylist.Rows[i + 1].Cells[0].Value.ToString());
                    }
                    timer1.Enabled = true;

                    //if (chkShuffleSong.Checked == true)
                    //{
                    //    CurrentRow = i + 2;
                    //}
                    //else
                    //{
                        CurrentRow = i;
                    //}

                    timer1.Enabled = true;
                    return;
                }

            }
        }


        private void NextSongDisplay2(string NextSongId)
        {
            try
            {
                string mlsSql;
                var Special_Name = "";
                string Special_Change = "";
                mlsSql = "SELECT  Titles.Title as songname, Albums.Name as AlbumsName, Artists.Name AS ArtistsName FROM ( Albums INNER JOIN Titles ON Albums.AlbumID = Titles.AlbumID ) INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID where Titles.titleid=" + Convert.ToInt32(NextSongId);
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet_Local(mlsSql);

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["songname"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                lblSongName.Text = Special_Change;

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["ArtistsName"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                lblArtistName.Text = Special_Change;

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["AlbumsName"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                //lblalbumName.Text = Special_Change;
                UpcomingSongPlayerOne = NextSongId;
                UpcomingSongPlayerTwo = "";

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            try
            {
                double a = Math.Floor(musicPlayer2.Ctlcontrols.currentPosition);
                lblCurrentTiming.Text = a.ToString();
                double t = Math.Floor(musicPlayer2.currentMedia.duration - musicPlayer2.Ctlcontrols.currentPosition);
                lblMusic2Timeremaing.Text = (t.ToString());
                PlayFadeSong();
            }
            catch
            {
            }
        }

        private void PlayFadeSong()
        {
           
            if (lblCurrentTiming.Text == "1")
            {
                int musicVolume ;


                musicVolume = musicPlayer1.settings.volume;
                musicPlayer2.settings.volume = 25;
                musicPlayer1.settings.volume = 75;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer1.settings.volume = 0;
                //}
                //else
                //    if (musicVolume >= 40)
                //{
                //    musicPlayer1.settings.volume = 30;
                //}
                //else
                //{
                //    musicPlayer1.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblCurrentTiming.Text == "2")
            {
                int musicVolume;
                musicVolume = musicPlayer1.settings.volume;
                musicPlayer2.settings.volume = 50;
                musicPlayer1.settings.volume = 50;
                GetSavedRating(musicPlayer2.currentMedia.name, dgSongRatingPlayerTwo);
                SetDisableRating(dgSongRatingPlayerOne);
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer1.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer1.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblCurrentTiming.Text == "4")
            {
                int musicVolume;
                musicVolume = musicPlayer1.settings.volume;
                musicPlayer2.settings.volume = 75;
                musicPlayer1.settings.volume = 25;

                //musicPlayer2.settings.volume = 30;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer1.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer1.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblCurrentTiming.Text == "6")
            {
                int musicVolume;
                musicVolume = musicPlayer1.settings.volume;
                musicPlayer2.settings.volume = 85;
                musicPlayer1.settings.volume = 25;

                //musicPlayer2.settings.volume = 35;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer1.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer1.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblCurrentTiming.Text == "8")
            {
                musicPlayer1.settings.volume = 0;
                musicPlayer1.Ctlcontrols.stop();
                musicPlayer1.URL = "";
                musicPlayer2.settings.volume = 100;
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                IsbtnClick = "N";
                Song_Set_foucs2();
                lblMusicTimeOne.Text = "00:00";
                lblSongDurationOne.Text = "00:00";
            }
            else if (lblCurrentTiming.Text == "10")
            {
                musicPlayer1.settings.volume = 0;
                musicPlayer1.Ctlcontrols.stop();
                musicPlayer1.URL = "";
                musicPlayer2.settings.volume = 100;
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                ObjMainClass.DeleteAllOgg(musicPlayer2.currentMedia.name.ToString() + ".ogg");
            }
        }

        private void dgPlaylist_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                 drawLine = false;
                
                RowDeselect(dgPlaylist);
                dgPlaylist.Rows[e.RowIndex].Selected = true;
                dgPlaylist.DoDragDrop(dgPlaylist.Rows[e.RowIndex].Cells[0].Value.ToString(), DragDropEffects.Copy);
            }
             
            
        }
        
        private void GetNextSong(string RunningPlayer)
        {
            string currentFileName;
            if (RunningPlayer=="1")
            {
                currentFileName = musicPlayer2.currentMedia.name;
                for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                {
                    if (currentFileName == dgPlaylist.Rows[i].Cells[0].Value.ToString())
                    {
                        CurrentRow = i;
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                        return;
                    }
                }
            }
            else if (RunningPlayer == "2")
            {
                currentFileName = musicPlayer1.currentMedia.name;
                for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                {
                    if (currentFileName == dgPlaylist.Rows[i].Cells[0].Value.ToString())
                    {
                        CurrentRow = i;
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                        return;
                    }
                }

            }

        }

       
       
 
        private void Song_Clear_foucs()
        {
            try
            {
                for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                {
                    dgPlaylist.Rows[i].Cells[1].Style.SelectionBackColor = Color.White;
                    dgPlaylist.Rows[i].Cells[1].Style.SelectionForeColor = Color.Black;

                    dgPlaylist.Rows[i].Cells[2].Style.SelectionBackColor = Color.White;
                    dgPlaylist.Rows[i].Cells[2].Style.SelectionForeColor = Color.Black;
                    
                    dgPlaylist.Rows[i].Cells[3].Style.SelectionBackColor = Color.White;
                    dgPlaylist.Rows[i].Cells[3].Style.SelectionForeColor = Color.Black;

                }
            }
            catch  
            {
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            try
            {
                double a = Math.Floor(musicPlayer1.Ctlcontrols.currentPosition);
                lblCurrentTimingPlayerOne.Text = a.ToString();
                double t = Math.Floor(musicPlayer1.currentMedia.duration - musicPlayer1.Ctlcontrols.currentPosition);
                lblMusic1Timeremaing.Text = (t.ToString());
                PlayFadeSongPlayerOne();
            }
            catch { }
        }
        private void PlayFadeSongPlayerOne()
        {
            if (lblCurrentTimingPlayerOne.Text == "1")
            {
                int musicVolume;

                musicVolume = musicPlayer2.settings.volume;
                musicPlayer1.settings.volume = 25;
                musicPlayer2.settings.volume = 75;
                //musicPlayer1.settings.volume = 15;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer2.settings.volume = 0;
                //}
                //else if (musicVolume >= 40)
                //{
                //    musicPlayer2.settings.volume = 30;
                //}
                //else
                //{
                //    musicPlayer2.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblCurrentTimingPlayerOne.Text == "2")
            {
                int musicVolume;
                musicVolume = musicPlayer2.settings.volume;
                musicPlayer1.settings.volume = 50;
                musicPlayer2.settings.volume = 50;
                GetSavedRating(musicPlayer1.currentMedia.name, dgSongRatingPlayerOne);
                SetDisableRating(dgSongRatingPlayerTwo);
                //musicPlayer1.settings.volume = 25;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer2.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer2.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblCurrentTimingPlayerOne.Text == "4")
            {
                int musicVolume;
                musicVolume = musicPlayer2.settings.volume;
                musicPlayer1.settings.volume = 75;
                musicPlayer2.settings.volume = 25;

                //musicPlayer1.settings.volume = 30;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer2.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer2.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblCurrentTimingPlayerOne.Text == "6")
            {
                int musicVolume;
                musicVolume = musicPlayer2.settings.volume;
                musicPlayer1.settings.volume = 85;
                musicPlayer2.settings.volume = 25;

                //musicPlayer1.settings.volume = 35;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer2.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer2.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblCurrentTimingPlayerOne.Text == "8")
            {
                musicPlayer2.settings.volume = 0;
                musicPlayer2.Ctlcontrols.stop();
                musicPlayer2.URL = "";
                musicPlayer1.settings.volume = 100;
                IsbtnClick = "N";
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                lblMusicTimeTwo.Text = "00:00";
                lblSongDurationTwo.Text = "00:00";
                Song_Set_foucs();
            }
            else if (lblCurrentTimingPlayerOne.Text == "10")
            {
                musicPlayer2.settings.volume = 0;
                musicPlayer2.Ctlcontrols.stop();
                musicPlayer2.URL = "";
                musicPlayer1.settings.volume = 100;
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                ObjMainClass.DeleteAllOgg(musicPlayer1.currentMedia.name.ToString() + ".ogg");
            }

        }

        private void musicPlayer2_MediaChange(object sender, AxWMPLib._WMPOCXEvents_MediaChangeEvent e)
        {
            try
            {
                string mlsSql="";
                string currentFileName;
                var Special_Name = "";
                string Special_Change = "";
                currentFileName = musicPlayer2.currentMedia.name;
                mlsSql = "SELECT  Titles.Title as songname, Albums.Name as AlbumsName, Artists.Name AS ArtistsName FROM ( Albums INNER JOIN Titles ON Albums.AlbumID = Titles.AlbumID ) INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID where Titles.titleid=" + Convert.ToInt32(currentFileName);
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet_Local(mlsSql);

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["songname"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                lblSongName2.Text = Special_Change;

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["ArtistsName"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                lblArtistName2.Text = Special_Change;

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["AlbumsName"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                //lblAlbumName2.Text = Special_Change;

                TimerEventProcessorPlayerOne();
                Song_Set_foucs2();


                if (Song_Mute == true)
                {
                    musicPlayer2.settings.mute = true;
                }
                else
                {
                    musicPlayer2.settings.mute = false;
                }

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
        }

        

       
        private void timAutoFadePlayerTwo_Tick(object sender, EventArgs e)
        {
            try
            {
                //drawLine = false;
                //dgPlaylist.Invalidate();
                double t = Math.Floor(musicPlayer1.currentMedia.duration - musicPlayer1.Ctlcontrols.currentPosition);
                lblMusicTimeremaingPlayerOne.Text = (t.ToString());
                PlayAutoFadeSongPlayerTwo();
            }
            catch { }
        }

        private void PlayAutoFadeSongPlayerTwo()
        {
            
            if (lblMusicTimeremaingPlayerOne.Text == "12")
            {
                int musicVolume;
                label1.Text = "Player Two----10";
                panPlayerButton.Enabled = false;
                panComman.Enabled = false;
                panPlaylist.Enabled = false;

                PlayAutoFadingSongPlayerTwo();

                musicVolume = musicPlayer1.settings.volume;
                musicPlayer1.settings.volume = 75;
                musicPlayer2.settings.volume = 25;
                //musicPlayer2.settings.volume = 15;

                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer1.settings.volume = 0;
                //}
                //else if (musicVolume >= 40)
                //{
                //    musicPlayer1.settings.volume = 20;
                //}
                //else
                //{
                //    musicPlayer1.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblMusicTimeremaingPlayerOne.Text == "10")
            {
                int musicVolume;
                label1.Text = "Player Two----8";
                musicVolume = musicPlayer1.settings.volume;
                musicPlayer1.settings.volume = 50;
                musicPlayer2.settings.volume = 50;
                GetSavedRating(musicPlayer2.currentMedia.name, dgSongRatingPlayerTwo);
                SetDisableRating(dgSongRatingPlayerOne);
                //musicPlayer2.settings.volume = 25;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer1.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer1.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblMusicTimeremaingPlayerOne.Text == "8")
            {
                int musicVolume;
                label1.Text = "Player Two----6";
                musicVolume = musicPlayer1.settings.volume;
                musicPlayer1.settings.volume = 25;
                musicPlayer2.settings.volume = 75;
                Song_Set_foucs2();
                //musicPlayer2.settings.volume = 30;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer1.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer1.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblMusicTimeremaingPlayerOne.Text == "6")
            {
                int musicVolume;
                
                label1.Text = "Player Two----4";
                musicVolume = musicPlayer1.settings.volume;
                musicPlayer1.settings.volume = 25;
                musicPlayer2.settings.volume = 85;
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                
            }

            else if (lblMusicTimeremaingPlayerOne.Text == "4")
            {
                label1.Text = "Player Two----2";
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                musicPlayer1.settings.volume = 0;
                musicPlayer1.Ctlcontrols.stop();
                musicPlayer1.URL = "";
                musicPlayer2.settings.volume = 100;
                if (CurrentRow == dgPlaylist.Rows.Count - 1)
                {
                    NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                }
                else
                {
                    NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                }
                Song_Set_foucs2();
                ObjMainClass.DeleteAllOgg(musicPlayer2.currentMedia.name.ToString() + ".ogg");
            }
            else if (lblMusicTimeremaingPlayerOne.Text == "2")
            {
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                musicPlayer1.settings.volume = 0;
                musicPlayer1.Ctlcontrols.stop();
                musicPlayer1.URL = "";
                musicPlayer2.settings.volume = 100;
            }
        }
        private void PlayAutoFadingSongPlayerTwo()
        {
            string MusicFileName = "";
            string TempMusicFileName = "";
            string mlsSql = "";
            string FindSong = "";
            DataTable dtDetail;

            if (dgPlaylist.Rows.Count  == 0)
            {
                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                {
                    CurrentPlaylistRow = 0;
                }
                else
                {
                    CurrentPlaylistRow = CurrentPlaylistRow + 1;
                }
            GHTE:
                for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count > 0))
                    {
                        FindSong = "True";
                        CurrentPlaylistRow = i;
                        break;
                        
                    }
                    else
                    {
                        FindSong = "false";
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;
                        }
                        else
                        {
                            CurrentPlaylistRow = i;
                        }
                    }
                }
                if (FindSong == "false")
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count == 0))
                    {
                        CurrentPlaylistRow = 0;
                        goto GHTE;
                    }
                }
                dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                //dgPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;

                if (chkShuffleSong.Checked == true)
                {
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }

                CurrentRow = 0;
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer2.URL = MusicFileName;
                    musicPlayer2.settings.volume = 0;
                    timer2.Enabled = true;
                    return;
                }
            }



            if (dgPlaylist.Rows.Count -1 == 0)
            {
                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                {
                    CurrentPlaylistRow = 0;
                }
                else
                {
                    CurrentPlaylistRow = CurrentPlaylistRow + 1;
                }
            GHT:
                for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count > 0))
                    {
                        FindSong = "True";
                        CurrentPlaylistRow = i;
                        break;

                    }
                    else
                    {
                        FindSong = "false";
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;
                        }
                        else
                        {
                            CurrentPlaylistRow = i;
                        }
                    }
                }
                if (FindSong == "false")
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count == 0))
                    {
                        CurrentPlaylistRow = 0;
                        goto GHT;
                    }
                }
                dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                //dgPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;

                if (chkShuffleSong.Checked == true)
                {
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }

                CurrentRow = 0;
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer2.URL = MusicFileName;
                    musicPlayer2.settings.volume = 0;
                    timer2.Enabled = true;
                    return;
                }
            }



        gg:
            if (CurrentRow == dgPlaylist.Rows.Count - 1)
            {
                if (IsDrop_Song == false)
                {
                    if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                    {
                        CurrentPlaylistRow = 0;
                    }
                    else
                    {
                        CurrentPlaylistRow = CurrentPlaylistRow + 1;
                    }

                    for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                    {
                        mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                        dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                        if ((dtDetail.Rows.Count > 0))
                        {
                            CurrentPlaylistRow = i;
                            break;
                        }
                        else
                        {
                            if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                            {
                                CurrentPlaylistRow = 0;
                            }
                            else
                            {
                                CurrentPlaylistRow = i;
                            }
                            //return;
                        }
                    }
                    dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                    //dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                    dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;

                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                    }
                    CurrentRow = 0;
                }
                else
                {
                    IsDrop_Song = false;
                }
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer2.URL = MusicFileName;
                    musicPlayer2.settings.volume = 0;
                    timer2.Enabled = true;
                    return;
                }


            }
            //if (chkShuffleSong.Checked == true)
            //{
            //    if (CurrentRow == 0)
            //    {
            //        CurrentRow = CurrentRow + 3;
            //    }
            //    else if (CurrentRow == 1)
            //    {
            //        CurrentRow = CurrentRow + 2;
            //    }
            //    else
            //    {
            //        CurrentRow = CurrentRow - 2;
            //    }
            //}
            //else
            //{
        if (CurrentRow >= dgPlaylist.Rows.Count)
        {
            CurrentRow = 0;
        }
        else
        {
            CurrentRow = CurrentRow + 1;
        }
            //}
            if (CurrentRow == dgPlaylist.Rows.Count)
            {
                CurrentRow = dgPlaylist.Rows.Count - 1;
                goto gg;
            }
            TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
            MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
            if (System.IO.File.Exists(TempMusicFileName))
            {
                DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                musicPlayer2.URL = MusicFileName;
                musicPlayer2.settings.volume = 0;

                timer2.Enabled = true;
                return;
            }
            for (int i = Convert.ToInt16(CurrentRow); i < dgPlaylist.Rows.Count; i++)
            {
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[i].Cells[0].Value));
                    musicPlayer2.URL = MusicFileName;
                    musicPlayer2.settings.volume = 0;

                    timer2.Enabled = true;

                    //if (chkShuffleSong.Checked == true)
                    //{
                    //    CurrentRow = i + 1;
                    //}
                    //else
                    //{
                        CurrentRow = i;
                    //}

                    timer2.Enabled = true;
                    return;
                }

            }
        }


        private void timAutoFadePlayerOne_Tick(object sender, EventArgs e)
        {

            try
            {
                //drawLine = false;
                //dgPlaylist.Invalidate();
                double t = Math.Floor(musicPlayer2.currentMedia.duration - musicPlayer2.Ctlcontrols.currentPosition);
                lblMusicTimeremaingPlayerTwo.Text = (t.ToString());
                PlayAutoFadeSongPlayerOne();
            }
            catch { }
        }

        private void PlayAutoFadeSongPlayerOne()
        {
           
            if (lblMusicTimeremaingPlayerTwo.Text == "12")
            {
                int musicVolume;
                label6.Text = "Player One----10";
                panPlayerButton.Enabled = false;
                panComman.Enabled = false;
                panPlaylist.Enabled = false;

                PlayAutoFadingSongPlayerOne();

                musicVolume = musicPlayer2.settings.volume;
                musicPlayer2.settings.volume = 25;
                musicPlayer1.settings.volume = 75;
                //musicPlayer1.settings.volume = 15;

                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer2.settings.volume = 0;
                //}
                //else if (musicVolume >= 40)
                //{
                //    musicPlayer2.settings.volume = 20;
                //}
                //else
                //{
                //    musicPlayer2.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblMusicTimeremaingPlayerTwo.Text == "10")
            {
                int musicVolume;
                label6.Text = "Player One----8";
                musicVolume = musicPlayer2.settings.volume;
                musicPlayer2.settings.volume = 50;
                musicPlayer1.settings.volume = 50;
                GetSavedRating(musicPlayer1.currentMedia.name, dgSongRatingPlayerOne);
                SetDisableRating(dgSongRatingPlayerTwo);
                //musicPlayer1.settings.volume = 25;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer2.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer2.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblMusicTimeremaingPlayerTwo.Text == "8")
            {
                int musicVolume;
                label6.Text = "Player One----6";
                musicVolume = musicPlayer2.settings.volume;
                musicPlayer2.settings.volume = 25;
                musicPlayer1.settings.volume = 75;
                Song_Set_foucs();
                //musicPlayer1.settings.volume = 30;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer2.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer2.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblMusicTimeremaingPlayerTwo.Text == "6")
            {
                int musicVolume;
                label6.Text = "Player One----4";
                musicVolume = musicPlayer2.settings.volume;
                musicPlayer2.settings.volume = 25;
                musicPlayer1.settings.volume = 85;
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                
                //musicPlayer1.settings.volume = 35;
                //panPlayerButton.Enabled = true;
                //panComman.Enabled = true;
                //panPlaylist.Enabled = true;
                //if ((musicVolume - 5) < 0)
                //{
                //    musicPlayer2.settings.volume = 0;
                //}
                //else
                //{
                //    musicPlayer2.settings.volume = musicVolume - 5;
                //}
            }

            else if (lblMusicTimeremaingPlayerTwo.Text == "4")
            {
                label6.Text = "Player One----2";
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                musicPlayer2.settings.volume = 0;
                musicPlayer2.Ctlcontrols.stop();
                musicPlayer2.URL = "";
                musicPlayer1.settings.volume = 100;
                if (CurrentRow == dgPlaylist.Rows.Count - 1)
                {
                    NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                }
                else
                {
                    NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                }
                Song_Set_foucs();
                ObjMainClass.DeleteAllOgg(musicPlayer1.currentMedia.name.ToString() + ".ogg");
            }
            else if (lblMusicTimeremaingPlayerTwo.Text == "2")
            {
                panPlayerButton.Enabled = true;
                panComman.Enabled = true;
                panPlaylist.Enabled = true;
                musicPlayer2.settings.volume = 0;
                musicPlayer2.Ctlcontrols.stop();
                musicPlayer2.URL = "";
                musicPlayer1.settings.volume = 100;
                ObjMainClass.DeleteAllOgg(musicPlayer1.currentMedia.name.ToString() + ".ogg");
            }
             
        }
        private void PlayAutoFadingSongPlayerOne()
        {
            string MusicFileName = "";
            string TempMusicFileName = "";
            string mlsSql = "";
            string FindSong = "";
            DataTable dtDetail;
            if (dgPlaylist.Rows.Count  == 0)
            {
                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                {
                    CurrentPlaylistRow = 0;
                    
                }
                else
                {
                    CurrentPlaylistRow = CurrentPlaylistRow + 1;
                }
            GHTE:
                for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count > 0))
                    {
                        FindSong = "True";
                        CurrentPlaylistRow = i;
                        break;
                    }
                    else
                    {
                        FindSong = "false";
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;
                        }
                        else
                        {
                            CurrentPlaylistRow = i;
                        }
                    }
                }
            if (FindSong == "false")
            {
                mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                if ((dtDetail.Rows.Count == 0))
                {
                    CurrentPlaylistRow = 0;
                    goto GHTE;
                }
            }
                dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                //dgPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;
                if (chkShuffleSong.Checked == true)
                {
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }
                CurrentRow = 0;
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer1.URL = MusicFileName;
                    musicPlayer1.settings.volume = 0;
                    timer1.Enabled = true;
                    return;
                }
            }



            if (dgPlaylist.Rows.Count -1 == 0)
            {
                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                {
                    CurrentPlaylistRow = 0;

                }
                else
                {
                    CurrentPlaylistRow = CurrentPlaylistRow + 1;
                }
            GHT:
                for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count > 0))
                    {
                        FindSong = "True";
                        CurrentPlaylistRow = i;
                        break;
                    }
                    else
                    {
                        FindSong = "false";
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;
                        }
                        else
                        {
                            CurrentPlaylistRow = i;
                        }
                    }
                }
                if (FindSong == "false")
                {
                    mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                    dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                    if ((dtDetail.Rows.Count == 0))
                    {
                        CurrentPlaylistRow = 0;
                        goto GHT;
                    }
                }
                dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                //dgPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;
                if (chkShuffleSong.Checked == true)
                {
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }
                CurrentRow = 0;
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer1.URL = MusicFileName;
                    musicPlayer1.settings.volume = 0;
                    timer1.Enabled = true;
                    return;
                }
            }




        gg:
            if (CurrentRow == dgPlaylist.Rows.Count - 1)
            {
                if (IsDrop_Song == false)
                {
                    if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                    {
                        CurrentPlaylistRow = 0;
                    }
                    else
                    {
                        CurrentPlaylistRow = CurrentPlaylistRow + 1;
                    }

                    for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                    {
                        mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                        dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                        if ((dtDetail.Rows.Count > 0))
                        {
                            CurrentPlaylistRow = i;
                            break;
                        }
                        else
                        {
                            if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                            {
                                CurrentPlaylistRow = 0;
                            }
                            else
                            {
                                CurrentPlaylistRow = i;
                            }
                        }
                    }

                    dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                    //dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = false;
                    dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;

                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[0].Value));
                    }
                    CurrentRow = 0;
                }
                else
                {
                    IsDrop_Song = false;
                }
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                    musicPlayer1.URL = MusicFileName;
                    musicPlayer1.settings.volume = 0;
                    timer1.Enabled = true;
                    return;
                }


            }
            //if (chkShuffleSong.Checked == true)
            //{
            //    CurrentRow = CurrentRow + 1;
            //}
            //else
            //{
        if (CurrentRow >= dgPlaylist.Rows.Count)
        {
            CurrentRow = 0;
        }
        else
        {
            CurrentRow = CurrentRow + 1;
        }
            //}
            if (CurrentRow == dgPlaylist.Rows.Count)
            {
                CurrentRow = dgPlaylist.Rows.Count - 1;
                goto gg;
            }

            TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".sec";
            MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
            if (System.IO.File.Exists(TempMusicFileName))
            {
                DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value));
                musicPlayer1.URL = MusicFileName;
                musicPlayer1.settings.volume = 0;
                timer1.Enabled = true;
                return;
            }
            for (int i = Convert.ToInt16(CurrentRow); i < dgPlaylist.Rows.Count; i++)
            {
                TempMusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".sec";
                MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[i].Cells[0].Value + ".ogg";
                if (System.IO.File.Exists(TempMusicFileName))
                {
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[i].Cells[0].Value));
                    musicPlayer1.URL = MusicFileName;
                    musicPlayer1.settings.volume = 0;

                    timer1.Enabled = true;

                    //if (chkShuffleSong.Checked == true)
                    //{
                    //    CurrentRow = i + 1;
                    //}
                    //else
                    //{
                        CurrentRow = i;
                    //}

                    timer1.Enabled = true;
                    return;
                }

            }
        }
        private void NextSongDisplay(string NextSongId)
        {
            try
            {
                string mlsSql="";
                var Special_Name = "";
                string Special_Change = "";

                mlsSql = "SELECT  Titles.Title as songname, Albums.Name as AlbumsName, Artists.Name AS ArtistsName FROM (Albums INNER JOIN Titles ON Albums.AlbumID = Titles.AlbumID) INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID where Titles.titleid=" + Convert.ToInt32(NextSongId);
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet_Local(mlsSql);

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["songname"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                lblSongName2.Text = Special_Change;

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["ArtistsName"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                lblArtistName2.Text = Special_Change;

                Special_Name = "";
                Special_Change = "";
                Special_Name = ds.Tables[0].Rows[0]["AlbumsName"].ToString();
                Special_Change = Special_Name.Replace("??$$$??", "'");
                //lblAlbumName2.Text = Special_Change;
                UpcomingSongPlayerOne = "";
                UpcomingSongPlayerTwo = NextSongId;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }
        
        private void panWmp2_DragDrop(object sender, DragEventArgs e)
        {
            string file;
            string LocalFileName;
            string TempLocalFileName;
            Boolean SongFind;
            SongFind = false;
            Grid_Clear = false;
             file = (string)e.Data.GetData(DataFormats.Text);
             Drop_Song = false;
            LocalFileName = Application.StartupPath + "\\" + file + ".ogg";
            TempLocalFileName = Application.StartupPath + "\\" + file + ".sec";
            if (dgLocalPlaylist.Rows.Count == 0 && dgPlaylist.Rows.Count == 0)
            {
                SaveDefaultPlaylist(file);
                PlaySongDefault();
                btnPlay.Text = "";
                return;
            }
            else if (dgLocalPlaylist.Rows.Count != 0 && dgPlaylist.Rows.Count == 0)
            {
                insert_Playlist_song(file,"Yes");
                PlaySongDefault();
                btnPlay.Text = "";
                return;
            }
            for (int i = 0; i < dgPlaylist.Rows.Count; i++)
            {
                if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == file)
                {
                    SongFind = true;
                }
            }
            if (SongFind == false)
            {
                if (ObjMainClass.CheckForInternetConnection() == false)
                {
                    MessageBox.Show("Check your internet connection", "Eu4y music player");
                    return;
                }
                if (System.IO.File.Exists(TempLocalFileName))
                {
                    IsDrop_Song = true;
                    insert_Playlist_song(file,"Yes");
                    DeleteHideSongs();
                    InsertHideSong(file);
                    RowHide();
                    DownloadSong();
                    if (musicPlayer1.URL != "")
                    {
                        Set_foucs_PayerOne();
                    }
                    else if (musicPlayer2.URL != "")
                    {
                        Set_foucs_PayerTwo();
                    }
                }
                else
                {
                    string sQr = "";
                    sQr = "select COUNT(dfclientid) as TotalDownload from UserDownloadTitle where DfClientId=" + StaticClass.UserId + " and TokenId= " + StaticClass.TokenId;
                    DataSet dsTitle = new DataSet();
                    dsTitle = ObjMainClass.fnFillDataSet(sQr);
                    if (StaticClass.TotalTitles == dsTitle.Tables[0].Rows[0]["TotalDownload"].ToString())
                    {
                        MessageBox.Show("Your songs downloading limit is over." + Environment.NewLine + "Please contact vendor to resume the service.", "Eu4y Music Player");
                        return;
                    }
                    IsDrop_Song = true;
                    Add_Playlist = true;
                    Drop_Song = true;
                    FirstTimeSong = false;
                    insert_temp_data(file);
                    multi_song_download();
                    return;
                }

            }

            if (musicPlayer2.URL == "")
            {
                NextSongDisplay(file);
                Song_Set_foucs3(file);
                return;

            }
            else if (musicPlayer1.URL == "")
            {
                NextSongDisplay2(file);
                Song_Set_foucs3(file);
                return;

            }
        }
        private void Song_Set_foucs3(string fileName)
        {
            for (int i = 0; i < dgPlaylist.Rows.Count; i++)
            {
                if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == fileName)
                {
                    CurrentRow = i-1 ;
                    return;
                }
            }
        }

        private void panWmp2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void SaveDefaultPlaylist(string DefaultSongId)
        {
            string lStr = "";
            lStr = "select * from PlayLists where Name='Default' and userid=" + StaticClass.UserId;
            DataSet ds = new DataSet();
            ds = ObjMainClass.fnFillDataSet(lStr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DefaultPlaylistSave("Def_ault");
                FillLocalPlaylist();
               // MessageBox.Show("Playlist name already exits", "Eu4y Music Player");
                return;
            }
            else if (StaticClass.Is_Admin != "1")
            {
                MessageBox.Show(ObjMainClass.MainMessage, "Eu4y Music Player");
                return;
            }
            DefaultPlaylistSave("Default");

            FillLocalPlaylist();
            
        }

        private void DefaultPlaylistSave(string PlaylistName)
        {
            Int32 Playlist_Id = 0;
            StaticClass.constr.Open();
            SqlCommand cmd = new SqlCommand("InsertPlayLists", StaticClass.constr);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@UserID", SqlDbType.BigInt));
            cmd.Parameters["@UserID"].Value = StaticClass.UserId;

            cmd.Parameters.Add(new SqlParameter("@IsPredefined", SqlDbType.Bit));
            cmd.Parameters["@IsPredefined"].Value = 0;

            cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 50));
            cmd.Parameters["@Name"].Value = PlaylistName;

            cmd.Parameters.Add(new SqlParameter("@Summary", SqlDbType.VarChar, 50));
            cmd.Parameters["@Summary"].Value = " ";

            cmd.Parameters.Add(new SqlParameter("@Description", SqlDbType.VarChar, 50));
            cmd.Parameters["@Description"].Value = " ";

            try
            {
                Playlist_Id = Convert.ToInt32(cmd.ExecuteScalar());
                string sQr = "";
                if (StaticClass.LocalCon.State == ConnectionState.Open) StaticClass.LocalCon.Close();
                sQr = "insert into PlayLists values(" + Playlist_Id + ", ";
                sQr = sQr + StaticClass.UserId + " , '" + PlaylistName + "', " + StaticClass.TokenId + " )";
                StaticClass.LocalCon.Open();
                OleDbCommand cmdSaveLocal = new OleDbCommand();
                cmdSaveLocal.Connection = StaticClass.LocalCon;
                cmdSaveLocal.CommandText = sQr;
                cmdSaveLocal.ExecuteNonQuery();
                StaticClass.LocalCon.Close();

                // MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                // throw new ApplicationException ("Data error.");
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                StaticClass.constr.Close();
            }
        }
        
        private void panWmp1_DragDrop(object sender, DragEventArgs e)
        {
            string file;
            string LocalFileName;
            string TempLocalFileName;
            Boolean SongFind ;
            SongFind = false;
            Grid_Clear = false;
            file = (string)e.Data.GetData(DataFormats.Text);
            Drop_Song = false;

            LocalFileName = Application.StartupPath + "\\" + file + ".ogg";
            TempLocalFileName = Application.StartupPath + "\\" + file + ".sec";
            if (dgLocalPlaylist.Rows.Count == 0 && dgPlaylist.Rows.Count == 0)
            {
                SaveDefaultPlaylist(file);
                PlaySongDefault();
                btnPlay.Text = "";
                return;
            }
            else if (dgLocalPlaylist.Rows.Count != 0 && dgPlaylist.Rows.Count == 0)
            {
                insert_Playlist_song(file,"Yes");
                PlaySongDefault();
                btnPlay.Text = "";
                return;
            }

            for (int i = 0; i < dgPlaylist.Rows.Count; i++)
            {
                if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == file)
                {
                    SongFind = true;
                }
            }
            if (SongFind == false)
            {
                if (ObjMainClass.CheckForInternetConnection() == false)
                {
                    MessageBox.Show("Check your internet connection", "Eu4y music player");
                    return;
                }
                if (System.IO.File.Exists(TempLocalFileName))
                {
                    IsDrop_Song = true;
                    insert_Playlist_song(file,"Yes");
                    DeleteHideSongs();
                    InsertHideSong(file);
                    RowHide();
                    DownloadSong();
                    if (musicPlayer1.URL != "")
                    {
                        Set_foucs_PayerOne();
                    }
                    else if (musicPlayer2.URL != "")
                    {
                        Set_foucs_PayerTwo();
                    }
                }
                else
                {
                    string sQr = "";
                    sQr = "select COUNT(dfclientid) as TotalDownload from UserDownloadTitle where DfClientId=" + StaticClass.UserId + " and TokenId= " + StaticClass.TokenId;
                    DataSet dsTitle = new DataSet();
                    dsTitle = ObjMainClass.fnFillDataSet(sQr);
                    if (StaticClass.TotalTitles == dsTitle.Tables[0].Rows[0]["TotalDownload"].ToString())
                    {
                        MessageBox.Show("Your songs downloading limit is over." + Environment.NewLine + "Please contact vendor to resume the service.", "Eu4y Music Player");
                        return;
                    }

                    Add_Playlist = true;
                    Drop_Song = true;
                    IsDrop_Song = true;
                    FirstTimeSong = false;
                    insert_temp_data(file);
                    multi_song_download();
                    return;
                }
                
            }
            if (musicPlayer2.URL == "")
            {

                NextSongDisplay(file);
                Song_Set_foucs3(file);
                return;

            }
            else if (musicPlayer1.URL == "")
            {
                NextSongDisplay2(file);
                 Song_Set_foucs3(file);
                return;

            }

        }

        private void panWmp1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        
        private void timMusicTimeOne_Tick(object sender, EventArgs e)
        {
            try
            {

                double t1 = Math.Floor(musicPlayer1.currentMedia.duration - musicPlayer1.Ctlcontrols.currentPosition);
                double w1 = Math.Floor(musicPlayer1.Ctlcontrols.currentPosition);
                double mint1 = Math.Floor(t1 / 60);
                double s1;
                int r1;
                s1 = Convert.ToInt16(Math.Abs(t1 / 60));
                r1 = Convert.ToInt16(t1 % 60);
                //--------------------------------------------//
                //--------------------------------------------//

                double fd;
                fd = Math.Floor(musicPlayer1.currentMedia.duration);
                double zh;
                zh = fd / 60;
                double left = System.Math.Floor(zh);
                double sec2 = fd % 60;
                //--------------------------------------------//
                //--------------------------------------------//

                if (musicPlayer1.status == "Ready")
                {
                    lblMusicTimeOne.Text = "00:00";
                    lblSongDurationOne.Text = "00:00";
                }
                else
                {
                     lblMusicTimeOne.Text= mint1.ToString("00") + ":" + r1.ToString("00");
                     lblSongDurationOne.Text = left.ToString("00") + ":" + sec2.ToString("00");
                }
                double w = Math.Floor(musicPlayer1.Ctlcontrols.currentPosition);
                pbarMusic1.Maximum = Convert.ToInt16(musicPlayer1.currentMedia.duration);
                pbarMusic1.Value = Convert.ToInt16(w);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void timMusicTimeTwo_Tick(object sender, EventArgs e)
        {
            try
            {
                double t1 = Math.Floor(musicPlayer2.currentMedia.duration - musicPlayer2.Ctlcontrols.currentPosition);
                double w1 = Math.Floor(musicPlayer2.Ctlcontrols.currentPosition);
                double mint1 = Math.Floor(t1 / 60);
                double s1;
                int r1;
                s1 = Convert.ToInt16(Math.Abs(t1 / 60));
                r1 = Convert.ToInt16(t1 % 60);
                //--------------------------------------------//
                //--------------------------------------------//

                double fd;
                fd = Math.Floor(musicPlayer2.currentMedia.duration);
                double zh;
                zh = fd / 60;
                double left = System.Math.Floor(zh);
                double sec2 = fd % 60;
                //--------------------------------------------//
                //--------------------------------------------//

                if (musicPlayer2.status == "Ready")
                {
                    lblMusicTimeTwo.Text = "00:00";
                    lblSongDurationTwo.Text = "00:00";
                }
                else
                {
                    lblMusicTimeTwo.Text = mint1.ToString("00") + ":" + r1.ToString("00");
                    lblSongDurationTwo.Text = left.ToString("00") + ":" + sec2.ToString("00");
                }
                double w = Math.Floor(musicPlayer2.Ctlcontrols.currentPosition);
                pbarMusic2.Maximum = Convert.ToInt16(musicPlayer2.currentMedia.duration);
                pbarMusic2.Value = Convert.ToInt16(w);
            }
            catch
            {
            }
        }

        private void dgCommanGrid_SelectionChanged(object sender, EventArgs e)
        {
            //dgCommanGrid.ReadOnly = false;
            dgCommanGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dgCommanGrid.MultiSelect = true ;
        }

        private void dgLocalPlaylist_SelectionChanged(object sender, EventArgs e)
        {
            dgLocalPlaylist.ReadOnly = true;
            dgLocalPlaylist.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgLocalPlaylist.MultiSelect = false;
        }

        private void chkShuffleSong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgPlaylist.CurrentCell.RowIndex == -1) return;
                
                if (chkShuffleSong.Checked == true)
                {
                    chkShuffleSong.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.shuffle_blue));
                    
                    if (ShuffleCount == 4)
                    {
                        TotShuffle = 0;
                        ShuffleCount = 0;
                    }
                    if (ShuffleCount == 0)
                    {
                        TotShuffle = TotShuffle + 1;
                        ShuffleCount = Convert.ToInt16(TotShuffle);
                    }
                    else
                    {
                        TotShuffle = TotShuffle + 1;
                        ShuffleCount = Convert.ToInt16(TotShuffle);
                    }
//                    ShuffleNo = ShuffleCount;
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);

                    if (musicPlayer1.URL != "")
                    {
                        Get_Current_Song(musicPlayer1.currentMedia.name);
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                    }
                    if (musicPlayer2.URL != "")
                    {
                        Get_Current_Song(musicPlayer2.currentMedia.name);
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                    }
                }
                else
                {
                    chkShuffleSong.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.shuffle_blue));
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);

                    if (musicPlayer1.URL != "")
                    {
                        Get_Current_Song(musicPlayer1.currentMedia.name);
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                    }
                    if (musicPlayer2.URL != "")
                    {
                        Get_Current_Song(musicPlayer2.currentMedia.name);
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                    }
                }
            }
            catch { }
        }


        private void Get_Current_Song(string fileName)
        {
            for (int i = 0; i < dgPlaylist.Rows.Count; i++)
            {
                if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == fileName)
                {
                    CurrentRow = i  ;
                    return;
                }
            }
        }
        private void PopulateShuffleSong(Int32 currentPlayRow, Int16 ShuffleNo)
        {
            try
            {
                string mlsSql = "";
                string GetLocalPath = "";
                string TitleYear = "";
                string TitleTime = "";
                var Special_Name = "";
                string Special_Change = "";
                Int32 iCtr=0;
                Int32 srNo=0;
                DataTable dtDetail;
                mlsSql = "SELECT  Titles.TitleID, ltrim(Titles.Title) as Title, Titles.Time,Albums.Name AS AlbumName ,";
                mlsSql = mlsSql + " ISNULL(Titles.TitleYear,0) as TitleYear ,  ltrim(Artists.Name) as ArtistName  FROM ((( TitlesInPlaylists  ";
                mlsSql = mlsSql + " INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID )  ";
                mlsSql = mlsSql + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID ) ";
                mlsSql = mlsSql + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID ) ";
                mlsSql = mlsSql + " where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(currentPlayRow) + " order by NEWID()";

                if (ObjMainClass.CheckForInternetConnection() == true)
                {
                    dtDetail = ObjMainClass.fnFillDataTable(mlsSql);
                    InitilizeGrid();
                    if ((dtDetail.Rows.Count > 0))
                    {
                        for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                        {
                            GetLocalPath = dtDetail.Rows[iCtr]["TitleID"] + ".ogg";
                            srNo = iCtr;
                            dgPlaylist.Rows.Add();
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["TitleID"];

                            Special_Name = "";
                            Special_Change = "";
                            Special_Name = dtDetail.Rows[iCtr]["Title"].ToString();
                            Special_Change = Special_Name.Replace("??$$$??", "'");
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[1].Value = Special_Change;
                            
                            string str = dtDetail.Rows[iCtr]["Time"].ToString();
                            string[] arr = str.Split(':');
                            TitleTime = arr[1] + ":" + arr[2];

                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[2].Value = TitleTime;

                            Special_Name = "";
                            Special_Change = "";
                            Special_Name = dtDetail.Rows[iCtr]["AlbumName"].ToString();
                            Special_Change = Special_Name.Replace("??$$$??", "'");
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[3].Value = Special_Change;

                            TitleYear = dtDetail.Rows[iCtr]["TitleYear"].ToString();
                            if (TitleYear == "0")
                            {
                                dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[4].Value = "- - -";
                            }
                            else
                            {
                                dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[4].Value = dtDetail.Rows[iCtr]["TitleYear"];
                            }

                            Special_Name = "";
                            Special_Change = "";
                            Special_Name = dtDetail.Rows[iCtr]["ArtistName"].ToString();
                            Special_Change = Special_Name.Replace("??$$$??", "'");
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[5].Value = Special_Change;

                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[1].Style.Font = new Font("Segoe UI", 12, System.Drawing.FontStyle.Regular);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[2].Style.Font = new Font("Segoe UI", 10);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[3].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Italic);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[4].Style.Font = new Font("Segoe UI", 10);
                            dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[5].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Italic);

                        }
                    }
                    foreach (DataGridViewRow row in dgPlaylist.Rows)
                    {
                        row.Height = 30;
                    }
                    RowHide();
                }
                else
                {
                    MessageBox.Show("Check your internet connection","Eu4y Music Player");
                    chkShuffleSong.Checked = false;
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }
               
            }
            catch
            {
               
            }
        }
        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (musicPlayer1.URL != "")
            {
                if (btnPlay.Text == ".")
                {
                    btnPlay.Text = "";
                    musicPlayer1.Ctlcontrols.play();
                    musicPlayer1.settings.volume = 100;
                    btnPlay.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pause_Blue));
                }
                else if (btnPlay.Text == "")
                {
                    btnPlay.Text = ".";
                    musicPlayer1.Ctlcontrols.pause();
                    btnPlay.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Play_Blue));
                }
            }
            else if (musicPlayer2.URL != "")
            {
                if (btnPlay.Text == ".")
                {
                    btnPlay.Text = "";
                    musicPlayer2.Ctlcontrols.play();
                    musicPlayer2.settings.volume = 100;
                    btnPlay.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pause_Blue));
                }
                else if (btnPlay.Text == "")
                {
                    btnPlay.Text = ".";
                    musicPlayer2.Ctlcontrols.pause();
                    btnPlay.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Play_Blue));
                }
            }

        }

        private void btnMute_Click(object sender, EventArgs e)
        {
            if (musicPlayer1.URL != "")
            {
                if (btnMute.Text == "")
                {
                    btnMute.Text = ".";
                    musicPlayer1.settings.mute = true;
                    Song_Mute = true;
                    btnMute.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Mute_red));
                }
                else if (btnMute.Text == ".")
                {
                    btnMute.Text = "";
                    musicPlayer1.settings.mute = false;
                    Song_Mute = false;
                    btnMute.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Mute_blue));
                }
            }
            else if (musicPlayer2.URL != "")
            {
                if (btnMute.Text == "")
                {
                    btnMute.Text = ".";
                    musicPlayer2.settings.mute = true;
                    Song_Mute = true;
                    btnMute.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Mute_red));
                }
                else if (btnMute.Text == ".")
                {
                    btnMute.Text = "";
                    musicPlayer2.settings.mute = false;
                    Song_Mute = false;
                    btnMute.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Mute_blue));
                }
            }
        }
        private void btnShop_Click(object sender, EventArgs e)
        {
            musicPlayer1.Ctlcontrols.stop();
            musicPlayer2.Ctlcontrols.stop();
            btnPlay.Text = "Play";
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Int32 CurrrentPos;
            if (musicPlayer1.URL != "")
            {
                CurrrentPos = Convert.ToInt32(musicPlayer1.Ctlcontrols.currentPosition);
                musicPlayer1.Ctlcontrols.currentPosition = CurrrentPos + 5;
            }
            if (musicPlayer2.URL != "")
            {
                CurrrentPos = Convert.ToInt32(musicPlayer2.Ctlcontrols.currentPosition);
                musicPlayer2.Ctlcontrols.currentPosition = CurrrentPos + 5;
            }

        }

       
        private void txtPlaylistName_KeyDown(object sender, KeyEventArgs e)
        {
           
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (ObjMainClass.CheckForInternetConnection() == false)
                    {
                        MessageBox.Show("Check your internet connection", "Eu4y music player");
                        return;
                    }
                    string lStr = "";
                    lStr = "select * from PlayLists where Name='" + txtPlaylistName.Text + "' and userid=" + StaticClass.UserId + " and tokenid=" + StaticClass.TokenId;
                    DataSet ds = new DataSet();
                    ds = ObjMainClass.fnFillDataSet(lStr);

                    if (txtPlaylistName.Text == "")
                    {
                        MessageBox.Show("Playlist cannot be blank", "Eu4y Music Player");
                        return;
                    }
                    else if (pAction == "New") 
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            MessageBox.Show("Playlist name already exits", "Eu4y Music Player");
                            return;
                        }
                    }
                    else if (StaticClass.Is_Admin != "1")
                    {
                        MessageBox.Show(ObjMainClass.MainMessage, "Eu4y Music Player");
                        return;
                    }
                    if (pAction == "New")
                    {
                        PlaylistSave();
                        txtPlaylistName.Text = "";
                        pAction = "New";
                        ModifyPlaylistId = 0;
                    }
                    else
                    {
                        PlaylistModify();
                        txtPlaylistName.Text = "";
                        pAction = "New";
                        ModifyPlaylistId = 0;
                    }
                    FillLocalPlaylist();
                }
               
            }
            catch
            {
               // MessageBox.Show("Check your internet connection","Eu4y Music Player");
            }

        }

        private void dgPlaylist_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
            
        }

        private void dgPlaylist_DragDrop(object sender, DragEventArgs e)
        {
            string SongName;
            string TempSongName;
            string lStr;
            string file;
            int Index;
            try
            {
                drawLine = false;
                dgPlaylist.Invalidate();
                Grid_Clear = false;
                if (dgPlaylist.Rows.Count >= 300)
                {
                    MessageBox.Show("Playlist is full. Create new playlist", "Eu4y Music Player");
                    return;
                }

                file = (string)e.Data.GetData(DataFormats.Text);
                TempSongName = Application.StartupPath + "\\" + file + ".sec";
                SongName = Application.StartupPath + "\\" + file + ".ogg";
                lStr = "select * from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID=" + file;
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet_Local(lStr);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (Show_Record == true)
                    {
                        DeleteHideSong(file);
                        if (chkShuffleSong.Checked == true)
                        {
                            PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                        }
                        else
                        {
                            PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                        }
                    }
                }
                else
                {
                    if (ObjMainClass.CheckForInternetConnection() == false)
                    {
                        MessageBox.Show("Check your internet connection", "Eu4y music player");
                        return;
                    }
                    if (System.IO.File.Exists(TempSongName))
                    {
                        if (dgPlaylist.Rows.Count == 300)
                        {
                            MessageBox.Show("Playlist is full. Create new playlist", "Eu4y Music Player");
                            return;
                        }
                        else
                        {

                            insert_Playlist_song(file,"No");
                            Point clientPoint = dgPlaylist.PointToClient(new Point(e.X, e.Y));
                            Index = dgPlaylist.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
                            if (dgPlaylist.Rows.Count == 0 || dgPlaylist.Rows.Count == 1)
                            {
                                dgPlaylist.Rows.Add();
                                Index = 0;
                                ResetPlaylist(Index, file);
                                if (chkShuffleSong.Checked == true)
                                {
                                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                                }
                                else
                                {
                                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                                }
                                DownloadSong();
                                return;

                            }
                            else if (Index == -1)
                            {
                                Index = 1;
                                ResetPlaylist(Index, file);
                                DownloadSong();
                                return;
                            }
                            else if (Index != -1)
                            {
                                ResetPlaylist(Index, file);
                                
                            }
                            DownloadSong();
                            if (musicPlayer1.URL != "")
                            {
                                Song_Set_foucs();
                            }
                            else if (musicPlayer2.URL != "")
                            {
                                Song_Set_foucs2();
                            } 
                        }

                    }
                    else
                    {
                        string sQr = "";
                        sQr = "select COUNT(dfclientid) as TotalDownload from UserDownloadTitle where DfClientId=" + StaticClass.UserId + " and TokenId= " + StaticClass.TokenId;
                        DataSet dsTitle = new DataSet();
                        dsTitle = ObjMainClass.fnFillDataSet(sQr);
                        if (StaticClass.TotalTitles == dsTitle.Tables[0].Rows[0]["TotalDownload"].ToString())
                        {
                            MessageBox.Show("Your songs downloading limit is over." + Environment.NewLine + "Please contact vendor to resume the service.", "Eu4y Music Player");
                            return;
                        }
                        eX = e.X;
                        eY = e.Y;
                        DropTitleSong = "Yes";
                        Add_Playlist = true;
                        FirstTimeSong = false;
                        insert_temp_data(file);
                        multi_song_download();
                    }
                }
                Show_Record = false;

                Is_Drop = false;
            }
            catch { }
        }
        private void ResetPlaylist(int RowIndex, string New_Song_Id)
        {
            string mlsSql = "";
            string TitleYear = "";
            string TitleTime = "";
            Int32 iCtr = 0;
            Int32 srNo = 0;
            string Title_id = "";
            string sr_No = "";
            string Title = "";
            string AlbumName = "";
            string Title_Year = "";
            string ArtistName = "";
            var Special_Name = "";
            string Special_Change = "";
            DataTable dtDetail = new DataTable();
            mlsSql = "SELECT distinct  Titles.TitleID, Titles.Title, Titles.Time,Albums.Name AS AlbumName ,";
            mlsSql = mlsSql + " Titles.TitleYear ,  Artists.Name as ArtistName  FROM ((( TitlesInPlaylists  ";
            mlsSql = mlsSql + " INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID )  ";
            mlsSql = mlsSql + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID ) ";
            mlsSql = mlsSql + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID ) ";
            mlsSql = mlsSql + " where Titles.TitleID=" + New_Song_Id;
            dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
            if ((dtDetail.Rows.Count > 0))
            {
                srNo = iCtr;
                Title_id = dtDetail.Rows[iCtr]["TitleID"].ToString();
                sr_No = srNo + 1 + ".";

                Special_Name = "";
                Special_Change = "";
                Special_Name = dtDetail.Rows[iCtr]["Title"].ToString(); 
                Special_Change = Special_Name.Replace("??$$$??", "'");
                Title = Special_Change;

                string str = dtDetail.Rows[iCtr]["Time"].ToString();
                string[] arr = str.Split(':');
                TitleTime = arr[1] + ":" + arr[2];
                AlbumName = dtDetail.Rows[iCtr]["AlbumName"].ToString();
                TitleYear = dtDetail.Rows[iCtr]["TitleYear"].ToString();
                if (TitleYear == "0")
                {
                    Title_Year = "- - -";
                }
                else
                {
                    Title_Year = dtDetail.Rows[iCtr]["TitleYear"].ToString();
                }

                ArtistName = dtDetail.Rows[iCtr]["ArtistName"].ToString();
                ArtistName = ArtistName.Replace("??$$$??", "'");
                var addedRow = dgPlaylist.Rows[RowIndex];
                dgPlaylist.Rows.Insert(RowIndex, Title_id, Title, TitleTime, AlbumName, Title_Year, ArtistName);

            }
            for (iCtr = 0; iCtr < dgPlaylist.Rows.Count; iCtr++)
            {
                dgPlaylist.Rows[iCtr].Cells[1].Style.Font = new Font("Segoe UI", 12, System.Drawing.FontStyle.Regular);
                dgPlaylist.Rows[iCtr].Cells[2].Style.Font = new Font("Segoe UI", 10);
                dgPlaylist.Rows[iCtr].Cells[3].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Italic);
                dgPlaylist.Rows[iCtr].Cells[4].Style.Font = new Font("Segoe UI", 10);
                dgPlaylist.Rows[iCtr].Cells[5].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Italic);
            }

            foreach (DataGridViewRow row in dgPlaylist.Rows)
            {
                row.Height = 30;
            }

        }

        private void dgCommanGrid_CellClick(object sender, DataGridViewCellEventArgs e) 
        {
            string SongName = "";
            string sQr = "";
            try
            {
                if (e.ColumnIndex == 5 && e.RowIndex == -1)
                {
                    return;
                }
                 
                if (e.ColumnIndex == 5)
                {
                    if (ObjMainClass.CheckForInternetConnection() == false)
                    {
                        MessageBox.Show("Check your internet connection", "Eu4y music player");
                        return;
                    }
                    Add_Playlist = false;
                    FirstTimeSong = false;
                    panPlayerButton.Enabled = true;

                    SongName = Application.StartupPath + "\\" + dgCommanGrid.Rows[e.RowIndex].Cells[0].Value + ".ogg";
                    if (System.IO.File.Exists(SongName))
                    {
                        return;
                    }
                    sQr = "select COUNT(dfclientid) as TotalDownload from UserDownloadTitle where DfClientId=" + StaticClass.UserId + " and TokenId= " + StaticClass.TokenId ;
                    DataSet ds = new DataSet();
                    ds = ObjMainClass.fnFillDataSet(sQr);
                    if (StaticClass.TotalTitles==ds.Tables[0].Rows[0]["TotalDownload"].ToString())
                    {
                        MessageBox.Show("Your songs downloading limit is over." + Environment.NewLine + "Please contact vendor to resume the service.","Eu4y Music Player");
                        return;
                    }

                    insert_temp_data(dgCommanGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    multi_song_download();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }

        }

        private void dgCommanGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //string SongName;
            //string lStr;
            //string file;
            //file = dgCommanGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
            //SongName = Application.StartupPath + "\\" + file + ".ogg";
            //lStr = "select * from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID=" + file;
            //DataSet ds = new DataSet();
            //ds = objClass1.fnFillDataSet(lStr);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //}
            //else
            //{
            //    if (System.IO.File.Exists(SongName))
            //    {
            //        insert_Playlist_song(file);

            //    }
            //    else
            //    {
            //        insert_temp_data(file);
            //        multi_song_download();
            //        insert_Playlist_song(file);
            //    }
            //}

        }

        private void dgPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if (ObjMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Eu4y music player");
                return;
            }
            try
            {
                string localfilename = "";
                if (e.KeyCode == Keys.Delete)
                {
                    localfilename = dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString() + ".ogg";
                    string localfilePath = Application.StartupPath + "\\" + localfilename;

                    if (StaticClass.isDownload != "1" || StaticClass.isRemove != "1")
                    {
                        MessageBox.Show(ObjMainClass.MainMessage, "Eu4y Music Player");
                        return;
                    }
                    if (musicPlayer1.URL != "")
                    {
                        if (dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString() == musicPlayer1.currentMedia.name.ToString())
                        {
                            MessageBox.Show("You cannot delete current song", "Eu4y Music Player");
                            return;
                        }
                    }
                    if (musicPlayer2.URL != "")
                    {
                        if (dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString() == musicPlayer2.currentMedia.name.ToString())
                        {
                            MessageBox.Show("You cannot delete current song", "Eu4y Music Player");
                            return;
                        }
                    }

                    if (Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) != 0)
                    {
                        
                        StaticClass.constr.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = StaticClass.constr;
                        cmd.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value;
                        cmd.ExecuteNonQuery();
                        StaticClass.constr.Close();

                        StaticClass.LocalCon.Open();
                        OleDbCommand cmdLocal = new OleDbCommand();
                        cmdLocal.Connection = StaticClass.LocalCon;
                        cmdLocal.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value;
                        cmdLocal.ExecuteNonQuery();
                        StaticClass.LocalCon.Close();

                        delete_temp_data(dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString());

                        //System.IO.File.Delete(localfilePath);
                        if (chkShuffleSong.Checked == true)
                        {
                            PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                        }
                        else
                        {
                            PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                        }

                        DownloadSong();

                        if (musicPlayer1.URL == "")
                        {
                            if (CurrentRow == dgPlaylist.Rows.Count - 1)
                            {
                                NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                            }
                            else
                            {
                                NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                            }
                        }
                        else if (musicPlayer2.URL == "")
                        {
                            if (CurrentRow == dgPlaylist.Rows.Count - 1)
                            {
                                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                            }
                            else
                            {
                                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                            }
                        }

                    }

                    else
                    {
                        MessageBox.Show("Select a playlist", "Eu4y Music Player");
                    }

                }
            }
            catch 
            {
                
                return;
            }
        }

        private void dgLocalPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (ObjMainClass.CheckForInternetConnection() == false)
                    {
                        MessageBox.Show("Check your internet connection", "Eu4y music player");
                        return;
                    }
                    string sgr = "";
                    if (musicPlayer1.URL != "")
                    {
                        sgr = "select * from TitlesInPlaylists where PlaylistID=" + dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value + " and TitleId=" + musicPlayer1.currentMedia.name.ToString();
                        DataSet ds = new DataSet();
                        ds = ObjMainClass.fnFillDataSet(sgr);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                            {
                                if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == musicPlayer1.currentMedia.name.ToString())
                                {
                                    MessageBox.Show("You cannot delete current playlist", "Eu4y Music Player");
                                    return;
                                }
                            }
                        }
                    }
                    if (musicPlayer2.URL != "")
                    {
                        sgr = "select * from TitlesInPlaylists where PlaylistID=" + dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value + " and TitleId=" + musicPlayer2.currentMedia.name.ToString();
                        DataSet ds = new DataSet();
                        ds = ObjMainClass.fnFillDataSet(sgr);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                            {
                                if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == musicPlayer2.currentMedia.name.ToString())
                                {
                                    MessageBox.Show("You cannot delete current playlist", "Eu4y Music Player");
                                    return;
                                }
                            }
                        }
                    }

                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand("Delete_PlayList", StaticClass.constr);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@PlaylistID", SqlDbType.BigInt));
                    cmd.Parameters["@PlaylistID"].Value = Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value);
                    try
                    {
                        cmd.ExecuteNonQuery();

                        string sQr = "";

                        if (StaticClass.LocalCon.State == ConnectionState.Open)
                        {
                            StaticClass.LocalCon.Close();
                        }
                        sQr = "delete from TitlesInPlaylists where PlaylistID =" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value);
                        StaticClass.LocalCon.Open();
                        OleDbCommand cmdDelPlaylistLocal = new OleDbCommand();
                        cmdDelPlaylistLocal.Connection = StaticClass.LocalCon;
                        cmdDelPlaylistLocal.CommandText = sQr;
                        cmdDelPlaylistLocal.ExecuteNonQuery();
                        StaticClass.LocalCon.Close();

                        sQr = "";
                        if (StaticClass.LocalCon.State == ConnectionState.Open)
                        {
                            StaticClass.LocalCon.Close();
                        }
                        sQr = "delete from Playlists where PlaylistID =" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value);
                        StaticClass.LocalCon.Open();
                        OleDbCommand cmdDelLocal = new OleDbCommand();
                        cmdDelLocal.Connection = StaticClass.LocalCon;
                        cmdDelLocal.CommandText = sQr;
                        cmdDelLocal.ExecuteNonQuery();
                        StaticClass.LocalCon.Close();

                        string sdr = "";
                        if (StaticClass.constr.State == ConnectionState.Open)
                        {
                            StaticClass.constr.Close();
                        }
                        sdr = "delete from tblmusic_player_settings where DFClientId=" + StaticClass.UserId + " and localUserId= " + StaticClass.LocalUserId + " and LastPlaylistId= " + dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value + " and tokenno= " + StaticClass.TokenId;
                        StaticClass.constr.Open();
                        SqlCommand cmdDel = new SqlCommand();
                        cmdDel.Connection = StaticClass.constr;
                        cmdDel.CommandText = sdr;
                        cmdDel.ExecuteNonQuery();
                        StaticClass.constr.Close();

                        FillLocalPlaylist();
                        if (chkShuffleSong.Checked == true)
                        {
                            PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                        }
                        else
                        {
                            PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            catch
            {
                
                return;
            }
        }

        private void dgCommanGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                if (Grid_Clear == false)
                {
                    RowDeselect(dgCommanGrid);
                    dgCommanGrid.Rows[e.RowIndex].Selected = true;
                }
                else
                {
                    RowSelect(dgCommanGrid, dgCommanGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
                drawLine = true;
                dgCommanGrid.DoDragDrop(dgCommanGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), DragDropEffects.Copy);
                Is_Drop = true;
            }
        }
        private void RowSelect(DataGridView Grid_Name, string Current_Value)
        {
            foreach (DataGridViewRow dr in Grid_Name.Rows)
            {
                if (dr.Cells[0].Value.ToString() == Current_Value)
                {
                    dr.Visible = true;
                }
            }
        }
        private void RowDeselect(DataGridView Grid_Name)
        {
            foreach (DataGridViewRow dr in Grid_Name.Rows)
            {
                dr.Selected = false;
            }
        }
        private void picSongPlay_Click(object sender, EventArgs e)
        {
            if (dgPlaylist.CurrentCell.RowIndex == -1)
            {
                return;
            }
            int rowindex = dgPlaylist.CurrentCell.RowIndex;
            int columnindex = dgPlaylist.CurrentCell.ColumnIndex;
            string localfilename;
            string Templocalfilename;
            try
            {
                localfilename = dgPlaylist.Rows[rowindex].Cells[0].Value.ToString() + ".ogg";
                Templocalfilename = dgPlaylist.Rows[rowindex].Cells[0].Value.ToString() + ".sec";
                string localfilePath = Application.StartupPath + "\\" + localfilename;
                string TemplocalfilePath = Application.StartupPath + "\\" + Templocalfilename;

                if (System.IO.File.Exists(TemplocalfilePath))
                    {
                        DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[rowindex].Cells[0].Value));
                        musicPlayer1.URL = localfilePath;
                        musicPlayer1.settings.volume = 100;
                        musicPlayer2.URL = "";
                        musicPlayer2.Ctlcontrols.stop();
                        CurrentRow = rowindex;

                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                        GetSavedRating(musicPlayer1.currentMedia.name, dgSongRatingPlayerOne);
                        SetDisableRating(dgSongRatingPlayerTwo);
                        return;
                    }
                } 
            catch  {}
        }

        private void picSongRemove_Click(object sender, EventArgs e)
        {
            string MusicFileName = "";
            string mlsSql = "";
            DataTable dtDetail;
            if (ObjMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Eu4y music player");
                return;
            }
            try
            {
                if (dgPlaylist.CurrentCell.RowIndex == -1)
                {
                    return;
                }
                int rowindex = dgPlaylist.CurrentCell.RowIndex;
                int columnindex = dgPlaylist.CurrentCell.ColumnIndex;
                string localfilename;
                localfilename = dgPlaylist.Rows[rowindex].Cells[0].Value.ToString() + ".ogg";
                string localfilePath = Application.StartupPath + "\\" + localfilename;


                if (StaticClass.isDownload != "1" || StaticClass.isRemove != "1")
                {
                    MessageBox.Show(ObjMainClass.MainMessage, "Eu4y Music Player");
                    return;
                }
                if (musicPlayer1.URL != "")
                {
                    if (dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString() == musicPlayer1.currentMedia.name.ToString())
                    {
                        MessageBox.Show("You cannot delete current song", "Eu4y Music Player");
                        return;
                    }
                }
                if (musicPlayer2.URL != "")
                {
                    if (dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString() == musicPlayer2.currentMedia.name.ToString())
                    {
                        MessageBox.Show("You cannot delete current song", "Eu4y Music Player");
                        return;
                    }
                }

                if (Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) != 0)
                {

                    
                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgPlaylist.Rows[rowindex].Cells[0].Value;
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();

                    if (StaticClass.LocalCon.State == ConnectionState.Open) StaticClass.LocalCon.Close();
                    StaticClass.LocalCon.Open();
                    OleDbCommand cmdLocal = new OleDbCommand();
                    cmdLocal.Connection = StaticClass.LocalCon;
                    cmdLocal.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgPlaylist.Rows[rowindex].Cells[0].Value;
                    cmdLocal.ExecuteNonQuery();
                    StaticClass.LocalCon.Close();



                    delete_temp_data(dgPlaylist.Rows[dgPlaylist.CurrentCell.RowIndex].Cells[0].Value.ToString());

                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                    }




                    if (dgPlaylist.Rows.Count == 0)
                    {
                        if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                        {
                            CurrentPlaylistRow = 0;

                        }
                        else
                        {
                            CurrentPlaylistRow = CurrentPlaylistRow + 1;
                        }

                        for (int i = Convert.ToInt16(CurrentPlaylistRow); i < dgLocalPlaylist.Rows.Count; i++)
                        {
                            mlsSql = "SELECT  Titles.TitleID, Titles.Title FROM TitlesInPlaylists INNER JOIN Titles ON TitlesInPlaylists.TitleID = Titles.TitleID where TitlesInPlaylists.PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[i].Cells[0].Value);
                            dtDetail = ObjMainClass.fnFillDataTable_Local(mlsSql);
                            if ((dtDetail.Rows.Count > 0))
                            {
                                CurrentPlaylistRow = i;
                                break;
                            }
                            else
                            {
                                if (CurrentPlaylistRow == dgLocalPlaylist.Rows.Count - 1)
                                {
                                    CurrentPlaylistRow = 0;
                                }
                                else
                                {
                                    CurrentPlaylistRow = i;
                                }
                            }
                        }
                        dgLocalPlaylist.CurrentCell = dgLocalPlaylist.Rows[CurrentPlaylistRow].Cells[1];
                        dgLocalPlaylist.Rows[CurrentPlaylistRow].Selected = true;
                        if (chkShuffleSong.Checked == true)
                        {
                            PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                        }
                        else
                        {
                            PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                        }

                        CurrentRow = 0;
                        MusicFileName = Application.StartupPath + "\\" + dgPlaylist.Rows[Convert.ToInt32(CurrentRow)].Cells[0].Value + ".ogg";
                        if (System.IO.File.Exists(MusicFileName))
                        {
                            musicPlayer1.URL = MusicFileName;
                            musicPlayer1.settings.volume = 0;
                            if (CurrentRow == dgPlaylist.Rows.Count - 1)
                            {
                                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                            }
                            else
                            {
                                NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                            }

                            return;
                        }
                    }

                    if (musicPlayer1.URL == "")
                    {
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else if (CurrentRow > dgPlaylist.Rows.Count)
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay2(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                    }

                    else if (musicPlayer2.URL == "")
                    {
                        if (CurrentRow == dgPlaylist.Rows.Count - 1)
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else if (CurrentRow > dgPlaylist.Rows.Count)
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
                        }
                        else
                        {
                            NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
                        }
                    }


                }

                else
                {
                    MessageBox.Show("Select a playlist", "Eu4y Music Player");
                }
            }
            catch
            {
                return;
            }
            }


        private void picAddtoPlaylist_Click(object sender, EventArgs e)
        {
            string SongName;
            string TempSongName;
            string lStr;
            int TotalSelectSongs;
            TotalSelectSongs = 0;
            Grid_Clear = false;
            if (ObjMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Eu4y music player");
                return;
            }
            try
            {
                drawLine = false;
                dgPlaylist.Invalidate();
                if (dgPlaylist.Rows.Count >= 300)
                {
                    MessageBox.Show("Playlist is full. Create new playlist", "Eu4y Music Player");
                    return;
                }

                for (int i = 0; i < dgCommanGrid.Rows.Count; i++)
                {
                    if (dgCommanGrid.Rows[i].Selected == true)
                    {
                        if (TotalSelectSongs == 0)
                        {
                            TotalSelectSongs = 1;
                        }
                        else
                        {
                            TotalSelectSongs = TotalSelectSongs + 1;
                        }
                    }
                }

                if (TotalSelectSongs > 10)
                {
                    MessageBox.Show("You cannot add more than ten songs", "Eu4y Music Player");
                    return;
                }
                //277123
                Add_Playlist = true;
                FirstTimeSong = false;
                for (int i = 0; i < dgCommanGrid.Rows.Count; i++)
                {
                    if (dgCommanGrid.Rows[i].Selected == true)
                    {
                        SongName = Application.StartupPath + "\\" + dgCommanGrid.Rows[i].Cells[0].Value + ".ogg";
                        TempSongName = Application.StartupPath + "\\" + dgCommanGrid.Rows[i].Cells[0].Value + ".sec";
                        lStr = "select * from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID=" + dgCommanGrid.Rows[i].Cells[0].Value;
                        DataSet ds = new DataSet();
                        ds = ObjMainClass.fnFillDataSet_Local(lStr);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            DeleteHideSong(dgCommanGrid.Rows[i].Cells[0].Value.ToString());
                            if (chkShuffleSong.Checked == true)
                            {
                                PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                            }
                            else
                            {
                                PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                            }
                        }
                        else
                        {
                            if (System.IO.File.Exists(TempSongName))
                            {
                                if (dgPlaylist.Rows.Count == 300)
                                {
                                    MessageBox.Show("Playlist is full. Create new playlist", "Eu4y Music Player");
                                    return;
                                }
                                else
                                {
                                    DeleteHideSong(dgCommanGrid.Rows[i].Cells[0].Value.ToString());
                                    insert_Playlist_song(dgCommanGrid.Rows[i].Cells[0].Value.ToString(),"Yes");
                                    
                                    DownloadSong();
                                }


                            }
                            else
                            {
                                string sQr = "";
                                sQr = "select COUNT(dfclientid) as TotalDownload from UserDownloadTitle where DfClientId=" + StaticClass.UserId + " and TokenId= " + StaticClass.TokenId;
                                DataSet dsTitle = new DataSet();
                                dsTitle = ObjMainClass.fnFillDataSet(sQr);
                                if (StaticClass.TotalTitles == dsTitle.Tables[0].Rows[0]["TotalDownload"].ToString())
                                {
                                    MessageBox.Show("Your songs downloading limit is over." + Environment.NewLine + "Please contact vendor to resume the service.", "Eu4y Music Player");
                                    return;
                                }

                                insert_temp_data(dgCommanGrid.Rows[i].Cells[0].Value.ToString());
                                multi_song_download();
                            }
                        }

                        // rowSel = rowSel + ", " + dgCommanGrid.Rows[i].Cells[0].Value.ToString();
                    }
                }
            }
            catch 
            {
                
                
            }

        }

        private void picPlaylistRemove_Click(object sender, EventArgs e)
        {
            string sgr = "";
            if (ObjMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Eu4y music player");
                return;
            }
            try
            {
                if (musicPlayer1.URL != "")
                {
                    sgr = "select * from TitlesInPlaylists where PlaylistID=" + dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value + " and TitleId=" + musicPlayer1.currentMedia.name.ToString();
                    DataSet ds = new DataSet();
                    ds = ObjMainClass.fnFillDataSet_Local(sgr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                        {
                            if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == musicPlayer1.currentMedia.name.ToString())
                            {
                                MessageBox.Show("You cannot delete current playlist", "Eu4y Music Player");
                                return;
                            }
                        }
                    }
                }
                if (musicPlayer2.URL != "")
                {
                    sgr = "select * from TitlesInPlaylists where PlaylistID=" + dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value + " and TitleId=" + musicPlayer2.currentMedia.name.ToString();
                    DataSet ds = new DataSet();
                    ds = ObjMainClass.fnFillDataSet_Local(sgr);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dgPlaylist.Rows.Count; i++)
                        {
                            if (dgPlaylist.Rows[i].Cells[0].Value.ToString() == musicPlayer2.currentMedia.name.ToString())
                            {
                                MessageBox.Show("You cannot delete current playlist", "Eu4y Music Player");
                                return;
                            }
                        }
                    }
                }


                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand("Delete_PlayList", StaticClass.constr);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@PlaylistID", SqlDbType.BigInt));
                cmd.Parameters["@PlaylistID"].Value = Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value);
                try
                {
                    cmd.ExecuteNonQuery();

                    string sQr = "";
                    if (StaticClass.LocalCon.State == ConnectionState.Open)
                    {
                        StaticClass.LocalCon.Close();
                    }
                    sQr = "delete from Playlists where PlaylistID =" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value);
                    StaticClass.LocalCon.Open();
                    OleDbCommand cmdDelLocal = new OleDbCommand();
                    cmdDelLocal.Connection = StaticClass.LocalCon;
                    cmdDelLocal.CommandText = sQr;
                    cmdDelLocal.ExecuteNonQuery();
                    StaticClass.LocalCon.Close();


                    string sdr = "";
                    if (StaticClass.constr.State == ConnectionState.Open)
                    {
                        StaticClass.constr.Close();
                    }
                    sdr = "delete from tblmusic_player_settings where DFClientId=" + StaticClass.UserId + " and localUserId= " + StaticClass.LocalUserId + " and LastPlaylistId= " + dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value + " and tokenno= " + StaticClass.TokenId;
                    StaticClass.constr.Open();
                    SqlCommand cmdDel = new SqlCommand();
                    cmdDel.Connection = StaticClass.constr;
                    cmdDel.CommandText = sdr;
                    cmdDel.ExecuteNonQuery();
                    StaticClass.constr.Close();

                    FillLocalPlaylist();
                    if (chkShuffleSong.Checked == true)
                    {
                        PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                    }
                    else
                    {
                        PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    StaticClass.constr.Close();
                }
            }
            catch
            {
                
                return;
            }

        }


        private void picSavePlaylist_Click(object sender, EventArgs e)
        {
            string lStr = "";
            if (ObjMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Eu4y music player");
                return;
            }
            try
            {
                lStr = "select * from PlayLists where Name='" + txtPlaylistName.Text + "' and userid=" + StaticClass.UserId;
                DataSet ds = new DataSet();
                ds = ObjMainClass.fnFillDataSet(lStr);

                if (txtPlaylistName.Text == "")
                {
                    MessageBox.Show("Playlist cannot be blank", "Eu4y Music Player");
                    return;
                }
                else if (ds.Tables[0].Rows.Count > 0)
                {
                    if (pAction == "New")
                    {
                        MessageBox.Show("Playlist name already exits", "Eu4y Music Player");
                        return;
                    }
                    else
                    {
                        txtPlaylistName.Text = "";
                        return;
                    }
                }

                else if (StaticClass.Is_Admin != "1")
                {
                    MessageBox.Show(ObjMainClass.MainMessage, "Eu4y Music Player");
                    return;
                }
                if (pAction == "New")
                {
                    PlaylistSave();
                    txtPlaylistName.Text = "";
                    pAction = "New";
                    ModifyPlaylistId = 0;
                }
                else
                {
                    PlaylistModify();
                    txtPlaylistName.Text = "";
                    pAction = "New";
                    ModifyPlaylistId = 0;
                }

                FillLocalPlaylist();
            }
            catch
            {
                
                return;
            }

        }


        private void picLock_Click(object sender, EventArgs e)
        {
                panPlaylist.Enabled = false;
                panComman.Enabled = false;
                panPlaylist.Enabled = false;
                txtLoginPassword.Text = "";
                txtloginUserName.Text = "";
                panLock.Visible = true;
                panLock.Location = new Point(0, 0);
                panLock.Height = 662;
                panLock.Width = 1030;
        }
        private void dgBestOf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = "";
            try
            {
                str = "SELECT Titles.TitleID, ltrim(Titles.Title) as Title,Titles.Time, ltrim(Artists.Name) AS ArtistName, Albums.Name AS AlbumName ";
                str = str + " FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID ";
                str = str + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                str = str + " INNER JOIN TitlesInPlaylists ON Titles.TitleID = TitlesInPlaylists.TitleID ";
                str = str + " where TitlesInPlaylists.PlaylistID= " + dgBestOf.Rows[e.RowIndex].Cells[0].Value + " order by Titles.Title ";
                FillGrid(str);
                DownloadSong();
                //if (dgBestOf.Rows[e.RowIndex].Cells[0].Value.ToString() == "-50")
                //{
                //    str = "select PlaylistId as IdName, Name as textName from Playlists where isPredefined=1 order by Name";
                //    FillCommanOptionGrid(str, dgBestOf);
                //}
                //else if (BestOffRecordShowType == "MainAlbum")
                //{
                //    FillBestOffData(Convert.ToInt32(dgBestOf.Rows[e.RowIndex].Cells[0].Value));
                //}
            }
            catch (Exception ex)
            {
                
            }

        }
        private void FillBestOffData(Int32 CurrentBestOffAlbumId)
        {
            string str = "";
            int iCtr;
            DataTable dtDetail;
            str = "SELECT Titles.TitleID, Titles.Title,Titles.Time, Artists.Name AS ArtistName, Albums.Name AS AlbumName ";
            str= str+" FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID ";
            str= str+" INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
            str= str+" INNER JOIN TitlesInPlaylists ON Titles.TitleID = TitlesInPlaylists.TitleID ";
            str = str + " where TitlesInPlaylists.PlaylistID= " + CurrentBestOffAlbumId + " order by Titles.TitleID desc";


            dtDetail = ObjMainClass.fnFillDataTable(str);

            InitilizeBestOffTitleGrid();
            BestOffRecordShowType = "BestOffTitle";
            dgBestOf.Rows.Add();
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[0].Value = "-50";
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[1].Value = "<< BACK";
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[1].Style.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[1].Style.ForeColor = Color.Yellow;
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[1].Style.BackColor = Color.FromArgb(55, 51, 45);
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[1].Style.SelectionForeColor = Color.Yellow;
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[1].Style.SelectionBackColor = Color.FromArgb(55, 51, 45);

            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[2].Style.BackColor = Color.FromArgb(55, 51, 45);
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[2].Style.SelectionForeColor = Color.Yellow;
            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[2].Style.SelectionBackColor = Color.FromArgb(55, 51, 45);



            dgBestOf.Rows[dgBestOf.Rows.Count - 1].Frozen = true;

            if ((dtDetail.Rows.Count > 0))
            {

                for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                {
                    dgBestOf.Rows.Add();
                    dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["titleId"];
                    dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["Title"];
                    dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[2].Value = dtDetail.Rows[iCtr]["ArtistName"];
                    dgBestOf.Rows[dgBestOf.Rows.Count - 1].Cells[2].Style.Font = new Font("Segoe UI", 8, System.Drawing.FontStyle.Italic);

                }


            }
            foreach (DataGridViewRow row in dgBestOf.Rows)
            {
                row.Height = 30;
            }
            


        }
       private void InitilizeBestOffTitleGrid()
        {
            if (dgBestOf.Rows.Count > 0)
            {
                dgBestOf.Rows.Clear();
            }
            if (dgBestOf.Columns.Count > 0)
            {
                dgBestOf.Columns.Clear();
            }

            dgBestOf.Columns.Add("playlistId", "playlist Id");
            dgBestOf.Columns["playlistId"].Width = 0;
            dgBestOf.Columns["playlistId"].Visible = false;
            dgBestOf.Columns["playlistId"].ReadOnly = true;

            dgBestOf.Columns.Add("Title", "Title");
            dgBestOf.Columns["Title"].Width = 190;
            dgBestOf.Columns["Title"].Visible = true;
            dgBestOf.Columns["Title"].ReadOnly = true;

            dgBestOf.Columns.Add("Artist", "Artist");
            dgBestOf.Columns["Artist"].Width = 80;
            dgBestOf.Columns["Artist"].Visible = true;
            dgBestOf.Columns["Artist"].ReadOnly = true;

            dgBestOf.ColumnHeadersVisible = true;

        }
        private void RowHide()
        {
            for (int i = 0; i < dgHideSongs.Rows.Count; i++)
            {
                foreach (DataGridViewRow dr in dgPlaylist.Rows)
                {
                    if (dr.Cells[0].Value.ToString() == dgHideSongs.Rows[i].Cells[0].Value.ToString())
                    {
                        dr.Visible = false;
                    }
                }
            }
        }
        private void UpdateHideSong(string Song_id)
        {
            for (int i = 0; i < dgHideSongs.Rows.Count; i++)
            {
                if (Convert.ToString(dgHideSongs.Rows[i].Cells[0].Value) == Song_id)
                {
                    dgHideSongs.Rows[i].Cells[1].Value = "Done";
                }

            }
        }
        private void InsertHideSong(string Song_id)
        {
            //string IsExist = "No";

            //for (int i = 0; i < dgHideSongs.Rows.Count; i++)
            //{
            //    if (Convert.ToString(dgHideSongs.Rows[i].Cells[0].Value) == Song_id)
            //    {
            //        IsExist = "Yes";
            //    }

            //}
            //if (IsExist == "No")
            //{
            InitilizeHideGrid();
            dgHideSongs.Rows.Add();
            dgHideSongs.Rows[dgHideSongs.Rows.Count - 1].Cells[0].Value = Song_id;
            //}
        }
        private void DeleteHideSongs()
        {
            try
            {
                for (int i = 0; i < dgHideSongs.Rows.Count; i++)
                {
                    if (StaticClass.constr.State == ConnectionState.Open)
                    {
                        StaticClass.constr.Close();
                    }
                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgHideSongs.Rows[i].Cells[0].Value;
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();
                    //----------------------------- Local Database ------------------------//
                    if (StaticClass.LocalCon.State == ConnectionState.Open)
                    {
                        StaticClass.LocalCon.Close();
                    }
                    StaticClass.LocalCon.Open();
                    OleDbCommand cmdLocal = new OleDbCommand();
                    cmdLocal.Connection = StaticClass.LocalCon;
                    cmdLocal.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgHideSongs.Rows[i].Cells[0].Value;
                    cmdLocal.ExecuteNonQuery();
                    StaticClass.LocalCon.Close();

                }
                if (chkShuffleSong.Checked == true)
                {
                    PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
                }
                else
                {
                    PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
                }
            }
            catch { }
        }
        private void DeleteHideSong(string Song_id)
        {
            for (int i = 0; i < dgHideSongs.Rows.Count; i++)
            {
                if (Convert.ToString(dgHideSongs.Rows[i].Cells[0].Value) == Song_id)
                {
                    dgHideSongs.Rows.RemoveAt(i);
                    Show_Record = true;
                    break;
                }
                Show_Record = false;

            }
            
        }

        private void DeleteParticularHideSong()
        {
            for (int i = 0; i < dgHideSongs.Rows.Count; i++)
            {
                if (Convert.ToString(dgHideSongs.Rows[i].Cells[1].Value) == "Done")
                {

                    if (StaticClass.constr.State == ConnectionState.Open)
                    {
                        StaticClass.constr.Close();
                    }
                    StaticClass.constr.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = StaticClass.constr;
                    cmd.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgHideSongs.Rows[i].Cells[0].Value;
                    cmd.ExecuteNonQuery();
                    StaticClass.constr.Close();

                    if (StaticClass.LocalCon.State == ConnectionState.Open)
                    {
                        StaticClass.LocalCon.Close();
                    }
                    StaticClass.LocalCon.Open();
                    OleDbCommand cmdLocal = new OleDbCommand();
                    cmdLocal.Connection = StaticClass.LocalCon;
                    cmdLocal.CommandText = "delete from TitlesInPlaylists where PlaylistID=" + Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value) + " and TitleID =" + dgHideSongs.Rows[i].Cells[0].Value;
                    cmdLocal.ExecuteNonQuery();
                    StaticClass.LocalCon.Close();

                    DeleteHideSong(dgHideSongs.Rows[i].Cells[0].Value.ToString());
                }
            }
            if (chkShuffleSong.Checked == true)
            {
                PopulateShuffleSong(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value), ShuffleCount);
            }
            else
            {
                PopulateInputFileTypeDetail(Convert.ToInt32(dgLocalPlaylist.Rows[dgLocalPlaylist.CurrentCell.RowIndex].Cells[0].Value));
            }
        }

        private void btnGreenDownload_Click(object sender, EventArgs e)
        {
            if (ObjMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Eu4y music player");
                return;
            }
            try
            {
                string sZr = "";
                sZr = "";
                sZr = " SELECT   distinct  Titles.TitleID, Titles.Title, Titles.Time, Artists.Name AS ArtistName, Albums.Name AS AlbumName";
                sZr = sZr + " FROM Titles ";
                sZr = sZr + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID ";
                sZr = sZr + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID ";
                sZr = sZr + " INNER JOIN TitlesInPlaylists ON Titles.TitleID = TitlesInPlaylists.TitleID ";
                sZr = sZr + " INNER JOIN Playlists ON TitlesInPlaylists.PlaylistID = Playlists.PlaylistID ";
                sZr = sZr + " where Playlists.UserID= " + StaticClass.UserId + " ";
                sZr = sZr + " order by Titles.TitleID desc";
                FillGrid(sZr);
            }
            catch { }
        }

        private void btnPurple_Click(object sender, EventArgs e)
        {
            if (ObjMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Eu4y music player");
                return;
            }
            try
            {
                string sZr = "";
                sZr = "SELECT  Titles.TitleID, Titles.Title, Titles.Time, Artists.Name AS ArtistName, Albums.Name AS AlbumName";
                sZr = sZr + " FROM         Titles INNER JOIN";
                sZr = sZr + " Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN ";
                sZr = sZr + "  Artists ON Titles.ArtistID = Artists.ArtistID ";
                sZr = sZr + " INNER JOIN UserDownloadTitle ON Titles.TitleID = UserDownloadTitle.TitleId ";
                sZr = sZr + " where UserDownloadTitle.DFClientID=" + StaticClass.UserId + " ";
                sZr = sZr + " and UserDownloadTitle.TitleId not in ";
                sZr = sZr + " (SELECT   distinct  Titles.TitleID ";
                sZr = sZr + " FROM Titles ";
                sZr = sZr + " INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID ";
                sZr = sZr + " INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID  ";
                sZr = sZr + " INNER JOIN TitlesInPlaylists ON Titles.TitleID = TitlesInPlaylists.TitleID ";
                sZr = sZr + " INNER JOIN Playlists ON TitlesInPlaylists.PlaylistID = Playlists.PlaylistID ";
                sZr = sZr + " where Playlists.UserID=" + StaticClass.UserId + ")";
                FillGrid(sZr);
                DownloadSong();
            }
            catch
            {
                
                return;
            }
        }


        

        private void dgCommanGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.ControlKey)
            {
                Grid_Clear = true;
            }
            else
            {
                Grid_Clear = false;
            }
        }

        private void dgNewest_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                drawLine = true;
                RowSelect(dgNewest, dgNewest.Rows[e.RowIndex].Cells[0].Value.ToString());
                dgNewest.DoDragDrop(dgNewest.Rows[e.RowIndex].Cells[0].Value.ToString(), DragDropEffects.Copy);
                Is_Drop = true;
            }
        }

        private void tbcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ObjMainClass.CheckForInternetConnection() == false)
                {
                    MessageBox.Show("Check your internet connection", "Eu4y music player");
                    return;
                }
                 
                string str = "";
            }
            catch { return; }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            string str = "";
            if (ObjMainClass.CheckForInternetConnection() == false)
            {
                MessageBox.Show("Check your internet connection", "Eu4y music player");
                return;
            }
            if (txtSearch.Text == "" || txtSearch.Text == "Search")
            {
                str = "SELECT TOP (200) Titles.TitleID, Titles.Title, Titles.Time, Artists.Name as ArtistName, Albums.Name AS AlbumName FROM Titles INNER JOIN Albums ON Titles.AlbumID = Albums.AlbumID INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID where titlecategoryid=4 order by TitleID desc";
                FillGrid(str);
                DownloadSong();
                return;

            }
            if (txtSearch.Text.Length < 2)
            {
                MessageBox.Show("Atleast enter two character for search", "Eu4y Music Player");
                return;
            }
           
            SearchText = txtSearch.Text;
            CommanSearch();
            
            //stSearch = "spOverallSearch'" + txtSearch.Text + "',300";
            //FillGrid(stSearch);
            
            txtSearch.TextAlign = HorizontalAlignment.Left;
            txtSearch.ForeColor = Color.White;
            txtSearch.Text = "";
            DownloadSong();
            
        }
       
        private void CommanSearch()
        {
            string stSearch = "";
            string strAlbum = "";
            if (rdoTitle.Checked == true)
            {
                stSearch = "spSearch_Title '" + SearchText +"'";
                FillGrid(stSearch);
            }
            else if (rdoArtist.Checked == true)
            {
                stSearch = "spSearch_Artist '" + SearchText + "'";
                FillGrid(stSearch);
            }
            else if (rdoAlbum.Checked == true)
            {
                //strAlbum = "select AlbumID,Name from Albums where name like '%" + SearchText + "%' and AlbumID <> 22558 and AlbumID <> 22557  order by AlbumID desc";

                strAlbum = "spSearch_Album_Copyright '" + SearchText + "'";
                ObjMainClass.fnFillComboBox(strAlbum, cmbAlbum, "AlbumID", "Name", "");
                cmbAlbum.Visible = true;
                txtSearch.Visible = false;
                //stSearch = "spSearch_Album " + cmbAlbum.SelectedValue  ;
                //FillGrid(stSearch);
            }
        }
        
        private void mainwindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //DialogResult result;
            //try
            //{

            //    result = MessageBox.Show("Are you sure to exit ?", "Eu4y Music Player", buttons);
            //    if (result == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        if (bgWorker.IsBusy == true)
            //        {
            //            MessageBox.Show("Song downloading in process" + Environment.NewLine + "Application is not exit ?", "Eu4y Music Player");
            //            return;
            //        }
            //        if (ObjMainClass.CheckForInternetConnection() == false)
            //        {
            //            Application.Exit();
            //            return;
            //        }
            //        delete_temp_table();
            //        DeleteHideSongs();
            //        Music_Player_Settings();
            //        Application.Exit();
            //        return;
            //    }
            //    else if (result == System.Windows.Forms.DialogResult.No)
            //    {
                    
            //        MessageBox.Show("No");
            //        return;
            //    }
            //}
            //catch (Exception ex)
            //{
                 
            //}

        }

      
        private void dgPlaylist_DragOver(object sender, DragEventArgs e)
        {
            try
            {

                DataGridView.HitTestInfo info = this.dgPlaylist.HitTest(e.X, e.Y);
                label5.Text = e.Y.ToString();
                if (drawLine == true)
                {
                    if (Convert.ToInt32(label5.Text) <= Convert.ToInt32(217))
                    {
                        info = this.dgPlaylist.HitTest(20, 20);
                    }
                    else if (Convert.ToInt32(label5.Text) > Convert.ToInt32(217) && Convert.ToInt32(label5.Text) <= Convert.ToInt32(247))
                    {
                        info = this.dgPlaylist.HitTest(50, 50);
                    }
                    else if (Convert.ToInt32(label5.Text) > Convert.ToInt32(247) && Convert.ToInt32(label5.Text) <= Convert.ToInt32(277))
                    {
                        info = this.dgPlaylist.HitTest(80, 80);
                    }
                    else if (Convert.ToInt32(label5.Text) > Convert.ToInt32(277) && Convert.ToInt32(label5.Text) <= Convert.ToInt32(307))
                    {
                        info = this.dgPlaylist.HitTest(110, 110);
                    }
                    else if (Convert.ToInt32(label5.Text) > Convert.ToInt32(307) && Convert.ToInt32(label5.Text) <= Convert.ToInt32(337))
                    {
                        info = this.dgPlaylist.HitTest(140, 140);
                    }
                    else if (Convert.ToInt32(label5.Text) > Convert.ToInt32(337) && Convert.ToInt32(label5.Text) <= Convert.ToInt32(367))
                    {
                        info = this.dgPlaylist.HitTest(170, 170);
                    }
                    else if (Convert.ToInt32(label5.Text) > Convert.ToInt32(367) && Convert.ToInt32(label5.Text) <= Convert.ToInt32(397))
                    {
                        info = this.dgPlaylist.HitTest(200, 200);
                    }
                    else if (Convert.ToInt32(label5.Text) > Convert.ToInt32(397) && Convert.ToInt32(label5.Text) <= Convert.ToInt32(427))
                    {
                        info = this.dgPlaylist.HitTest(230, 230);
                    }
                    else
                    {
                        info = this.dgPlaylist.HitTest(240, 240);
                    }



                    if (info.ColumnIndex != -1)
                    {
                        Rectangle rect = this.dgPlaylist.GetRowDisplayRectangle(
                            info.RowIndex, true);
                        this.p1.X = rect.Left;
                        this.p1.Y = rect.Bottom;
                        this.p2.X = rect.Right;
                        this.p2.Y = rect.Bottom;
                        this.drawLine = true;
                        this.dgPlaylist.Invalidate();
                    }
                }
                else
                {
                    this.drawLine = false;
                    this.dgPlaylist.Invalidate();

                }
            }
            catch (Exception ex)
            {
            }

        }

        private void dgPlaylist_Paint(object sender, PaintEventArgs e)
        {
            if (this.drawLine)
            {
                using (p = new Pen(Color.Red, 3))
                {
                    EventSpl = e;
                    e.Graphics.DrawLine(p, p1, p2);
                }
            }
            else
            {
                //using (p = new Pen(Color.White, 0))
                //{
                //    EventSpl = e;
                //    e.Graphics.DrawLine(p, p1, p2);
                //}
            }
        }

        private void dgPlaylist_DragLeave(object sender, EventArgs e)
        {
            drawLine = false;
            dgPlaylist.Invalidate();
        }

        private void tbcMain_Click(object sender, EventArgs e)
        {
           
        }

        private void dgPlaylist_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgPlaylist_MouseLeave(object sender, EventArgs e)
        {
            drawLine = false;
            dgPlaylist.Invalidate();
        }

        private void timResetSong_Tick(object sender, EventArgs e)
        {
            string LocalUpcomingSong = "";
            if (dgPlaylist.Rows.Count == 0) return;

            if (pbarMusic1.Value == 0 && pbarMusic2.Value == 0)
            {
                if (UpcomingSongPlayerOne != "" && UpcomingSongPlayerTwo == "")
                {
                    DecrpetSec(Convert.ToInt32(UpcomingSongPlayerOne));
                    musicPlayer1.URL = UpcomingSongPlayerOne + ".ogg";
                    musicPlayer1.settings.volume = 100;
                    musicPlayer1.Ctlcontrols.play();

                    lblSongName.ForeColor = Color.Yellow;
                    lblArtistName.ForeColor = Color.Yellow;
                    lblMusicTimeOne.ForeColor = Color.Yellow;
                    lblSongDurationOne.ForeColor = Color.Yellow;
                    pbarMusic1.ForeColor = Color.Yellow;
                    panMusicOne.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.CurrentPlayer));
                    pbarMusic1.BackColor = Color.FromArgb(9, 130, 154);

                    lblSongName2.ForeColor = Color.Gray;
                    lblArtistName2.ForeColor = Color.Gray;
                    lblMusicTimeTwo.ForeColor = Color.Gray;
                    lblSongDurationTwo.ForeColor = Color.Gray;
                    pbarMusic2.ForeColor = Color.Gray;
                    pbarMusic2.BackColor = Color.FromArgb(175, 175, 175);
                    panMusicTwo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.DisablePlayer));
                    return;
                }
                else if (UpcomingSongPlayerOne == "" && UpcomingSongPlayerTwo != "")
                {
                    DecrpetSec(Convert.ToInt32(UpcomingSongPlayerTwo));
                    musicPlayer2.URL = UpcomingSongPlayerTwo + ".ogg";
                    musicPlayer2.settings.volume = 100;
                    musicPlayer2.Ctlcontrols.play();

                    lblSongName2.ForeColor = Color.Yellow;
                    lblArtistName2.ForeColor = Color.Yellow;
                    lblMusicTimeTwo.ForeColor = Color.Yellow;
                    lblSongDurationTwo.ForeColor = Color.Yellow;
                    pbarMusic2.ForeColor = Color.Yellow;
                    pbarMusic2.BackColor = Color.FromArgb(9, 130, 154);
                    panMusicTwo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.CurrentPlayer));

                    lblSongName.ForeColor = Color.Gray;
                    lblArtistName.ForeColor = Color.Gray;
                    lblMusicTimeOne.ForeColor = Color.Gray;
                    lblSongDurationOne.ForeColor = Color.Gray;
                    pbarMusic1.ForeColor = Color.Gray;
                    pbarMusic1.BackColor = Color.FromArgb(175, 175, 175);
                    panMusicOne.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.DisablePlayer));
                    return;
                }
                else if (UpcomingSongPlayerOne == "" && UpcomingSongPlayerTwo == "")
                {
                    LocalUpcomingSong = dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString();
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value));
                    musicPlayer1.URL = LocalUpcomingSong + ".ogg";
                    musicPlayer1.settings.volume = 100;
                    musicPlayer1.Ctlcontrols.play();

                    lblSongName.ForeColor = Color.Yellow;
                    lblArtistName.ForeColor = Color.Yellow;
                    lblMusicTimeOne.ForeColor = Color.Yellow;
                    lblSongDurationOne.ForeColor = Color.Yellow;
                    pbarMusic1.ForeColor = Color.Yellow;
                    panMusicOne.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.CurrentPlayer));
                    pbarMusic1.BackColor = Color.FromArgb(9, 130, 154);

                    lblSongName2.ForeColor = Color.Gray;
                    lblArtistName2.ForeColor = Color.Gray;
                    lblMusicTimeTwo.ForeColor = Color.Gray;
                    lblSongDurationTwo.ForeColor = Color.Gray;
                    pbarMusic2.ForeColor = Color.Gray;
                    pbarMusic2.BackColor = Color.FromArgb(175, 175, 175);
                    panMusicTwo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.DisablePlayer));
                    return;
                }
                else if (UpcomingSongPlayerOne != "" && UpcomingSongPlayerTwo != "")
                {
                    LocalUpcomingSong = dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString();
                    DecrpetSec(Convert.ToInt32(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value));
                    musicPlayer1.URL = LocalUpcomingSong + ".ogg";
                    musicPlayer1.settings.volume = 100;
                    musicPlayer1.Ctlcontrols.play();

                    lblSongName.ForeColor = Color.Yellow;
                    lblArtistName.ForeColor = Color.Yellow;
                    lblMusicTimeOne.ForeColor = Color.Yellow;
                    lblSongDurationOne.ForeColor = Color.Yellow;
                    pbarMusic1.ForeColor = Color.Yellow;
                    panMusicOne.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.CurrentPlayer));
                    pbarMusic1.BackColor = Color.FromArgb(9, 130, 154);

                    lblSongName2.ForeColor = Color.Gray;
                    lblArtistName2.ForeColor = Color.Gray;
                    lblMusicTimeTwo.ForeColor = Color.Gray;
                    lblSongDurationTwo.ForeColor = Color.Gray;
                    pbarMusic2.ForeColor = Color.Gray;
                    pbarMusic2.BackColor = Color.FromArgb(175, 175, 175);
                    panMusicTwo.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.DisablePlayer));
                    return;
                }
            }
            //string Reset_SongName = "";
            //string TempRest_SongPath = "";
            //if (dgPlaylist.Rows.Count == 0) return;
            //Reset_SongName = dgPlaylist.Rows[dgPlaylist.Rows.Count - 1].Cells[0].Value.ToString();

            //if (musicPlayer1.playState == WMPLib.WMPPlayState.wmppsReady && musicPlayer2.playState == WMPLib.WMPPlayState.wmppsStopped)
            //{
            //    TempRest_SongPath = Application.StartupPath + "\\" + Reset_SongName + ".sec";
            //    DecrpetSec(Convert.ToInt32(Reset_SongName));

            //    musicPlayer1.URL = Application.StartupPath + "\\" + Reset_SongName + ".ogg";
            //    musicPlayer1.Ctlcontrols.currentPosition = 10;
            //    musicPlayer1.settings.volume = 100;
            //    CurrentRow = 0;
            //    if (CurrentRow == dgPlaylist.Rows.Count - 1)
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
            //    }
            //    else
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
            //    }

            //}
            //else if (musicPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped && musicPlayer2.playState == WMPLib.WMPPlayState.wmppsReady)
            //{
            //    TempRest_SongPath = Application.StartupPath + "\\" + Reset_SongName + ".sec";
            //    DecrpetSec(Convert.ToInt32(Reset_SongName));
            //    musicPlayer1.URL = Application.StartupPath + "\\" + Reset_SongName + ".ogg";
            //    musicPlayer1.Ctlcontrols.currentPosition = 10;
            //    musicPlayer1.settings.volume = 100;
            //    CurrentRow = 0;
            //    if (CurrentRow == dgPlaylist.Rows.Count - 1)
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
            //    }
            //    else
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
            //    }

            //}
            //else if (musicPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped && musicPlayer2.playState == WMPLib.WMPPlayState.wmppsStopped)
            //{
            //    TempRest_SongPath = Application.StartupPath + "\\" + Reset_SongName + ".sec";
            //    DecrpetSec(Convert.ToInt32(Reset_SongName));
            //    musicPlayer1.URL = Application.StartupPath + "\\" + Reset_SongName + ".ogg";
            //    musicPlayer1.Ctlcontrols.currentPosition = 10;
            //    musicPlayer1.settings.volume = 100;
            //    CurrentRow = 0;
            //    if (CurrentRow == dgPlaylist.Rows.Count - 1)
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
            //    }
            //    else
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
            //    }

            //}
            //else if (musicPlayer1.playState == WMPLib.WMPPlayState.wmppsReady && musicPlayer2.playState == WMPLib.WMPPlayState.wmppsReady)
            //{
            //    TempRest_SongPath = Application.StartupPath + "\\" + Reset_SongName + ".sec";
            //    DecrpetSec(Convert.ToInt32(Reset_SongName));
            //    musicPlayer1.URL = Application.StartupPath + "\\" + Reset_SongName + ".ogg";
            //    musicPlayer1.Ctlcontrols.currentPosition = 10;
            //    musicPlayer1.settings.volume = 100;
            //    CurrentRow = 0;
            //    if (CurrentRow == dgPlaylist.Rows.Count - 1)
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
            //    }
            //    else
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
            //    }
            //}
            //else if (musicPlayer1.playState == WMPLib.WMPPlayState.wmppsReady && musicPlayer2.playState == WMPLib.WMPPlayState.wmppsUndefined)
            //{
            //    TempRest_SongPath = Application.StartupPath + "\\" + Reset_SongName + ".sec";
            //    DecrpetSec(Convert.ToInt32(Reset_SongName));
            //    musicPlayer1.URL = Application.StartupPath + "\\" + Reset_SongName + ".ogg";
            //    musicPlayer1.Ctlcontrols.currentPosition = 10;
            //    musicPlayer1.settings.volume = 100;
            //    CurrentRow = 0;
            //    if (CurrentRow == dgPlaylist.Rows.Count - 1)
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
            //    }
            //    else
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
            //    }
            //}
            //else if (musicPlayer1.playState == WMPLib.WMPPlayState.wmppsUndefined && musicPlayer2.playState == WMPLib.WMPPlayState.wmppsReady)
            //{
            //    TempRest_SongPath = Application.StartupPath + "\\" + Reset_SongName + ".sec";
            //    DecrpetSec(Convert.ToInt32(Reset_SongName));
            //    musicPlayer1.URL = Application.StartupPath + "\\" + Reset_SongName + ".ogg";
            //    musicPlayer1.Ctlcontrols.currentPosition = 10;
            //    musicPlayer1.settings.volume = 100;
            //    CurrentRow = 0;
            //    if (CurrentRow == dgPlaylist.Rows.Count - 1)
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(0)].Cells[0].Value.ToString());
            //    }
            //    else
            //    {
            //        NextSongDisplay(dgPlaylist.Rows[Convert.ToInt32(CurrentRow + 1)].Cells[0].Value.ToString());
            //    }

            //}
        }

        private void mainwindow_Move(object sender, EventArgs e)
        {
           // this.Location = new Point(121, 19);
        }

        private void mainwindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            try
            {
                
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    if (bgWorker.IsBusy == true)
                    {
                        MessageBox.Show("Song downloading in process" + Environment.NewLine + "Application is not exit ?", "Eu4y Music Player");
                        e.Cancel = true;
                        return;
                    }
                    result = MessageBox.Show("Are you sure to exit ?", "Eu4y Music Player", buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {

                        if (musicPlayer1.URL != "")
                        {
                            musicPlayer1.Ctlcontrols.stop();
                           
                        }
                        if (musicPlayer2.URL != "")
                        {
                            musicPlayer2.Ctlcontrols.stop();
                            
                        }
                        if (StreamMusicPlayer.URL != "")
                        {
                            
                            StreamMusicPlayer.Ctlcontrols.stop();
                        }
                       
                        //if (ObjMainClass.CheckForInternetConnection() == false)
                        //{
                        //    Application.Exit();
                        //    return;
                        //}
                        //delete_temp_table();
                        //DeleteHideSongs();
                        INetFwPolicy2 firewallPolicyDel = (INetFwPolicy2)Activator.CreateInstance(
                    Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                        firewallPolicyDel.Rules.Remove("MusicPlayer");

                        ObjMainClass.DeleteAllOgg("0");
                        Music_Player_Settings();
                        musicPlayer1.URL = "";
                        musicPlayer2.URL = "";
                        StreamMusicPlayer.URL = "";
                        e.Cancel = false;
                        Application.Exit();
                        return;
                    }
                    else if (result == System.Windows.Forms.DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void txtPlaylistName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 39 || Convert.ToInt32(e.KeyChar) == 37)
            {
                e.Handled = true;
                return;
            }
        }

        private void rdoTitle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTitle.Checked == true)
            {
                cmbAlbum.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void rdoArtist_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoArtist.Checked == true)
            {
                cmbAlbum.Visible = false;
                txtSearch.Visible = true;
            }

        }

        private void rdoAlbum_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAlbum.Checked == true)
            {
                cmbAlbum.Visible = false;
                txtSearch.Visible = true;
            }
        }

        private void cmbAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stSearch = "";
            stSearch = "spSearch_Album " + cmbAlbum.SelectedValue;
            FillGrid(stSearch);
        }

        private void mainwindow_SizeChanged(object sender, EventArgs e)
        {
            panStream.Height = this.Height;
            panStream.Width = this.Width;
            panMusicUpper.Location = new Point(
           this.panelMainPlayer.Width / 2 - panMusicUpper.Size.Width / 2,
           this.panelMainPlayer.Height / 2 - panMusicUpper.Size.Height / 2);

            panStreamControls.Location = new Point(
         this.panStreamMainControls.Width / 2 - panStreamControls.Size.Width / 2,
         this.panStreamMainControls.Height / 2 - panStreamControls.Size.Height / 2);

            picStreaming.Location = new Point(
           this.panStreamUpper.Width / 2 - picStreaming.Size.Width / 2,
           this.panStreamUpper.Height / 2 - picStreaming.Size.Height / 2);

            if (this.Width.ToString() == "1020")
            {
                dgPlaylist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgPlaylist.Columns["songname"].Width = 450;
                dgPlaylist.Columns["Length"].Width = 80;
                dgPlaylist.Columns["Album"].Width = 0;
                dgPlaylist.Columns["Artist"].Width = 150;

                dgCommanGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgCommanGrid.Columns["songname"].Width = 430;
                dgCommanGrid.Columns["Length"].Width = 80;
                dgCommanGrid.Columns["aritstname"].Width = 140;
                SongDownload.Width = 30;

                dgStream.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                dgStream.Columns["StreamName"].Width = 940;
                Column_Img_Stream.Width = 40;
            }
            else
            {
                dgPlaylist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgCommanGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgStream.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                SongDownload.Width = 50;
                Column_Img_Stream.Width = 40;
            }
        }
        private void dgLocalPlaylist_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if (e.ColumnIndex == 1)
            {
                if (e.RowIndex >= 0)
                {
                    txtPlaylistName.Text = dgLocalPlaylist.Rows[e.RowIndex].Cells[1].Value.ToString();
                    ModifyPlaylistId = Convert.ToInt32(dgLocalPlaylist.Rows[e.RowIndex].Cells[0].Value);
                    pAction = "Modify";
                    txtPlaylistName.Focus();
                }
            }
        }
        #region StreamCode
        private void picStream_Click(object sender, EventArgs e)
        {
            if (ClientsRightsValidation() == false) return;
            lblStreamTime.Text = "";
            if (StreamMusicPlayer.URL == "")
            {
                lblStreamName.Text = dgStream.Rows[0].Cells[2].Value.ToString();
                StreamMusicPlayer.URL = dgStream.Rows[0].Cells[1].Value.ToString();
            }

            if (musicPlayer1.URL != "")
            {
                musicPlayer1.Ctlcontrols.pause();
                panStream.Visible = true;
                StreamMusicPlayer.Ctlcontrols.play();
            }
            else if (musicPlayer2.URL != "")
            {
                musicPlayer2.Ctlcontrols.pause();
                panStream.Visible = true;
                StreamMusicPlayer.Ctlcontrols.play();
            }

            panStream.Location = new Point(0, 0);
            panStream.Height = this.Height;
            panStream.Width = this.Width;
            btnStreamPlay.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pause_Blue));
            btnStreamPlay.Text = "";
            btnStreamMute.Text = "";
            dgStream.Rows[0].Selected = true;
            dgStream.Rows[0].Cells["Column_Img_Stream"].Value = ((System.Drawing.Image)(Properties.Resources.Play_Blue));
            GetCurrentStream();
            timStream.Enabled = true;
            timStreamMusicTime.Enabled = true;
        }
        private Boolean ClientsRightsValidation()
        {
            if (StaticClass.StreamExpiryMessage == "NoLic")
            {
                MessageBox.Show("!! Purchase the subscription of Online Streaming !!", "Eu4y Music Player");
                return false;
            }
            else if (StaticClass.StreamExpiryMessage == "Yes")
            {
                MessageBox.Show("!! Subscription is expire !!", "Eu4y Music Player");
                return false;
            }
            else if (StaticClass.StreamExpiryMessage != "NoLic" && StaticClass.LeftStreamtDays == 0)
            {
                lblStreamExpiry.Text = "Last day to renewal of subscription";
                return true;
            }
            else if (StaticClass.StreamExpiryMessage != "NoLic" && StaticClass.LeftStreamtDays <= 10)
            {
                lblStreamExpiry.Text = Convert.ToString(StaticClass.LeftStreamtDays) + " days left to renewal of subscription";
                return true;
            }
            
            return true;
        }
        private void InitilizeStreamGrid()
        {
            if (dgStream.Rows.Count > 0)
            {
                dgStream.Rows.Clear();
            }
            if (dgStream.Columns.Count > 0)
            {
                dgStream.Columns.Clear();
            }

            dgStream.Columns.Add("Streamid", "Stream Id");
            dgStream.Columns["Streamid"].Width = 0;
            dgStream.Columns["Streamid"].Visible = false;
            dgStream.Columns["Streamid"].ReadOnly = true;

            dgStream.Columns.Add("StreamLink", "Stream Link");
            dgStream.Columns["StreamLink"].Width = 0;
            dgStream.Columns["StreamLink"].Visible = false;
            dgStream.Columns["StreamLink"].ReadOnly = true;

            dgStream.Columns.Add("StreamName", "Stream Name");
            dgStream.Columns["StreamName"].Width = 940;
            dgStream.Columns["StreamName"].Visible = true;
            dgStream.Columns["StreamName"].ReadOnly = true;

            dgStream.Columns.Add(Column_Img_Stream);
            Column_Img_Stream.HeaderText = "";
            Column_Img_Stream.Name = "Column_Img_Stream";
            Column_Img_Stream.Width = 40;
            Column_Img_Stream.ImageLayout = DataGridViewImageCellLayout.Zoom;
            Column_Img_Stream.Visible = true;

            dgStream.Columns["Column_Img_Stream"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void FillStreamData()
        {
            string str;
            int iCtr;
            DataTable dtDetail;
            str = "Select * from  tblOnlineStreaming where titlecategoryId=4 order by titlecategoryId, streamName";
            dtDetail = ObjMainClass.fnFillDataTable(str);

            InitilizeStreamGrid();

            if ((dtDetail.Rows.Count > 0))
            {
                for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                {
                    dgStream.Rows.Add();
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["StreamId"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["StreamLink"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells[2].Value = dtDetail.Rows[iCtr]["StreamName"];
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells["Column_Img_Stream"].Value = ((System.Drawing.Image)(Properties.Resources.NextData_Hover));
                    dgStream.Rows[dgStream.Rows.Count - 1].Cells[2].Style.Font = new Font("Segoe UI", 12, System.Drawing.FontStyle.Regular);

                }
                foreach (DataGridViewRow row in dgStream.Rows)
                {
                    row.Height = 30;
                }

            }

        }
        

        private void dgStream_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblStreamName.Text = dgStream.Rows[e.RowIndex].Cells[2].Value.ToString();
            StreamMusicPlayer.URL = dgStream.Rows[e.RowIndex].Cells[1].Value.ToString();
            StreamMusicPlayer.Ctlcontrols.play();
            timStream.Enabled = true;
            timStreamMusicTime.Enabled = true;
            dgStream.Rows[e.RowIndex].Selected = true;
            dgStream.Rows[e.RowIndex].Cells["Column_Img_Stream"].Value = ((System.Drawing.Image)(Properties.Resources.Play_Blue));
            GetCurrentStream();
        }


        private void btnStreamPlay_Click(object sender, EventArgs e)
        {
            if (StreamMusicPlayer.URL != "")
            {
                if (btnStreamPlay.Text == ".")
                {
                    btnStreamPlay.Text = "";
                    StreamMusicPlayer.Ctlcontrols.play();
                    StreamMusicPlayer.settings.volume = 100;
                    btnStreamPlay.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Pause_Blue));
                    timStreamMusicTime.Enabled = true;
                    picWaveOne.Visible = true;
                    picWaveTwo.Visible = true;
                }
                else if (btnStreamPlay.Text == "")
                {
                    btnStreamPlay.Text = ".";
                    StreamMusicPlayer.Ctlcontrols.pause();
                    btnStreamPlay.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Play_Blue));
                    timStreamMusicTime.Enabled = false;
                    picWaveOne.Visible = false;
                    picWaveTwo.Visible = false;
                }
            }
        }



        private void btnStreamMute_Click(object sender, EventArgs e)
        {
            if (StreamMusicPlayer.URL != "")
            {
                if (btnStreamMute.Text == "")
                {
                    btnStreamMute.Text = ".";
                    StreamMusicPlayer.settings.mute = true;
                    btnStreamMute.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Mute_red));
                }
                else if (btnStreamMute.Text == ".")
                {
                    btnStreamMute.Text = "";
                    StreamMusicPlayer.settings.mute = false;
                    btnStreamMute.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Mute_blue));
                }
            }
        }
        private void GetCurrentStream()
        {
            for (int i = 0; i < dgStream.Rows.Count; i++)
            {
                if (dgStream.Rows[i].Cells[2].Value.ToString() != lblStreamName.Text.Trim())
                {
                    dgStream.Rows[i].Selected = false;
                    dgStream.Rows[i].Cells["Column_Img_Stream"].Value = ((System.Drawing.Image)(Properties.Resources.NextData_Hover));
                }
            }
        }


        private void picSwitchOff_Click(object sender, EventArgs e)
        {
            if (musicPlayer1.URL != "")
            {
                musicPlayer1.Ctlcontrols.play();
                panStream.Visible = false;
                StreamMusicPlayer.Ctlcontrols.pause();
            }
            else if (musicPlayer2.URL != "")
            {
                musicPlayer2.Ctlcontrols.play();
                panStream.Visible = false;
                StreamMusicPlayer.Ctlcontrols.pause();
            }
            timStreamMusicTime.Enabled = false;
        }
       

        private void timStream_Tick(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            picWaveOne.Visible = false;
            picWaveTwo.Visible = false;
        }

        private void timStreamMusicTime_Tick(object sender, EventArgs e)
        {
            lblStreamTime.Text = StreamMusicPlayer.Ctlcontrols.currentPositionString;
            if (lblStreamTime.Text != "")
            {
                pictureBox2.Visible = false;
                picWaveOne.Visible = true;
                picWaveTwo.Visible = true;
                timStream.Enabled = false;

            }
        }
 #endregion


        private void DecrpetSec(Int32 Title_Song_Id)
        {
            try
            {
                using (MemoryStream st = amcrypt.getStream(Title_Song_Id))
                {
                    long length = st.Length;
                    byte[] data = new byte[length];
                    st.Read(data, 0, (int)length);
                    FileStream fs = new FileStream(Application.StartupPath + "//" + Title_Song_Id + ".ogg", FileMode.Create);
                    fs.Write(data, 0, (int)length);
                    fs.Flush();
                    fs.Close();
                }
            }
            catch (Exception ex) { }
        }

        private void mainwindow_Validating(object sender, CancelEventArgs e)
        {
            drawLine = false;
            dgPlaylist.Invalidate(); 
        }

        #region SongRating
        private void FillStar(DataGridView GridName)
        {
            if (GridName.Rows.Count > 0)
            {
                GridName.Rows.Clear();
            }
            if (GridName.Columns.Count > 0)
            {
                GridName.Columns.Clear();
            }

            DataGridViewImageColumn Star1 = new DataGridViewImageColumn();
            Star1.HeaderText = "Star1";
            Star1.Name = "Star1";
            GridName.Columns.Add(Star1);
            Star1.Width = 20;
            Star1.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewImageColumn Star2 = new DataGridViewImageColumn();
            Star2.HeaderText = "Star2";
            Star2.Name = "Star2";
            GridName.Columns.Add(Star2);
            Star2.Width = 20;
            Star2.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewImageColumn Star3 = new DataGridViewImageColumn();
            Star3.HeaderText = "Star3";
            Star3.Name = "Star3";
            GridName.Columns.Add(Star3);
            Star3.Width = 20;
            Star3.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewImageColumn Star4 = new DataGridViewImageColumn();
            Star4.HeaderText = "Star4";
            Star4.Name = "Star4";
            GridName.Columns.Add(Star4);
            Star4.Width = 20;
            Star4.ImageLayout = DataGridViewImageCellLayout.Stretch;

            DataGridViewImageColumn Star5 = new DataGridViewImageColumn();
            GridName.Columns.Add(Star5);
            Star5.HeaderText = "Star5";
            Star5.Name = "Star5";
            Star5.Width = 20;
            Star5.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void dgSongRatingPlayerOne_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (musicPlayer1.URL != "")
            {
                Int32 TotalStar = e.ColumnIndex;
                Image StarON;
                StarON = Properties.Resources.starON;
                Image OffStar;
                OffStar = Properties.Resources.starOFF;
                for (int i = 0; i <= 4; i++)
                {
                    if (i <= TotalStar)
                    {
                        dgSongRatingPlayerOne.Rows[0].Cells[i].Value = StarON;
                    }
                    else
                    {
                        dgSongRatingPlayerOne.Rows[0].Cells[i].Value = OffStar;
                    }
                }
            }
        }
        private void GetSavedRating(string titleID, DataGridView GridName)
        {

            try
            {
                DataTable dtRating = new DataTable();
                string str = "";

                Image StarON;
                StarON = Properties.Resources.starON;

                Image OffStar;
                OffStar = Properties.Resources.starOFF;
                FillStar(GridName);
                GridName.Rows.Add();
                str = "select * from tbTitleRating where tokenid=" + StaticClass.TokenId + "  and titleid= " + titleID;


                dtRating = ObjMainClass.fnFillDataTable_Local(str);

                if (dtRating.Rows.Count > 0)
                {
                    GridName.GridColor = Color.FromArgb(25, 146, 166);
                    Int32 TotalStar = Convert.ToInt32(dtRating.Rows[0]["TitleRating"]);

                    for (int i = 0; i <= 4; i++)
                    {
                        if (i <= TotalStar)
                        {
                            GridName.Rows[0].Cells[i].Value = StarON;
                        }
                        else
                        {
                            GridName.Rows[0].Cells[i].Value = OffStar;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i <= 4; i++)
                    {
                        GridName.Rows[0].Cells[i].Value = OffStar;
                        GridName.GridColor = Color.FromArgb(25, 146, 166);
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void SetDisableRating(DataGridView GridName)
        {
            try
            {
                Image StarDisable;
                StarDisable = Properties.Resources.StarDisable;
                FillStar(GridName);
                GridName.Rows.Add();
                GridName.GridColor = Color.FromArgb(175, 175, 175);
                for (int i = 0; i <= 4; i++)
                {
                    GridName.Rows[0].Cells[i].Value = StarDisable;
                }
            }
            catch (Exception ex) { }
        }
        private void SetRating(DataGridView GridName)
        {
            try
            {
                Image StarDisable;
                StarDisable = Properties.Resources.starOFF;
                FillStar(GridName);
                GridName.Rows.Add();
                GridName.GridColor = Color.FromArgb(25, 146, 166);
                for (int i = 0; i <= 4; i++)
                {
                    GridName.Rows[0].Cells[i].Value = StarDisable;
                }
            }
            catch (Exception ex) { }
        }
        private void dgSongRatingPlayerOne_MouseLeave(object sender, EventArgs e)
        {
            if (musicPlayer1.URL != "")
            {
                GetSavedRating(musicPlayer1.currentMedia.name, dgSongRatingPlayerOne);
            }

        }

        private void dgSongRatingPlayerOne_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (musicPlayer1.URL != "")
            {
                SaveRating(e.ColumnIndex, Convert.ToInt32(musicPlayer1.currentMedia.name));
            }

        }
        private void SaveRating(Int32 TitleRating, Int32 RatingTitleId)
        {
            string strInsertrating = "";
            try
            {
                if (ObjMainClass.CheckForInternetConnection() == false)
                {
                    MessageBox.Show("Check your internet connection", "Eufory music player");
                    return;
                }
                ////////////// Save Online Data ////////////////
                if (StaticClass.constr.State == ConnectionState.Open) StaticClass.constr.Close();
                StaticClass.constr.Open();
                SqlCommand cmd = new SqlCommand("spTitleRating", StaticClass.constr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@TokenId", SqlDbType.BigInt));
                cmd.Parameters["@TokenId"].Value = StaticClass.TokenId;
                cmd.Parameters.Add(new SqlParameter("@TitleId", SqlDbType.BigInt));
                cmd.Parameters["@TitleId"].Value = RatingTitleId;
                cmd.Parameters.Add(new SqlParameter("@TitleRating", SqlDbType.BigInt));
                cmd.Parameters["@TitleRating"].Value = TitleRating;
                cmd.ExecuteNonQuery();

                ////////////// Save Local Data ////////////////

                if (StaticClass.LocalCon.State == ConnectionState.Open) StaticClass.LocalCon.Close();
                strInsertrating = "delete from tbTitleRating where tokenid=" + StaticClass.TokenId + " and titleId= " + RatingTitleId + "";
                StaticClass.LocalCon.Open();
                OleDbCommand cmdTitleDelete = new OleDbCommand();
                cmdTitleDelete.Connection = StaticClass.LocalCon;
                cmdTitleDelete.CommandText = strInsertrating;
                cmdTitleDelete.ExecuteNonQuery();
                StaticClass.LocalCon.Close();
                /////////////////////////////////////////////////////////////
                if (StaticClass.LocalCon.State == ConnectionState.Open) StaticClass.LocalCon.Close();
                strInsertrating = "insert into tbTitleRating values (" + StaticClass.TokenId + " , " + RatingTitleId + " , ";
                strInsertrating = strInsertrating + TitleRating + ")";

                StaticClass.LocalCon.Open();
                OleDbCommand cmdTitle = new OleDbCommand();
                cmdTitle.Connection = StaticClass.LocalCon;
                cmdTitle.CommandText = strInsertrating;
                cmdTitle.ExecuteNonQuery();
                StaticClass.LocalCon.Close();


                if (musicPlayer1.URL != "")
                {
                    GetSavedRating(musicPlayer1.currentMedia.name, dgSongRatingPlayerOne);
                }
                if (musicPlayer2.URL != "")
                {
                    GetSavedRating(musicPlayer2.currentMedia.name, dgSongRatingPlayerTwo);
                }
            }
            catch (Exception ex) { }
        }

        private void dgSongRatingPlayerTwo_MouseLeave(object sender, EventArgs e)
        {
            if (musicPlayer2.URL != "")
            {
                GetSavedRating(musicPlayer2.currentMedia.name, dgSongRatingPlayerTwo);
            }
        }

        private void dgSongRatingPlayerTwo_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (musicPlayer2.URL != "")
            {
                SaveRating(e.ColumnIndex, Convert.ToInt32(musicPlayer2.currentMedia.name));
            }
        }

        private void dgSongRatingPlayerTwo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (musicPlayer2.URL != "")
            {
                Int32 TotalStar = e.ColumnIndex;
                Image StarON;
                StarON = Properties.Resources.starON;
                Image OffStar;
                OffStar = Properties.Resources.starOFF;
                for (int i = 0; i <= 4; i++)
                {
                    if (i <= TotalStar)
                    {
                        dgSongRatingPlayerTwo.Rows[0].Cells[i].Value = StarON;
                    }
                    else
                    {
                        dgSongRatingPlayerTwo.Rows[0].Cells[i].Value = OffStar;
                    }
                }
            }
        }
        private void InitilizeTop250Grid()
        {
            if (dgTop250.Rows.Count > 0)
            {
                dgTop250.Rows.Clear();
            }
            if (dgTop250.Columns.Count > 0)
            {
                dgTop250.Columns.Clear();
            }

            dgTop250.Columns.Add("songid", "song Id");
            dgTop250.Columns["songid"].Width = 0;
            dgTop250.Columns["songid"].Visible = false;
            dgTop250.Columns["songid"].ReadOnly = true;

            dgTop250.Columns.Add("songname", "Title");
            dgTop250.Columns["songname"].Width = 180;
            dgTop250.Columns["songname"].Visible = true;
            dgTop250.Columns["songname"].ReadOnly = true;

            dgTop250.Columns.Add("Artist", "Artist");
            dgTop250.Columns["Artist"].Width = 107;
            dgTop250.Columns["Artist"].Visible = true;
            dgTop250.Columns["Artist"].ReadOnly = true;
        }
        private void FillTop250Grid()
        {
            int iCtr;
            string str = "SELECT TOP (250) Titles.TitleID , ltrim(Titles.Title) as Title, Artists.Name as ArtistName ";
            str = str + " FROM Titles  INNER JOIN Artists ON Titles.ArtistID = Artists.ArtistID ";
            str = str + " INNER JOIN tbTitleRating ON Titles.titleid = tbTitleRating.titleid ";
            str = str + " where titlecategoryid=4 and tbTitleRating.tokenid=" + StaticClass.TokenId + " order by tbTitleRating.titlerating desc ";
            try
            {
                InitilizeTop250Grid();
                DataTable dtDetail;
                dtDetail = ObjMainClass.fnFillDataTable(str);
                if ((dtDetail.Rows.Count > 0))
                {
                    for (iCtr = 0; (iCtr <= (dtDetail.Rows.Count - 1)); iCtr++)
                    {

                        dgTop250.Rows.Add();
                        dgTop250.Rows[dgTop250.Rows.Count - 1].Cells[0].Value = dtDetail.Rows[iCtr]["TitleID"];
                        dgTop250.Rows[dgTop250.Rows.Count - 1].Cells[1].Value = dtDetail.Rows[iCtr]["Title"];
                        dgTop250.Rows[dgTop250.Rows.Count - 1].Cells[2].Value = dtDetail.Rows[iCtr]["ArtistName"];

                        dgTop250.Rows[dgTop250.Rows.Count - 1].Cells[1].Style.Font = new Font("Segoe UI", 10, System.Drawing.FontStyle.Regular);
                        dgTop250.Rows[dgTop250.Rows.Count - 1].Cells[2].Style.Font = new Font("Segoe UI", 8, System.Drawing.FontStyle.Italic);

                    }
                    foreach (DataGridViewRow row in dgTop250.Rows)
                    {
                        row.Height = 30;
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }


        private void rdoPlaylist_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPlaylist.Checked == true)
            {
                panTop250Main.Visible = false;
                panPlaylistMain.Dock = DockStyle.Fill;
                panPlaylistMain.Visible = true;
            }
        }

        private void rdoTop250_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTop250.Checked == true)
            {
                FillTop250Grid();
                panPlaylistMain.Visible = false;
                panTop250Main.Dock = DockStyle.Fill;
                panTop250Main.Visible = true;
            }
        }
        private void dgTop250_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                drawLine = true;
                RowSelect(dgTop250, dgTop250.Rows[e.RowIndex].Cells[0].Value.ToString());
                dgTop250.DoDragDrop(dgTop250.Rows[e.RowIndex].Cells[0].Value.ToString(), DragDropEffects.Copy);
                Is_Drop = true;
            }
        }
        #endregion
    }
}
